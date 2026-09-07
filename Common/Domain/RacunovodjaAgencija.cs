using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class RacunovodjaAgencija: IEntity
    {
        public Racunovodja Racunovodja { get; set; }
        public Agencija Agencija { get; set; }
        public int BrojUgovora { get; set; }

        public string TableName => "Racunovodja_Agencija";
        public string Values => $"'{Racunovodja.IdRacunovodja}', '{Agencija.IdAgencija}', '{BrojUgovora}'";
        public string Join => "JOIN Racunovodja r on (ra.idRacunovodja=r.idRacunovodja) JOIN Agencija a on (ra.idAgencija=a.idAgencija) ";
        public string Alias => "ra";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"brojUgovora='{BrojUgovora}'";
        public string IdName => "idRacunovodja, IdAgencija";
        public object Condition {  get; set; }
        public override bool Equals(object? obj)
        {
            return obj is RacunovodjaAgencija ra && Racunovodja.IdRacunovodja == ra.Racunovodja.IdRacunovodja && Agencija.IdAgencija == ra.Agencija.IdAgencija; 
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            return new RacunovodjaAgencija {
                Racunovodja = new Racunovodja
                {
                    IdRacunovodja = (int)reader["idRacunovodja"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"]
                },
                Agencija = new Agencija
                {
                    IdAgencija = (int)reader["idAgencija"],
                    Naziv = (string)reader["naziv"],
                    DatumOsnivanja = (DateTime)reader["datumOsnivanja"],
                    Direktor = (string)reader["direktor"],
                    BrojTelefona = (string)reader["brojTelefona"],
                    Adresa = (string)reader["adresa"],
                    Email = (string)reader["email"],
                    PIB = (string)reader["PIB"]
                },
                BrojUgovora = (int)reader["brojUgovora"]
            };
        }
        
    }
}
