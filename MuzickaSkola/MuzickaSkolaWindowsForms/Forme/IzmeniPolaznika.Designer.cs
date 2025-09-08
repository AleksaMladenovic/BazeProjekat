namespace MuzickaSkolaWindowsForms.Forme
{
    partial class IzmeniPolaznika
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
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.rbOdrasli = new System.Windows.Forms.RadioButton();
            this.rbDete = new System.Windows.Forms.RadioButton();
            this.tbJMBG = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDynamic = new System.Windows.Forms.Panel();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.gbEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdit
            // 
            this.gbEdit.Location = new System.Drawing.Point(12, 12);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(700, 340);
            this.gbEdit.TabIndex = 0;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Izmena polaznika";
            // 
            // rbDete / rbOdrasli
            // 
            this.rbDete.AutoSize = true;
            this.rbDete.Location = new System.Drawing.Point(20, 22);
            this.rbDete.Name = "rbDete";
            this.rbDete.Size = new System.Drawing.Size(51, 19);
            this.rbDete.TabIndex = 1;
            this.rbDete.TabStop = true;
            this.rbDete.Text = "Dete";
            this.rbDete.UseVisualStyleBackColor = true;
            this.rbDete.Enabled = false;

            this.rbOdrasli.AutoSize = true;
            this.rbOdrasli.Location = new System.Drawing.Point(95, 22);
            this.rbOdrasli.Name = "rbOdrasli";
            this.rbOdrasli.Size = new System.Drawing.Size(63, 19);
            this.rbOdrasli.TabIndex = 2;
            this.rbOdrasli.TabStop = true;
            this.rbOdrasli.Text = "Odrasli";
            this.rbOdrasli.UseVisualStyleBackColor = true;
            this.rbOdrasli.Enabled = false;
            // 
            // labels left
            // 
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 55); this.label1.Text = "JMBG";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 85); this.label2.Text = "Ime";
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 115); this.label3.Text = "Prezime";
            // 
            // fields left
            // 
            this.tbJMBG.Location = new System.Drawing.Point(90, 52); this.tbJMBG.Size = new System.Drawing.Size(230, 23);
            this.tbIme.Location = new System.Drawing.Point(90, 82); this.tbIme.Size = new System.Drawing.Size(230, 23);
            this.tbPrezime.Location = new System.Drawing.Point(90, 112); this.tbPrezime.Size = new System.Drawing.Size(230, 23);
            // 
            // labels right
            // 
            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(360, 55); this.label6.Text = "Adresa";
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(360, 85); this.label4.Text = "Telefon";
            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(360, 115); this.label5.Text = "Email";
            // 
            // fields right
            // 
            this.tbAdresa.Location = new System.Drawing.Point(420, 52); this.tbAdresa.Size = new System.Drawing.Size(250, 23);
            this.tbTelefon.Location = new System.Drawing.Point(420, 82); this.tbTelefon.Size = new System.Drawing.Size(250, 23);
            this.tbEmail.Location = new System.Drawing.Point(420, 112); this.tbEmail.Size = new System.Drawing.Size(250, 23);
            // 
            // dynamic header + panel
            // 
            this.label7.AutoSize = true; this.label7.Location = new System.Drawing.Point(20, 145); this.label7.Text = "Specifična polja";
            this.pnlDynamic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDynamic.Location = new System.Drawing.Point(20, 165);
            this.pnlDynamic.Name = "pnlDynamic";
            this.pnlDynamic.Size = new System.Drawing.Size(650, 90);
            // 
            // buttons
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(370, 270);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(150, 35);
            this.btnSacuvaj.TabIndex = 50;
            this.btnSacuvaj.Text = "Sačuvaj izmene";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);

            this.btnOdustani.Location = new System.Drawing.Point(520, 270);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(150, 35);
            this.btnOdustani.TabIndex = 51;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // add controls to groupbox
            // 
            this.gbEdit.Controls.AddRange(new System.Windows.Forms.Control[] {
        this.rbDete, this.rbOdrasli,
        this.label1, this.tbJMBG, this.label2, this.tbIme, this.label3, this.tbPrezime,
        this.label6, this.tbAdresa, this.label4, this.tbTelefon, this.label5, this.tbEmail,
        this.label7, this.pnlDynamic, this.btnSacuvaj, this.btnOdustani
    });
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 364);
            this.Controls.Add(this.gbEdit);
            this.Name = "IzmeniPolaznika";
            this.Text = "Izmeni polaznika";
            this.Load += new System.EventHandler(this.IzmeniPolaznikaForm_Load);
            this.gbEdit.ResumeLayout(false);
            this.gbEdit.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox gbEdit;
        private RadioButton rbOdrasli;
        private RadioButton rbDete;
        private TextBox tbJMBG, tbIme, tbPrezime, tbAdresa, tbTelefon, tbEmail;
        private Label label1, label2, label3, label4, label5, label6, label7;
        private Panel pnlDynamic;
        private Button btnSacuvaj, btnOdustani;
    }
}