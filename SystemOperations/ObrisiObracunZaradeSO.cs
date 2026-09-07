using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemOperations
{
    public class ObrisiObracunZaradeSO : BaseSO
    {
        private ObracunZarade oz;
        public bool Result { get; set; }

        public ObrisiObracunZaradeSO(ObracunZarade obracunZarade)
        {
            oz = obracunZarade;
        }

        protected override void ExecuteConcreteOperation()
        {
            
            ObracunZarade pun = new ObracunZarade { Condition = $"oz.idObracunZarade = {oz.IdObracunZarade}" };
            ObracunZarade postojeci = broker.GetByConditionJoin(pun).Cast<ObracunZarade>().FirstOrDefault();

            if (postojeci == null)
            {
                throw new Exception("Obračun zarade ne postoji.");
            }

            if (!postojeci.Storniran)
            {
                throw new Exception("Obračun zarade mora prvo biti storniran da bi mogao da se obriše.");
            }

            
            StavkaObracunaZarade stavka = new StavkaObracunaZarade
            {
                Condition = $"idObracunZarade = {postojeci.IdObracunZarade}"
            };
            broker.Delete(stavka);

            postojeci.Condition = $"idObracunZarade = {postojeci.IdObracunZarade}";
            broker.Delete(postojeci);

            Result = true;
        }
    }
}