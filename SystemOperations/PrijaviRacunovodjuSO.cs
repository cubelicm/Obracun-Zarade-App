using Common.Domain;
using SystemOperations;
namespace SystemOperations
{
    public class PrijaviRacunovodjuSO : BaseSO
    {
        private readonly Racunovodja korisnik;
        public Racunovodja Result { get; set; }

        public PrijaviRacunovodjuSO(Racunovodja racunovodja)
        {
            this.korisnik = racunovodja;
        }

        protected override void ExecuteConcreteOperation()
        {
            korisnik.Condition = $"korisnickoIme = '{korisnik.KorisnickoIme}' AND sifra = '{korisnik.Sifra}'";
            List<IEntity> lista = broker.GetByCondition(korisnik);

            Result = lista.Cast<Racunovodja>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Korisničko ime i šifra nisu ispravni.");
            }

        }
    }
}
