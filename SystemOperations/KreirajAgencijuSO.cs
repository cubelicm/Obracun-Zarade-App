using Common.Domain;

namespace SystemOperations
{
    public class KreirajAgencijuSO : BaseSO
    {
        private Agencija agencija;

        public Agencija Result { get; set; }

        public KreirajAgencijuSO(Agencija agencija)
        {
            this.agencija = agencija;
        }

        protected override void ExecuteConcreteOperation()
        {
            
            Agencija praznaAgencija = new Agencija
            {
                Naziv = "",
                Direktor = "",
                BrojTelefona = "",
                Adresa = "",
                Email = "",
                PIB = "",
                DatumOsnivanja = DateTime.Now
            };

            int idAgencija = broker.AddWithId(praznaAgencija);

            
            agencija.IdAgencija = idAgencija;
            agencija.Condition = $"idAgencija = {idAgencija}";

            broker.Update(agencija);

            Result = agencija;
        }
    }
}