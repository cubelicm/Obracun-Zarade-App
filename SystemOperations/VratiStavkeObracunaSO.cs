using Common.Domain;
 
namespace SystemOperations
{
    public class VratiStavkeObracunaSO : BaseSO
    {
        private ObracunZarade oz;
        public List<StavkaObracunaZarade> Result { get; set; }

        public VratiStavkeObracunaSO(ObracunZarade oz)
        {
            this.oz = oz;
        }

        protected override void ExecuteConcreteOperation()
        {
           
            var stavka = new StavkaObracunaZarade();
            stavka.Condition = $"soz.idObracunZarade = {oz.IdObracunZarade}";

            Result = broker.GetByConditionJoin(stavka)
                           .Cast<StavkaObracunaZarade>()
                           .ToList();
        }
    }
}
