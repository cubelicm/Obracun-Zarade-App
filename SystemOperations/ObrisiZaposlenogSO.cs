using Common.Domain;

namespace SystemOperations
{
    public class ObrisiZaposlenogSO : BaseSO
    {
        private Zaposleni z;
        public bool Result { get; set; }

        public ObrisiZaposlenogSO(Zaposleni zaposleni)
        {
            z = zaposleni;
        }

        protected override void ExecuteConcreteOperation()
        {
            z.Condition = $"z.idZaposleni = {z.IdZaposleni}";

            Zaposleni pronadjen = broker.GetOne(z) as Zaposleni;
            if (pronadjen == null)
            {
                Result = false;
                return;
            }

            z.Condition = $"idZaposleni = {z.IdZaposleni}";
            broker.Delete(z);
            Result = true;
        }
    }
}