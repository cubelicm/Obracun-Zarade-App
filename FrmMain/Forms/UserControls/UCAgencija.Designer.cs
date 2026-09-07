namespace Client.Forms.UserControls
{
    partial class UCAgencija
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
            lblNaziv = new Label();
            lblDatumOsnivanja = new Label();
            lblDirektor = new Label();
            lblBrojTelefona = new Label();
            lblAdresa = new Label();
            lblEmail = new Label();
            lblPIB = new Label();
            txtNaziv = new TextBox();
            txtDirektor = new TextBox();
            txtBrojTelefona = new TextBox();
            txtAdresa = new TextBox();
            txtEmail = new TextBox();
            txtPIB = new TextBox();
            btnUbaci = new Button();
            dateTimePickerDatumOsnivanja = new DateTimePicker();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Font = new Font("Segoe UI", 20F);
            lblNaslov.Location = new Point(3, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(410, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Kreiraj računovodstvenu agenciju";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(19, 59);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(36, 15);
            lblNaziv.TabIndex = 1;
            lblNaziv.Text = "Naziv";
            // 
            // lblDatumOsnivanja
            // 
            lblDatumOsnivanja.AutoSize = true;
            lblDatumOsnivanja.Location = new Point(19, 101);
            lblDatumOsnivanja.Name = "lblDatumOsnivanja";
            lblDatumOsnivanja.Size = new Size(98, 15);
            lblDatumOsnivanja.TabIndex = 2;
            lblDatumOsnivanja.Text = "Datum Osnivanja";
            // 
            // lblDirektor
            // 
            lblDirektor.AutoSize = true;
            lblDirektor.Location = new Point(19, 144);
            lblDirektor.Name = "lblDirektor";
            lblDirektor.Size = new Size(49, 15);
            lblDirektor.TabIndex = 3;
            lblDirektor.Text = "Direktor";
            // 
            // lblBrojTelefona
            // 
            lblBrojTelefona.AutoSize = true;
            lblBrojTelefona.Location = new Point(19, 188);
            lblBrojTelefona.Name = "lblBrojTelefona";
            lblBrojTelefona.Size = new Size(75, 15);
            lblBrojTelefona.TabIndex = 4;
            lblBrojTelefona.Text = "Broj Telefona";
            // 
            // lblAdresa
            // 
            lblAdresa.AutoSize = true;
            lblAdresa.Location = new Point(19, 224);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(43, 15);
            lblAdresa.TabIndex = 5;
            lblAdresa.Text = "Adresa";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(19, 263);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // lblPIB
            // 
            lblPIB.AutoSize = true;
            lblPIB.Location = new Point(19, 298);
            lblPIB.Name = "lblPIB";
            lblPIB.Size = new Size(24, 15);
            lblPIB.TabIndex = 7;
            lblPIB.Text = "PIB";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(136, 51);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(200, 23);
            txtNaziv.TabIndex = 8;
            // 
            // txtDirektor
            // 
            txtDirektor.Location = new Point(136, 136);
            txtDirektor.Name = "txtDirektor";
            txtDirektor.Size = new Size(200, 23);
            txtDirektor.TabIndex = 9;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(136, 185);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(200, 23);
            txtBrojTelefona.TabIndex = 10;
            txtBrojTelefona.TextChanged += txtBrojTelefona_TextChanged;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(136, 221);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(200, 23);
            txtAdresa.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(136, 255);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 12;
            // 
            // txtPIB
            // 
            txtPIB.Location = new Point(136, 295);
            txtPIB.Name = "txtPIB";
            txtPIB.Size = new Size(200, 23);
            txtPIB.TabIndex = 13;
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(19, 356);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(317, 23);
            btnUbaci.TabIndex = 14;
            btnUbaci.Text = "Kreiraj računovodstvenu agenciju";
            btnUbaci.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDatumOsnivanja
            // 
            dateTimePickerDatumOsnivanja.Location = new Point(136, 98);
            dateTimePickerDatumOsnivanja.Name = "dateTimePickerDatumOsnivanja";
            dateTimePickerDatumOsnivanja.Size = new Size(200, 23);
            dateTimePickerDatumOsnivanja.TabIndex = 15;
            // 
            // UCAgencija
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimePickerDatumOsnivanja);
            Controls.Add(btnUbaci);
            Controls.Add(txtPIB);
            Controls.Add(txtEmail);
            Controls.Add(txtAdresa);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtDirektor);
            Controls.Add(txtNaziv);
            Controls.Add(lblPIB);
            Controls.Add(lblEmail);
            Controls.Add(lblAdresa);
            Controls.Add(lblBrojTelefona);
            Controls.Add(lblDirektor);
            Controls.Add(lblDatumOsnivanja);
            Controls.Add(lblNaziv);
            Controls.Add(lblNaslov);
            Name = "UCAgencija";
            Size = new Size(900, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaslov;
        private Label lblNaziv;
        private Label lblDatumOsnivanja;
        private Label lblDirektor;
        private Label lblBrojTelefona;
        private Label lblAdresa;
        private Label lblEmail;
        private Label lblPIB;
        private TextBox txtNaziv;
        private TextBox txtDirektor;
        private TextBox txtBrojTelefona;
        private TextBox txtAdresa;
        private TextBox txtEmail;
        private TextBox txtPIB;
        private Button btnUbaci;
        private DateTimePicker dateTimePickerDatumOsnivanja;

        public Label LblNaslov { get => lblNaslov; set => lblNaslov = value; }
        public Label LblNaziv { get => lblNaziv; set => lblNaziv = value; }
        public Label LblDatumOsnivanja { get => lblDatumOsnivanja; set => lblDatumOsnivanja = value; }
        public Label LblDirektor { get => lblDirektor; set => lblDirektor = value; }
        public Label LblBrojTelefona { get => lblBrojTelefona; set => lblBrojTelefona = value; }
        public Label LblAdresa { get => lblAdresa; set => lblAdresa = value; }
        public Label LblEmail { get => lblEmail; set => lblEmail = value; }
        public Label LblPIB { get => lblPIB; set => lblPIB = value; }
        public TextBox TxtNaziv { get => txtNaziv; set => txtNaziv = value; }
        public TextBox TxtDirektor { get => txtDirektor; set => txtDirektor = value; }
        public TextBox TxtBrojTelefona { get => txtBrojTelefona; set => txtBrojTelefona = value; }
        public TextBox TxtAdresa { get => txtAdresa; set => txtAdresa = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public TextBox TxtPIB { get => txtPIB; set => txtPIB = value; }
        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }
        public DateTimePicker DateTimePickerDatumOsnivanja { get => dateTimePickerDatumOsnivanja; set => dateTimePickerDatumOsnivanja = value; }
    }
}
