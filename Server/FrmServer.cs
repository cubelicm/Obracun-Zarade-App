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
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start();

                lbl_status.Text = "Server je pokrenut!";
                btn_Start.Enabled = false;
                btn_Stop.Enabled = true;
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
                server.Stop();
                lbl_status.Text = "Server nije pokrenut!";
                btn_Start.Enabled = true;
                btn_Stop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
