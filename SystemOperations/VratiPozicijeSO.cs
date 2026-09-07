using Common.Domain;

namespace SystemOperations
{
    public class VratiPozicijeSO : BaseSO
    {
        public List<Pozicija> Result { get; set;  }

        protected override void ExecuteConcreteOperation()
        {
            Result= broker.GetAll(new Pozicija()).Cast<Pozicija>().ToList();
        }
    }
}