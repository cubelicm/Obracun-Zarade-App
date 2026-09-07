using Client.Forms;
using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiControllers
{
    internal class MainCoordinator
    {
        
        private static MainCoordinator instance;
        private LoginController loginController;
        private MainController mainController;
       

        public Racunovodja UlogovanRacunovodja { get; set; }
        public LoginFrm LoginForm { get; set; }
        public MainFrm MainForm { get; set; }
       
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null) instance = new MainCoordinator();
                return instance;
            }
        }


        private MainCoordinator()
        {
            loginController = new LoginController();
            mainController = new MainController(null);

        }


        internal void CreateMainForm(Racunovodja user)
        {
            try
            {
                
                UlogovanRacunovodja = user;
                MainForm = mainController.CreateMainForm(user);
                MainForm.ShowDialog();
                
            }
            //obrati paznju na exception

            catch (IOException io)
            {
                MessageBox.Show("Greska pri komunikaciji sa serverom");
                
                
            }
            catch (SocketException se)
            {
                MessageBox.Show("Greska pri komunikaciji sa serverom");
                
            }
            
            catch (Exception)
            {
                MessageBox.Show("Ne može da se otvori glavna forma i meni.");
                return;
            }

        }

        internal void OpenLoginForm()
        {
            try
            {
                Communication.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da se poveze na server");
                return;
            }

            LoginForm = loginController.CreateLoginForm();
            LoginForm.ShowDialog();
        }

        internal void ShowUbaciZaposlenogPanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(ZaposleniGuiController.Instance.ShowDetaljiZaposlenogUC(ZaposleniGuiController.Mod.Ubaci));
        }
        internal void ShowPretraziZaposlenePanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(PretraziZaposleneGuiController.Instance.ShowPretraziZaposleneUC());
        }
        internal void ShowPromeniZaposlenogPanelPoziv(Zaposleni z)
        {
            MainForm.ChangePanel(ZaposleniGuiController.Instance.ShowDetaljiZaposlenogUC(ZaposleniGuiController.Mod.Promeni, z));
        }
        internal void ShowUbaciVrstuZaradePanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(VrstaZaradeGuiController.Instance.ShowVrstaZaradeUC());
        }
        internal void ShowUbaciObracunZaradePanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(ObracunZaradeGuiController.Instance.ShowObracunZaradeUC(ObracunZaradeGuiController.ModObracunZarade.Ubaci));
        }
        internal void ShowPretraziObracuneZaradaPanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(PretraziObracuneZaradaGuiController.Instance.ShowPretraziObracunZaradeUC());
        }
        internal void ShowKreirajAgencijuPanel(object? sender, EventArgs e)
        {
            MainForm.ChangePanel(AgencijaGuiController.Instance.ShowAgencijaUC());
        }

        internal void ShowPlaceholderPanel(object? sender, EventArgs e)
        {
            
            MainForm.ChangePanel(new UCPlaceholder());
        }
    }
}

