using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiControllers
{
    internal class VrstaZaradeGuiController
    {
        UCVrstaZarade ucVrstaZarade;
        private static VrstaZaradeGuiController instance;
        public static VrstaZaradeGuiController Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new VrstaZaradeGuiController();
                }
                return instance;
            } 
        }
        private VrstaZaradeGuiController() 
        { 
        
        }
        
        public UCVrstaZarade ShowVrstaZaradeUC()
        {
            ucVrstaZarade = new UCVrstaZarade();
            ucVrstaZarade.BtnKreiraj.Click += BtnKreiraj_Click;
            return ucVrstaZarade;
        }

        private void BtnKreiraj_Click(object? sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(ucVrstaZarade.TxtImeVrsteZarade.Text) || string.IsNullOrEmpty(ucVrstaZarade.TxtZaradaPoSatu.Text)
                || !decimal.TryParse(ucVrstaZarade.TxtZaradaPoSatu.Text,out decimal zaradaPoSatu))
            {
                MessageBox.Show("Sistem ne moze da zapamti vrstu zarade");
                return;
            }
            VrstaZarade vz = new VrstaZarade()
            {
                ImeVrste = ucVrstaZarade.TxtImeVrsteZarade.Text,
                ZaradaPoSatu = zaradaPoSatu,
                Opis = ucVrstaZarade.TxtOpis.Text
            };
            try
            {
                Response odgovor = Communication.Instance.VratiVrsteZarada();
                
                List<VrstaZarade> vrsteZarada = Communication.Instance.serializer.ReadType<List<VrstaZarade>>(odgovor.Object);
                if(vrsteZarada.Any(v=> v.ImeVrste == vz.ImeVrste))
                {
                    MessageBox.Show("Sistem ne moze da zapamti vrstu zarade");
                    return;
                }
                Response odgovor2 = Communication.Instance.UbaciVrstuZarade(vz);

                if (!odgovor2.isSuccessful)
                {
                    MessageBox.Show("Sistem ne moze da zapamti vrstu zarade");
                    return;
                }

                string poruka =
                        "Sistem je zapamtio vrstu zarade\n\n" +
                        $"Naziv vrste zarade: {vz.ImeVrste}\n" +
                        $"Zarada po satu: {vz.ZaradaPoSatu}\n" +
                        $"Opis: {vz.Opis}\n";
                        

                MessageBox.Show(poruka);
               
                ucVrstaZarade.TxtImeVrsteZarade.Clear();
                ucVrstaZarade.TxtZaradaPoSatu.Clear();
                ucVrstaZarade.TxtOpis.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
                return;
            }
        }
    }
}
