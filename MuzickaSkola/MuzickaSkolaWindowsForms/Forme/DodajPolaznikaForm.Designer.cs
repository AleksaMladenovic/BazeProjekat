namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajPolaznikaForm
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
            gbDodaj = new GroupBox();
            rbOdrasli = new RadioButton();
            rbDete = new RadioButton();
            tbEmail = new TextBox();
            tbTelefon = new TextBox();
            tbAdresa = new TextBox();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbJMBG = new TextBox();
            label7 = new Label();
            pnlDynamic = new Panel();
            btnDodaj = new Button();
            gbDodaj.SuspendLayout();
            SuspendLayout();
            // 
            // gbDodaj
            // 
            gbDodaj.Controls.Add(rbOdrasli);
            gbDodaj.Controls.Add(rbDete);
            gbDodaj.Controls.Add(tbEmail);
            gbDodaj.Controls.Add(tbTelefon);
            gbDodaj.Controls.Add(tbAdresa);
            gbDodaj.Controls.Add(tbPrezime);
            gbDodaj.Controls.Add(tbIme);
            gbDodaj.Controls.Add(label6);
            gbDodaj.Controls.Add(label5);
            gbDodaj.Controls.Add(label4);
            gbDodaj.Controls.Add(label3);
            gbDodaj.Controls.Add(label2);
            gbDodaj.Controls.Add(label1);
            gbDodaj.Controls.Add(tbJMBG);
            gbDodaj.Controls.Add(label7);
            gbDodaj.Controls.Add(pnlDynamic);
            gbDodaj.Controls.Add(btnDodaj);
            gbDodaj.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            gbDodaj.ForeColor = Color.MidnightBlue;
            gbDodaj.Location = new Point(12, 14);
            gbDodaj.Name = "gbDodaj";
            gbDodaj.Size = new Size(660, 300);
            gbDodaj.TabIndex = 0;
            gbDodaj.TabStop = false;
            gbDodaj.Text = "Dodaj Polaznika";
            // 
            // rbOdrasli
            // 
            rbOdrasli.AutoSize = true;
            rbOdrasli.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            rbOdrasli.ForeColor = Color.MidnightBlue;
            rbOdrasli.Location = new Point(136, 22);
            rbOdrasli.Name = "rbOdrasli";
            rbOdrasli.Size = new Size(122, 21);
            rbOdrasli.TabIndex = 14;
            rbOdrasli.TabStop = true;
            rbOdrasli.Text = "Odrasli polaznik";
            rbOdrasli.UseVisualStyleBackColor = true;
            rbOdrasli.CheckedChanged += rbOdrasli_CheckedChanged;
            // 
            // rbDete
            // 
            rbDete.AutoSize = true;
            rbDete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            rbDete.ForeColor = Color.MidnightBlue;
            rbDete.Location = new Point(21, 22);
            rbDete.Name = "rbDete";
            rbDete.Size = new Size(108, 21);
            rbDete.TabIndex = 13;
            rbDete.TabStop = true;
            rbDete.Text = "Dete polaznik";
            rbDete.UseVisualStyleBackColor = true;
            rbDete.CheckedChanged += rbDete_CheckedChanged;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(440, 111);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(193, 25);
            tbEmail.TabIndex = 11;
            // 
            // tbTelefon
            // 
            tbTelefon.Location = new Point(440, 78);
            tbTelefon.Name = "tbTelefon";
            tbTelefon.Size = new Size(193, 25);
            tbTelefon.TabIndex = 10;
            // 
            // tbAdresa
            // 
            tbAdresa.Location = new Point(440, 45);
            tbAdresa.Name = "tbAdresa";
            tbAdresa.Size = new Size(193, 25);
            tbAdresa.TabIndex = 9;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(88, 112);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(228, 25);
            tbPrezime.TabIndex = 8;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(88, 81);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(228, 25);
            tbIme.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.MidnightBlue;
            label6.Location = new Point(371, 48);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 6;
            label6.Text = "Adresa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.MidnightBlue;
            label5.Location = new Point(373, 114);
            label5.Name = "label5";
            label5.Size = new Size(40, 17);
            label5.TabIndex = 5;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(371, 81);
            label4.Name = "label4";
            label4.Size = new Size(51, 17);
            label4.TabIndex = 4;
            label4.Text = "Telefon";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(21, 112);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 3;
            label3.Text = "Prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(21, 81);
            label2.Name = "label2";
            label2.Size = new Size(31, 17);
            label2.TabIndex = 2;
            label2.Text = "Ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(21, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 1;
            label1.Text = "JMBG";
            // 
            // tbJMBG
            // 
            tbJMBG.Location = new Point(88, 48);
            tbJMBG.Name = "tbJMBG";
            tbJMBG.Size = new Size(228, 25);
            tbJMBG.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.MidnightBlue;
            label7.Location = new Point(21, 135);
            label7.Name = "label7";
            label7.Size = new Size(100, 17);
            label7.TabIndex = 15;
            label7.Text = "Specifična polja";
            // 
            // pnlDynamic
            // 
            pnlDynamic.BorderStyle = BorderStyle.FixedSingle;
            pnlDynamic.Location = new Point(21, 153);
            pnlDynamic.Name = "pnlDynamic";
            pnlDynamic.Size = new Size(612, 80);
            pnlDynamic.TabIndex = 16;
            // 
            // btnDodaj
            // 
            btnDodaj.BackColor = Color.MidnightBlue;
            btnDodaj.ForeColor = Color.White;
            btnDodaj.Location = new Point(232, 250);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(195, 35);
            btnDodaj.TabIndex = 12;
            btnDodaj.Text = "Dodaj polaznika";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // DodajPolaznikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 326);
            Controls.Add(gbDodaj);
            Name = "DodajPolaznikaForm";
            Load += DodajPolaznikaForm_Load;
            gbDodaj.ResumeLayout(false);
            gbDodaj.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDodaj;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbJMBG;
        private Button btnDodaj;
        private TextBox tbEmail;
        private TextBox tbTelefon;
        private TextBox tbAdresa;
        private TextBox tbPrezime;
        private TextBox tbIme;
        private RadioButton rbOdrasli;
        private RadioButton rbDete;
        private Label label7;
        private Panel pnlDynamic;
    }
}