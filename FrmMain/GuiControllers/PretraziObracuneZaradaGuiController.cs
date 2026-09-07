using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiControllers
{
    internal class PretraziObracuneZaradaGuiController
    {
        public UCPretraziObracunZarade UcPretraziObracunZarade { get; set; }

        private static readonly Color BojaStorniranogReda = Color.FromArgb(255, 220, 220);

        private PretraziObracuneZaradaGuiController() { }

        private static PretraziObracuneZaradaGuiController instance;
        public static PretraziObracuneZaradaGuiController Instance
        {
            get
            {
                if (instance == null) instance = new PretraziObracuneZaradaGuiController();
                return instance;
            }
        }

        public UCPretraziObracunZarade ShowPretraziObracunZaradeUC()
        {
            UcPretraziObracunZarade = new UCPretraziObracunZarade();

            UcitajComboBoxeve();
            PodesiDgv();
            PopuniDgv();

            
            UcPretraziObracunZarade.BtnPretrazi.Visible = true;
            UcPretraziObracunZarade.BtnPretrazi.Text = "Pretrazi obracun";

            UcPretraziObracunZarade.CbRacunovodja.SelectedIndexChanged += Filter_SelectedIndexChanged;
            UcPretraziObracunZarade.CbZaposleni.SelectedIndexChanged += Filter_SelectedIndexChanged;
            UcPretraziObracunZarade.CbVrstaZarade.SelectedIndexChanged += Filter_SelectedIndexChanged;

            UcPretraziObracunZarade.BtnPretrazi.Click += BtnPretrazi_Click;
            UcPretraziObracunZarade.BtnDetalji.Click += BtnDetalji_Click;
            UcPretraziObracunZarade.BtnIzmeni.Click += BtnIzmeni_Click;
            UcPretraziObracunZarade.BtnIzbrisi.Click += BtnIzbrisi_Click;

            return UcPretraziObracunZarade;
        }

        private ObracunZarade ProveriObracunUBazi(ObracunZarade oz)
        {
            Response res = Communication.Instance.VratiObracunZarade(
                new ObracunZarade { IdObracunZarade = oz.IdObracunZarade });

            if (!res.isSuccessful) return null;

            return Communication.Instance.serializer.ReadType<ObracunZarade>(res.Object);
        }

        

        private void BtnPretrazi_Click(object sender, EventArgs e)
        {
            UcPretraziObracunZarade.LblError.Text = "";
            ObracunZarade oz = GetSelektovaniObracun();

            if (oz == null)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Morate selektovati obračun za proveru.";
                return;
            }

            try
            {
                ObracunZarade svezi = ProveriObracunUBazi(oz);
                if (svezi == null)
                {
                    MessageBox.Show("Sistem ne moze da nadje obracun zarade", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PretraziObracune();
                    return;
                }

                MessageBox.Show("Sistem je nasao obracun zarade", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PretraziObracune();
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška: " + ex.Message;
            }
        }

        private void BtnDetalji_Click(object sender, EventArgs e)
        {
            UcPretraziObracunZarade.LblError.Text = "";
            ObracunZarade oz = GetSelektovaniObracun();

            if (oz == null)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Morate selektovati obračun da biste prikazali detalje.";
                return;
            }

            try
            {
                ObracunZarade svezi = ProveriObracunUBazi(oz);
                if (svezi == null)
                {
                    MessageBox.Show("Sistem ne moze da nadje obracun zarade", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PretraziObracune();
                    return;
                }
                MessageBox.Show("Sistem je nasao obracun zarade", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainCoordinator.Instance.MainForm.ChangePanel(
                    ObracunZaradeGuiController.Instance.ShowObracunZaradeUC(
                        ObracunZaradeGuiController.ModObracunZarade.Detalji, svezi));
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška: " + ex.Message;
            }
        }

        private void BtnIzmeni_Click(object sender, EventArgs e)
        {
            UcPretraziObracunZarade.LblError.Text = "";
            ObracunZarade oz = GetSelektovaniObracun();

            if (oz == null)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Morate selektovati obračun za izmenu.";
                return;
            }

            try
            {
                ObracunZarade svezi = ProveriObracunUBazi(oz);
                if (svezi == null)
                {
                    MessageBox.Show("Sistem ne moze da nadje obracun zarade", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PretraziObracune();
                    return;
                }
                MessageBox.Show("Sistem je nasao obracun zarade", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainCoordinator.Instance.MainForm.ChangePanel(
                    ObracunZaradeGuiController.Instance.ShowObracunZaradeUC(
                        ObracunZaradeGuiController.ModObracunZarade.Promeni, svezi));
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška: " + ex.Message;
            }
        }

        private void BtnIzbrisi_Click(object sender, EventArgs e)
        {
            UcPretraziObracunZarade.LblError.Text = "";
            ObracunZarade oz = GetSelektovaniObracun();

            if (oz == null)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Morate selektovati obračun koji želite da obrišete.";
                return;
            }

            try
            {
                
                ObracunZarade svezi = ProveriObracunUBazi(oz);
                if (svezi == null)
                {
                    MessageBox.Show("Sistem ne moze da nadje obracun zarade", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PretraziObracune();
                    return;
                }
                MessageBox.Show("Sistem je nasao obracun zarade", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Provera storniranja na svezem objektu iz baze (ne iz DGV-a)
                if (!svezi.Storniran)
                {
                    UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                    UcPretraziObracunZarade.LblError.Text =
                        "Obračun se ne može obrisati dok nije storniran. Prvo ga stornirajte preko opcije Izmeni.";
                    return;
                }

                DialogResult potvrda = MessageBox.Show(
                    "Da li ste sigurni da želite da obrišete ovaj storniran obračun zarade? Brisanje je trajno.",
                    "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (potvrda != DialogResult.Yes) return;

                Response res = Communication.Instance.ObrisiObracunZarade(svezi);
                if (!res.isSuccessful)
                {
                    UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                    UcPretraziObracunZarade.LblError.Text = "Sistem ne može da obriše obračun\n\n\n" + res.Error;
                    return;
                }

                UcPretraziObracunZarade.LblError.ForeColor = Color.Green;
                UcPretraziObracunZarade.LblError.Text = "Obračun zarade je uspešno obrisan.";
                PretraziObracune();
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška: " + ex.Message;
            }
        }

        private ObracunZarade GetSelektovaniObracun()
        {
            var grid = UcPretraziObracunZarade.DgvEU;
            if (grid.SelectedRows.Count == 0) return null;
            return grid.SelectedRows[0].DataBoundItem as ObracunZarade;
        }

        private void UcitajComboBoxeve()
        {
            try
            {
                UcPretraziObracunZarade.CbRacunovodja.SelectedIndexChanged -= Filter_SelectedIndexChanged;
                UcPretraziObracunZarade.CbZaposleni.SelectedIndexChanged -= Filter_SelectedIndexChanged;
                UcPretraziObracunZarade.CbVrstaZarade.SelectedIndexChanged -= Filter_SelectedIndexChanged;

                Response resRac = Communication.Instance.VratiRacunovodje();
                List<Racunovodja> racunovodje = Communication.Instance.serializer
                    .ReadType<List<Racunovodja>>(resRac.Object);
                racunovodje.Insert(0, new Racunovodja { IdRacunovodja = 0, Ime = "Sve", Prezime = "racunovodje" });

                Response resZap = Communication.Instance.VratiZaposlene();
                List<Zaposleni> zaposleni = Communication.Instance.serializer
                    .ReadType<List<Zaposleni>>(resZap.Object);
                zaposleni.Insert(0, new Zaposleni { IdZaposleni = 0, Ime = "Svi", Prezime = "zaposleni" });

                Response resVrstaZarade = Communication.Instance.VratiVrsteZarada();
                List<VrstaZarade> vrsteZarada = Communication.Instance.serializer
                    .ReadType<List<VrstaZarade>>(resVrstaZarade.Object);
                vrsteZarada.Insert(0, new VrstaZarade { IdVrstaZarade = 0, ImeVrste = "Sve vrste zarada" });

                UcPretraziObracunZarade.CbRacunovodja.DataSource = racunovodje;
                UcPretraziObracunZarade.CbRacunovodja.DisplayMember = "ImePrezime";
                UcPretraziObracunZarade.CbRacunovodja.ValueMember = "IdRacunovodja";
                UcPretraziObracunZarade.CbRacunovodja.SelectedIndex = 0;

                UcPretraziObracunZarade.CbZaposleni.DataSource = zaposleni;
                UcPretraziObracunZarade.CbZaposleni.DisplayMember = "ImePrezime";
                UcPretraziObracunZarade.CbZaposleni.ValueMember = "IdZaposleni";
                UcPretraziObracunZarade.CbZaposleni.SelectedIndex = 0;

                UcPretraziObracunZarade.CbVrstaZarade.DataSource = vrsteZarada;
                UcPretraziObracunZarade.CbVrstaZarade.DisplayMember = "ImeVrste";
                UcPretraziObracunZarade.CbVrstaZarade.ValueMember = "IdVrstaZarade";
                UcPretraziObracunZarade.CbVrstaZarade.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška pri učitavanju podataka: " + ex.Message;
            }
            finally
            {
                UcPretraziObracunZarade.CbRacunovodja.SelectedIndexChanged += Filter_SelectedIndexChanged;
                UcPretraziObracunZarade.CbZaposleni.SelectedIndexChanged += Filter_SelectedIndexChanged;
                UcPretraziObracunZarade.CbVrstaZarade.SelectedIndexChanged += Filter_SelectedIndexChanged;
            }
        }

        private void PodesiDgv()
        {
            var grid = UcPretraziObracunZarade.DgvEU;
            grid.DataSource = null;
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ImePrezimeRacunovodje",
                HeaderText = "Računovođa",
                Name = "colRacunovodja"
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ImePrezimeZaposlenog",
                HeaderText = "Zaposleni",
                Name = "colZaposleni"
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Period",
                HeaderText = "Period (od - do)",
                Name = "colPeriod"
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UkupnaZarada",
                HeaderText = "Ukupna zarada",
                Name = "colUkupnaZarada"
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StornoTekst",
                HeaderText = "Storniran",
                Name = "colStorniran"
            });

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            grid.CellFormatting -= Grid_CellFormatting;
            grid.CellFormatting += Grid_CellFormatting;
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = UcPretraziObracunZarade.DgvEU;
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;

            if (grid.Rows[e.RowIndex].DataBoundItem is ObracunZarade oz)
            {
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    oz.Storniran ? BojaStorniranogReda : Color.White;
            }
        }

        private void PrikaziDgvPodatke(List<ObracunZarade> obracuni)
        {
            var grid = UcPretraziObracunZarade.DgvEU;
            grid.DataSource = null;
            grid.DataSource = new BindingList<ObracunZarade>(obracuni);
            grid.ClearSelection();
            grid.CurrentCell = null;
            grid.Refresh();
        }

        private void PopuniDgv()
        {
            PretraziObracune();
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PretraziObracune();
        }

        private void PretraziObracune()
        {
            UcPretraziObracunZarade.LblError.Text = "";

            Racunovodja racunovodja = UcPretraziObracunZarade.CbRacunovodja.SelectedItem as Racunovodja;
            Zaposleni zaposleni = UcPretraziObracunZarade.CbZaposleni.SelectedItem as Zaposleni;
            VrstaZarade vrstaZarade = UcPretraziObracunZarade.CbVrstaZarade.SelectedItem as VrstaZarade;

            List<string> uslovi = new List<string>();

            if (racunovodja != null && racunovodja.IdRacunovodja != 0)
                uslovi.Add($"oz.idRacunovodja = {racunovodja.IdRacunovodja}");

            if (zaposleni != null && zaposleni.IdZaposleni != 0)
                uslovi.Add($"oz.idZaposleni = {zaposleni.IdZaposleni}");

            if (vrstaZarade != null && vrstaZarade.IdVrstaZarade != 0)
                uslovi.Add($"oz.idObracunZarade IN (SELECT soz.idObracunZarade FROM StavkaObracunaZarade soz WHERE soz.idVrstaZarade = {vrstaZarade.IdVrstaZarade})");

            ObracunZarade oz = new ObracunZarade
            {
                Condition = uslovi.Count == 0 ? "1=1" : string.Join(" AND ", uslovi)
            };

            try
            {
                Response res = Communication.Instance.PretraziObracuneZarade(oz);
                if (!res.isSuccessful)
                {
                    UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                    UcPretraziObracunZarade.LblError.Text = "Sistem ne može da nađe obračune zarada po zadatim kriterijumima.";
                    PrikaziDgvPodatke(new List<ObracunZarade>());
                    return;
                }

                List<ObracunZarade> obracuni = Communication.Instance.serializer
                    .ReadType<List<ObracunZarade>>(res.Object);

                UcPretraziObracunZarade.LblError.ForeColor = Color.Green;
                UcPretraziObracunZarade.LblError.Text = $"Sistem je nasao obracune zarada po zadatim kriterijumima: {obracuni.Count}";
                PrikaziDgvPodatke(obracuni);
            }
            catch (Exception ex)
            {
                UcPretraziObracunZarade.LblError.ForeColor = Color.Red;
                UcPretraziObracunZarade.LblError.Text = "Greška: " + ex.Message;
            }
        }
    }
}