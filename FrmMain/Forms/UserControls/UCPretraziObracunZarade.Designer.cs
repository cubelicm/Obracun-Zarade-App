using System.Xml.Linq;

namespace Client.Forms.UserControls
{
    
        partial class UCPretraziObracunZarade
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
            lblNaslov = new Label();
            lblRacunovodja = new Label();
            lblZaposleni = new Label();
            cbRacunovodja = new ComboBox();
            cbZaposleni = new ComboBox();
            dgvEU = new DataGridView();
            btnPretrazi = new Button();
            btnIzmeni = new Button();
            btnDetalji = new Button();
            btnIzbrisi = new Button();
            lblError = new Label();
            cbVrstaZarade = new ComboBox();
            lblVrstaZarade = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEU).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(279, 0);
            lblNaslov.Margin = new Padding(2, 0, 2, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(321, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Pretraga obracuna zarada";
            // 
            // lblRacunovodja
            // 
            lblRacunovodja.AutoSize = true;
            lblRacunovodja.Location = new Point(176, 64);
            lblRacunovodja.Margin = new Padding(2, 0, 2, 0);
            lblRacunovodja.Name = "lblRacunovodja";
            lblRacunovodja.Size = new Size(76, 15);
            lblRacunovodja.TabIndex = 1;
            lblRacunovodja.Text = "Racunovodja";
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new Point(441, 64);
            lblZaposleni.Margin = new Padding(2, 0, 2, 0);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new Size(58, 15);
            lblZaposleni.TabIndex = 2;
            lblZaposleni.Text = "Zaposleni";
            // 
            // cbRacunovodja
            // 
            cbRacunovodja.FormattingEnabled = true;
            cbRacunovodja.Location = new Point(112, 82);
            cbRacunovodja.Margin = new Padding(2);
            cbRacunovodja.Name = "cbRacunovodja";
            cbRacunovodja.Size = new Size(227, 23);
            cbRacunovodja.TabIndex = 3;
            // 
            // cbZaposleni
            // 
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(357, 82);
            cbZaposleni.Margin = new Padding(2);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(227, 23);
            cbZaposleni.TabIndex = 4;
            // 
            // dgvEU
            // 
            dgvEU.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEU.Location = new Point(14, 167);
            dgvEU.Margin = new Padding(2);
            dgvEU.Name = "dgvEU";
            dgvEU.RowHeadersWidth = 62;
            dgvEU.Size = new Size(870, 308);
            dgvEU.TabIndex = 5;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(750, 120);
            btnPretrazi.Margin = new Padding(2);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(78, 30);
            btnPretrazi.TabIndex = 6;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(112, 122);
            btnIzmeni.Margin = new Padding(2);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(78, 29);
            btnIzmeni.TabIndex = 7;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(208, 121);
            btnDetalji.Margin = new Padding(2);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(78, 29);
            btnDetalji.TabIndex = 8;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            // 
            // btnIzbrisi
            // 
            btnIzbrisi.Location = new Point(302, 121);
            btnIzbrisi.Margin = new Padding(2);
            btnIzbrisi.Name = "btnIzbrisi";
            btnIzbrisi.Size = new Size(78, 30);
            btnIzbrisi.TabIndex = 9;
            btnIzbrisi.Text = "Izbrisi";
            btnIzbrisi.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 12F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(30, 41);
            lblError.Margin = new Padding(2, 0, 2, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 21);
            lblError.TabIndex = 10;
            // 
            // cbVrstaZarade
            // 
            cbVrstaZarade.FormattingEnabled = true;
            cbVrstaZarade.Location = new Point(604, 82);
            cbVrstaZarade.Name = "cbVrstaZarade";
            cbVrstaZarade.Size = new Size(224, 23);
            cbVrstaZarade.TabIndex = 11;
            // 
            // lblVrstaZarade
            // 
            lblVrstaZarade.AutoSize = true;
            lblVrstaZarade.Location = new Point(684, 64);
            lblVrstaZarade.Name = "lblVrstaZarade";
            lblVrstaZarade.Size = new Size(69, 15);
            lblVrstaZarade.TabIndex = 12;
            lblVrstaZarade.Text = "VrstaZarade";
            // 
            // UCPretraziObracunZarade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblVrstaZarade);
            Controls.Add(cbVrstaZarade);
            Controls.Add(lblError);
            Controls.Add(btnIzbrisi);
            Controls.Add(btnDetalji);
            Controls.Add(btnIzmeni);
            Controls.Add(btnPretrazi);
            Controls.Add(dgvEU);
            Controls.Add(cbZaposleni);
            Controls.Add(cbRacunovodja);
            Controls.Add(lblZaposleni);
            Controls.Add(lblRacunovodja);
            Controls.Add(lblNaslov);
            Margin = new Padding(2);
            Name = "UCPretraziObracunZarade";
            Size = new Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)dgvEU).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
            private Label lblRacunovodja;
            private Label lblZaposleni;
            private ComboBox cbRacunovodja;
            private ComboBox cbZaposleni;
            private DataGridView dgvEU;
            private Button btnPretrazi;
            private Button btnIzmeni;
        private Button btnDetalji;
        private Button btnIzbrisi;
        private Label lblError;
        private ComboBox cbVrstaZarade;
        private Label lblVrstaZarade;

        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Label LblRacunovodja { get => lblRacunovodja; set => lblRacunovodja = value; }
        public Label LblZaposleni { get => lblZaposleni; set => lblZaposleni = value; }
        public ComboBox CbRacunovodja { get => cbRacunovodja; set => cbRacunovodja = value; }
        public ComboBox CbZaposleni { get => cbZaposleni; set => cbZaposleni = value; }
        public DataGridView DgvEU { get => dgvEU; set => dgvEU = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
        public Button BtnIzbrisi { get => btnIzbrisi; set => btnIzbrisi = value; }
        public Label LblError { get => lblError; set => lblError = value; }
        public ComboBox CbVrstaZarade { get => cbVrstaZarade; set => cbVrstaZarade = value; }
        public Label LblVrstaZarade { get => lblVrstaZarade; set => lblVrstaZarade = value; }
    }
    }

