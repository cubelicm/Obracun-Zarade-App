using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System.ComponentModel;

namespace Client.GuiControllers
{
    public class PretraziZaposleneGuiController
    {
        public UCPretraziZaposlenog UcPretraziZaposlenog { get; set; }

        private PretraziZaposleneGuiController() { }

        private static PretraziZaposleneGuiController instance;
        public static PretraziZaposleneGuiController Instance
        {
            get
            {
                if (instance == null) instance = new PretraziZaposleneGuiController();
                return instance;
            }
        }

        public UCPretraziZaposlenog ShowPretraziZaposleneUC()
        {
            UcPretraziZaposlenog = new UCPretraziZaposlenog();
            PopuniPodatke();
            PodesiDgv();
            PopuniDgv();
            UcPretraziZaposlenog.LblError.Text = "";
            UcPretraziZaposlenog.TxtIme.TextChanged += Filter_Changed;
            UcPretraziZaposlenog.TxtPrezime.TextChanged += Filter_Changed;
            UcPretraziZaposlenog.CbPozicija.SelectedIndexChanged += Filter_Changed;

            UcPretraziZaposlenog.BtnIzmeniZaposlenog.Click += BtnIzmeni_Click;
            UcPretraziZaposlenog.BtnObrisiZaposlenog.Click += BtnObrisi_Click;
            UcPretraziZaposlenog.BtnPretrazi.Click += BtnPretrazi_Click;
            return UcPretraziZaposlenog;
        }

        

