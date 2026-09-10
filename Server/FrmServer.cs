using System.Configuration;
using System.Web;
using DBBroker;
using Microsoft.Data.SqlClient;
namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            UcitajPodesavanja();

            lbl_status.Text = "Server nije pokrenut!";
            btn_Stop.Enabled = false;

            btn_Start.Click += btn_Start_Click;
            btn_Stop.Click += btn_Stop_Click;

            lblPovezani.Text = "Povezanih klijenata: 0";
            lblUlogovani.Text = "Ulogovanih korisnika: 0";

            dgvUlogovani.AutoGenerateColumns = false;
            dgvUlogovani.Columns.Clear();
            dgvUlogovani.Columns.Add("KorisnickoIme", "Username");
            dgvUlogovani.Columns.Add("ImePrezime", "Ime i prezime");
            dgvUlogovani.Columns.Add("VremePovezivanja", "Vreme povezivanja");
            dgvUlogovani.Columns.Add("VremeLogovanja", "Vreme logovanja");
            dgvUlogovani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                Broker testBroker = new Broker();
                testBroker.OpenConnection();
                testBroker.CloseConnection();
                testBroker = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Neuspešna konekcija sa bazom! Proverite podešavanja.\n\n" + ex.Message,
                        "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                server = new Server();

                server.PromenaNaServeru += AzurirajPrikaz;

                server.Start();

                lbl_status.Text = "Server je pokrenut!";
                lbl_status.ForeColor = Color.Green;
                btn_Start.Enabled = false;
                btn_Stop.Enabled = true;
                AzurirajPrikaz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                server.PromenaNaServeru -= AzurirajPrikaz;
                server.Stop();
                lbl_status.Text = "Server nije pokrenut!";
                lbl_status.ForeColor = Color.Black;
                btn_Start.Enabled = true;
                btn_Stop.Enabled = false;

                lblPovezani.Text = "Povezanih klijenata: 0";
                lblUlogovani.Text = "Ulogovanih korisnika: 0";
                dgvUlogovani.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AzurirajPrikaz()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AzurirajPrikaz));
                return;
            }

            if (server == null)
            {
                return;
            }

            int ukupanBrojPovezanih = server.Clients.Count;

            var ulogovaniKorisnici = server.Clients
                .Where(k => k.UlogovaniRacunovodja != null)
                .ToList();

            lblPovezani.Text = $"Povezanih klijenata: {ukupanBrojPovezanih}";
            lblUlogovani.Text = $"Ulogovanih korisnika: {ulogovaniKorisnici.Count}";

            dgvUlogovani.Rows.Clear();

            foreach (var klijent in ulogovaniKorisnici)
            {
                dgvUlogovani.Rows.Add(
                    klijent.UlogovaniRacunovodja.KorisnickoIme,
                    klijent.UlogovaniRacunovodja.ImePrezime,
                    klijent.VremePovezivanja.ToString("HH:mm:ss"),
                    klijent.VremeLogovanja?.ToString("HH:mm:ss")
                );
            }

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {

        }

        private void UcitajPodesavanja()
        {
            var config = ConfigurationManager.ConnectionStrings["MojaBaza"];
            if (config != null && !string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(config.ConnectionString);

                txtDataSource.Text = builder.DataSource;
                txtInitialCatalog.Text = builder.InitialCatalog;
                chkIntegratedSecurity.Checked = builder.IntegratedSecurity;

                txtIPAdresa.Text = ConfigurationManager.AppSettings["IPAdresa"] ?? "127.0.0.1";
                txtPort.Text = ConfigurationManager.AppSettings["Port"] ?? "9999";
            }
        }

        private void btnSacuvajPodesavanja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDataSource.Text) || string.IsNullOrWhiteSpace(txtInitialCatalog.Text)||
                string.IsNullOrWhiteSpace(txtIPAdresa.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Sva polja za bazu i mrežu moraju biti popunjena.");
                return;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = txtDataSource.Text,
                InitialCatalog = txtInitialCatalog.Text,
                IntegratedSecurity = chkIntegratedSecurity.Checked,
                TrustServerCertificate = true // Zbog lokalnih baza
            };

            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.ConnectionStrings.ConnectionStrings["MojaBaza"] != null)
            {
                config.ConnectionStrings.ConnectionStrings["MojaBaza"].ConnectionString = builder.ConnectionString;
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings("MojaBaza", builder.ConnectionString, "Microsoft.Data.SqlClient"));
            }

            if (config.AppSettings.Settings["IPAdresa"] != null)
            {
                config.AppSettings.Settings["IPAdresa"].Value = txtIPAdresa.Text;
            }
            else
            {
                config.AppSettings.Settings.Add("IPAdresa", txtIPAdresa.Text);
            }

            if (config.AppSettings.Settings["Port"] != null)
            {
                config.AppSettings.Settings["Port"].Value = txtPort.Text;
            }
            else
            {
                config.AppSettings.Settings.Add("Port", txtPort.Text);
            }


            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Podešavanja su uspešno sačuvana!");
        }
    }
}
