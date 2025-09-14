namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajPolozeniIspitForm
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
            cmbKursevi = new ComboBox();
            label2 = new Label();
            cmbKomisije = new ComboBox();
            label3 = new Label();
            dtpDatum = new DateTimePicker();
            label4 = new Label();
            numOcena = new NumericUpDown();
            chkSertifikat = new CheckBox();
            btnDodaj = new Button();
            btnOtkazi = new Button();
            ((System.ComponentModel.ISupportInitialize)numOcena).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(34, 30);
            label1.Name = "label1";
            label1.Size = new Size(38, 17);
            label1.TabIndex = 0;
            label1.Text = "Kurs:";
            // 
            // cmbKursevi
            // 
            cmbKursevi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKursevi.FormattingEnabled = true;
            cmbKursevi.Location = new Point(160, 27);
            cmbKursevi.Name = "cmbKursevi";
            cmbKursevi.Size = new Size(285, 25);
            cmbKursevi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(34, 70);
            label2.Name = "label2";
            label2.Size = new Size(61, 17);
            label2.TabIndex = 2;
            label2.Text = "Komisija:";
            // 
            // cmbKomisije
            // 
            cmbKomisije.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKomisije.FormattingEnabled = true;
            cmbKomisije.Location = new Point(160, 67);
            cmbKomisije.Name = "cmbKomisije";
            cmbKomisije.Size = new Size(285, 25);
            cmbKomisije.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(34, 110);
            label3.Name = "label3";
            label3.Size = new Size(115, 17);
            label3.TabIndex = 4;
            label3.Text = "Datum polaganja:";
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(160, 104);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(285, 25);
            dtpDatum.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(34, 150);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 6;
            label4.Text = "Ocena:";
            // 
            // numOcena
            // 
            numOcena.Location = new Point(160, 148);
            numOcena.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numOcena.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numOcena.Name = "numOcena";
            numOcena.Size = new Size(137, 25);
            numOcena.TabIndex = 7;
            numOcena.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // chkSertifikat
            // 
            chkSertifikat.AutoSize = true;
            chkSertifikat.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkSertifikat.ForeColor = Color.MidnightBlue;
            chkSertifikat.Location = new Point(160, 188);
            chkSertifikat.Name = "chkSertifikat";
            chkSertifikat.Size = new Size(136, 21);
            chkSertifikat.TabIndex = 8;
            chkSertifikat.Text = "Dodeljen sertifikat";
            chkSertifikat.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(160, 240);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(137, 30);
            btnDodaj.TabIndex = 9;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnOtkazi
            // 
            btnOtkazi.BackColor = Color.MidnightBlue;
            btnOtkazi.ForeColor = Color.White;
            btnOtkazi.Location = new Point(309, 240);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(137, 30);
            btnOtkazi.TabIndex = 10;
            btnOtkazi.Text = "Otkaži";
            btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += btnOtkazi_Click;
            // 
            // DodajPolozeniIspitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 301);
            Controls.Add(btnOtkazi);
            Controls.Add(btnDodaj);
            Controls.Add(chkSertifikat);
            Controls.Add(numOcena);
            Controls.Add(label4);
            Controls.Add(dtpDatum);
            Controls.Add(label3);
            Controls.Add(cmbKomisije);
            Controls.Add(label2);
            Controls.Add(cmbKursevi);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.MidnightBlue;
            Name = "DodajPolozeniIspitForm";
            Load += DodajPolozeniIspitForm_Load;
            ((System.ComponentModel.ISupportInitialize)numOcena).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKursevi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKomisije;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numOcena;
        private System.Windows.Forms.CheckBox chkSertifikat;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnOtkazi;
    }
}