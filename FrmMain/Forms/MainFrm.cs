using Client.GuiControllers;

namespace Client.Forms
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            
        }


        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();

            control.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(control);


        }

      
    }
}
