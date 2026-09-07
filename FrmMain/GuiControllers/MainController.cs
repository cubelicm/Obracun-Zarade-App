using Client.Forms;
using Common.Communication;
using Common.Domain;
using System;
using System.Windows.Forms;

namespace Client.GuiControllers
{
    internal class MainController
    {
        private System.Windows.Forms.Timer _pingTimer;
        private bool isDisconnected = false;
        private Racunovodja user;
        internal MainFrm MainForm { get; set; }

        public MainController(Racunovodja user)
        {
            this.user = user;
        }

        public MainFrm CreateMainForm(Racunovodja user)
        {
            MainForm = new MainFrm();
            MainForm.LblKorisnik.Text = "Prijavljeni računovodja: " + user.ImePrezime;

            MainForm.FormClosed += (s, e) =>
            {
                _pingTimer?.Stop();
                _pingTimer?.Dispose();
                Communication.Instance.Disconnected -= OnDisconnectedMain;
            };

            Communication.Instance.Disconnected -= OnDisconnectedMain;
            Communication.Instance.Disconnected += OnDisconnectedMain;

            _pingTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _pingTimer.Tick += (s, e) =>
            {
                if (Communication.Instance.serializer != null && !Communication.Instance.TryPing())
                {
                    CloseApp("Server je prestao sa radom.");
                }
            };
            _pingTimer.Start();

            MainForm.UbaciVrstuZaradeToolStripMenuItem.Click += MainCoordinator.Instance.ShowUbaciVrstuZaradePanel;
            MainForm.UbaciZaposlenogToolStripMenuItem.Click += MainCoordinator.Instance.ShowUbaciZaposlenogPanel;
            MainForm.UbaciObračunZaradeToolStripMenuItem.Click += MainCoordinator.Instance.ShowUbaciObracunZaradePanel;
            MainForm.KreirajAgencijuToolStripMenuItem.Click += MainCoordinator.Instance.ShowKreirajAgencijuPanel;
            MainForm.PretražiObračuneZaradaToolStripMenuItem.Click += MainCoordinator.Instance.ShowPretraziObracuneZaradaPanel;
            MainForm.PretražiZaposleneToolStripMenuItem.Click += MainCoordinator.Instance.ShowPretraziZaposlenePanel;

            MainForm.UbaciPozicijuToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;
            MainForm.UbaciRačunovodjuToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;
            MainForm.PretražiPozicijeToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;
            MainForm.PretražiRačunovodjeToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;
            MainForm.PretražiAgencijeToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;
            MainForm.PretražiVrsteZaradaToolStripMenuItem.Click += MainCoordinator.Instance.ShowPlaceholderPanel;

            return MainForm;
        }

        private void OnDisconnectedMain()
        {
            if (MainForm?.IsHandleCreated == true)
            {
                MainForm.BeginInvoke(new Action(() =>
                {
                    CloseApp("Veza sa serverom je prekinuta.");
                }));
            }
        }

        private void CloseApp(string poruka)
        {
            if (isDisconnected) return;

            isDisconnected = true;
            _pingTimer?.Stop();

            MessageBox.Show(MainForm,
                poruka + " Aplikacija će se zatvoriti.",
                "Prekid veze",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            try
            {
                Communication.Instance.Abort();
            }
            catch { }

            Application.Exit();
            Environment.Exit(0);
        }
    }
}