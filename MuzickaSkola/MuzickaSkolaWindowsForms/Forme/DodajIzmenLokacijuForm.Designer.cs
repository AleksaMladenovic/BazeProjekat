namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmenLokacijuForm
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
            label1 = new Label();
            label2 = new Label();
            txtAdresa = new TextBox();
            txtRadnoVreme = new TextBox();
            cmdSacuvajLokaciju = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(53, 9);
            label1.Name = "label1";
            label1.Size = new Size(53, 17);
            label1.TabIndex = 0;
            label1.Text = "Adresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(14, 45);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 1;
            label2.Text = "Radno vreme:";
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(115, 6);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(188, 25);
            txtAdresa.TabIndex = 2;
            // 
            // txtRadnoVreme
            // 
            txtRadnoVreme.Location = new Point(115, 42);
            txtRadnoVreme.Name = "txtRadnoVreme";
            txtRadnoVreme.Size = new Size(188, 25);
            txtRadnoVreme.TabIndex = 3;
            // 
            // cmdSacuvajLokaciju
            // 
            cmdSacuvajLokaciju.BackColor = Color.MidnightBlue;
            cmdSacuvajLokaciju.ForeColor = Color.White;
            cmdSacuvajLokaciju.Location = new Point(14, 82);
            cmdSacuvajLokaciju.Name = "cmdSacuvajLokaciju";
            cmdSacuvajLokaciju.Size = new Size(290, 32);
            cmdSacuvajLokaciju.TabIndex = 4;
            cmdSacuvajLokaciju.Text = "Sačuvaj";
            cmdSacuvajLokaciju.UseVisualStyleBackColor = false;
            cmdSacuvajLokaciju.Click += cmdSacuvajLokaciju_Click;
            // 
            // DodajIzmenLokacijuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 117);
            Controls.Add(cmdSacuvajLokaciju);
            Controls.Add(txtRadnoVreme);
            Controls.Add(txtAdresa);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.White;
            Name = "DodajIzmenLokacijuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtAdresa;
        private TextBox txtRadnoVreme;
        private Button cmdSacuvajLokaciju;
    }
}