        private void Filter_Changed(object? sender, EventArgs e)
        {
            PretraziZaposlenog();
        }
        private void PopuniPodatke()
        {
            try
            {
                // event skinut kako se ne bi okidao tokom ucitavanja user kontrole
                UcPretraziZaposlenog.CbPozicija.SelectedIndexChanged -= Filter_Changed;

                Response res = Communication.Instance.VratiPozicije();
                List<Pozicija> pozicije = Communication.Instance.serializer.ReadType<List<Pozicija>>(res.Object);
                pozicije.Insert(0, new Pozicija { IdPozicija = 0, Naziv = "Sve pozicije" });

                UcPretraziZaposlenog.CbPozicija.DataSource = pozicije;
                UcPretraziZaposlenog.CbPozicija.DisplayMember = "Naziv";
                UcPretraziZaposlenog.CbPozicija.ValueMember = "idPozicija";
                UcPretraziZaposlenog.CbPozicija.SelectedIndex = 0;

                UcPretraziZaposlenog.CbPozicija.SelectedIndexChanged += Filter_Changed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void PodesiDgv()
        {
            var grid = UcPretraziZaposlenog.DataGridViewZaposleni;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ClearSelection();
            grid.CurrentCell = null;
        }

        

        private void PretraziZaposlenog()
        {
            string ime = UcPretraziZaposlenog.TxtIme.Text.Trim();
            string prezime = UcPretraziZaposlenog.TxtPrezime.Text.Trim();
            Pozicija pozicija = UcPretraziZaposlenog.CbPozicija.SelectedItem as Pozicija;

            List<string> uslovi = new List<string>();

            if (!string.IsNullOrWhiteSpace(ime))
                uslovi.Add($"z.Ime LIKE '{ime}%'");

            if (!string.IsNullOrWhiteSpace(prezime))
                uslovi.Add($"z.Prezime LIKE '{prezime}%'");

            if (pozicija != null && pozicija.IdPozicija != 0)
                uslovi.Add($"z.idPozicija = {pozicija.IdPozicija}");

            Zaposleni z = new Zaposleni
            {
                // Kad nema kriterijuma vraca sve (1=1)
                Condition = uslovi.Count == 0 ? "1=1" : string.Join(" AND ", uslovi)
            };

            try
            {
                Response res = Communication.Instance.PretraziZaposlene(z);
                if (!res.isSuccessful)
                {
                    UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                    UcPretraziZaposlenog.LblError.Text = "Sistem ne može da nađe zaposlene po zadatim kriterijumima.";
                    PrikaziDgvPodatke(new List<Zaposleni>());
                    return;
                }

                List<Zaposleni> zaposleni = Communication.Instance.serializer
                    .ReadType<List<Zaposleni>>(res.Object);
                UcPretraziZaposlenog.LblError.ForeColor = Color.Green;
                UcPretraziZaposlenog.LblError.Text = $"Sistem je nasao zaposlene po zadatim kriterijumima: {zaposleni.Count}";
                PrikaziDgvPodatke(zaposleni);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void PopuniDgv()
        {
            PretraziZaposlenog();
        }

        private Zaposleni GetSelektovaniZaposleni()
        {
            var grid = UcPretraziZaposlenog.DataGridViewZaposleni;
            if (grid.SelectedRows.Count == 0) return null;
            return grid.SelectedRows[0].DataBoundItem as Zaposleni;
        }

        
        private Zaposleni ProveriZaposlenogUBazi(Zaposleni zaposleni)
        {
            Zaposleni upit = new Zaposleni
            {
                Condition = $"z.idZaposleni = {zaposleni.IdZaposleni}"
            };

            Response res = Communication.Instance.PretraziZaposlene(upit);

            if (!res.isSuccessful) return null;

            List<Zaposleni> lista = Communication.Instance.serializer
                .ReadType<List<Zaposleni>>(res.Object);

            return lista.FirstOrDefault();
        }

        private void BtnIzmeni_Click(object? sender, EventArgs e)
        {
            Zaposleni zaposleni = GetSelektovaniZaposleni();

            if (zaposleni == null)
            {
                UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                UcPretraziZaposlenog.LblError.Text = "Morate selektovati zaposlenog za izmenu.";
                return;
            }

            try
            {
                Zaposleni svezi = ProveriZaposlenogUBazi(zaposleni);
                if (svezi == null)
                {
                    //UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                    //UcPretraziZaposlenog.LblError.Text = "Sistem ne može da nađe zaposlenog.";
                    MessageBox.Show("Sistem ne moze da nadje zaposlenog","Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopuniDgv();
                    return;
                }
                MessageBox.Show("Sistem je nasao zaposlenog", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainCoordinator.Instance.ShowPromeniZaposlenogPanelPoziv(svezi);
                PopuniDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void BtnObrisi_Click(object? sender, EventArgs e)
        {
            Zaposleni zaposleni = GetSelektovaniZaposleni();

            if (zaposleni == null)
            {
                UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                UcPretraziZaposlenog.LblError.Text = "Morate selektovati zaposlenog za brisanje.";
                return;
            }

            try
            {
                Zaposleni svezi = ProveriZaposlenogUBazi(zaposleni);
                if (svezi == null)
                {
                    //UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                    //UcPretraziZaposlenog.LblError.Text = "Sistem ne može da nađe zaposlenog.";
                    MessageBox.Show("Sistem ne moze da nadje zaposlenog", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopuniDgv();
                    return;
                }
                MessageBox.Show("Sistem je nasao zaposlenog", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Response res = Communication.Instance.ObrisiZaposlenog(svezi);

                if (!res.isSuccessful)
                {
                    //UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                    //UcPretraziZaposlenog.LblError.Text = "Sistem ne može da obriše zaposlenog.";
                    MessageBox.Show("Sistem ne moze da obrise zaposlenog", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //UcPretraziZaposlenog.LblError.ForeColor = Color.Green;
                //UcPretraziZaposlenog.LblError.Text = "Sistem je obrisao zaposlenog.";
                MessageBox.Show("Sistem je obrisao zaposlenog", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }
        private void BtnPretrazi_Click(object? sender, EventArgs e)
        {
            Zaposleni zaposleni = GetSelektovaniZaposleni();

            if (zaposleni == null)
            {
                UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                UcPretraziZaposlenog.LblError.Text = "Morate selektovati zaposlenog za proveru.";
                return;
            }

            try
            {
                Zaposleni svezi = ProveriZaposlenogUBazi(zaposleni);
                if (svezi == null)
                {
                    //UcPretraziZaposlenog.LblError.ForeColor = Color.Red;
                    //UcPretraziZaposlenog.LblError.Text = "Sistem ne može da nađe zaposlenog.";
                    MessageBox.Show("Sistem ne moze da nadje zaposlenog", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopuniDgv();
                    return;
                }
                //UcPretraziZaposlenog.LblError.ForeColor = Color.Green;
                //UcPretraziZaposlenog.LblError.Text = "Sistem je našao zaposlenog.";
                MessageBox.Show("Sistem je nasao zaposlenog", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void PrikaziDgvPodatke(List<Zaposleni> zaposleni)
        {
            var grid = UcPretraziZaposlenog.DataGridViewZaposleni;
            grid.DataSource = null;
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ime", HeaderText = "Ime" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Prezime", HeaderText = "Prezime" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BrojTelefona", HeaderText = "Broj Telefona" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NazivPozicije", HeaderText = "Pozicija" });

            grid.DataSource = new BindingList<Zaposleni>(zaposleni);
            grid.ClearSelection();
            grid.CurrentCell = null;
        }
    }
}