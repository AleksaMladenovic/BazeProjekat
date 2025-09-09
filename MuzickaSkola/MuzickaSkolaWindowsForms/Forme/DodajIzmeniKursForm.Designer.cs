namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmeniKursForm
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
            txtNaziv = new TextBox();
            txtNivo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbNastavnici = new ComboBox();
            cmbTipKursa = new ComboBox();
            pnlInstrument = new Panel();
            txtInstrument = new TextBox();
            label5 = new Label();
            pnlGrupaInstrumenata = new Panel();
            txtGrupaInstrumenata = new TextBox();
            label6 = new Label();
            pnlMuzickaTeorija = new Panel();
            txtNazivPredmeta = new TextBox();
            label7 = new Label();
            cmdSacuvaj = new Button();
            pnlInstrument.SuspendLayout();
            pnlGrupaInstrumenata.SuspendLayout();
            pnlMuzickaTeorija.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv kursa:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(98, 6);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(194, 23);
            txtNaziv.TabIndex = 1;
            // 
            // txtNivo
            // 
            txtNivo.Location = new Point(98, 36);
            txtNivo.Name = "txtNivo";
            txtNivo.Size = new Size(194, 23);
            txtNivo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 39);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 2;
            label2.Text = "Nivo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 72);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 4;
            label3.Text = "Nastavnik:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 105);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 6;
            label4.Text = "Tip kursa:";
            // 
            // cmbNastavnici
            // 
            cmbNastavnici.FormattingEnabled = true;
            cmbNastavnici.Location = new Point(98, 69);
            cmbNastavnici.Name = "cmbNastavnici";
            cmbNastavnici.Size = new Size(194, 23);
            cmbNastavnici.TabIndex = 8;
            // 
            // cmbTipKursa
            // 
            cmbTipKursa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipKursa.FormattingEnabled = true;
            cmbTipKursa.Location = new Point(98, 98);
            cmbTipKursa.Name = "cmbTipKursa";
            cmbTipKursa.Size = new Size(194, 23);
            cmbTipKursa.TabIndex = 9;
            cmbTipKursa.SelectedIndexChanged += cmbTipKursa_SelectedIndexChanged;
            // 
            // pnlInstrument
            // 
            pnlInstrument.Controls.Add(txtInstrument);
            pnlInstrument.Controls.Add(label5);
            pnlInstrument.Location = new Point(3, 127);
            pnlInstrument.Name = "pnlInstrument";
            pnlInstrument.Size = new Size(254, 41);
            pnlInstrument.TabIndex = 10;
            pnlInstrument.Visible = false;
            // 
            // txtInstrument
            // 
            txtInstrument.Location = new Point(95, 6);
            txtInstrument.Name = "txtInstrument";
            txtInstrument.Size = new Size(148, 23);
            txtInstrument.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 9);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 2;
            label5.Text = "Instrument:";
            // 
            // pnlGrupaInstrumenata
            // 
            pnlGrupaInstrumenata.Controls.Add(txtGrupaInstrumenata);
            pnlGrupaInstrumenata.Controls.Add(label6);
            pnlGrupaInstrumenata.Location = new Point(3, 127);
            pnlGrupaInstrumenata.Name = "pnlGrupaInstrumenata";
            pnlGrupaInstrumenata.Size = new Size(292, 41);
            pnlGrupaInstrumenata.TabIndex = 11;
            pnlGrupaInstrumenata.Visible = false;
            // 
            // txtGrupaInstrumenata
            // 
            txtGrupaInstrumenata.Location = new Point(130, 6);
            txtGrupaInstrumenata.Name = "txtGrupaInstrumenata";
            txtGrupaInstrumenata.Size = new Size(159, 23);
            txtGrupaInstrumenata.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 9);
            label6.Name = "label6";
            label6.Size = new Size(115, 15);
            label6.TabIndex = 2;
            label6.Text = "Grupa instrumenata:";
            // 
            // pnlMuzickaTeorija
            // 
            pnlMuzickaTeorija.Controls.Add(txtNazivPredmeta);
            pnlMuzickaTeorija.Controls.Add(label7);
            pnlMuzickaTeorija.Location = new Point(3, 127);
            pnlMuzickaTeorija.Name = "pnlMuzickaTeorija";
            pnlMuzickaTeorija.Size = new Size(292, 41);
            pnlMuzickaTeorija.TabIndex = 12;
            pnlMuzickaTeorija.Visible = false;
            // 
            // txtNazivPredmeta
            // 
            txtNazivPredmeta.Location = new Point(130, 6);
            txtNazivPredmeta.Name = "txtNazivPredmeta";
            txtNazivPredmeta.Size = new Size(159, 23);
            txtNazivPredmeta.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 9);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 2;
            label7.Text = "Naziv predmeta:";
            // 
            // cmdSacuvaj
            // 
            cmdSacuvaj.Location = new Point(12, 174);
            cmdSacuvaj.Name = "cmdSacuvaj";
            cmdSacuvaj.Size = new Size(280, 23);
            cmdSacuvaj.TabIndex = 13;
            cmdSacuvaj.Text = "Sačuvaj";
            cmdSacuvaj.UseVisualStyleBackColor = true;
            cmdSacuvaj.Click += cmdSacuvaj_Click;
            // 
            // DodajIzmeniKursForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 206);
            Controls.Add(cmdSacuvaj);
            Controls.Add(pnlMuzickaTeorija);
            Controls.Add(pnlGrupaInstrumenata);
            Controls.Add(pnlInstrument);
            Controls.Add(cmbTipKursa);
            Controls.Add(cmbNastavnici);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNivo);
            Controls.Add(label2);
            Controls.Add(txtNaziv);
            Controls.Add(label1);
            Name = "DodajIzmeniKursForm";
            Text = "DodajIzmeniKursForm";
            Load += DodajIzmeniKursForm_Load;
            pnlInstrument.ResumeLayout(false);
            pnlInstrument.PerformLayout();
            pnlGrupaInstrumenata.ResumeLayout(false);
            pnlGrupaInstrumenata.PerformLayout();
            pnlMuzickaTeorija.ResumeLayout(false);
            pnlMuzickaTeorija.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNaziv;
        private TextBox txtNivo;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbNastavnici;
        private ComboBox cmbTipKursa;
        private Panel pnlInstrument;
        private TextBox txtInstrument;
        private Label label5;
        private Panel pnlGrupaInstrumenata;
        private TextBox txtGrupaInstrumenata;
        private Label label6;
        private Panel pnlMuzickaTeorija;
        private TextBox txtNazivPredmeta;
        private Label label7;
        private Button cmdSacuvaj;
    }
}