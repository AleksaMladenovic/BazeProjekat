namespace MuzickaSkolaWindowsForms.Mapiranja
{
    partial class NastavaForm
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
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            cmdObrisiNastavu = new Button();
            cmdIzmeniNastavu = new Button();
            cmdDodajNastavu = new Button();
            listViewNastava = new ListView();
            chId = new ColumnHeader();
            chDatumOd = new ColumnHeader();
            chDatumDo = new ColumnHeader();
            Tip = new ColumnHeader();
            lblInfoKursa = new Label();
            label1 = new Label();
            cmdUkloniPrisustvo = new Button();
            cmdIzmeniOcenu = new Button();
            cmdDodajPrisustvo = new Button();
            listViewPrisustvo = new ListView();
            chIme = new ColumnHeader();
            chPrezime = new ColumnHeader();
            chOcena = new ColumnHeader();
            cmdObrisiCas = new Button();
            cmdIzmeniCas = new Button();
            cmdDodajCas = new Button();
            listViewCasovi = new ListView();
            chIdCasa = new ColumnHeader();
            chTermin = new ColumnHeader();
            chTema = new ColumnHeader();
            chNastavnik = new ColumnHeader();
            chUcionica = new ColumnHeader();
            lblInfoNastava = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(lblInfoKursa);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(cmdUkloniPrisustvo);
            splitContainer1.Panel2.Controls.Add(cmdIzmeniOcenu);
            splitContainer1.Panel2.Controls.Add(cmdDodajPrisustvo);
            splitContainer1.Panel2.Controls.Add(listViewPrisustvo);
            splitContainer1.Panel2.Controls.Add(cmdObrisiCas);
            splitContainer1.Panel2.Controls.Add(cmdIzmeniCas);
            splitContainer1.Panel2.Controls.Add(cmdDodajCas);
            splitContainer1.Panel2.Controls.Add(listViewCasovi);
            splitContainer1.Panel2.Controls.Add(lblInfoNastava);
            splitContainer1.Size = new Size(921, 538);
            splitContainer1.SplitterDistance = 381;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdObrisiNastavu);
            groupBox1.Controls.Add(cmdIzmeniNastavu);
            groupBox1.Controls.Add(cmdDodajNastavu);
            groupBox1.Controls.Add(listViewNastava);
            groupBox1.Location = new Point(3, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 499);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nastavni blokovi";
            // 
            // cmdObrisiNastavu
            // 
            cmdObrisiNastavu.BackColor = Color.MidnightBlue;
            cmdObrisiNastavu.FlatAppearance.BorderSize = 0;
            cmdObrisiNastavu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdObrisiNastavu.FlatStyle = FlatStyle.Flat;
            cmdObrisiNastavu.ForeColor = Color.White;
            cmdObrisiNastavu.Location = new Point(282, 470);
            cmdObrisiNastavu.Name = "cmdObrisiNastavu";
            cmdObrisiNastavu.Size = new Size(86, 30);
            cmdObrisiNastavu.TabIndex = 3;
            cmdObrisiNastavu.Text = "Obriši";
            cmdObrisiNastavu.UseVisualStyleBackColor = false;
            cmdObrisiNastavu.Click += cmdObrisiNastavu_Click;
            // 
            // cmdIzmeniNastavu
            // 
            cmdIzmeniNastavu.BackColor = Color.MidnightBlue;
            cmdIzmeniNastavu.FlatAppearance.BorderSize = 0;
            cmdIzmeniNastavu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdIzmeniNastavu.FlatStyle = FlatStyle.Flat;
            cmdIzmeniNastavu.ForeColor = Color.White;
            cmdIzmeniNastavu.Location = new Point(173, 470);
            cmdIzmeniNastavu.Name = "cmdIzmeniNastavu";
            cmdIzmeniNastavu.Size = new Size(86, 30);
            cmdIzmeniNastavu.TabIndex = 2;
            cmdIzmeniNastavu.Text = "Izmeni";
            cmdIzmeniNastavu.UseVisualStyleBackColor = false;
            cmdIzmeniNastavu.Click += cmdIzmeniNastavu_Click;
            // 
            // cmdDodajNastavu
            // 
            cmdDodajNastavu.BackColor = Color.MidnightBlue;
            cmdDodajNastavu.FlatAppearance.BorderSize = 0;
            cmdDodajNastavu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdDodajNastavu.FlatStyle = FlatStyle.Flat;
            cmdDodajNastavu.ForeColor = Color.White;
            cmdDodajNastavu.Location = new Point(65, 470);
            cmdDodajNastavu.Name = "cmdDodajNastavu";
            cmdDodajNastavu.Size = new Size(86, 30);
            cmdDodajNastavu.TabIndex = 1;
            cmdDodajNastavu.Text = "Dodaj";
            cmdDodajNastavu.UseVisualStyleBackColor = false;
            cmdDodajNastavu.Click += cmdDodajNastavu_Click;
            // 
            // listViewNastava
            // 
            listViewNastava.Columns.AddRange(new ColumnHeader[] { chId, chDatumOd, chDatumDo, Tip });
            listViewNastava.FullRowSelect = true;
            listViewNastava.Location = new Point(10, 0);
            listViewNastava.Name = "listViewNastava";
            listViewNastava.Size = new Size(420, 464);
            listViewNastava.TabIndex = 0;
            listViewNastava.UseCompatibleStateImageBehavior = false;
            listViewNastava.View = View.Details;
            listViewNastava.SelectedIndexChanged += listViewNastava_SelectedIndexChanged;
            // 
            // chId
            // 
            chId.Text = "Id";
            // 
            // chDatumOd
            // 
            chDatumOd.Text = "Datum Od";
            chDatumOd.Width = 100;
            // 
            // chDatumDo
            // 
            chDatumDo.Text = "Datum Do";
            chDatumDo.Width = 100;
            // 
            // Tip
            // 
            Tip.Text = "Tip Nastave";
            Tip.Width = 100;
            // 
            // lblInfoKursa
            // 
            lblInfoKursa.AutoSize = true;
            lblInfoKursa.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblInfoKursa.ForeColor = Color.MidnightBlue;
            lblInfoKursa.Location = new Point(14, 9);
            lblInfoKursa.Name = "lblInfoKursa";
            lblInfoKursa.Size = new Size(69, 17);
            lblInfoKursa.TabIndex = 0;
            lblInfoKursa.Text = "Info kursa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(3, 258);
            label1.Name = "label1";
            label1.Size = new Size(222, 17);
            label1.TabIndex = 11;
            label1.Text = "Prisutni polaznici za selektovani čas";
            // 
            // cmdUkloniPrisustvo
            // 
            cmdUkloniPrisustvo.BackColor = Color.MidnightBlue;
            cmdUkloniPrisustvo.FlatAppearance.BorderSize = 0;
            cmdUkloniPrisustvo.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdUkloniPrisustvo.FlatStyle = FlatStyle.Flat;
            cmdUkloniPrisustvo.ForeColor = Color.White;
            cmdUkloniPrisustvo.Location = new Point(344, 497);
            cmdUkloniPrisustvo.Name = "cmdUkloniPrisustvo";
            cmdUkloniPrisustvo.Size = new Size(128, 30);
            cmdUkloniPrisustvo.TabIndex = 10;
            cmdUkloniPrisustvo.Text = "Ukloni prisustvo";
            cmdUkloniPrisustvo.UseVisualStyleBackColor = false;
            cmdUkloniPrisustvo.Click += cmdUkloniPrisustvo_Click;
            // 
            // cmdIzmeniOcenu
            // 
            cmdIzmeniOcenu.BackColor = Color.MidnightBlue;
            cmdIzmeniOcenu.FlatAppearance.BorderSize = 0;
            cmdIzmeniOcenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdIzmeniOcenu.FlatStyle = FlatStyle.Flat;
            cmdIzmeniOcenu.ForeColor = Color.White;
            cmdIzmeniOcenu.Location = new Point(221, 497);
            cmdIzmeniOcenu.Name = "cmdIzmeniOcenu";
            cmdIzmeniOcenu.Size = new Size(117, 30);
            cmdIzmeniOcenu.TabIndex = 9;
            cmdIzmeniOcenu.Text = "Izmeni ocenu";
            cmdIzmeniOcenu.UseVisualStyleBackColor = false;
            cmdIzmeniOcenu.Click += cmdIzmeniOcenu_Click;
            // 
            // cmdDodajPrisustvo
            // 
            cmdDodajPrisustvo.BackColor = Color.MidnightBlue;
            cmdDodajPrisustvo.FlatAppearance.BorderSize = 0;
            cmdDodajPrisustvo.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdDodajPrisustvo.FlatStyle = FlatStyle.Flat;
            cmdDodajPrisustvo.ForeColor = Color.White;
            cmdDodajPrisustvo.Location = new Point(96, 497);
            cmdDodajPrisustvo.Name = "cmdDodajPrisustvo";
            cmdDodajPrisustvo.Size = new Size(119, 30);
            cmdDodajPrisustvo.TabIndex = 8;
            cmdDodajPrisustvo.Text = "Dodaj prisustvo";
            cmdDodajPrisustvo.UseVisualStyleBackColor = false;
            cmdDodajPrisustvo.Click += cmdDodajPrisustvo_Click;
            // 
            // listViewPrisustvo
            // 
            listViewPrisustvo.Columns.AddRange(new ColumnHeader[] { chIme, chPrezime, chOcena });
            listViewPrisustvo.FullRowSelect = true;
            listViewPrisustvo.Location = new Point(3, 276);
            listViewPrisustvo.Name = "listViewPrisustvo";
            listViewPrisustvo.Size = new Size(611, 215);
            listViewPrisustvo.TabIndex = 7;
            listViewPrisustvo.UseCompatibleStateImageBehavior = false;
            listViewPrisustvo.View = View.Details;
            listViewPrisustvo.SelectedIndexChanged += listViewPrisustvo_SelectedIndexChanged;
            // 
            // chIme
            // 
            chIme.Text = "Ime";
            chIme.Width = 120;
            // 
            // chPrezime
            // 
            chPrezime.Text = "Prezime";
            chPrezime.Width = 200;
            // 
            // chOcena
            // 
            chOcena.Text = "Ocena";
            // 
            // cmdObrisiCas
            // 
            cmdObrisiCas.BackColor = Color.MidnightBlue;
            cmdObrisiCas.FlatAppearance.BorderSize = 0;
            cmdObrisiCas.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdObrisiCas.FlatStyle = FlatStyle.Flat;
            cmdObrisiCas.ForeColor = Color.White;
            cmdObrisiCas.Location = new Point(344, 222);
            cmdObrisiCas.Name = "cmdObrisiCas";
            cmdObrisiCas.Size = new Size(86, 30);
            cmdObrisiCas.TabIndex = 6;
            cmdObrisiCas.Text = "Obriši";
            cmdObrisiCas.UseVisualStyleBackColor = false;
            cmdObrisiCas.Click += cmdObrisiCas_Click;
            // 
            // cmdIzmeniCas
            // 
            cmdIzmeniCas.BackColor = Color.MidnightBlue;
            cmdIzmeniCas.FlatAppearance.BorderSize = 0;
            cmdIzmeniCas.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdIzmeniCas.FlatStyle = FlatStyle.Flat;
            cmdIzmeniCas.ForeColor = Color.White;
            cmdIzmeniCas.Location = new Point(239, 222);
            cmdIzmeniCas.Name = "cmdIzmeniCas";
            cmdIzmeniCas.Size = new Size(86, 30);
            cmdIzmeniCas.TabIndex = 5;
            cmdIzmeniCas.Text = "Izmeni";
            cmdIzmeniCas.UseVisualStyleBackColor = false;
            cmdIzmeniCas.Click += cmdIzmeniCas_Click;
            // 
            // cmdDodajCas
            // 
            cmdDodajCas.BackColor = Color.MidnightBlue;
            cmdDodajCas.FlatAppearance.BorderSize = 0;
            cmdDodajCas.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdDodajCas.FlatStyle = FlatStyle.Flat;
            cmdDodajCas.ForeColor = Color.White;
            cmdDodajCas.Location = new Point(129, 222);
            cmdDodajCas.Name = "cmdDodajCas";
            cmdDodajCas.Size = new Size(86, 30);
            cmdDodajCas.TabIndex = 4;
            cmdDodajCas.Text = "Dodaj";
            cmdDodajCas.UseVisualStyleBackColor = false;
            cmdDodajCas.Click += cmdDodajCas_Click;
            // 
            // listViewCasovi
            // 
            listViewCasovi.Columns.AddRange(new ColumnHeader[] { chIdCasa, chTermin, chTema, chNastavnik, chUcionica });
            listViewCasovi.FullRowSelect = true;
            listViewCasovi.Location = new Point(3, 27);
            listViewCasovi.Name = "listViewCasovi";
            listViewCasovi.Size = new Size(611, 189);
            listViewCasovi.TabIndex = 1;
            listViewCasovi.UseCompatibleStateImageBehavior = false;
            listViewCasovi.View = View.Details;
            listViewCasovi.SelectedIndexChanged += listViewCasovi_SelectedIndexChanged;
            // 
            // chIdCasa
            // 
            chIdCasa.Text = "Id ";
            // 
            // chTermin
            // 
            chTermin.Text = "Termin";
            chTermin.Width = 140;
            // 
            // chTema
            // 
            chTema.Text = "Tema Časa";
            chTema.Width = 100;
            // 
            // chNastavnik
            // 
            chNastavnik.Text = "Nastavnik";
            chNastavnik.Width = 130;
            // 
            // chUcionica
            // 
            chUcionica.Text = "Učionica";
            chUcionica.Width = 100;
            // 
            // lblInfoNastava
            // 
            lblInfoNastava.AutoSize = true;
            lblInfoNastava.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblInfoNastava.ForeColor = Color.MidnightBlue;
            lblInfoNastava.Location = new Point(3, 9);
            lblInfoNastava.Name = "lblInfoNastava";
            lblInfoNastava.Size = new Size(85, 17);
            lblInfoNastava.TabIndex = 0;
            lblInfoNastava.Text = "Info Nastava";
            // 
            // NastavaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 538);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.MidnightBlue;
            Name = "NastavaForm";
            Load += NastavaForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblInfoKursa;
        private GroupBox groupBox1;
        private Button cmdDodajNastavu;
        private ListView listViewNastava;
        private ColumnHeader chId;
        private ColumnHeader chDatumOd;
        private ColumnHeader chDatumDo;
        private ColumnHeader Tip;
        private Button cmdObrisiNastavu;
        private Button cmdIzmeniNastavu;
        private Button cmdObrisiCas;
        private Button cmdIzmeniCas;
        private Button cmdDodajCas;
        private ListView listViewCasovi;
        private ColumnHeader chIdCasa;
        private ColumnHeader chTermin;
        private ColumnHeader chTema;
        private ColumnHeader chNastavnik;
        private Label lblInfoNastava;
        private ColumnHeader chUcionica;
        private Button cmdUkloniPrisustvo;
        private Button cmdIzmeniOcenu;
        private Button cmdDodajPrisustvo;
        private ListView listViewPrisustvo;
        private ColumnHeader chIme;
        private ColumnHeader chPrezime;
        private ColumnHeader chOcena;
        private Label label1;
    }
}