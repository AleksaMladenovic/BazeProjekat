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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKursevi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKomisije = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.numOcena = new System.Windows.Forms.NumericUpDown();
            this.chkSertifikat = new System.Windows.Forms.CheckBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOcena)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kurs:";
            // 
            // cmbKursevi
            // 
            this.cmbKursevi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKursevi.FormattingEnabled = true;
            this.cmbKursevi.Location = new System.Drawing.Point(140, 27);
            this.cmbKursevi.Name = "cmbKursevi";
            this.cmbKursevi.Size = new System.Drawing.Size(250, 21);
            this.cmbKursevi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Komisija:";
            // 
            // cmbKomisije
            // 
            this.cmbKomisije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKomisije.FormattingEnabled = true;
            this.cmbKomisije.Location = new System.Drawing.Point(140, 67);
            this.cmbKomisije.Name = "cmbKomisije";
            this.cmbKomisije.Size = new System.Drawing.Size(250, 21);
            this.cmbKomisije.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datum polaganja:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(140, 104);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(250, 20);
            this.dtpDatum.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ocena:";
            // 
            // numOcena
            // 
            this.numOcena.Location = new System.Drawing.Point(140, 148);
            this.numOcena.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOcena.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numOcena.Name = "numOcena";
            this.numOcena.Size = new System.Drawing.Size(120, 20);
            this.numOcena.TabIndex = 7;
            this.numOcena.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkSertifikat
            // 
            this.chkSertifikat.AutoSize = true;
            this.chkSertifikat.Location = new System.Drawing.Point(140, 188);
            this.chkSertifikat.Name = "chkSertifikat";
            this.chkSertifikat.Size = new System.Drawing.Size(113, 17);
            this.chkSertifikat.TabIndex = 8;
            this.chkSertifikat.Text = "Dodeljen sertifikat";
            this.chkSertifikat.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(140, 240);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(120, 30);
            this.btnDodaj.TabIndex = 9;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(270, 240);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(120, 30);
            this.btnOtkazi.TabIndex = 10;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // DodajPolozeniIspitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 301);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.chkSertifikat);
            this.Controls.Add(this.numOcena);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKomisije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKursevi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DodajPolozeniIspitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj položeni ispit";
            this.Load += new System.EventHandler(this.DodajPolozeniIspitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOcena)).EndInit();
            this.ResumeLayout(false);
            

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