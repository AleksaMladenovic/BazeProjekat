namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmeniCasForm
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
            dtpTermin = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTema = new TextBox();
            cmbNastavnici = new ComboBox();
            cmbUcionice = new ComboBox();
            cmdSacuvaj = new Button();
            SuspendLayout();
            // 
            // dtpTermin
            // 
            dtpTermin.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpTermin.Format = DateTimePickerFormat.Custom;
            dtpTermin.Location = new Point(89, 11);
            dtpTermin.Name = "dtpTermin";
            dtpTermin.Size = new Size(194, 25);
            dtpTermin.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(29, 17);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 1;
            label1.Text = "Termin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(38, 43);
            label2.Name = "label2";
            label2.Size = new Size(43, 17);
            label2.TabIndex = 2;
            label2.Text = "Tema:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(11, 73);
            label3.Name = "label3";
            label3.Size = new Size(72, 17);
            label3.TabIndex = 3;
            label3.Text = "Nastavnik:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(18, 102);
            label4.Name = "label4";
            label4.Size = new Size(61, 17);
            label4.TabIndex = 4;
            label4.Text = "Učionica:";
            // 
            // txtTema
            // 
            txtTema.Location = new Point(89, 40);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(194, 25);
            txtTema.TabIndex = 5;
            // 
            // cmbNastavnici
            // 
            cmbNastavnici.FormattingEnabled = true;
            cmbNastavnici.Location = new Point(89, 70);
            cmbNastavnici.Name = "cmbNastavnici";
            cmbNastavnici.Size = new Size(194, 25);
            cmbNastavnici.TabIndex = 6;
            // 
            // cmbUcionice
            // 
            cmbUcionice.FormattingEnabled = true;
            cmbUcionice.Location = new Point(89, 99);
            cmbUcionice.Name = "cmbUcionice";
            cmbUcionice.Size = new Size(194, 25);
            cmbUcionice.TabIndex = 7;
            // 
            // cmdSacuvaj
            // 
            cmdSacuvaj.BackColor = Color.MidnightBlue;
            cmdSacuvaj.ForeColor = Color.White;
            cmdSacuvaj.Location = new Point(18, 128);
            cmdSacuvaj.Name = "cmdSacuvaj";
            cmdSacuvaj.Size = new Size(265, 31);
            cmdSacuvaj.TabIndex = 8;
            cmdSacuvaj.Text = "Sačuvaj";
            cmdSacuvaj.UseVisualStyleBackColor = false;
            cmdSacuvaj.Click += cmdSacuvaj_Click;
            // 
            // DodajIzmeniCasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 162);
            Controls.Add(cmdSacuvaj);
            Controls.Add(cmbUcionice);
            Controls.Add(cmbNastavnici);
            Controls.Add(txtTema);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpTermin);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.White;
            Name = "DodajIzmeniCasForm";
            Load += DodajIzmeniCasForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpTermin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTema;
        private ComboBox cmbNastavnici;
        private ComboBox cmbUcionice;
        private Button cmdSacuvaj;
    }
}