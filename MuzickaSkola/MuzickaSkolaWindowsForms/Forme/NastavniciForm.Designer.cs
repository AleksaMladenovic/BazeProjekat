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
            panelNastavnici = new Panel();
            labelNaslov = new Label();
            Komande.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panelNastavnici.SuspendLayout();
            SuspendLayout();
            // 
            // listViewNastavnici
            // 
            listViewNastavnici.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewNastavnici.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewNastavnici.FullRowSelect = true;
            listViewNastavnici.GridLines = true;
            listViewNastavnici.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewNastavnici.Location = new Point(12, 69);
            listViewNastavnici.Name = "listViewNastavnici";
            listViewNastavnici.OwnerDraw = true;
            listViewNastavnici.Size = new Size(568, 426);
            listViewNastavnici.TabIndex = 0;
            listViewNastavnici.UseCompatibleStateImageBehavior = false;
            listViewNastavnici.View = View.Details;
            listViewNastavnici.DrawColumnHeader += listViewNastavnici_DrawColumnHeader;
            listViewNastavnici.DrawItem += listViewNastavnici_DrawItem;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "JMBG";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Prezime";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Stručna sprema";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip Zaposlenja";
            columnHeader5.Width = 113;
            // 
            // Komande
            // 
            Komande.Controls.Add(btnDodajNastavnika);
            Komande.Controls.Add(btnIzmeniNastavnika);
            Komande.Controls.Add(btnObrisiNastavnika);
            Komande.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Komande.ForeColor = Color.MidnightBlue;
            Komande.Location = new Point(586, 69);
            Komande.Name = "Komande";
            Komande.Size = new Size(202, 145);
            Komande.TabIndex = 1;
            Komande.TabStop = false;
            Komande.Text = "Osnovne operacije";
            // 
            // btnDodajNastavnika
            // 
            btnDodajNastavnika.BackColor = Color.MidnightBlue;
            btnDodajNastavnika.FlatAppearance.BorderSize = 0;
            btnDodajNastavnika.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDodajNastavnika.FlatStyle = FlatStyle.Flat;
            btnDodajNastavnika.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDodajNastavnika.ForeColor = Color.White;
            btnDodajNastavnika.Location = new Point(7, 27);
            btnDodajNastavnika.Name = "btnDodajNastavnika";
            btnDodajNastavnika.Size = new Size(185, 27);
            btnDodajNastavnika.TabIndex = 3;
            btnDodajNastavnika.Text = "Dodaj Nastavnika";
            btnDodajNastavnika.UseVisualStyleBackColor = false;
            btnDodajNastavnika.Click += btnDodajNastavnika_Click;
            // 
            // btnIzmeniNastavnika
            // 
            btnIzmeniNastavnika.BackColor = Color.MidnightBlue;
            btnIzmeniNastavnika.FlatAppearance.BorderSize = 0;
            btnIzmeniNastavnika.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnIzmeniNastavnika.FlatStyle = FlatStyle.Flat;
            btnIzmeniNastavnika.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnIzmeniNastavnika.ForeColor = Color.White;
            btnIzmeniNastavnika.Location = new Point(7, 60);
            btnIzmeniNastavnika.Name = "btnIzmeniNastavnika";
            btnIzmeniNastavnika.Size = new Size(185, 30);
            btnIzmeniNastavnika.TabIndex = 2;
            btnIzmeniNastavnika.Text = "Izmeni Nastavnika";
            btnIzmeniNastavnika.UseVisualStyleBackColor = false;
            btnIzmeniNastavnika.Click += btnIzmeniNastavnika_Click;
            // 
            // btnObrisiNastavnika
            // 
            btnObrisiNastavnika.BackColor = Color.MidnightBlue;
            btnObrisiNastavnika.FlatAppearance.BorderSize = 0;
            btnObrisiNastavnika.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnObrisiNastavnika.FlatStyle = FlatStyle.Flat;
            btnObrisiNastavnika.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnObrisiNastavnika.ForeColor = Color.White;
            btnObrisiNastavnika.Location = new Point(7, 96);
            btnObrisiNastavnika.Name = "btnObrisiNastavnika";
            btnObrisiNastavnika.Size = new Size(185, 30);
            btnObrisiNastavnika.TabIndex = 1;
            btnObrisiNastavnika.Text = "Obriši Nastavnika";
            btnObrisiNastavnika.UseVisualStyleBackColor = false;
            btnObrisiNastavnika.Click += btnObrisiNastavnika_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDetalji);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(586, 220);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(202, 59);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detaljne informacije";
            // 
            // btnDetalji
            // 
            btnDetalji.BackColor = Color.MidnightBlue;
            btnDetalji.FlatAppearance.BorderSize = 0;
            btnDetalji.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDetalji.FlatStyle = FlatStyle.Flat;
            btnDetalji.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDetalji.ForeColor = Color.White;
            btnDetalji.Location = new Point(6, 22);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(186, 25);
            btnDetalji.TabIndex = 0;
            btnDetalji.Text = "Prikaži Detalje";
            btnDetalji.UseVisualStyleBackColor = false;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.MidnightBlue;
            groupBox2.Controls.Add(btnKomisije);
            groupBox2.Controls.Add(btnUpravljajKomisijama);
            groupBox2.Controls.Add(btnPrikaziCasove);
            groupBox2.Controls.Add(btnDodeliMentora);
            groupBox2.Controls.Add(btnPrikaziKurseve);
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(586, 285);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(202, 210);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Složene funkcionalnosti";
            // 
            // btnKomisije
            // 
            btnKomisije.BackColor = Color.MidnightBlue;
            btnKomisije.FlatAppearance.BorderSize = 0;
            btnKomisije.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnKomisije.FlatStyle = FlatStyle.Flat;
            btnKomisije.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnKomisije.ForeColor = Color.White;
            btnKomisije.Location = new Point(6, 170);
            btnKomisije.Name = "btnKomisije";
            btnKomisije.Size = new Size(181, 31);
            btnKomisije.TabIndex = 5;
            btnKomisije.Text = "Komisije i članovi";
            btnKomisije.UseVisualStyleBackColor = false;
            btnKomisije.Click += btnKomisije_Click;
            // 
            // btnUpravljajKomisijama
            // 
            btnUpravljajKomisijama.BackColor = Color.MidnightBlue;
            btnUpravljajKomisijama.FlatAppearance.BorderSize = 0;
            btnUpravljajKomisijama.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnUpravljajKomisijama.FlatStyle = FlatStyle.Flat;
            btnUpravljajKomisijama.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUpravljajKomisijama.ForeColor = Color.White;
            btnUpravljajKomisijama.Location = new Point(5, 133);
            btnUpravljajKomisijama.Name = "btnUpravljajKomisijama";
            btnUpravljajKomisijama.Size = new Size(183, 31);
            btnUpravljajKomisijama.TabIndex = 4;
            btnUpravljajKomisijama.Text = "Upravljaj komisijama";
            btnUpravljajKomisijama.UseVisualStyleBackColor = false;
            btnUpravljajKomisijama.Click += btnUpravljajKomisijama_Click;
            // 
            // btnPrikaziCasove
            // 
            btnPrikaziCasove.BackColor = Color.MidnightBlue;
            btnPrikaziCasove.FlatAppearance.BorderSize = 0;
            btnPrikaziCasove.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPrikaziCasove.FlatStyle = FlatStyle.Flat;
            btnPrikaziCasove.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrikaziCasove.ForeColor = Color.White;
            btnPrikaziCasove.Location = new Point(6, 59);
            btnPrikaziCasove.Name = "btnPrikaziCasove";
            btnPrikaziCasove.Size = new Size(184, 31);
            btnPrikaziCasove.TabIndex = 2;
            btnPrikaziCasove.Text = "Prikaži casove";
            btnPrikaziCasove.UseVisualStyleBackColor = false;
            btnPrikaziCasove.Click += btnPrikaziCasove_Click;
            // 
            // btnDodeliMentora
            // 
            btnDodeliMentora.BackColor = Color.MidnightBlue;
            btnDodeliMentora.FlatAppearance.BorderSize = 0;
            btnDodeliMentora.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDodeliMentora.FlatStyle = FlatStyle.Flat;
            btnDodeliMentora.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDodeliMentora.ForeColor = Color.White;
            btnDodeliMentora.Location = new Point(5, 96);
            btnDodeliMentora.Name = "btnDodeliMentora";
            btnDodeliMentora.Size = new Size(185, 31);
            btnDodeliMentora.TabIndex = 1;
            btnDodeliMentora.Text = "Dodeli mentora";
            btnDodeliMentora.UseVisualStyleBackColor = false;
            btnDodeliMentora.Click += btnDodeliMentora_Click;
            // 
            // btnPrikaziKurseve
            // 
            btnPrikaziKurseve.BackColor = Color.MidnightBlue;
            btnPrikaziKurseve.FlatAppearance.BorderSize = 0;
            btnPrikaziKurseve.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPrikaziKurseve.FlatStyle = FlatStyle.Flat;
            btnPrikaziKurseve.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrikaziKurseve.ForeColor = Color.White;
            btnPrikaziKurseve.Location = new Point(6, 22);
            btnPrikaziKurseve.Name = "btnPrikaziKurseve";
            btnPrikaziKurseve.Size = new Size(185, 31);
            btnPrikaziKurseve.TabIndex = 0;
            btnPrikaziKurseve.Text = "Prikaži kurseve";
            btnPrikaziKurseve.UseVisualStyleBackColor = false;
            btnPrikaziKurseve.Click += btnPrikaziKurseve_Click;
            // 
            // panelNastavnici
            // 
            panelNastavnici.BackColor = Color.MidnightBlue;
            panelNastavnici.Controls.Add(labelNaslov);
            panelNastavnici.Dock = DockStyle.Top;
            panelNastavnici.Location = new Point(0, 0);
            panelNastavnici.Name = "panelNastavnici";
            panelNastavnici.Size = new Size(800, 60);
            panelNastavnici.TabIndex = 4;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(308, 14);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(234, 33);
            labelNaslov.TabIndex = 1;
            labelNaslov.Text = "Pregled Nastavnika";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            labelNaslov.Click += labelNaslov_Click;
            // 
            // NastavniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 507);
            Controls.Add(panelNastavnici);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Komande);
            Controls.Add(listViewNastavnici);
            Name = "NastavniciForm";
            Load += NastavniciForm_Load;
            Komande.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panelNastavnici.ResumeLayout(false);
            panelNastavnici.PerformLayout();
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
        private Panel panelNastavnici;
        private Label labelNaslov;
    }
}