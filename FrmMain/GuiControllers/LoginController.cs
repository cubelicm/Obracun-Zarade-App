using Client.Forms;
using Common.Communication;
using Common.Domain;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiControllers
{
    public class LoginController
    {
        public LoginFrm Frm { get; set; }
        //proverava da li server radi ako ne gasi formu
        private System.Windows.Forms.Timer _loginPingTimer;
        private bool isDisconnectClose = false;

        public LoginFrm CreateLoginForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Frm = new LoginFrm();
            
            
            Frm.TbSifra.PasswordChar = '*';

            Communication.Instance.Disconnected -= OnDisconnectedLogin;
            Communication.Instance.Disconnected += OnDisconnectedLogin;

            // da ne ostane vise puta prijavljen
            /*LoginFrm.FormClosed += (s, e) =>
            Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;*/
            Frm.FormClosed += (s, e) =>
            {
                //Communication.Instance.Disconnected -= OnDisconnectedLogin;
                _loginPingTimer?.Stop();
            };

            _loginPingTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _loginPingTimer.Tick += (s, e) =>
            {
                // pinguj samo ako je već bilo povezivanja
                if (Communication.Instance.serializer != null && !Communication.Instance.TryPing()) //da app proverava stalno jel server ziv
                {
                    CloseApp("Server je prestao sa radom.");
                    //_loginPingTimer.Stop();
                    //MessageBox.Show(LoginFrm, "Server je prestao sa radom. Aplikacija će se zatvoriti.",
                    //"Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Application.Exit();
                }
            };

            _loginPingTimer.Start();

            /*LoginFrm.FormClosed += (s, e) =>
            {
                _loginPingTimer?.Stop();
                _loginPingTimer?.Dispose();
                Komunikacija.Instance.Disconnected -= OnDisconnectedLogin;
            };*/

            Frm.TbKorisnickoIme.TextChanged += TextChanged;
            Frm.TbSifra.TextChanged += TextChanged;
            

                Frm.BtnLogin.Click += BtnLogin_Click;
            return Frm;
        }

        private void CloseApp(string poruka)
        {
            if (isDisconnectClose) return;

            isDisconnectClose = true;
            _loginPingTimer?.Stop();

            MessageBox.Show(Frm,
                poruka + " Aplikacija će se zatvoriti.",
                "Prekid veze",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            try
            {
                //Komunikacija.Instance.ZatvoriKonekciju();
                Communication.Instance.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Application.Exit();


            // fallback ako nešto ostane živo
            Environment.Exit(0);
        }
        private void TextChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Frm.TbKorisnickoIme.Text))
                Frm.TbKorisnickoIme.BackColor=Color.White;
            if (!string.IsNullOrEmpty(Frm.TbSifra.Text))
                Frm.TbSifra.BackColor=Color.White;
        }
        public bool Validation()
        {
            Frm.TbKorisnickoIme.BackColor = Color.White;
            Frm.TbSifra.BackColor = Color.White;
            bool isValid = true;
            if (string.IsNullOrEmpty(Frm.TbKorisnickoIme.Text))
            {
                Frm.TbKorisnickoIme.BackColor = Color.Salmon;
                isValid = false;
            }
            if (string.IsNullOrEmpty(Frm.TbSifra.Text))
            {
                Frm.TbSifra.BackColor = Color.Salmon;
                isValid = false;
            }
            return isValid;
        }
        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            if (!Validation())
            {
                Frm.LblError.Text = ("Korisnicko ime i sifra nisu uneti");
                return;
            }

            string username = Frm.TbKorisnickoIme.Text;
            string password = Frm.TbSifra.Text;

            Racunovodja racunovodja = new Racunovodja
            {
                KorisnickoIme = username,
                Sifra = password
            };


            Response res = new Response();
            res = Communication.Instance.Login(racunovodja);

            try
            {
                if (!res.isSuccessful)
                {
                    Frm.LblError.Text=("Korisnicko ime i sifra nisu ispravni");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska: " + ex.Message);
            }

            Racunovodja user = Communication.Instance.serializer.ReadType<Racunovodja>(res.Object);

            MessageBox.Show($"Korisnicko ime i sifra su ispravni\n Dobro dosli {user.ImePrezime}", "Uspesna prijava");

            _loginPingTimer?.Stop();
            _loginPingTimer?.Dispose();
           // Communication.Instance.Disconnected -= OnDisconnectedLogin;

            Frm.Dispose();
            try {
                MainCoordinator.Instance.CreateMainForm(user);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Ne može da se otvori glavna forma i meni");
            }
           

        }

        /*private void OnDisconnectedLogin()
        {
            _loginPingTimer?.Stop();

            // ako je forma još živa
            if (LoginFrm != null && !LoginFrm.IsDisposed)
            {
                LoginFrm.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("Server je prestao sa radom. Aplikacija će se zatvoriti.",
                                    "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    Environment.Exit(0);
                }));
            }*/
        /*else
        {
            // forma je već disposed – samo poruka i izlaz
            MessageBox.Show("Server je prestao sa radom. Aplikacija će se zatvoriti.",
                            "Prekid veze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Exit();
        }
    }*/
       private void OnDisconnectedLogin()
        {
            if (Frm?.IsHandleCreated == true)
            {
                Frm.BeginInvoke(new Action(() =>
                {
                    CloseApp("Veza sa serverom je prekinuta.");
                }));
            }
        }
    }
}

