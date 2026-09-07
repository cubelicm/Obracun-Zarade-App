
﻿using Common.Communication;
using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
//OVDE TREBA DODATI SVAKU SO
namespace Server
{
    internal class Controller
    {
        //singleton
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller()
        {
        }

        public Racunovodja PrijaviRacunovodju(Racunovodja racunovodja)
        {
            PrijaviRacunovodjuSO so = new PrijaviRacunovodjuSO(racunovodja);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal void UbaciZaposlenog(Zaposleni z)
        {
            UbaciZaposlenogSO operation = new UbaciZaposlenogSO(z);
            operation.ExecuteTemplate();
        }

        internal void IzmeniZaposlenog(Zaposleni z)
        {
            PromeniZaposlenogSO operation = new PromeniZaposlenogSO(z);
            operation.ExecuteTemplate();
        }

        internal object VratiPozicije()
        {
            VratiPozicijeSO operation = new VratiPozicijeSO();
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal object VratiZaposlene()
        {
            VratiZaposleneSO operation = new VratiZaposleneSO();
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal List<Zaposleni> PretraziZaposlene(Zaposleni z)
        {
            PretraziZaposleneSO operation = new PretraziZaposleneSO(z);
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal bool ObrisiZaposlenog(Zaposleni z)
        {
            ObrisiZaposlenogSO operation = new ObrisiZaposlenogSO(z);
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal List<VrstaZarade> VratiVrsteZarada()
        {
            VratiListuSveVrsteZaradaSO operation = new VratiListuSveVrsteZaradaSO();
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal void UbaciVrstuZarade(VrstaZarade vz)
        {
            UbaciVrstuZaradeSO operation = new UbaciVrstuZaradeSO(vz);
            operation.ExecuteTemplate();
        }

        internal List<Racunovodja> VratiRacunovodje()
        {
            VratiListuSveRacunovodjeSO operation = new VratiListuSveRacunovodjeSO();
            operation.ExecuteTemplate();
            return operation.Result;
        }
        internal ObracunZarade UbaciObracunZarade(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            UbaciObracunZaradeSO operation = new UbaciObracunZaradeSO(oz, stavke);
            operation.ExecuteTemplate();
            return operation.Result;
        }
        internal void IzmeniObracunZarade(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            PromeniObracunZaradeSO operation = new PromeniObracunZaradeSO(oz, stavke);
            operation.ExecuteTemplate();
        }

        internal List<StavkaObracunaZarade> VratiStavkeObracuna(ObracunZarade oz)
        {
            VratiStavkeObracunaSO operation = new VratiStavkeObracunaSO(oz);
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal ObracunZarade VratiObracunZarade(ObracunZarade oz)
        {
            VratiObracunZaradeSO operation = new VratiObracunZaradeSO(oz);
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal List<ObracunZarade> PretraziObracuneZarade(ObracunZarade oz)
        {
            PretraziObracuneZaradaSO operation = new PretraziObracuneZaradaSO(oz);
            operation.ExecuteTemplate();
            return operation.Result;
        }

        internal bool ObrisiObracunZarade(ObracunZarade oz)
        {
            ObrisiObracunZaradeSO operation = new ObrisiObracunZaradeSO(oz);
            operation.ExecuteTemplate();
            return operation.Result;
        }
        internal Agencija KreirajAgenciju(Agencija agencija)
        {
            KreirajAgencijuSO operation = new KreirajAgencijuSO(agencija);
            operation.ExecuteTemplate();
            return operation.Result;
        }

    }
}
