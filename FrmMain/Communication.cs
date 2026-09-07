
﻿using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Communication
    {
        //singleton
        private static Communication instance;
        public static Communication Instance
        {
            get
            {
                if (instance == null) instance = new Communication();
                return instance;
            }
        }
        public event Action? Disconnected;
        private Communication()
        {
        }

        private Socket socket;
        public JSONNetworkSerializer serializer;

        public void Connect()
        {

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JSONNetworkSerializer(socket);


        }
        internal bool TryPing()
        {
            if (serializer == null) return false;
            try
            {
                var req = new Request { Operation = Operation.Ping };
                serializer.Send(req);
                var _ = serializer.Receive<Response>();
                return true;
            }

            catch (IOException io)
            {
                Debug.WriteLine("IO>>>" + io.Message);
                return false;
            }
            catch (SocketException se)
            {
                Debug.WriteLine("SE>>>" + se.Message);
                return false;
            }
            catch (ObjectDisposedException ode)
            {
                Debug.WriteLine("ODE>>>" + ode.Message);
                return false;
            }
        }
        internal Response Login(Racunovodja racunovodja)
        {
            Request request = new Request
            {
                Operation = Operation.Login,
                Object = racunovodja
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();

            return response;
        }
        internal void Abort()
        {
            try
            {
                socket?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXXXXX>>>>>>" + ex.Message);
            }

            socket = null;
            serializer = null;
        }
        internal void CloseConnection()
        {
            try
            {
                socket?.Shutdown(SocketShutdown.Both);
                socket?.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("EX>>>" + e.Message);
            }
            socket = null;
            serializer = null;
        }

        internal Response UbaciZaposlenog(Zaposleni z)
        {
            Request req = new Request
            {
                Object = z,
                Operation = Operation.UbaciZaposlenog
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response IzmeniZaposlenog(Zaposleni z)
        {
            Request req = new Request
            {
                Object = z,
                Operation = Operation.IzmeniZaposlenog
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response VratiPozicije()
        {
            Request req = new Request
            {
                Operation = Operation.VratiPozicije
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }



        internal Response ObrisiZaposlenog(Zaposleni zaposleni)
        {
            Request req = new Request
            {
                Operation = Operation.ObrisiZaposlenog,
                Object = zaposleni
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response VratiZaposlene()
        {
            Request req = new Request
            {
                Operation = Operation.VratiZaposlene
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response PretraziZaposlene(Zaposleni z)
        {
            Request req = new Request
            {
                Operation = Operation.PretraziZaposlene,
                Object = z
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }
        

        internal Response VratiVrsteZarada()
        {
            Request req = new Request
            {
                Operation = Operation.VratiVrsteZarada
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response UbaciVrstuZarade(VrstaZarade vz)
        {
            Request req = new Request
            {
                Operation = Operation.UbaciVrstuZarade,
                Object = vz
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response VratiRacunovodje()
        {
            Request req = new Request
            {
                Operation = Operation.VratiRacunovodje,
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            return res;
        }

        internal Response UbaciObracunZarade(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            serializer.Send(new Request
            {
                Operation = Operation.UbaciObracunZarade,
                Object = new ObracunZaradeSaStavkamaDTO { ObracunZarade = oz, Stavke = stavke }
            });
            return serializer.Receive<Response>();
        }
        internal Response IzmeniObracunZarade(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            serializer.Send(new Request
            {
                Operation = Operation.IzmeniObracunZarade,
                Object = new ObracunZaradeSaStavkamaDTO { ObracunZarade = oz, Stavke = stavke }
            });
            return serializer.Receive<Response>();
        }

        internal Response VratiStavkeObracuna(ObracunZarade oz)
        {
            Request req = new Request
            {
                Operation = Operation.VratiStavkeObracuna,
                Object = oz
            };
            serializer.Send(req);
            return serializer.Receive<Response>();
        }
        internal Response VratiObracunZarade(ObracunZarade oz)
        {
            Request req = new Request
            {
                Operation = Operation.VratiObracunZarade,
                Object = oz
            };
            serializer.Send(req);
            return serializer.Receive<Response>();
        }

        internal Response PretraziObracuneZarade(ObracunZarade oz)
        {
            Request req = new Request
            {
                Operation = Operation.PretraziObracuneZarade,
                Object = oz
            };
            serializer.Send(req);
            return serializer.Receive<Response>();
        }

        internal Response ObrisiObracunZarade(ObracunZarade oz)
        {
            Request req = new Request
            {
                Operation = Operation.ObrisiObracunZarade,
                Object = oz
            };
            serializer.Send(req);
            return serializer.Receive<Response>();
        }
        internal Response KreirajAgenciju(Agencija agencija)
        {
            Request req = new Request
            {
                Operation = Operation.KreirajAgenciju,
                Object = agencija
            };
            serializer.Send(req);
            return serializer.Receive<Response>();
        }

    }



}


