using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Zaposleni: IEntity
    {
        public int IdZaposleni {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime
        {
            get
            {
                return $"{Ime} {Prezime}";
            }
        }
        public string BrojTekucegRacuna { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public Pozicija Pozicija { get; set; }
        
        public string NazivPozicije => Pozicija?.Naziv ?? "";
        public string TableName => "Zaposleni";
        public string Values => $"'{Ime}','{Prezime}','{BrojTekucegRacuna}','{DatumRodjenja.ToString("yyyyMMdd")}','{DatumZaposlenja.ToString("yyyyMMdd")}','{Email}','{BrojTelefona}','{Pozicija.IdPozicija}'";
        public string Join => " JOIN Pozicija p ON (z.idPozicija = p.idPozicija)";
        public string Alias => "z";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"ime='{Ime}',prezime='{Prezime}',brojTekucegRacuna='{BrojTekucegRacuna}',datumRodjenja='{DatumRodjenja.ToString("yyyyMMdd")}',datumZaposlenja='{DatumZaposlenja.ToString("yyyyMMdd")}',email='{Email}',brojTelefona='{BrojTelefona}',idPozicija='{Pozicija.IdPozicija}'";
        public string IdName => "idZaposleni";
        public object Condition { get; set;  }
        public override bool Equals(object? obj)
        {
            return obj is Zaposleni z && z.IdZaposleni == IdZaposleni;
        }
        public Zaposleni()
        {
            Pozicija = new Pozicija();
        }
        public IEntity GetOne(SqlDataReader reader)
        {
            return new Zaposleni
            {
                IdZaposleni = (int)reader["idZaposleni"],
                Ime = (string)reader["ime"],
                Prezime = (string)reader["prezime"],
                BrojTekucegRacuna = (string)reader["brojTekucegRacuna"],
                DatumRodjenja = (DateTime)reader["datumRodjenja"],
                DatumZaposlenja = (DateTime)reader["datumZaposlenja"],
                Email = (string)reader["email"],
                BrojTelefona = (string)reader["brojTelefona"],
                Pozicija = new Pozicija
                {
                    IdPozicija = (int)reader["idPozicija"],
                    Naziv = (string)reader["naziv"],
                    Sektor = (string)reader["sektor"]
                }
            };
        }
    }
}
