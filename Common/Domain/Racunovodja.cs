
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class Racunovodja : IEntity
    {
        public int IdRacunovodja { get; set;  }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime
        {
            get
            {
                return $"{Ime} {Prezime}";
            }
        }
        public string TableName => "Racunovodja";
        public string Values => $"'{KorisnickoIme}','{Sifra}','{Ime}','{Prezime}'";
        public string Join => "";
        public string Alias => "r";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"korisnickoIme='{KorisnickoIme}',sifra='{Sifra}',ime='{Ime}',prezime='{Prezime}'";
        public string IdName => "idRacunovodja";
        public object Condition { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is Racunovodja racunovodja && this.IdRacunovodja==racunovodja.IdRacunovodja;
        }
        public IEntity GetOne(SqlDataReader reader)
        {
            return new Racunovodja
            {
                IdRacunovodja = (int)reader["idRacunovodja"],
                KorisnickoIme = (string)reader["korisnickoIme"],
                Sifra = (string)reader["sifra"],
                Ime = (string)reader["ime"],
                Prezime = (string)reader["prezime"]
            };
        }
        
    }
}
