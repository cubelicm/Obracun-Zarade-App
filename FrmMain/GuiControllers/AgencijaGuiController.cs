using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.GuiControllers
{
    internal class AgencijaGuiController
    {
        private UCAgencija ucAgencija;

        private static AgencijaGuiController instance;
        public static AgencijaGuiController Instance
        {
            get
            {
                if (instance == null) instance = new AgencijaGuiController();
                return instance;
            }
        }

        private AgencijaGuiController()
        {
        }

        public UCAgencija ShowAgencijaUC()
        {
            ucAgencija = new UCAgencija();

            ucAgencija.DateTimePickerDatumOsnivanja.Value = DateTime.Now;

            ucAgencija.TxtNaziv.TextChanged += TextChanged;
            ucAgencija.TxtPIB.TextChanged += TextChanged;

            ucAgencija.BtnUbaci.Click += BtnUbaci_Click;

            return ucAgencija;
        }

        
        private void TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucAgencija.TxtNaziv.Text))
                ucAgencija.TxtNaziv.BackColor = Color.White;
            if (!string.IsNullOrEmpty(ucAgencija.TxtPIB.Text))
                ucAgencija.TxtPIB.BackColor = Color.White;
        }

        
        public bool Validation()
        {
            ucAgencija.TxtNaziv.BackColor = Color.White;
            ucAgencija.TxtPIB.BackColor = Color.White;

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(ucAgencija.TxtNaziv.Text))
            {
                ucAgencija.TxtNaziv.BackColor = Color.Salmon;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ucAgencija.TxtPIB.Text))
            {
                ucAgencija.TxtPIB.BackColor = Color.Salmon;
                isValid = false;
            }

            return isValid;
        }

        private void BtnUbaci_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                MessageBox.Show("Naziv i PIB su obavezna polja.");
                return;
            }

            try
            {
                Agencija agencija = new Agencija
                {
                    Naziv = ucAgencija.TxtNaziv.Text,
                    DatumOsnivanja = ucAgencija.DateTimePickerDatumOsnivanja.Value,
                    Direktor = ucAgencija.TxtDirektor.Text,
                    BrojTelefona = ucAgencija.TxtBrojTelefona.Text,
                    Adresa = ucAgencija.TxtAdresa.Text,
                    Email = ucAgencija.TxtEmail.Text,
                    PIB = ucAgencija.TxtPIB.Text
                };

                Response res = Communication.Instance.KreirajAgenciju(agencija);

                if (!res.isSuccessful)
                {
                    MessageBox.Show("Sistem ne može da ubaci agenciju: " + res.Error);
                    return;
                }

                MessageBox.Show("Agencija je uspešno ubačena.");
                OcistiFormu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OcistiFormu()
        {
            ucAgencija.TxtNaziv.Text = "";
            ucAgencija.TxtDirektor.Text = "";
            ucAgencija.TxtBrojTelefona.Text = "";
            ucAgencija.TxtAdresa.Text = "";
            ucAgencija.TxtEmail.Text = "";
            ucAgencija.TxtPIB.Text = "";
            ucAgencija.DateTimePickerDatumOsnivanja.Value = DateTime.Now;
        }
    }
}