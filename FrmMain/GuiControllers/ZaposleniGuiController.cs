using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiControllers
{
    internal class ZaposleniGuiController
    {
        Mod mod;
        Zaposleni zaposleniZaIzmenu;
        public enum Mod
        {
            Ubaci,
            Promeni
        }
        private static ZaposleniGuiController instance;
        public static ZaposleniGuiController Instance
        {
            get
            {
                if (instance == null) instance = new ZaposleniGuiController();
                return instance;
            }
        }


        private ZaposleniGuiController()
        {

        }

        UCDetaljiZaposlenog ucDetaljiZaposlenog;
        internal Control ShowDetaljiZaposlenogUC(Mod mod, Zaposleni zaposleni = null)
        {
            ucDetaljiZaposlenog = new UCDetaljiZaposlenog();
            
            this.mod = mod;
            this.zaposleniZaIzmenu = zaposleni;

            LoadTitle();

            if (mod == Mod.Promeni)
            {
                ucDetaljiZaposlenog.BtnSubmit.Text = "Promeni zaposlenog";
                ucDetaljiZaposlenog.LblNaslov.Text = "Promeni postojećeg zaposlenog";
                LoadEmployeeData();
            }
            else if (mod == Mod.Ubaci)
            {
                ucDetaljiZaposlenog.BtnSubmit.Text = "Ubaci Zaposlenog";
            }
            ucDetaljiZaposlenog.BtnSubmit.Click += Submit_Click;
            return ucDetaljiZaposlenog;
        }

        private void LoadTitle()
        {
            var res = Communication.Instance.VratiPozicije();
            var list = Communication.Instance.serializer.ReadType<List<Pozicija>>(res.Object);

            ucDetaljiZaposlenog.CbPozicija.DataSource = list;
            ucDetaljiZaposlenog.CbPozicija.DisplayMember = "Naziv";
            ucDetaljiZaposlenog.CbPozicija.ValueMember = "IdPozicija";
            ucDetaljiZaposlenog.CbPozicija.SelectedIndex = -1;
        }

        private void Submit_Click(object? sender, EventArgs e)
        {
            if (!FormValidation()) return;
            string telefon = ucDetaljiZaposlenog.TxtBrojTelefona.Text.Trim();
            telefon = telefon.Replace(" ", "");

            string brRacuna = ucDetaljiZaposlenog.TxtBrojTekucegRacuna.Text.Trim().Replace(" ", "").Replace("-", "");
            Zaposleni z = new Zaposleni
            {
                Ime = ucDetaljiZaposlenog.TxtIme.Text.Trim(),
                Prezime = ucDetaljiZaposlenog.TxtPrezime.Text.Trim(),
                BrojTelefona = telefon,
                BrojTekucegRacuna = brRacuna,
                Email = ucDetaljiZaposlenog.TxtEmail.Text.Trim(),
                DatumRodjenja = ucDetaljiZaposlenog.DateTimePickerDatumRodjenja.Value,
                DatumZaposlenja = ucDetaljiZaposlenog.DateTimePickerDatumZaposlenja.Value,
                Pozicija = (Pozicija)ucDetaljiZaposlenog.CbPozicija.SelectedItem
            };
            if (mod == Mod.Promeni)
            {
                z.IdZaposleni = zaposleniZaIzmenu.IdZaposleni;
            }
            try
            {
                Response res = mod == Mod.Ubaci
                   ? Communication.Instance.UbaciZaposlenog(z)
                   : Communication.Instance.IzmeniZaposlenog(z);

                if (!res.isSuccessful)
                {
                   
                    MessageBox.Show(mod == Mod.Ubaci
                        ? "Sistem ne moze da zapamti zaposlenog"
                        : "Sistem ne moze da izmeni zaposlenog");
                    return;
                }
                string message =
                    "Sistem je zapamtio zaposlenog\n\n" +
                    $"Ime: {z.Ime}\n" +
                    $"Prezime: {z.Prezime}\n" +
                    $"Broj Telefona: {z.BrojTelefona}\n" +
                    $"Broj Tekućeg računa: {z.BrojTekucegRacuna}\n" +
                    $"Email adresa: {z.Email}\n" +
                    $"Pozicija: {z.Pozicija.Naziv}\n" +
                    $"Datum rodjenja: {z.DatumRodjenja.ToString("dd.MM.yyyy")}\n" +
                    $"Datum zaposlenja: {z.DatumZaposlenja.ToString("dd.MM.yyyy")}\n";

                MessageBox.Show(message);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }

        private bool FormValidation()
        {
            bool isValid = true;
            ResetFieldColor();

            
            if (string.IsNullOrWhiteSpace(ucDetaljiZaposlenog.TxtIme.Text) || !ucDetaljiZaposlenog.TxtIme.Text.All(char.IsLetter))
            {
                ucDetaljiZaposlenog.TxtIme.BackColor = Color.LightCoral;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ucDetaljiZaposlenog.TxtPrezime.Text) || !ucDetaljiZaposlenog.TxtPrezime.Text.All(char.IsLetter))
            {
                ucDetaljiZaposlenog.TxtPrezime.BackColor = Color.LightCoral;
                isValid = false;
            }

         
            if (string.IsNullOrWhiteSpace(ucDetaljiZaposlenog.TxtEmail.Text) || !ucDetaljiZaposlenog.TxtEmail.Text.Contains("@"))
            {
                ucDetaljiZaposlenog.TxtEmail.BackColor = Color.LightCoral;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(ucDetaljiZaposlenog.TxtBrojTekucegRacuna.Text) || ucDetaljiZaposlenog.TxtBrojTekucegRacuna.Text.Any(char.IsLetter))
            {
                ucDetaljiZaposlenog.TxtBrojTekucegRacuna.BackColor = Color.LightCoral;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(ucDetaljiZaposlenog.TxtBrojTelefona.Text) || ucDetaljiZaposlenog.TxtBrojTelefona.Text.Any(char.IsLetter))
            {
                ucDetaljiZaposlenog.TxtBrojTelefona.BackColor = Color.LightCoral;
                isValid = false;
            }
            
            if (!isValid)
            {
                MessageBox.Show("Sistem ne moze da zapamti zaposlenog"
                        + "\nUneti podaci nisu validni. Proverite označena polja.");
             
                return false;
            }
            
            if (ucDetaljiZaposlenog.CbPozicija.SelectedItem is not Pozicija p || p.IdPozicija <= 0)
            {
                MessageBox.Show("Sistem ne moze da zapamti zaposlenog"
                        + "\nMorate izabrati poziciju iz padajuceg menija.");
                
                return false;
            }
            return true;
        }

        private void ResetFieldColor()
        {
            ucDetaljiZaposlenog.TxtIme.BackColor = Color.White;
            ucDetaljiZaposlenog.TxtPrezime.BackColor = Color.White;
            ucDetaljiZaposlenog.TxtEmail.BackColor = Color.White;
            ucDetaljiZaposlenog.TxtBrojTelefona.BackColor = Color.White;
            ucDetaljiZaposlenog.TxtBrojTekucegRacuna.BackColor = Color.White;
        }

        private void LoadEmployeeData()
        {
            if (zaposleniZaIzmenu == null)
            {
                return;
            }
            ucDetaljiZaposlenog.TxtIdZaposlenog.Text = zaposleniZaIzmenu.IdZaposleni.ToString();
            ucDetaljiZaposlenog.TxtIme.Text = zaposleniZaIzmenu.Ime;
            ucDetaljiZaposlenog.TxtPrezime.Text = zaposleniZaIzmenu.Prezime;
            ucDetaljiZaposlenog.TxtBrojTelefona.Text = zaposleniZaIzmenu.BrojTelefona;
            ucDetaljiZaposlenog.TxtBrojTekucegRacuna.Text = zaposleniZaIzmenu.BrojTekucegRacuna;
            ucDetaljiZaposlenog.CbPozicija.SelectedItem = zaposleniZaIzmenu.Pozicija;
            ucDetaljiZaposlenog.DateTimePickerDatumRodjenja.Value = zaposleniZaIzmenu.DatumRodjenja;
            ucDetaljiZaposlenog.DateTimePickerDatumZaposlenja.Value = zaposleniZaIzmenu.DatumZaposlenja;
            ucDetaljiZaposlenog.TxtEmail.Text = zaposleniZaIzmenu.Email;
        }
    }
}
