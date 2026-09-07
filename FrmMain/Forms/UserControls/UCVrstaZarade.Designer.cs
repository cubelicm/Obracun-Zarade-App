namespace Client.Forms.UserControls
{
    partial class UCVrstaZarade
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblImeVrste = new Label();
            lblZaradaPoSatu = new Label();
            lblOpis = new Label();
            txtImeVrsteZarade = new TextBox();
            txtZaradaPoSatu = new TextBox();
            txtOpis = new TextBox();
            lblNaslov = new Label();
            btnKreiraj = new Button();
            SuspendLayout();
            // 
            // lblImeVrste
            // 
            lblImeVrste.AutoSize = true;
            lblImeVrste.Location = new Point(134, 103);
            lblImeVrste.Name = "lblImeVrste";
            lblImeVrste.Size = new Size(92, 15);
            lblImeVrste.TabIndex = 0;
            lblImeVrste.Text = "Ime vrste zarade";
            // 
            // lblZaradaPoSatu
            // 
            lblZaradaPoSatu.AutoSize = true;
            lblZaradaPoSatu.Location = new Point(141, 157);
            lblZaradaPoSatu.Name = "lblZaradaPoSatu";
            lblZaradaPoSatu.Size = new Size(85, 15);
            lblZaradaPoSatu.TabIndex = 1;
            lblZaradaPoSatu.Text = "Zarada po satu";
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(193, 206);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(31, 15);
            lblOpis.TabIndex = 2;
            lblOpis.Text = "Opis";
            // 
            // txtImeVrsteZarade
            // 
            txtImeVrsteZarade.Location = new Point(232, 100);
            txtImeVrsteZarade.Name = "txtImeVrsteZarade";
            txtImeVrsteZarade.Size = new Size(153, 23);
            txtImeVrsteZarade.TabIndex = 3;
            // 
            // txtZaradaPoSatu
            // 
            txtZaradaPoSatu.Location = new Point(230, 154);
            txtZaradaPoSatu.Name = "txtZaradaPoSatu";
            txtZaradaPoSatu.Size = new Size(155, 23);
            txtZaradaPoSatu.TabIndex = 4;
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(230, 203);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(155, 23);
            txtOpis.TabIndex = 5;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(134, 35);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(301, 37);
            lblNaslov.TabIndex = 6;
            lblNaslov.Text = "Ubaci novu vrstu zarade";
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(141, 259);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(244, 23);
            btnKreiraj.TabIndex = 7;
            btnKreiraj.Text = "Ubaci vrstu zarade";
            btnKreiraj.UseVisualStyleBackColor = true;
            // 
            // UCVrstaZarade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKreiraj);
            Controls.Add(lblNaslov);
            Controls.Add(txtOpis);
            Controls.Add(txtZaradaPoSatu);
            Controls.Add(txtImeVrsteZarade);
            Controls.Add(lblOpis);
            Controls.Add(lblZaradaPoSatu);
            Controls.Add(lblImeVrste);
            Name = "UCVrstaZarade";
            Size = new Size(900, 500);
            Load += UCVrstaZarade_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImeVrste;
        private Label lblZaradaPoSatu;
        private Label lblOpis;
        private TextBox txtImeVrsteZarade;
        private TextBox txtZaradaPoSatu;
        private TextBox txtOpis;
        private Label lblNaslov;
        private Button btnKreiraj;

        public Label LblImeVrste { get => lblImeVrste; set => lblImeVrste = value; }
        public Label LblZaradaPoSatu { get => lblZaradaPoSatu; set => lblZaradaPoSatu = value; }
        public Label LblOpis { get => lblOpis; set => lblOpis = value; }
        public TextBox TxtImeVrsteZarade { get => txtImeVrsteZarade; set => txtImeVrsteZarade = value; }
        public TextBox TxtZaradaPoSatu { get => txtZaradaPoSatu; set => txtZaradaPoSatu = value; }
        public TextBox TxtOpis { get => txtOpis; set => txtOpis = value; }
        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Button BtnKreiraj { get => btnKreiraj; set => btnKreiraj = value; }
    }
}
