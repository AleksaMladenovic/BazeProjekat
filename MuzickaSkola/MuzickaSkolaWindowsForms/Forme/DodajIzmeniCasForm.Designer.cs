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
            dtpTermin.Location = new Point(78, 11);
            dtpTermin.Name = "dtpTermin";
            dtpTermin.Size = new Size(170, 23);
            dtpTermin.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 17);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Termin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 43);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Tema:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 73);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 3;
            label3.Text = "Nastavnik:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 102);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Učionica:";
            // 
            // txtTema
            // 
            txtTema.Location = new Point(78, 40);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(170, 23);
            txtTema.TabIndex = 5;
            // 
            // cmbNastavnici
            // 
            cmbNastavnici.FormattingEnabled = true;
            cmbNastavnici.Location = new Point(78, 70);
            cmbNastavnici.Name = "cmbNastavnici";
            cmbNastavnici.Size = new Size(170, 23);
            cmbNastavnici.TabIndex = 6;
            // 
            // cmbUcionice
            // 
            cmbUcionice.FormattingEnabled = true;
            cmbUcionice.Location = new Point(78, 99);
            cmbUcionice.Name = "cmbUcionice";
            cmbUcionice.Size = new Size(170, 23);
            cmbUcionice.TabIndex = 7;
            // 
            // cmdSacuvaj
            // 
            cmdSacuvaj.Location = new Point(16, 128);
            cmdSacuvaj.Name = "cmdSacuvaj";
            cmdSacuvaj.Size = new Size(232, 23);
            cmdSacuvaj.TabIndex = 8;
            cmdSacuvaj.Text = "Sačuvaj";
            cmdSacuvaj.UseVisualStyleBackColor = true;
            cmdSacuvaj.Click += cmdSacuvaj_Click;
            // 
            // DodajIzmeniCasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 162);
            Controls.Add(cmdSacuvaj);
            Controls.Add(cmbUcionice);
            Controls.Add(cmbNastavnici);
            Controls.Add(txtTema);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpTermin);
            Name = "DodajIzmeniCasForm";
            Text = "DodajIzmeniCasForm";
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