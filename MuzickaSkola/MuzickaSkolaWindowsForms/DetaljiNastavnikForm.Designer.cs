namespace MuzickaSkolaWindowsForms
{
    partial class DetaljiNastavnikForm
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
            lblAdresa = new Label();
            lblEmail = new Label();
            lblTelefon = new Label();
            lblZaposlenje = new Label();
            lblDetalji = new Label();
            SuspendLayout();
            // 
            // lblAdresa
            // 
            lblAdresa.AccessibleName = "";
            lblAdresa.AutoSize = true;
            lblAdresa.Location = new Point(12, 9);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(38, 15);
            lblAdresa.TabIndex = 0;
            lblAdresa.Text = "label1";
            // 
            // lblEmail
            // 
            lblEmail.AccessibleName = "";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 36);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(38, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "label2";
            // 
            // lblTelefon
            // 
            lblTelefon.AccessibleName = "";
            lblTelefon.AutoSize = true;
            lblTelefon.Location = new Point(12, 63);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(38, 15);
            lblTelefon.TabIndex = 2;
            lblTelefon.Text = "label3";
            // 
            // lblZaposlenje
            // 
            lblZaposlenje.AccessibleName = "";
            lblZaposlenje.AutoSize = true;
            lblZaposlenje.Location = new Point(12, 92);
            lblZaposlenje.Name = "lblZaposlenje";
            lblZaposlenje.Size = new Size(38, 15);
            lblZaposlenje.TabIndex = 3;
            lblZaposlenje.Text = "label4";
            // 
            // lblDetalji
            // 
            lblDetalji.AccessibleName = "";
            lblDetalji.AutoSize = true;
            lblDetalji.Location = new Point(12, 121);
            lblDetalji.Name = "lblDetalji";
            lblDetalji.Size = new Size(38, 15);
            lblDetalji.TabIndex = 4;
            lblDetalji.Text = "label5";
            // 
            // DetaljiNastavnikForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 156);
            Controls.Add(lblDetalji);
            Controls.Add(lblZaposlenje);
            Controls.Add(lblTelefon);
            Controls.Add(lblEmail);
            Controls.Add(lblAdresa);
            Name = "DetaljiNastavnikForm";
            Text = "DetaljiNastavnikForm";
            Load += DetaljiNastavnikaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAdresa;
        private Label lblEmail;
        private Label lblTelefon;
        private Label lblZaposlenje;
        private Label lblDetalji;
    }
}