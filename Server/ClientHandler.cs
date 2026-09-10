
﻿
using Common.Communication;
using Common.Domain;
using System.Diagnostics;
using System.Net.Sockets;


namespace Server
{
    internal class ClientHandler
    {
        private Socket client;
        private readonly List<ClientHandler> clients;
        private readonly Server server;
        public Racunovodja UlogovaniRacunovodja { get; private set; }
        public DateTime VremePovezivanja { get; private set; }
        public DateTime? VremeLogovanja { get; private set; }

        public Action KlijentAzuriran;
        private JSONNetworkSerializer serializer;

        bool isEnd = false;
        public ClientHandler(Socket client, List<ClientHandler> clients)
        {
            this.client = client;
            this.clients = clients;
            serializer = new JSONNetworkSerializer(client);

            VremePovezivanja = DateTime.Now;
        }

        public void Handle()
        {
            try
            {
                while (!isEnd)
                {
                    Request request = serializer.Receive<Request>();
                    Response response = HandleRequest(request);
                    serializer.Send(response);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
                Debug.WriteLine(">>>SOCKET>>> " + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
                Debug.WriteLine(">>>IO>>> " + ex.Message);
            }
            finally
            {
                clients.Remove(this);
                KlijentAzuriran?.Invoke();
                serializer.Close();
            }
        }

        private Response HandleRequest(Request? request)
        {
            Response response = new Response();
            response.isSuccessful = true;
            try
            {
                switch (request.Operation)
                {
                    case Operation.Login:
                        response.Object = Controller.Instance.PrijaviRacunovodju(serializer.ReadType<Racunovodja>(request.Object));
                        
                        if (response.Object != null)
                        {
                            response.isSuccessful = true;
                            UlogovaniRacunovodja = (Racunovodja)response.Object;
                            VremeLogovanja = DateTime.Now;
                            KlijentAzuriran?.Invoke();
                        }
                        else
                        {
                            response.isSuccessful = false;
                        }
                        break;
                    case Operation.UbaciZaposlenog:
                        Zaposleni z = serializer.ReadType<Zaposleni>(request.Object);
                        Controller.Instance.UbaciZaposlenog(z);
                        break;
                    case Operation.IzmeniZaposlenog:
                        z = serializer.ReadType<Zaposleni>(request.Object);
                        Controller.Instance.IzmeniZaposlenog(z);
                        break;
                    case Operation.VratiPozicije:
                        response.Object = Controller.Instance.VratiPozicije();
                        break;
                    case Operation.VratiZaposlene:
                        response.Object = Controller.Instance.VratiZaposlene();
                        break;
                    case Operation.PretraziZaposlene:
                        z = serializer.ReadType<Zaposleni>(request.Object);
                        List<Zaposleni> nadjeniZaposleni = Controller.Instance.PretraziZaposlene(z);
                        if (nadjeniZaposleni.Count == 0)
                        {
                            response.isSuccessful = false;
                            response.Object = null;
                        }
                        response.Object = nadjeniZaposleni;
                        break;
                    case Operation.ObrisiZaposlenog:
                        z = serializer.ReadType<Zaposleni>(request.Object);
                        bool r = Controller.Instance.ObrisiZaposlenog(z);
                        response.isSuccessful = r;
                        break;
                    case Operation.VratiVrsteZarada:
                        List<VrstaZarade> vrsteZarada = Controller.Instance.VratiVrsteZarada();
                        response.Object = vrsteZarada;
                        break;
                    case Operation.UbaciVrstuZarade:
                        VrstaZarade vz = serializer.ReadType<VrstaZarade>(request.Object);
                        Controller.Instance.UbaciVrstuZarade(vz);
                        break;
                    case Operation.VratiRacunovodje:
                        List<Racunovodja> racunovodje = Controller.Instance.VratiRacunovodje();
                        response.Object = racunovodje;
                        break;
                    case Operation.UbaciObracunZarade:
                        ObracunZaradeSaStavkamaDTO dto = serializer.ReadType<ObracunZaradeSaStavkamaDTO>(request.Object);
                        ObracunZarade noviObracun = Controller.Instance.UbaciObracunZarade(dto.ObracunZarade,dto.Stavke);
                        response.Object = noviObracun;
                        break;
                    case Operation.IzmeniObracunZarade:
                        dto = serializer.ReadType<ObracunZaradeSaStavkamaDTO>(request.Object);
                        Controller.Instance.IzmeniObracunZarade(dto.ObracunZarade, dto.Stavke);
                        break;

                    case Operation.VratiStavkeObracuna:
                        ObracunZarade oz = serializer.ReadType<ObracunZarade>(request.Object);
                        List<StavkaObracunaZarade> stavke = Controller.Instance.VratiStavkeObracuna(oz);
                        response.Object = stavke;
                        break;
                    case Operation.VratiObracunZarade:
                        oz = serializer.ReadType<ObracunZarade>(request.Object);
                        oz = Controller.Instance.VratiObracunZarade(oz);
                        response.Object = oz;
                        break;
                    case Operation.PretraziObracuneZarade:
                        oz = serializer.ReadType<ObracunZarade>(request.Object);
                        List<ObracunZarade> nadjeniObracuni = Controller.Instance.PretraziObracuneZarade(oz);
                        if (nadjeniObracuni.Count == 0)
                        {
                            response.isSuccessful = false;
                            response.Object = null;
                        }
                        response.Object = nadjeniObracuni;
                        break;
                    case Operation.ObrisiObracunZarade:
                        oz = serializer.ReadType<ObracunZarade>(request.Object);
                        bool obrisan = Controller.Instance.ObrisiObracunZarade(oz);
                        response.isSuccessful = obrisan;
                        break;
                    case Operation.KreirajAgenciju:
                        Agencija agencija = serializer.ReadType<Agencija>(request.Object);
                        Agencija novaAgencija = Controller.Instance.KreirajAgenciju(agencija);
                        response.Object = novaAgencija;
                        break;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                Debug.WriteLine("ERROR: " + response.Error);
                response.Error = ex.Message;
                response.isSuccessful = false;
            }
            return response;
        }

        internal void Close()
        {
            client.Close();
        }
    }
}

