namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmeniPrisustvoForm
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
            cmbPolaznici = new ComboBox();
            txtPolaznik = new TextBox();
            numOcena = new NumericUpDown();
            cmdSnimi = new Button();
            ((System.ComponentModel.ISupportInitialize)numOcena).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(62, 17);
            label1.TabIndex = 0;
            label1.Text = "Polaznik:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(49, 17);
            label2.TabIndex = 1;
            label2.Text = "Ocena:";
            // 
            // cmbPolaznici
            // 
            cmbPolaznici.FormattingEnabled = true;
            cmbPolaznici.Location = new Point(80, 18);
            cmbPolaznici.Name = "cmbPolaznici";
            cmbPolaznici.Size = new Size(196, 25);
            cmbPolaznici.TabIndex = 2;
            // 
            // txtPolaznik
            // 
            txtPolaznik.Location = new Point(80, 18);
            txtPolaznik.Name = "txtPolaznik";
            txtPolaznik.Size = new Size(196, 25);
            txtPolaznik.TabIndex = 3;
            // 
            // numOcena
            // 
            numOcena.Location = new Point(79, 57);
            numOcena.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numOcena.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numOcena.Name = "numOcena";
            numOcena.Size = new Size(197, 25);
            numOcena.TabIndex = 4;
            numOcena.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // cmdSnimi
            // 
            cmdSnimi.BackColor = Color.MidnightBlue;
            cmdSnimi.ForeColor = Color.White;
            cmdSnimi.Location = new Point(12, 98);
            cmdSnimi.Name = "cmdSnimi";
            cmdSnimi.Size = new Size(264, 29);
            cmdSnimi.TabIndex = 5;
            cmdSnimi.Text = "Snimi";
            cmdSnimi.UseVisualStyleBackColor = false;
            cmdSnimi.Click += cmdSnimi_Click;
            // 
            // DodajIzmeniPrisustvoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 129);
            Controls.Add(cmdSnimi);
            Controls.Add(numOcena);
            Controls.Add(txtPolaznik);
            Controls.Add(cmbPolaznici);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.MidnightBlue;
            Name = "DodajIzmeniPrisustvoForm";
            Load += DodajIzmeniPrisustvoForm_Load;
            ((System.ComponentModel.ISupportInitialize)numOcena).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbPolaznici;
        private TextBox txtPolaznik;
        private NumericUpDown numOcena;
        private Button cmdSnimi;
    }
}