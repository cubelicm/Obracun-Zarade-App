namespace Client.Forms.UserControls
{
    partial class UCPlaceholder
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
            lable1 = new Label();
            SuspendLayout();
            // 
            // lable1
            // 
            lable1.AutoSize = true;
            lable1.Font = new Font("Segoe UI", 20F);
            lable1.Location = new Point(208, 166);
            lable1.Name = "lable1";
            lable1.Size = new Size(462, 37);
            lable1.TabIndex = 0;
            lable1.Text = "Slučaj korišćenja nije implementiran :(";
            // 
            // UCPlaceholder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lable1);
            Name = "UCPlaceholder";
            Size = new Size(900, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lable1;
    }
}
