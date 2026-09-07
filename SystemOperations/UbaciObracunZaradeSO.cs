using Common.Domain;

namespace SystemOperations
{
    public class UbaciObracunZaradeSO : BaseSO
    {
        private ObracunZarade oz;
        private List<StavkaObracunaZarade> stavke;
        public ObracunZarade Result { get; set; }
        
        public UbaciObracunZaradeSO(ObracunZarade oz, List<StavkaObracunaZarade> stavke)
        {
            this.oz = oz;
            this.stavke = stavke;
        }

        protected override void ExecuteConcreteOperation()
        {
            int idObracunZarade = broker.AddWithId(oz);
            oz.IdObracunZarade = idObracunZarade;

            foreach (var stavka in stavke)
            {
                stavka.ObracunZarade = oz;
                broker.Add(stavka);
            }

            Result = oz;
        }
    }
}