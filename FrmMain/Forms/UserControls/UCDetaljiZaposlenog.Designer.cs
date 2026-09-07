namespace Client.Forms.UserControls
{
    partial class UCDetaljiZaposlenog
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
            lblIdZaposlenog = new Label();
            lblIme = new Label();
            lblPrezime = new Label();
            lblBrojTekucegRacuna = new Label();
            lblDatumRodjenja = new Label();
            lblDatumZaposlenja = new Label();
            lblEmail = new Label();
            lblBrojTelefona = new Label();
            lblIdPozicije = new Label();
            btnSubmit = new Button();
            txtIdZaposlenog = new TextBox();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtBrojTekucegRacuna = new TextBox();
            txtEmail = new TextBox();
            txtBrojTelefona = new TextBox();
            dateTimePickerDatumRodjenja = new DateTimePicker();
            dateTimePickerDatumZaposlenja = new DateTimePicker();
            cbPozicija = new ComboBox();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(279, 18);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(312, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Ubaci novog zaposlenog";
            lblNaslov.Click += lblNaslov_Click;
            // 
            // lblIdZaposlenog
            // 
            lblIdZaposlenog.AutoSize = true;
            lblIdZaposlenog.Location = new Point(61, 72);
            lblIdZaposlenog.Name = "lblIdZaposlenog";
            lblIdZaposlenog.Size = new Size(80, 15);
            lblIdZaposlenog.TabIndex = 1;
            lblIdZaposlenog.Text = "Id zaposlenog";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(114, 118);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(27, 15);
            lblIme.TabIndex = 2;
            lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(92, 161);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(49, 15);
            lblPrezime.TabIndex = 3;
            lblPrezime.Text = "Prezime";
            // 
            // lblBrojTekucegRacuna
            // 
            lblBrojTekucegRacuna.AutoSize = true;
            lblBrojTekucegRacuna.Location = new Point(29, 206);
            lblBrojTekucegRacuna.Name = "lblBrojTekucegRacuna";
            lblBrojTekucegRacuna.Size = new Size(112, 15);
            lblBrojTekucegRacuna.TabIndex = 4;
            lblBrojTekucegRacuna.Text = "Broj tekućeg računa";
            // 
            // lblDatumRodjenja
            // 
            lblDatumRodjenja.AutoSize = true;
            lblDatumRodjenja.Location = new Point(492, 118);
            lblDatumRodjenja.Name = "lblDatumRodjenja";
            lblDatumRodjenja.Size = new Size(86, 15);
            lblDatumRodjenja.TabIndex = 5;
            lblDatumRodjenja.Text = "Datum rođenja";
            // 
            // lblDatumZaposlenja
            // 
            lblDatumZaposlenja.AutoSize = true;
            lblDatumZaposlenja.Location = new Point(477, 167);
            lblDatumZaposlenja.Name = "lblDatumZaposlenja";
            lblDatumZaposlenja.Size = new Size(101, 15);
            lblDatumZaposlenja.TabIndex = 6;
            lblDatumZaposlenja.Text = "Datum zaposlenja";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(500, 214);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(78, 15);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail adresa";
            lblEmail.Click += label8_Click;
            // 
            // lblBrojTelefona
            // 
            lblBrojTelefona.AutoSize = true;
            lblBrojTelefona.Location = new Point(67, 257);
            lblBrojTelefona.Name = "lblBrojTelefona";
            lblBrojTelefona.Size = new Size(74, 15);
            lblBrojTelefona.TabIndex = 8;
            lblBrojTelefona.Text = "Broj telefona";
            // 
            // lblIdPozicije
            // 
            lblIdPozicije.AutoSize = true;
            lblIdPozicije.Location = new Point(94, 306);
            lblIdPozicije.Name = "lblIdPozicije";
            lblIdPozicije.Size = new Size(47, 15);
            lblIdPozicije.TabIndex = 9;
            lblIdPozicije.Text = "Pozicija";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(482, 254);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(333, 72);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Ubaci novog zaposlenog";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtIdZaposlenog
            // 
            txtIdZaposlenog.Enabled = false;
            txtIdZaposlenog.Location = new Point(174, 69);
            txtIdZaposlenog.Name = "txtIdZaposlenog";
            txtIdZaposlenog.Size = new Size(204, 23);
            txtIdZaposlenog.TabIndex = 12;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(174, 115);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(204, 23);
            txtIme.TabIndex = 13;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(174, 158);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(204, 23);
            txtPrezime.TabIndex = 14;
            // 
            // txtBrojTekucegRacuna
            // 
            txtBrojTekucegRacuna.Location = new Point(174, 203);
            txtBrojTekucegRacuna.Name = "txtBrojTekucegRacuna";
            txtBrojTekucegRacuna.Size = new Size(204, 23);
            txtBrojTekucegRacuna.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(611, 211);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 23);
            txtEmail.TabIndex = 16;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(174, 254);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(204, 23);
            txtBrojTelefona.TabIndex = 17;
            // 
            // dateTimePickerDatumRodjenja
            // 
            dateTimePickerDatumRodjenja.Location = new Point(611, 112);
            dateTimePickerDatumRodjenja.Name = "dateTimePickerDatumRodjenja";
            dateTimePickerDatumRodjenja.Size = new Size(204, 23);
            dateTimePickerDatumRodjenja.TabIndex = 18;
            dateTimePickerDatumRodjenja.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerDatumZaposlenja
            // 
            dateTimePickerDatumZaposlenja.Location = new Point(611, 161);
            dateTimePickerDatumZaposlenja.Name = "dateTimePickerDatumZaposlenja";
            dateTimePickerDatumZaposlenja.Size = new Size(204, 23);
            dateTimePickerDatumZaposlenja.TabIndex = 19;
            // 
            // cbPozicija
            // 
            cbPozicija.FormattingEnabled = true;
            cbPozicija.Location = new Point(174, 303);
            cbPozicija.Name = "cbPozicija";
            cbPozicija.Size = new Size(204, 23);
            cbPozicija.TabIndex = 20;
            // 
            // UCDetaljiZaposlenog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbPozicija);
            Controls.Add(dateTimePickerDatumZaposlenja);
            Controls.Add(dateTimePickerDatumRodjenja);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtEmail);
            Controls.Add(txtBrojTekucegRacuna);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(txtIdZaposlenog);
            Controls.Add(btnSubmit);
            Controls.Add(lblIdPozicije);
            Controls.Add(lblBrojTelefona);
            Controls.Add(lblEmail);
            Controls.Add(lblDatumZaposlenja);
            Controls.Add(lblDatumRodjenja);
            Controls.Add(lblBrojTekucegRacuna);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Controls.Add(lblIdZaposlenog);
            Controls.Add(lblNaslov);
            Name = "UCDetaljiZaposlenog";
            Size = new Size(900, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Label lblIdZaposlenog;
        private Label lblIme;
        private Label lblPrezime;
        private Label lblBrojTekucegRacuna;
        private Label lblDatumRodjenja;
        private Label lblDatumZaposlenja;
        private Label lblEmail;
        private Label lblBrojTelefona;
        private Label lblIdPozicije;
        private Button btnSubmit;
        private TextBox txtIdZaposlenog;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtBrojTekucegRacuna;
        private TextBox txtEmail;
        private TextBox txtBrojTelefona;
        private DateTimePicker dateTimePickerDatumRodjenja;
        private DateTimePicker dateTimePickerDatumZaposlenja;
        private ComboBox cbPozicija;

        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Label LblIdZaposlenog { get => lblIdZaposlenog; set => lblIdZaposlenog = value; }
        public Label LblIme { get => lblIme; set => lblIme = value; }
        public Label LblPrezime { get => lblPrezime; set => lblPrezime = value; }
        public Label LblBrojTekucegRacuna { get => lblBrojTekucegRacuna; set => lblBrojTekucegRacuna = value; }
        public Label LblDatumRodjenja { get => lblDatumRodjenja; set => lblDatumRodjenja = value; }
        public Label LblDatumZaposlenja { get => lblDatumZaposlenja; set => lblDatumZaposlenja = value; }
        public Label LblEmail { get => lblEmail; set => lblEmail = value; }
        public Label LblBrojTelefona { get => lblBrojTelefona; set => lblBrojTelefona = value; }
        public Label LblIdPozicije { get => lblIdPozicije; set => lblIdPozicije = value; }
        public Button BtnSubmit { get => btnSubmit; set => btnSubmit = value; }
      
        public TextBox TxtIdZaposlenog { get => txtIdZaposlenog; set => txtIdZaposlenog = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtBrojTekucegRacuna { get => txtBrojTekucegRacuna; set => txtBrojTekucegRacuna = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public TextBox TxtBrojTelefona { get => txtBrojTelefona; set => txtBrojTelefona = value; }
        public DateTimePicker DateTimePickerDatumRodjenja { get => dateTimePickerDatumRodjenja; set => dateTimePickerDatumRodjenja = value; }
        public DateTimePicker DateTimePickerDatumZaposlenja { get => dateTimePickerDatumZaposlenja; set => dateTimePickerDatumZaposlenja = value; }
        public ComboBox CbPozicija { get => cbPozicija; set => cbPozicija = value; }
    }
}
