using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public class StavkaObracunaZarade : IEntity
    {
        public ObracunZarade ObracunZarade { get; set; }
        public int Rb { get; set; }
        public int BrojSati { get; set; }
        public decimal UkupnaZaradaStavka { get; set; }
        public string Napomena { get; set; }
        public VrstaZarade VrstaZarade { get; set; }

        public string TableName => "StavkaObracunaZarade";
        public string Values => $"'{ObracunZarade.IdObracunZarade}','{Rb}','{BrojSati}', '{UkupnaZaradaStavka}', '{Napomena}','{VrstaZarade.IdVrstaZarade}'";
        public string Join => "JOIN ObracunZarade oz on (soz.idObracunZarade=oz.idObracunZarade) JOIN VrstaZarade vz on (soz.idVrstaZarade=vz.idVrstaZarade) JOIN Zaposleni z on (oz.idZaposleni=z.idZaposleni) JOIN Pozicija p on (z.idPozicija=p.idPozicija) JOIN Racunovodja r on (oz.idRacunovodja=r.idRacunovodja)";
        public string Alias => "soz";
        public string Select => "soz.*, oz.datumOd, oz.datumDo, oz.storniran, oz.napomena AS obracunNapomena, oz.ukupnaZarada, oz.idZaposleni, oz.idRacunovodja, " +
                                 "vz.imeVrste, vz.zaradaPoSatu, vz.opis, " +
                                 "z.ime AS zaposleniIme, z.prezime AS zaposleniPrezime, z.brojTekucegRacuna, z.datumRodjenja, z.datumZaposlenja, z.email, z.brojTelefona, z.idPozicija, " +
                                 "p.naziv, p.sektor, " +
                                 "r.ime AS racunovodjaIme, r.prezime AS racunovodjaPrezime, r.korisnickoIme, r.sifra";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"rb='{Rb}', brojSati='{BrojSati}', ukupnaZaradaStavka='{UkupnaZaradaStavka}', napomena='{Napomena}',vrstaZarade='{VrstaZarade.IdVrstaZarade}'";
        public string IdName => "idObracunZarade, rb";
        public object Condition { get; set; }

        public StavkaObracunaZarade()
        {
            ObracunZarade = new ObracunZarade();
            VrstaZarade = new VrstaZarade();
        }

        public override bool Equals(object? obj)
        {
            return obj is StavkaObracunaZarade soz &&
                ObracunZarade.IdObracunZarade == soz.ObracunZarade.IdObracunZarade &&
                Rb == soz.Rb;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            return new StavkaObracunaZarade
            {
                ObracunZarade = new ObracunZarade
                {
                    IdObracunZarade = (int)reader["idObracunZarade"],
                    DatumOd = (DateTime)reader["datumOd"],
                    DatumDo = (DateTime)reader["datumDo"],
                    Storniran = (bool)reader["storniran"],
                    Napomena = (string)reader["obracunNapomena"],
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
                },
                Rb = (int)reader["rb"],
                BrojSati = (int)reader["brojSati"],
                UkupnaZaradaStavka = (decimal)reader["ukupnaZaradaStavka"],
                Napomena = (string)reader["napomena"],
                VrstaZarade = new VrstaZarade
                {
                    IdVrstaZarade = (int)reader["idVrstaZarade"],
                    ImeVrste = (string)reader["imeVrste"],
                    ZaradaPoSatu = (decimal)reader["zaradaPoSatu"],
                    Opis = (string)reader["opis"]
                }
            };
        }
    }
}