namespace Client.Forms
{
    partial class LoginFrm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            tbKorisnickoIme = new TextBox();
            tbSifra = new TextBox();
            label3 = new Label();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(97, 392);
            btnLogin.Margin = new Padding(5, 6, 5, 6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(399, 69);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Prijavite se";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 220);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 28);
            label1.TabIndex = 1;
            label1.Text = "Korisničko ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 313);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 28);
            label2.TabIndex = 2;
            label2.Text = "Šifra";
            // 
            // tbKorisnickoIme
            // 
            tbKorisnickoIme.Location = new Point(190, 217);
            tbKorisnickoIme.Margin = new Padding(5, 6, 5, 6);
            tbKorisnickoIme.Name = "tbKorisnickoIme";
            tbKorisnickoIme.Size = new Size(304, 34);
            tbKorisnickoIme.TabIndex = 3;
            // 
            // tbSifra
            // 
            tbSifra.Location = new Point(190, 310);
            tbSifra.Margin = new Padding(5, 6, 5, 6);
            tbSifra.Name = "tbSifra";
            tbSifra.Size = new Size(304, 34);
            tbSifra.TabIndex = 4;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 25F);
            label3.Location = new Point(97, 32);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(399, 157);
            label3.TabIndex = 5;
            label3.Text = "Dobro došli, prijavite se sa vašim kredencijalima";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 13F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(97, 358);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 25);
            lblError.TabIndex = 6;
            // 
            // LoginFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 506);
            Controls.Add(lblError);
            Controls.Add(label3);
            Controls.Add(tbSifra);
            Controls.Add(tbKorisnickoIme);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginFrm";
            Text = "Obračun zarade- Prijavite se";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private TextBox tbKorisnickoIme;
        private TextBox tbSifra;
        private Label label3;
        private Label lblError;

        public Button BtnLogin { get => btnLogin; set => btnLogin = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TbKorisnickoIme { get => tbKorisnickoIme; set => tbKorisnickoIme = value; }
        public TextBox TbSifra { get => tbSifra; set => tbSifra = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label LblError { get => lblError; set => lblError = value; }
    }
}