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
            Komande.SuspendLayout();
            groupBox1.SuspendLayout();
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
            btnDetalji.Size = new Size(185, 25);
            btnDetalji.TabIndex = 0;
            btnDetalji.Text = "Prikazi Detalje";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // NastavniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(Komande);
            Controls.Add(listViewNastavnici);
            Name = "NastavniciForm";
            Text = "NastavniciForm";
            Load += NastavniciForm_Load;
            Komande.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
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
    }
}