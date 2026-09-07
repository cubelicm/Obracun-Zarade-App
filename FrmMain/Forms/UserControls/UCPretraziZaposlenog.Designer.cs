namespace Client.Forms.UserControls
{
    partial class UCPretraziZaposlenog
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
            lblIme = new Label();
            lblPrezime = new Label();
            lblPozicija = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            cbPozicija = new ComboBox();
            btnPretrazi = new Button();
            btnIzmeniZaposlenog = new Button();
            btnObrisiZaposlenog = new Button();
            dataGridViewZaposleni = new DataGridView();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewZaposleni).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(307, 20);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(250, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Pretraži zaposlenog";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(137, 71);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(27, 15);
            lblIme.TabIndex = 1;
            lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(329, 71);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(49, 15);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime";
            // 
            // lblPozicija
            // 
            lblPozicija.AutoSize = true;
            lblPozicija.Location = new Point(579, 71);
            lblPozicija.Name = "lblPozicija";
            lblPozicija.Size = new Size(47, 15);
            lblPozicija.TabIndex = 3;
            lblPozicija.Text = "Pozicija";
            lblPozicija.Click += lblPozicija_Click;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(79, 89);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(153, 23);
            txtIme.TabIndex = 4;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(279, 89);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(153, 23);
            txtPrezime.TabIndex = 5;
            // 
            // cbPozicija
            // 
            cbPozicija.AllowDrop = true;
            cbPozicija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPozicija.FormattingEnabled = true;
            cbPozicija.Location = new Point(519, 90);
            cbPozicija.Name = "cbPozicija";
            cbPozicija.Size = new Size(169, 23);
            cbPozicija.TabIndex = 6;
            cbPozicija.SelectedIndexChanged += cbPozicija_SelectedIndexChanged;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(703, 89);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(146, 23);
            btnPretrazi.TabIndex = 7;
            btnPretrazi.Text = "Pretraži zaposlenog";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniZaposlenog
            // 
            btnIzmeniZaposlenog.Location = new Point(189, 444);
            btnIzmeniZaposlenog.Name = "btnIzmeniZaposlenog";
            btnIzmeniZaposlenog.Size = new Size(167, 23);
            btnIzmeniZaposlenog.TabIndex = 8;
            btnIzmeniZaposlenog.Text = "Promeni Zaposlenog";
            btnIzmeniZaposlenog.UseVisualStyleBackColor = true;
            // 
            // btnObrisiZaposlenog
            // 
            btnObrisiZaposlenog.Location = new Point(539, 444);
            btnObrisiZaposlenog.Name = "btnObrisiZaposlenog";
            btnObrisiZaposlenog.Size = new Size(172, 23);
            btnObrisiZaposlenog.TabIndex = 9;
            btnObrisiZaposlenog.Text = "Obriši Zaposlenog";
            btnObrisiZaposlenog.UseVisualStyleBackColor = true;
            // 
            // dataGridViewZaposleni
            // 
            dataGridViewZaposleni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewZaposleni.Location = new Point(79, 147);
            dataGridViewZaposleni.Name = "dataGridViewZaposleni";
            dataGridViewZaposleni.Size = new Size(770, 291);
            dataGridViewZaposleni.TabIndex = 10;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(79, 115);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 28);
            lblError.TabIndex = 11;
            // 
            // UCPretraziZaposlenog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblError);
            Controls.Add(dataGridViewZaposleni);
            Controls.Add(btnObrisiZaposlenog);
            Controls.Add(btnIzmeniZaposlenog);
            Controls.Add(btnPretrazi);
            Controls.Add(cbPozicija);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(lblPozicija);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Controls.Add(lblNaslov);
            Name = "UCPretraziZaposlenog";
            Size = new Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)dataGridViewZaposleni).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Label lblIme;
        private Label lblPrezime;
        private Label lblPozicija;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private ComboBox cbPozicija;
        private Button btnPretrazi;
        private Button btnIzmeniZaposlenog;
        private Button btnObrisiZaposlenog;
        private DataGridView dataGridViewZaposleni;
        private Label lblError;

        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Label LblIme { get => lblIme; set => lblIme = value; }
        public Label LblPrezime { get => lblPrezime; set => lblPrezime = value; }
        public Label LblPozicija { get => lblPozicija; set => lblPozicija = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public ComboBox CbPozicija { get => cbPozicija; set => cbPozicija = value; }
        public Button BtnPretrazi { get => btnPretrazi; set => btnPretrazi = value; }
        public Button BtnIzmeniZaposlenog { get => btnIzmeniZaposlenog; set => btnIzmeniZaposlenog = value; }
        public Button BtnObrisiZaposlenog { get => btnObrisiZaposlenog; set => btnObrisiZaposlenog = value; }
        public DataGridView DataGridViewZaposleni { get => dataGridViewZaposleni; set => dataGridViewZaposleni = value; }
        public Label LblError { get => lblError; set => lblError = value; }
    }
}
