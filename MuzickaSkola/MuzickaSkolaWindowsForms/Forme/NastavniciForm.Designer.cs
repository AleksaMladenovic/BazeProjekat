namespace MuzickaSkolaWindowsForms.Forme
{
    partial class NastavniciForm
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
            listViewNastavnici = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            Komande = new GroupBox();
            btnDodajNastavnika = new Button();
            btnIzmeniNastavnika = new Button();
            btnObrisiNastavnika = new Button();
            groupBox1 = new GroupBox();
            btnDetalji = new Button();
            groupBox2 = new GroupBox();
            btnKomisije = new Button();
            btnUpravljajKomisijama = new Button();
            btnPrikaziCasove = new Button();
            btnDodeliMentora = new Button();
            btnPrikaziKurseve = new Button();
            Komande.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listViewNastavnici
            // 
            listViewNastavnici.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewNastavnici.FullRowSelect = true;
            listViewNastavnici.Location = new Point(12, 12);
            listViewNastavnici.Name = "listViewNastavnici";
            listViewNastavnici.Size = new Size(568, 426);
            listViewNastavnici.TabIndex = 0;
            listViewNastavnici.UseCompatibleStateImageBehavior = false;
            listViewNastavnici.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "JMBG";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Prezime";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Strucna sprema";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip Zaposlenja";
            columnHeader5.Width = 100;
            // 
            // Komande
            // 
            Komande.Controls.Add(btnDodajNastavnika);
            Komande.Controls.Add(btnIzmeniNastavnika);
            Komande.Controls.Add(btnObrisiNastavnika);
            Komande.Location = new Point(586, 12);
            Komande.Name = "Komande";
            Komande.Size = new Size(202, 145);
            Komande.TabIndex = 1;
            Komande.TabStop = false;
            Komande.Text = "Osnovne operacije";
            // 
            // btnDodajNastavnika
            // 
            btnDodajNastavnika.Location = new Point(7, 27);
            btnDodajNastavnika.Name = "btnDodajNastavnika";
            btnDodajNastavnika.Size = new Size(185, 27);
            btnDodajNastavnika.TabIndex = 3;
            btnDodajNastavnika.Text = "Dodaj Nastavnika";
            btnDodajNastavnika.UseVisualStyleBackColor = true;
            btnDodajNastavnika.Click += btnDodajNastavnika_Click;
            // 
            // btnIzmeniNastavnika
            // 
            btnIzmeniNastavnika.Location = new Point(7, 60);
            btnIzmeniNastavnika.Name = "btnIzmeniNastavnika";
            btnIzmeniNastavnika.Size = new Size(185, 30);
            btnIzmeniNastavnika.TabIndex = 2;
            btnIzmeniNastavnika.Text = "Izmeni Nastavnika";
            btnIzmeniNastavnika.UseVisualStyleBackColor = true;
            btnIzmeniNastavnika.Click += btnIzmeniNastavnika_Click;
            // 
            // btnObrisiNastavnika
            // 
            btnObrisiNastavnika.Location = new Point(7, 96);
            btnObrisiNastavnika.Name = "btnObrisiNastavnika";
            btnObrisiNastavnika.Size = new Size(185, 30);
            btnObrisiNastavnika.TabIndex = 1;
            btnObrisiNastavnika.Text = "Obrisi Nastavnika";
            btnObrisiNastavnika.UseVisualStyleBackColor = true;
            btnObrisiNastavnika.Click += btnObrisiNastavnika_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDetalji);
            groupBox1.Location = new Point(586, 163);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(202, 59);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detaljne informacije";
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(6, 22);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(186, 25);
            btnDetalji.TabIndex = 0;
            btnDetalji.Text = "Prikazi Detalje";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnKomisije);
            groupBox2.Controls.Add(btnUpravljajKomisijama);
            groupBox2.Controls.Add(btnPrikaziCasove);
            groupBox2.Controls.Add(btnDodeliMentora);
            groupBox2.Controls.Add(btnPrikaziKurseve);
            groupBox2.Location = new Point(586, 228);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(202, 210);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Slozene funkcionalnosti";
            // 
            // btnKomisije
            // 
            btnKomisije.Location = new Point(6, 170);
            btnKomisije.Name = "btnKomisije";
            btnKomisije.Size = new Size(181, 31);
            btnKomisije.TabIndex = 5;
            btnKomisije.Text = "Komisije i clanovi";
            btnKomisije.UseVisualStyleBackColor = true;
            btnKomisije.Click += btnKomisije_Click;
            // 
            // btnUpravljajKomisijama
            // 
            btnUpravljajKomisijama.Location = new Point(5, 133);
            btnUpravljajKomisijama.Name = "btnUpravljajKomisijama";
            btnUpravljajKomisijama.Size = new Size(183, 31);
            btnUpravljajKomisijama.TabIndex = 4;
            btnUpravljajKomisijama.Text = "Upravljaj komisijama";
            btnUpravljajKomisijama.UseVisualStyleBackColor = true;
            btnUpravljajKomisijama.Click += btnUpravljajKomisijama_Click;
            // 
            // btnPrikaziCasove
            // 
            btnPrikaziCasove.Location = new Point(6, 59);
            btnPrikaziCasove.Name = "btnPrikaziCasove";
            btnPrikaziCasove.Size = new Size(184, 31);
            btnPrikaziCasove.TabIndex = 2;
            btnPrikaziCasove.Text = "Prikazi casove";
            btnPrikaziCasove.UseVisualStyleBackColor = true;
            btnPrikaziCasove.Click += btnPrikaziCasove_Click;
            // 
            // btnDodeliMentora
            // 
            btnDodeliMentora.Location = new Point(5, 96);
            btnDodeliMentora.Name = "btnDodeliMentora";
            btnDodeliMentora.Size = new Size(185, 31);
            btnDodeliMentora.TabIndex = 1;
            btnDodeliMentora.Text = "Dodeli mentora";
            btnDodeliMentora.UseVisualStyleBackColor = true;
            btnDodeliMentora.Click += btnDodeliMentora_Click;
            // 
            // btnPrikaziKurseve
            // 
            btnPrikaziKurseve.Location = new Point(6, 22);
            btnPrikaziKurseve.Name = "btnPrikaziKurseve";
            btnPrikaziKurseve.Size = new Size(185, 31);
            btnPrikaziKurseve.TabIndex = 0;
            btnPrikaziKurseve.Text = "Prikazi kurseve";
            btnPrikaziKurseve.UseVisualStyleBackColor = true;
            btnPrikaziKurseve.Click += btnPrikaziKurseve_Click;
            // 
            // NastavniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Komande);
            Controls.Add(listViewNastavnici);
            Name = "NastavniciForm";
            Text = "NastavniciForm";
            Load += NastavniciForm_Load;
            Komande.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewNastavnici;
        private GroupBox Komande;
        private Button btnIzmeniNastavnika;
        private Button btnObrisiNastavnika;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnDodajNastavnika;
        private GroupBox groupBox1;
        private Button btnDetalji;
        private GroupBox groupBox2;
        private Button btnPrikaziKurseve;
        private Button btnDodeliMentora;
        private Button btnPrikaziCasove;
        private Button btnUpravljajKomisijama;
        private Button btnKomisije;
    }
}