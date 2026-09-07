namespace Client.Forms
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblKorisnik = new Label();
            menuStrip1 = new MenuStrip();
            obračuniZaradaToolStripMenuItem = new ToolStripMenuItem();
            ubaciObračunZaradeToolStripMenuItem = new ToolStripMenuItem();
            pretražiObračuneZaradaToolStripMenuItem = new ToolStripMenuItem();
            zaposleniToolStripMenuItem = new ToolStripMenuItem();
            ubaciZaposlenogToolStripMenuItem = new ToolStripMenuItem();
            pretražiZaposleneToolStripMenuItem = new ToolStripMenuItem();
            računovodjeToolStripMenuItem = new ToolStripMenuItem();
            ubaciRačunovodjuToolStripMenuItem = new ToolStripMenuItem();
            pretražiRačunovodjeToolStripMenuItem = new ToolStripMenuItem();
            vrsteZaradaToolStripMenuItem = new ToolStripMenuItem();
            ubaciVrstuZaradeToolStripMenuItem = new ToolStripMenuItem();
            pretražiVrsteZaradaToolStripMenuItem = new ToolStripMenuItem();
            pozicijaToolStripMenuItem = new ToolStripMenuItem();
            ubaciPozicijuToolStripMenuItem = new ToolStripMenuItem();
            pretražiPozicijeToolStripMenuItem = new ToolStripMenuItem();
            agencijeToolStripMenuItem = new ToolStripMenuItem();
            kreirajAgencijuToolStripMenuItem = new ToolStripMenuItem();
            pretražiAgencijeToolStripMenuItem = new ToolStripMenuItem();
            pnlMain = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblKorisnik
            // 
            lblKorisnik.AutoSize = true;
            lblKorisnik.Font = new Font("Segoe UI", 20F);
            lblKorisnik.Location = new Point(0, 24);
            lblKorisnik.Name = "lblKorisnik";
            lblKorisnik.Size = new Size(243, 37);
            lblKorisnik.TabIndex = 0;
            lblKorisnik.Text = "Prijavljeni korisnik: ";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { obračuniZaradaToolStripMenuItem, zaposleniToolStripMenuItem, računovodjeToolStripMenuItem, vrsteZaradaToolStripMenuItem, pozicijaToolStripMenuItem, agencijeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // obračuniZaradaToolStripMenuItem
            // 
            obračuniZaradaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciObračunZaradeToolStripMenuItem, pretražiObračuneZaradaToolStripMenuItem });
            obračuniZaradaToolStripMenuItem.Name = "obračuniZaradaToolStripMenuItem";
            obračuniZaradaToolStripMenuItem.Size = new Size(105, 20);
            obračuniZaradaToolStripMenuItem.Text = "Obračuni zarada";
            // 
            // ubaciObračunZaradeToolStripMenuItem
            // 
            ubaciObračunZaradeToolStripMenuItem.Name = "ubaciObračunZaradeToolStripMenuItem";
            ubaciObračunZaradeToolStripMenuItem.Size = new Size(203, 22);
            ubaciObračunZaradeToolStripMenuItem.Text = "Ubaci obračun zarade";
            // 
            // pretražiObračuneZaradaToolStripMenuItem
            // 
            pretražiObračuneZaradaToolStripMenuItem.Name = "pretražiObračuneZaradaToolStripMenuItem";
            pretražiObračuneZaradaToolStripMenuItem.Size = new Size(203, 22);
            pretražiObračuneZaradaToolStripMenuItem.Text = "Pretraži obračune zarada";
            // 
            // zaposleniToolStripMenuItem
            // 
            zaposleniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciZaposlenogToolStripMenuItem, pretražiZaposleneToolStripMenuItem });
            zaposleniToolStripMenuItem.Name = "zaposleniToolStripMenuItem";
            zaposleniToolStripMenuItem.Size = new Size(70, 20);
            zaposleniToolStripMenuItem.Text = "Zaposleni";
            // 
            // ubaciZaposlenogToolStripMenuItem
            // 
            ubaciZaposlenogToolStripMenuItem.Name = "ubaciZaposlenogToolStripMenuItem";
            ubaciZaposlenogToolStripMenuItem.Size = new Size(168, 22);
            ubaciZaposlenogToolStripMenuItem.Text = "Ubaci zaposlenog";
            // 
            // pretražiZaposleneToolStripMenuItem
            // 
            pretražiZaposleneToolStripMenuItem.Name = "pretražiZaposleneToolStripMenuItem";
            pretražiZaposleneToolStripMenuItem.Size = new Size(168, 22);
            pretražiZaposleneToolStripMenuItem.Text = "Pretraži zaposlene";
            // 
            // računovodjeToolStripMenuItem
            // 
            računovodjeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciRačunovodjuToolStripMenuItem, pretražiRačunovodjeToolStripMenuItem });
            računovodjeToolStripMenuItem.Name = "računovodjeToolStripMenuItem";
            računovodjeToolStripMenuItem.Size = new Size(88, 20);
            računovodjeToolStripMenuItem.Text = "Računovodje";
            // 
            // ubaciRačunovodjuToolStripMenuItem
            // 
            ubaciRačunovodjuToolStripMenuItem.Name = "ubaciRačunovodjuToolStripMenuItem";
            ubaciRačunovodjuToolStripMenuItem.Size = new Size(185, 22);
            ubaciRačunovodjuToolStripMenuItem.Text = "Ubaci Računovodju";
            // 
            // pretražiRačunovodjeToolStripMenuItem
            // 
            pretražiRačunovodjeToolStripMenuItem.Name = "pretražiRačunovodjeToolStripMenuItem";
            pretražiRačunovodjeToolStripMenuItem.Size = new Size(185, 22);
            pretražiRačunovodjeToolStripMenuItem.Text = "Pretraži Računovodje";
            // 
            // vrsteZaradaToolStripMenuItem
            // 
            vrsteZaradaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciVrstuZaradeToolStripMenuItem, pretražiVrsteZaradaToolStripMenuItem });
            vrsteZaradaToolStripMenuItem.Name = "vrsteZaradaToolStripMenuItem";
            vrsteZaradaToolStripMenuItem.Size = new Size(84, 20);
            vrsteZaradaToolStripMenuItem.Text = "Vrste Zarada";
            // 
            // ubaciVrstuZaradeToolStripMenuItem
            // 
            ubaciVrstuZaradeToolStripMenuItem.Name = "ubaciVrstuZaradeToolStripMenuItem";
            ubaciVrstuZaradeToolStripMenuItem.Size = new Size(181, 22);
            ubaciVrstuZaradeToolStripMenuItem.Text = "Ubaci Vrstu Zarade";
            // 
            // pretražiVrsteZaradaToolStripMenuItem
            // 
            pretražiVrsteZaradaToolStripMenuItem.Name = "pretražiVrsteZaradaToolStripMenuItem";
            pretražiVrsteZaradaToolStripMenuItem.Size = new Size(181, 22);
            pretražiVrsteZaradaToolStripMenuItem.Text = "Pretraži Vrste Zarada";
            // 
            // pozicijaToolStripMenuItem
            // 
            pozicijaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciPozicijuToolStripMenuItem, pretražiPozicijeToolStripMenuItem });
            pozicijaToolStripMenuItem.Name = "pozicijaToolStripMenuItem";
            pozicijaToolStripMenuItem.Size = new Size(59, 20);
            pozicijaToolStripMenuItem.Text = "Pozicije";
            // 
            // ubaciPozicijuToolStripMenuItem
            // 
            ubaciPozicijuToolStripMenuItem.Name = "ubaciPozicijuToolStripMenuItem";
            ubaciPozicijuToolStripMenuItem.Size = new Size(156, 22);
            ubaciPozicijuToolStripMenuItem.Text = "Ubaci Poziciju";
            // 
            // pretražiPozicijeToolStripMenuItem
            // 
            pretražiPozicijeToolStripMenuItem.Name = "pretražiPozicijeToolStripMenuItem";
            pretražiPozicijeToolStripMenuItem.Size = new Size(156, 22);
            pretražiPozicijeToolStripMenuItem.Text = "Pretraži Pozicije";
            // 
            // agencijeToolStripMenuItem
            // 
            agencijeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajAgencijuToolStripMenuItem, pretražiAgencijeToolStripMenuItem });
            agencijeToolStripMenuItem.Name = "agencijeToolStripMenuItem";
            agencijeToolStripMenuItem.Size = new Size(65, 20);
            agencijeToolStripMenuItem.Text = "Agencije";
            // 
            // kreirajAgencijuToolStripMenuItem
            // 
            kreirajAgencijuToolStripMenuItem.Name = "kreirajAgencijuToolStripMenuItem";
            kreirajAgencijuToolStripMenuItem.Size = new Size(162, 22);
            kreirajAgencijuToolStripMenuItem.Text = "Kreiraj Agenciju";
            // 
            // pretražiAgencijeToolStripMenuItem
            // 
            pretražiAgencijeToolStripMenuItem.Name = "pretražiAgencijeToolStripMenuItem";
            pretražiAgencijeToolStripMenuItem.Size = new Size(162, 22);
            pretražiAgencijeToolStripMenuItem.Text = "Pretraži Agencije";
            // 
            // pnlMain
            // 
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMain.BackColor = SystemColors.AppWorkspace;
            pnlMain.Location = new Point(0, 64);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(900, 510);
            pnlMain.TabIndex = 2;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 574);
            Controls.Add(pnlMain);
            Controls.Add(lblKorisnik);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainFrm";
            ShowIcon = false;
            Text = "Evidencija Zarade";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKorisnik;
        private MenuStrip menuStrip1;
        private Panel pnlMain;
        private ToolStripMenuItem obračuniZaradaToolStripMenuItem;
        private ToolStripMenuItem ubaciObračunZaradeToolStripMenuItem;
        private ToolStripMenuItem pretražiObračuneZaradaToolStripMenuItem;
        private ToolStripMenuItem zaposleniToolStripMenuItem;
        private ToolStripMenuItem ubaciZaposlenogToolStripMenuItem;
        private ToolStripMenuItem pretražiZaposleneToolStripMenuItem;
        private ToolStripMenuItem računovodjeToolStripMenuItem;
        private ToolStripMenuItem ubaciRačunovodjuToolStripMenuItem;
        private ToolStripMenuItem pretražiRačunovodjeToolStripMenuItem;
        private ToolStripMenuItem vrsteZaradaToolStripMenuItem;
        private ToolStripMenuItem ubaciVrstuZaradeToolStripMenuItem;
        private ToolStripMenuItem pretražiVrsteZaradaToolStripMenuItem;
        private ToolStripMenuItem pozicijaToolStripMenuItem;
        private ToolStripMenuItem ubaciPozicijuToolStripMenuItem;
        private ToolStripMenuItem pretražiPozicijeToolStripMenuItem;
        private ToolStripMenuItem agencijeToolStripMenuItem;
        private ToolStripMenuItem kreirajAgencijuToolStripMenuItem;
        private ToolStripMenuItem pretražiAgencijeToolStripMenuItem;

        public Label Label1 { get => lblKorisnik; set => lblKorisnik = value; }
        public Label LblKorisnik { get => lblKorisnik; set => lblKorisnik = value; }
        public MenuStrip MenuStrip1 { get => menuStrip1; set => menuStrip1 = value; }
        
        public Panel PnlMain { get => pnlMain; set => pnlMain = value; }
      
        public ToolStripMenuItem ObračuniZaradaToolStripMenuItem { get => obračuniZaradaToolStripMenuItem; set => obračuniZaradaToolStripMenuItem = value; }
        public ToolStripMenuItem UbaciObračunZaradeToolStripMenuItem { get => ubaciObračunZaradeToolStripMenuItem; set => ubaciObračunZaradeToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiObračuneZaradaToolStripMenuItem { get => pretražiObračuneZaradaToolStripMenuItem; set => pretražiObračuneZaradaToolStripMenuItem = value; }
        public ToolStripMenuItem ZaposleniToolStripMenuItem { get => zaposleniToolStripMenuItem; set => zaposleniToolStripMenuItem = value; }
        public ToolStripMenuItem UbaciZaposlenogToolStripMenuItem { get => ubaciZaposlenogToolStripMenuItem; set => ubaciZaposlenogToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiZaposleneToolStripMenuItem { get => pretražiZaposleneToolStripMenuItem; set => pretražiZaposleneToolStripMenuItem = value; }
        public ToolStripMenuItem RačunovodjeToolStripMenuItem { get => računovodjeToolStripMenuItem; set => računovodjeToolStripMenuItem = value; }
        public ToolStripMenuItem UbaciRačunovodjuToolStripMenuItem { get => ubaciRačunovodjuToolStripMenuItem; set => ubaciRačunovodjuToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiRačunovodjeToolStripMenuItem { get => pretražiRačunovodjeToolStripMenuItem; set => pretražiRačunovodjeToolStripMenuItem = value; }
        public ToolStripMenuItem VrsteZaradaToolStripMenuItem { get => vrsteZaradaToolStripMenuItem; set => vrsteZaradaToolStripMenuItem = value; }
        public ToolStripMenuItem UbaciVrstuZaradeToolStripMenuItem { get => ubaciVrstuZaradeToolStripMenuItem; set => ubaciVrstuZaradeToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiVrsteZaradaToolStripMenuItem { get => pretražiVrsteZaradaToolStripMenuItem; set => pretražiVrsteZaradaToolStripMenuItem = value; }
        public ToolStripMenuItem PozicijaToolStripMenuItem { get => pozicijaToolStripMenuItem; set => pozicijaToolStripMenuItem = value; }
        public ToolStripMenuItem UbaciPozicijuToolStripMenuItem { get => ubaciPozicijuToolStripMenuItem; set => ubaciPozicijuToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiPozicijeToolStripMenuItem { get => pretražiPozicijeToolStripMenuItem; set => pretražiPozicijeToolStripMenuItem = value; }
        public ToolStripMenuItem AgencijeToolStripMenuItem { get => agencijeToolStripMenuItem; set => agencijeToolStripMenuItem = value; }
        public ToolStripMenuItem KreirajAgencijuToolStripMenuItem { get => kreirajAgencijuToolStripMenuItem; set => kreirajAgencijuToolStripMenuItem = value; }
        public ToolStripMenuItem PretražiAgencijeToolStripMenuItem { get => pretražiAgencijeToolStripMenuItem; set => pretražiAgencijeToolStripMenuItem = value; }
    }
}
