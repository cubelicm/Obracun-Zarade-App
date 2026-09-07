using Microsoft.Data.SqlClient;
namespace Common.Domain
{
    public class ObracunZarade : IEntity
    {
        public int IdObracunZarade { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public bool Storniran { get; set; }
        public string Napomena { get; set; }
        public decimal UkupnaZarada { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Racunovodja Racunovodja { get; set; }
        public List<StavkaObracunaZarade> Stavke { get; set; }
        public string ImePrezimeRacunovodje => Racunovodja?.ImePrezime ?? "";
        public string ImePrezimeZaposlenog => Zaposleni?.ImePrezime ?? "";
        public string Period => $"{DatumOd:dd.MM.yyyy} - {DatumDo:dd.MM.yyyy}";
        public string StornoTekst => Storniran ? "Da" : "Ne";
        #region IEntityProperties
        public string TableName => "ObracunZarade";
        public string Values => $"'{DatumOd.ToString("yyyyMMdd")}', '{DatumDo.ToString("yyyyMMdd")}','{(Storniran ? 1 : 0)}','{Napomena}','{UkupnaZarada}','{Zaposleni.IdZaposleni}','{Racunovodja.IdRacunovodja}'";
        public string Join => "JOIN Zaposleni z on (oz.idZaposleni=z.idZaposleni) JOIN Pozicija p on (z.idPozicija = p.idPozicija) JOIN Racunovodja r on (oz.idRacunovodja=r.idRacunovodja)";
        public string IdName => $"idObracunZarade";
        public string Alias => $"oz";
        public string Select => "oz.*, z.ime AS zaposleniIme, z.prezime AS zaposleniPrezime, z.brojTekucegRacuna, z.datumRodjenja, z.datumZaposlenja, z.email, z.brojTelefona, z.idPozicija, p.naziv, p.sektor, r.ime AS racunovodjaIme, r.prezime AS racunovodjaPrezime, r.korisnickoIme, r.sifra";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"datumOd='{DatumOd.ToString("yyyyMMdd")}', datumDo='{DatumDo.ToString("yyyyMMdd")}',storniran='{(Storniran ? 1 : 0)}',napomena='{Napomena}',ukupnaZarada='{UkupnaZarada}',idZaposleni='{Zaposleni.IdZaposleni}',idRacunovodja='{Racunovodja.IdRacunovodja}'";
        #endregion

        public ObracunZarade()
        {
            Zaposleni = new Zaposleni();
            Racunovodja = new Racunovodja();
        }

        public object Condition { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is ObracunZarade obracun && IdObracunZarade == obracun.IdObracunZarade;
        }
        public IEntity GetOne(SqlDataReader reader)
        {
            return new ObracunZarade
            {
                IdObracunZarade = (int)reader["idObracunZarade"],
                DatumOd = (DateTime)reader["datumOd"],
                DatumDo = (DateTime)reader["datumDo"],
                Storniran = (bool)reader["storniran"],
                Napomena = (string)reader["napomena"],
                UkupnaZarada = (decimal)reader["ukupnaZarada"],
                Zaposleni = new Zaposleni
                {
                    IdZaposleni = (int)reader["idZaposleni"],
                    Ime = (string)reader["zaposleniIme"],
                    Prezime = (string)reader["zaposleniPrezime"],
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
                },
                Racunovodja = new Racunovodja
                {
                    IdRacunovodja = (int)reader["idRacunovodja"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Ime = (string)reader["racunovodjaIme"],
                    Prezime = (string)reader["racunovodjaPrezime"]
                }
            };
        }
    }
}