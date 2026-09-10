namespace Server
{
    partial class FrmServer
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
            tabControl1 = new TabControl();
            tabPageServer = new TabPage();
            lblUlogovani = new Label();
            lblPovezani = new Label();
            dgvUlogovani = new DataGridView();
            lbl_status = new Label();
            btn_Stop = new Button();
            btn_Start = new Button();
            tabPagePodesavanja = new TabPage();
            lblInitialCatalog = new Label();
            lblDataSource = new Label();
            btnSacuvajPodesavanja = new Button();
            chkIntegratedSecurity = new CheckBox();
            txtInitialCatalog = new TextBox();
            txtDataSource = new TextBox();
            lblIPAdresa = new Label();
            lblPort = new Label();
            txtIPAdresa = new TextBox();
            txtPort = new TextBox();
            tabControl1.SuspendLayout();
            tabPageServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUlogovani).BeginInit();
            tabPagePodesavanja.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageServer);
            tabControl1.Controls.Add(tabPagePodesavanja);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(760, 507);
            tabControl1.TabIndex = 0;
            // 
            // tabPageServer
            // 
            tabPageServer.Controls.Add(lblUlogovani);
            tabPageServer.Controls.Add(lblPovezani);
            tabPageServer.Controls.Add(dgvUlogovani);
            tabPageServer.Controls.Add(lbl_status);
            tabPageServer.Controls.Add(btn_Stop);
            tabPageServer.Controls.Add(btn_Start);
            tabPageServer.Location = new Point(4, 24);
            tabPageServer.Name = "tabPageServer";
            tabPageServer.Padding = new Padding(3);
            tabPageServer.Size = new Size(752, 479);
            tabPageServer.TabIndex = 0;
            tabPageServer.Text = "Server";
            tabPageServer.UseVisualStyleBackColor = true;
            // 
            // lblUlogovani
            // 
            lblUlogovani.AutoSize = true;
            lblUlogovani.Location = new Point(541, 51);
            lblUlogovani.Name = "lblUlogovani";
            lblUlogovani.Size = new Size(38, 15);
            lblUlogovani.TabIndex = 12;
            lblUlogovani.Text = "label1";
            // 
            // lblPovezani
            // 
            lblPovezani.AutoSize = true;
            lblPovezani.Location = new Point(26, 51);
            lblPovezani.Name = "lblPovezani";
            lblPovezani.Size = new Size(38, 15);
            lblPovezani.TabIndex = 11;
            lblPovezani.Text = "label1";
            // 
            // dgvUlogovani
            // 
            dgvUlogovani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUlogovani.Location = new Point(26, 81);
            dgvUlogovani.Name = "dgvUlogovani";
            dgvUlogovani.Size = new Size(709, 306);
            dgvUlogovani.TabIndex = 10;
            // 
            // lbl_status
            // 
            lbl_status.Font = new Font("Segoe UI", 20F);
            lbl_status.Location = new Point(13, 3);
            lbl_status.Margin = new Padding(2, 0, 2, 0);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(723, 37);
            lbl_status.TabIndex = 9;
            lbl_status.Text = "label1";
            lbl_status.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Stop
            // 
            btn_Stop.Location = new Point(611, 392);
            btn_Stop.Margin = new Padding(2);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(125, 50);
            btn_Stop.TabIndex = 8;
            btn_Stop.Text = "Stop";
            btn_Stop.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            btn_Start.AutoSize = true;
            btn_Start.Location = new Point(26, 392);
            btn_Start.Margin = new Padding(2);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(125, 50);
            btn_Start.TabIndex = 7;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            // 
            // tabPagePodesavanja
            // 
            tabPagePodesavanja.Controls.Add(txtPort);
            tabPagePodesavanja.Controls.Add(txtIPAdresa);
            tabPagePodesavanja.Controls.Add(lblPort);
            tabPagePodesavanja.Controls.Add(lblIPAdresa);
            tabPagePodesavanja.Controls.Add(lblInitialCatalog);
            tabPagePodesavanja.Controls.Add(lblDataSource);
            tabPagePodesavanja.Controls.Add(btnSacuvajPodesavanja);
            tabPagePodesavanja.Controls.Add(chkIntegratedSecurity);
            tabPagePodesavanja.Controls.Add(txtInitialCatalog);
            tabPagePodesavanja.Controls.Add(txtDataSource);
            tabPagePodesavanja.Location = new Point(4, 24);
            tabPagePodesavanja.Name = "tabPagePodesavanja";
            tabPagePodesavanja.Padding = new Padding(3);
            tabPagePodesavanja.Size = new Size(752, 479);
            tabPagePodesavanja.TabIndex = 1;
            tabPagePodesavanja.Text = "Podesavanja";
            tabPagePodesavanja.UseVisualStyleBackColor = true;
            // 
            // lblInitialCatalog
            // 
            lblInitialCatalog.AutoSize = true;
            lblInitialCatalog.Location = new Point(125, 146);
            lblInitialCatalog.Name = "lblInitialCatalog";
            lblInitialCatalog.Size = new Size(80, 15);
            lblInitialCatalog.TabIndex = 5;
            lblInitialCatalog.Text = "Initial Catalog";
            // 
            // lblDataSource
            // 
            lblDataSource.AutoSize = true;
            lblDataSource.Location = new Point(124, 92);
            lblDataSource.Name = "lblDataSource";
            lblDataSource.Size = new Size(70, 15);
            lblDataSource.TabIndex = 4;
            lblDataSource.Text = "Data Source";
            // 
            // btnSacuvajPodesavanja
            // 
            btnSacuvajPodesavanja.Location = new Point(236, 379);
            btnSacuvajPodesavanja.Name = "btnSacuvajPodesavanja";
            btnSacuvajPodesavanja.Size = new Size(189, 23);
            btnSacuvajPodesavanja.TabIndex = 3;
            btnSacuvajPodesavanja.Text = "Sačuvaj Podešavanja";
            btnSacuvajPodesavanja.UseVisualStyleBackColor = true;
            btnSacuvajPodesavanja.Click += btnSacuvajPodesavanja_Click;
            // 
            // chkIntegratedSecurity
            // 
            chkIntegratedSecurity.AutoSize = true;
            chkIntegratedSecurity.Location = new Point(122, 219);
            chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            chkIntegratedSecurity.Size = new Size(125, 19);
            chkIntegratedSecurity.TabIndex = 2;
            chkIntegratedSecurity.Text = "Integrated Security";
            chkIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // txtInitialCatalog
            // 
            txtInitialCatalog.Location = new Point(122, 170);
            txtInitialCatalog.Name = "txtInitialCatalog";
            txtInitialCatalog.Size = new Size(189, 23);
            txtInitialCatalog.TabIndex = 1;
            // 
            // txtDataSource
            // 
            txtDataSource.Location = new Point(122, 115);
            txtDataSource.Name = "txtDataSource";
            txtDataSource.Size = new Size(189, 23);
            txtDataSource.TabIndex = 0;
            // 
            // lblIPAdresa
            // 
            lblIPAdresa.AutoSize = true;
            lblIPAdresa.Location = new Point(354, 92);
            lblIPAdresa.Name = "lblIPAdresa";
            lblIPAdresa.Size = new Size(56, 15);
            lblIPAdresa.TabIndex = 6;
            lblIPAdresa.Text = "IP Adresa";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(354, 146);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(59, 15);
            lblPort.TabIndex = 7;
            lblPort.Text = "Broj Porta";
            // 
            // txtIPAdresa
            // 
            txtIPAdresa.Location = new Point(354, 115);
            txtIPAdresa.Name = "txtIPAdresa";
            txtIPAdresa.Size = new Size(176, 23);
            txtIPAdresa.TabIndex = 8;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(354, 170);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(176, 23);
            txtPort.TabIndex = 9;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 470);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            MinimumSize = new Size(600, 300);
            Name = "FrmServer";
            Text = "Serverska forma";
            Load += FrmServer_Load;
            tabControl1.ResumeLayout(false);
            tabPageServer.ResumeLayout(false);
            tabPageServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUlogovani).EndInit();
            tabPagePodesavanja.ResumeLayout(false);
            tabPagePodesavanja.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageServer;
        private TabPage tabPagePodesavanja;
        private Label lblUlogovani;
        private Label lblPovezani;
        private DataGridView dgvUlogovani;
        private Label lbl_status;
        private Button btn_Stop;
        private Button btn_Start;
        private TextBox txtDataSource;
        private Label lblInitialCatalog;
        private Label lblDataSource;
        private Button btnSacuvajPodesavanja;
        private CheckBox chkIntegratedSecurity;
        private TextBox txtInitialCatalog;
        private TextBox txtPort;
        private TextBox txtIPAdresa;
        private Label lblPort;
        private Label lblIPAdresa;
    }
}
