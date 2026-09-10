namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;

        public FrmServer()
        {
            InitializeComponent();
            lbl_status.Text = "Server nije pokrenut!";
            btn_Stop.Enabled = false;

            lblPovezani.Text = "Povezanih klijenata: 0";
            lblUlogovani.Text = "Povezanih klijenata: 0";

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
                server = new Server();

                server.PromenaNaServeru += AzurirajPrikaz;

                server.Start();

                lbl_status.Text = "Server je pokrenut!";
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

            var ulogovaniKorisnici= server.Clients
                .Where(k=> k.UlogovaniRacunovodja != null)
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

    }
}
