using Microsoft.Data.SqlClient;
namespace Common.Domain
{
    public class Pozicija : IEntity
    {
        public int IdPozicija { get; set; }
        public string Naziv {  get; set; }
        public string Sektor { get; set; }

        public string TableName => "Pozicija";
        public string Values => $"'{Naziv}', '{Sektor}'";
        public string Join => "";
        public string Alias => "p";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"naziv='{Naziv}',sektor='{Sektor}'";
        public string IdName => "idPozicija";

        public object Condition { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Pozicija poz&& IdPozicija== poz.IdPozicija;
        }
        public IEntity GetOne(SqlDataReader reader)
        {
            return new Pozicija
            {
                IdPozicija = (int)reader["idPozicija"],
                Naziv = (string)reader["naziv"],
                Sektor = (string)reader["sektor"]
            };
        }
       
    }
}
