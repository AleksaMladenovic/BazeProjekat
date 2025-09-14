namespace MuzickaSkolaWindowsForms.Forme
{
    partial class KurseviForm
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
            panel1 = new Panel();
            labelNaslov = new Label();
            listViewKursevi = new ListView();
            chId = new ColumnHeader();
            chNazivKursa = new ColumnHeader();
            chNivo = new ColumnHeader();
            chTipKursa = new ColumnHeader();
            chNastavnik = new ColumnHeader();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            button4 = new Button();
            button5 = new Button();
            cmdLokacijeOdrzavanja = new Button();
            cmdNastavniBlokovi = new Button();
            groupBox3 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            cmdObrisiKurs = new Button();
            cmdIzmeniKurs = new Button();
            cmdDodajKurs = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(listViewKursevi);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(920, 450);
            splitContainer1.SplitterDistance = 703;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 87);
            panel1.TabIndex = 2;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(257, 21);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(165, 33);
            labelNaslov.TabIndex = 1;
            labelNaslov.Text = "Lista kurseva";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // listViewKursevi
            // 
            listViewKursevi.Columns.AddRange(new ColumnHeader[] { chId, chNazivKursa, chNivo, chTipKursa, chNastavnik });
            listViewKursevi.Dock = DockStyle.Bottom;
            listViewKursevi.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            listViewKursevi.ForeColor = Color.MidnightBlue;
            listViewKursevi.FullRowSelect = true;
            listViewKursevi.GridLines = true;
            listViewKursevi.Location = new Point(0, 93);
            listViewKursevi.Name = "listViewKursevi";
            listViewKursevi.OwnerDraw = true;
            listViewKursevi.Size = new Size(703, 357);
            listViewKursevi.TabIndex = 1;
            listViewKursevi.UseCompatibleStateImageBehavior = false;
            listViewKursevi.View = View.Details;
            listViewKursevi.DrawColumnHeader += listViewKursevi_DrawColumnHeader;
            listViewKursevi.DrawItem += listViewKursevi_DrawItem;
            listViewKursevi.SelectedIndexChanged += listViewKursevi_SelectedIndexChanged;
            // 
            // chId
            // 
            chId.Text = "ID";
            chId.Width = 50;
            // 
            // chNazivKursa
            // 
            chNazivKursa.Text = "Naziv kursa";
            chNazivKursa.TextAlign = HorizontalAlignment.Center;
            chNazivKursa.Width = 250;
            // 
            // chNivo
            // 
            chNivo.Text = "Nivo";
            chNivo.TextAlign = HorizontalAlignment.Center;
            chNivo.Width = 100;
            // 
            // chTipKursa
            // 
            chTipKursa.Text = "Tip kursa";
            chTipKursa.TextAlign = HorizontalAlignment.Center;
            chTipKursa.Width = 150;
            // 
            // chNastavnik
            // 
            chNastavnik.Text = "Nastavnik";
            chNastavnik.TextAlign = HorizontalAlignment.Center;
            chNastavnik.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(cmdLokacijeOdrzavanja);
            groupBox2.Controls.Add(cmdNastavniBlokovi);
            groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.MidnightBlue;
            groupBox2.Location = new Point(3, 116);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(207, 78);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalji o selektovanom kursu";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button5);
            groupBox4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox4.ForeColor = Color.MidnightBlue;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(207, 78);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Detalji o selektovanom kursu";
            // 
            // button4
            // 
            button4.BackColor = Color.MidnightBlue;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(6, 48);
            button4.Name = "button4";
            button4.Size = new Size(195, 30);
            button4.TabIndex = 1;
            button4.Text = "Lokacije održavanja";
            button4.UseVisualStyleBackColor = false;
            button4.Click += cmdLokacijeOdrzavanja_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.MidnightBlue;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(6, 19);
            button5.Name = "button5";
            button5.Size = new Size(195, 23);
            button5.TabIndex = 0;
            button5.Text = "Nastavni blokovi";
            button5.UseVisualStyleBackColor = false;
            button5.Click += cmdNastavniBlokovi_Click;
            // 
            // cmdLokacijeOdrzavanja
            // 
            cmdLokacijeOdrzavanja.Location = new Point(6, 48);
            cmdLokacijeOdrzavanja.Name = "cmdLokacijeOdrzavanja";
            cmdLokacijeOdrzavanja.Size = new Size(195, 23);
            cmdLokacijeOdrzavanja.TabIndex = 1;
            cmdLokacijeOdrzavanja.Text = "Lokacije održavanja";
            cmdLokacijeOdrzavanja.UseVisualStyleBackColor = true;
            cmdLokacijeOdrzavanja.Click += cmdLokacijeOdrzavanja_Click;
            // 
            // cmdNastavniBlokovi
            // 
            cmdNastavniBlokovi.Location = new Point(6, 19);
            cmdNastavniBlokovi.Name = "cmdNastavniBlokovi";
            cmdNastavniBlokovi.Size = new Size(195, 23);
            cmdNastavniBlokovi.TabIndex = 0;
            cmdNastavniBlokovi.Text = "Nastavni blokovi";
            cmdNastavniBlokovi.UseVisualStyleBackColor = true;
            cmdNastavniBlokovi.Click += cmdNastavniBlokovi_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button3);
            groupBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox3.ForeColor = Color.MidnightBlue;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(207, 107);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Osnovne akcije";
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(6, 76);
            button1.Name = "button1";
            button1.Size = new Size(195, 23);
            button1.TabIndex = 2;
            button1.Text = "Obriši kurs";
            button1.UseVisualStyleBackColor = false;
            button1.Click += cmdObrisiKurs_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MidnightBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(6, 47);
            button2.Name = "button2";
            button2.Size = new Size(195, 23);
            button2.TabIndex = 1;
            button2.Text = "Izmeni kurs";
            button2.UseVisualStyleBackColor = false;
            button2.Click += cmdIzmeniKurs_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.MidnightBlue;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(6, 18);
            button3.Name = "button3";
            button3.Size = new Size(195, 23);
            button3.TabIndex = 0;
            button3.Text = "Dodaj novi kurs";
            button3.UseVisualStyleBackColor = false;
            button3.Click += cmdDodajKurs_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdObrisiKurs);
            groupBox1.Controls.Add(cmdIzmeniKurs);
            groupBox1.Controls.Add(cmdDodajKurs);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(207, 107);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Osnovne akcije";
            // 
            // cmdObrisiKurs
            // 
            cmdObrisiKurs.Location = new Point(6, 76);
            cmdObrisiKurs.Name = "cmdObrisiKurs";
            cmdObrisiKurs.Size = new Size(195, 23);
            cmdObrisiKurs.TabIndex = 2;
            cmdObrisiKurs.Text = "Obrisi kurs";
            cmdObrisiKurs.UseVisualStyleBackColor = true;
            cmdObrisiKurs.Click += cmdObrisiKurs_Click;
            // 
            // cmdIzmeniKurs
            // 
            cmdIzmeniKurs.Location = new Point(6, 47);
            cmdIzmeniKurs.Name = "cmdIzmeniKurs";
            cmdIzmeniKurs.Size = new Size(195, 23);
            cmdIzmeniKurs.TabIndex = 1;
            cmdIzmeniKurs.Text = "Izmeni kurs";
            cmdIzmeniKurs.UseVisualStyleBackColor = true;
            cmdIzmeniKurs.Click += cmdIzmeniKurs_Click;
            // 
            // cmdDodajKurs
            // 
            cmdDodajKurs.Location = new Point(6, 18);
            cmdDodajKurs.Name = "cmdDodajKurs";
            cmdDodajKurs.Size = new Size(195, 23);
            cmdDodajKurs.TabIndex = 0;
            cmdDodajKurs.Text = "Dodaj novi kurs";
            cmdDodajKurs.UseVisualStyleBackColor = true;
            cmdDodajKurs.Click += cmdDodajKurs_Click;
            // 
            // KurseviForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 450);
            Controls.Add(splitContainer1);
            Name = "KurseviForm";
            Load += KurseviForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListView listViewKursevi;
        private ColumnHeader chId;
        private ColumnHeader chNazivKursa;
        private ColumnHeader chNivo;
        private ColumnHeader chTipKursa;
        private ColumnHeader chNastavnik;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button cmdObrisiKurs;
        private Button cmdIzmeniKurs;
        private Button cmdDodajKurs;
        private Button cmdNastavniBlokovi;
        private Button cmdLokacijeOdrzavanja;
        private Panel panel1;
        private Label labelNaslov;
        private GroupBox groupBox4;
        private Button button4;
        private Button button5;
        private GroupBox groupBox3;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}