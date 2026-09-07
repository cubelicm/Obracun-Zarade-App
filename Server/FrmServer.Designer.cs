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
            btn_Start = new Button();
            btn_Stop = new Button();
            lbl_status = new Label();
            SuspendLayout();
            // 
            // btn_Start
            // 
            btn_Start.AutoSize = true;
            btn_Start.Location = new Point(73, 184);
            btn_Start.Margin = new Padding(2);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(125, 50);
            btn_Start.TabIndex = 0;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Location = new Point(379, 184);
            btn_Stop.Margin = new Padding(2);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(125, 50);
            btn_Stop.TabIndex = 1;
            btn_Stop.Text = "Stop";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // lbl_status
            // 
            lbl_status.Font = new Font("Segoe UI", 20F);
            lbl_status.Location = new Point(73, 45);
            lbl_status.Margin = new Padding(2, 0, 2, 0);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(431, 37);
            lbl_status.TabIndex = 2;
            lbl_status.Text = "label1";
            lbl_status.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(lbl_status);
            Controls.Add(btn_Stop);
            Controls.Add(btn_Start);
            Margin = new Padding(2);
            MinimumSize = new Size(600, 300);
            Name = "FrmServer";
            Text = "Serverska forma";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Start;
        private Button btn_Stop;
        private Label lbl_status;
    }
}
