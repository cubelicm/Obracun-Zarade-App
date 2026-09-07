namespace Client.Forms.UserControls
{
    partial class UCObracunZarade
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
            lblId = new Label();
            lblDatumOd = new Label();
            lblDatumDo = new Label();
            dateTimePickerDatumOd = new DateTimePicker();
            dateTimePickerDatumDo = new DateTimePicker();
            lblRacunovodja = new Label();
            lblZaposleni = new Label();
            cbZaposleni = new ComboBox();
            cbRacunovodja = new ComboBox();
            lblStorniran = new Label();
            lblNapomena = new Label();
            txtNapomena = new TextBox();
            dataGridView1 = new DataGridView();
            lblStavke = new Label();
            btnDodajStavku = new Button();
            btnObrisiStavku = new Button();
            lblUkupanIznos = new Label();
            btnSacuvaj = new Button();
            chkStorniran = new CheckBox();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(220, 7);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(333, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Ubaci novi obračun zarade";
            lblNaslov.Click += lblNaslov_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(38, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 1;
            lblId.Text = "ID";
            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.Location = new Point(38, 64);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Size = new Size(141, 15);
            lblDatumOd.TabIndex = 2;
            lblDatumOd.Text = "Datum početka obračuna";
            // 
            // lblDatumDo
            // 
            lblDatumDo.AutoSize = true;
            lblDatumDo.Location = new Point(409, 64);
            lblDatumDo.Name = "lblDatumDo";
            lblDatumDo.Size = new Size(124, 15);
            lblDatumDo.TabIndex = 3;
            lblDatumDo.Text = "Datum kraja obračuna";
            // 
            // dateTimePickerDatumOd
            // 
            dateTimePickerDatumOd.Location = new Point(185, 58);
            dateTimePickerDatumOd.Name = "dateTimePickerDatumOd";
            dateTimePickerDatumOd.Size = new Size(200, 23);
            dateTimePickerDatumOd.TabIndex = 4;
            dateTimePickerDatumOd.Value = new DateTime(2026, 6, 20, 16, 30, 28, 0);
            // 
            // dateTimePickerDatumDo
            // 
            dateTimePickerDatumDo.Location = new Point(554, 58);
            dateTimePickerDatumDo.Name = "dateTimePickerDatumDo";
            dateTimePickerDatumDo.Size = new Size(200, 23);
            dateTimePickerDatumDo.TabIndex = 5;
            // 
            // lblRacunovodja
            // 
            lblRacunovodja.AutoSize = true;
            lblRacunovodja.Location = new Point(38, 110);
            lblRacunovodja.Name = "lblRacunovodja";
            lblRacunovodja.Size = new Size(76, 15);
            lblRacunovodja.TabIndex = 6;
            lblRacunovodja.Text = "Računovodja";
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new Point(475, 107);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new Size(58, 15);
            lblZaposleni.TabIndex = 7;
            lblZaposleni.Text = "Zaposleni";
            // 
            // cbZaposleni
            // 
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(554, 107);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(200, 23);
            cbZaposleni.TabIndex = 8;
            // 
            // cbRacunovodja
            // 
            cbRacunovodja.FormattingEnabled = true;
            cbRacunovodja.Location = new Point(185, 107);
            cbRacunovodja.Name = "cbRacunovodja";
            cbRacunovodja.Size = new Size(200, 23);
            cbRacunovodja.TabIndex = 9;
            // 
            // lblStorniran
            // 
            lblStorniran.AutoSize = true;
            lblStorniran.Font = new Font("Segoe UI", 20F);
            lblStorniran.ForeColor = Color.Red;
            lblStorniran.Location = new Point(576, 194);
            lblStorniran.Name = "lblStorniran";
            lblStorniran.Size = new Size(160, 37);
            lblStorniran.TabIndex = 10;
            lblStorniran.Text = "STORNIRAN";
            lblStorniran.Visible = false;
            // 
            // lblNapomena
            // 
            lblNapomena.AutoSize = true;
            lblNapomena.Location = new Point(38, 161);
            lblNapomena.Name = "lblNapomena";
            lblNapomena.Size = new Size(66, 15);
            lblNapomena.TabIndex = 11;
            lblNapomena.Text = "Napomena";
            // 
            // txtNapomena
            // 
            txtNapomena.Location = new Point(185, 158);
            txtNapomena.MaxLength = 255;
            txtNapomena.Name = "txtNapomena";
            txtNapomena.Size = new Size(368, 23);
            txtNapomena.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 234);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(719, 213);
            dataGridView1.TabIndex = 13;
            // 
            // lblStavke
            // 
            lblStavke.AutoSize = true;
            lblStavke.Location = new Point(38, 202);
            lblStavke.Name = "lblStavke";
            lblStavke.Size = new Size(133, 15);
            lblStavke.TabIndex = 14;
            lblStavke.Text = "Stavke Obračuna zarade";
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.Location = new Point(185, 198);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(175, 23);
            btnDodajStavku.TabIndex = 15;
            btnDodajStavku.Text = "Dodaj novu stavku";
            btnDodajStavku.UseVisualStyleBackColor = true;
            // 
            // btnObrisiStavku
            // 
            btnObrisiStavku.Location = new Point(382, 198);
            btnObrisiStavku.Name = "btnObrisiStavku";
            btnObrisiStavku.Size = new Size(171, 23);
            btnObrisiStavku.TabIndex = 17;
            btnObrisiStavku.Text = "Obriši stavku";
            btnObrisiStavku.UseVisualStyleBackColor = true;
            // 
            // lblUkupanIznos
            // 
            lblUkupanIznos.AutoSize = true;
            lblUkupanIznos.Font = new Font("Segoe UI", 15F);
            lblUkupanIznos.Location = new Point(35, 450);
            lblUkupanIznos.Name = "lblUkupanIznos";
            lblUkupanIznos.Size = new Size(152, 28);
            lblUkupanIznos.TabIndex = 18;
            lblUkupanIznos.Text = "Ukupna zarada: ";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(507, 450);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(247, 37);
            btnSacuvaj.TabIndex = 19;
            btnSacuvaj.Text = "Sačuvaj obračun zarade";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // chkStorniran
            // 
            chkStorniran.AutoSize = true;
            chkStorniran.Location = new Point(582, 162);
            chkStorniran.Name = "chkStorniran";
            chkStorniran.Size = new Size(154, 19);
            chkStorniran.TabIndex = 20;
            chkStorniran.Text = "Storniraj obračun zarade";
            chkStorniran.UseVisualStyleBackColor = true;
            chkStorniran.Visible = false;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 12F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(38, 493);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 21);
            lblError.TabIndex = 21;
            // 
            // UCObracunZarade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblError);
            Controls.Add(chkStorniran);
            Controls.Add(btnSacuvaj);
            Controls.Add(lblUkupanIznos);
            Controls.Add(btnObrisiStavku);
            Controls.Add(btnDodajStavku);
            Controls.Add(lblStavke);
            Controls.Add(dataGridView1);
            Controls.Add(txtNapomena);
            Controls.Add(lblNapomena);
            Controls.Add(lblStorniran);
            Controls.Add(cbRacunovodja);
            Controls.Add(cbZaposleni);
            Controls.Add(lblZaposleni);
            Controls.Add(lblRacunovodja);
            Controls.Add(dateTimePickerDatumDo);
            Controls.Add(dateTimePickerDatumOd);
            Controls.Add(lblDatumDo);
            Controls.Add(lblDatumOd);
            Controls.Add(lblId);
            Controls.Add(lblNaslov);
            Name = "UCObracunZarade";
            Size = new Size(800, 563);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Label lblId;
        private Label lblDatumOd;
        private Label lblDatumDo;
        private DateTimePicker dateTimePickerDatumOd;
        private DateTimePicker dateTimePickerDatumDo;
        private Label lblRacunovodja;
        private Label lblZaposleni;
        private ComboBox cbZaposleni;
        private ComboBox cbRacunovodja;
        private Label lblStorniran;
        private Label lblNapomena;
        private TextBox txtNapomena;
        private DataGridView dataGridView1;
        private Label lblStavke;
        private Button btnDodajStavku;
        private Button btnObrisiStavku;
        private Label lblUkupanIznos;
        private Button btnSacuvaj;
        private CheckBox chkStorniran;
        private Label lblError;
        
        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Label LblId { get => lblId; set => lblId = value; }
        public Label LblDatumOd { get => lblDatumOd; set => lblDatumOd = value; }
        public Label LblDatumDo { get => lblDatumDo; set => lblDatumDo = value; }
        public DateTimePicker DateTimePickerDatumOd { get => dateTimePickerDatumOd; set => dateTimePickerDatumOd = value; }
        public DateTimePicker DateTimePickerDatumDo { get => dateTimePickerDatumDo; set => dateTimePickerDatumDo = value; }
        public Label LblRacunovodja { get => lblRacunovodja; set => lblRacunovodja = value; }
        public Label LblZaposleni { get => lblZaposleni; set => lblZaposleni = value; }
        public ComboBox CbZaposleni { get => cbZaposleni; set => cbZaposleni = value; }
        public ComboBox CbRacunovodja { get => cbRacunovodja; set => cbRacunovodja = value; }
        public Label LblStorniran { get => lblStorniran; set => lblStorniran = value; }
        public Label LblNapomena { get => lblNapomena; set => lblNapomena = value; }
        public TextBox TxtNapomena { get => txtNapomena; set => txtNapomena = value; }
        public DataGridView DataGridView1 { get => dataGridView1; set => dataGridView1 = value; }
        public Label LblStavke { get => lblStavke; set => lblStavke = value; }
        public Button BtnDodajStavku { get => btnDodajStavku; set => btnDodajStavku = value; }
        
        public Button BtnObrisiStavku { get => btnObrisiStavku; set => btnObrisiStavku = value; }
        public Label LblUkupanIznos { get => lblUkupanIznos; set => lblUkupanIznos = value; }
        public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
        public CheckBox ChkStorniran { get => chkStorniran; set => chkStorniran = value; }
        public Label LblError { get => lblError; set => lblError = value; }
    }
}
