using Common.Domain;

namespace SystemOperations
{
    public class VratiObracunZaradeSO : BaseSO
    {
        private ObracunZarade oz;
        public ObracunZarade Result { get; set; }

        public VratiObracunZaradeSO(ObracunZarade oz)
        {
            this.oz = oz;
        }

        protected override void ExecuteConcreteOperation()
        {
            oz.Condition = $"oz.idObracunZarade = {oz.IdObracunZarade}";
            Result = broker.GetByConditionJoin(oz)
                           .Cast<ObracunZarade>()
                           .FirstOrDefault();
        }
    }
}