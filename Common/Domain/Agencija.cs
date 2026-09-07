using Microsoft.Data.SqlClient;
namespace Common.Domain
{
    public class Agencija:IEntity
    {
        //propertiji
        public int IdAgencija { get; set; }
        public string Naziv {  get; set; }
        public DateTime DatumOsnivanja { get; set; }
        public string Direktor {  get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa {  get; set; }
        public string Email {  get; set; }
        public string PIB { get; set; }
        //IEntity propertiji
        public string TableName => "Agencija";
        public string Values => $"'{Naziv}', '{DatumOsnivanja.ToString("yyyyMMdd")}', '{Direktor}', '{BrojTelefona}', '{Adresa}', '{Email}', '{PIB}'";
        public string Join => "";
        public string IdName => "idAgencija";
        public string Alias => "a";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"naziv='{Naziv}', datumOsnivanja='{DatumOsnivanja.ToString("yyyyMMdd")}', direktor='{Direktor}', brojTelefona='{BrojTelefona}', adresa='{Adresa}', email='{Email}', PIB='{PIB}'";
        //Dodatni propertiji i metode
        public object Condition { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Agencija agencija && IdAgencija == agencija.IdAgencija;
        }
        //IEntity metode
        public IEntity GetOne(SqlDataReader reader)
        {
            return new Agencija
            { 
                IdAgencija = (int)reader["idAgencija"],
                Naziv = (string)reader["naziv"],
                DatumOsnivanja = (DateTime)reader["datumOsnivanja"],
                Direktor = (string)reader["direktor"],
                BrojTelefona = (string)reader["brojTelefona"],
                Adresa = (string)reader["adresa"],
                Email = (string)reader["email"],
                PIB = (string)reader["PIB"]
            };
        }

        /*public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> agencije = new List<IEntity>();
            while (reader.Read())
            {
                Agencija a = new Agencija
                {
                    IdAgencija = (int)reader["idAgencija"],
                    Naziv = (string)reader["naziv"],
                    DatumOsnivanja = (DateTime)reader["datumOsnivanja"],
                    Direktor = (string)reader["direktor"],
                    BrojTelefona = (string)reader["brojTelefona"],
                    Adresa = (string)reader["adresa"],
                    Email = (string)reader["email"],
                    PIB = (string)reader["PIB"]
                };
                agencije.Add(a);
            }
            return agencije;
        }*/

        
    }
}
