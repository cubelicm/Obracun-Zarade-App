using Common.Domain;
using System.Collections.Generic;

namespace SystemOperations
{
    public class PromeniObracunZaradeSO : BaseSO
    {
        private ObracunZarade oz;
        private List<StavkaObracunaZarade> stavke;
        public PromeniObracunZaradeSO(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            this.oz = oz;
            this.stavke = stavke;
        }

        protected override void ExecuteConcreteOperation()
        {
            
            oz.Condition = $"idObracunZarade = {oz.IdObracunZarade}";
            broker.Update(oz);
            StavkaObracunaZarade praznaStavka = new StavkaObracunaZarade
            {
                ObracunZarade = oz
            };
            praznaStavka.Condition = $"idObracunZarade = {oz.IdObracunZarade}";
            broker.Delete(praznaStavka);
            foreach (var stavka in stavke)
            {
                stavka.ObracunZarade = oz;
                broker.Add(stavka);
            }
        }
    }
}