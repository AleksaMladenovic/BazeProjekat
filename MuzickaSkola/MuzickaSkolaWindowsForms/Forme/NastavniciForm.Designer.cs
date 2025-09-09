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
            Komande = new GroupBox();
            btnIzmeniNastavnika = new Button();
            btnObrisiNastavnika = new Button();
            btnDodajNastavnika = new Button();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            Komande.SuspendLayout();
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
            // Komande
            // 
            Komande.Controls.Add(btnIzmeniNastavnika);
            Komande.Controls.Add(btnObrisiNastavnika);
            Komande.Controls.Add(btnDodajNastavnika);
            Komande.Location = new Point(586, 12);
            Komande.Name = "Komande";
            Komande.Size = new Size(202, 426);
            Komande.TabIndex = 1;
            Komande.TabStop = false;
            Komande.Text = "groupBox1";
            // 
            // btnIzmeniNastavnika
            // 
            btnIzmeniNastavnika.Location = new Point(7, 60);
            btnIzmeniNastavnika.Name = "btnIzmeniNastavnika";
            btnIzmeniNastavnika.Size = new Size(185, 30);
            btnIzmeniNastavnika.TabIndex = 2;
            btnIzmeniNastavnika.Text = "Izmeni Nastavnika";
            btnIzmeniNastavnika.UseVisualStyleBackColor = true;
            // 
            // btnObrisiNastavnika
            // 
            btnObrisiNastavnika.Location = new Point(7, 96);
            btnObrisiNastavnika.Name = "btnObrisiNastavnika";
            btnObrisiNastavnika.Size = new Size(185, 30);
            btnObrisiNastavnika.TabIndex = 1;
            btnObrisiNastavnika.Text = "Obrisi Nastavnika";
            btnObrisiNastavnika.UseVisualStyleBackColor = true;
            // 
            // btnDodajNastavnika
            // 
            btnDodajNastavnika.Location = new Point(7, 24);
            btnDodajNastavnika.Name = "btnDodajNastavnika";
            btnDodajNastavnika.Size = new Size(185, 30);
            btnDodajNastavnika.TabIndex = 0;
            btnDodajNastavnika.Text = "Dodaj Nastavnika";
            btnDodajNastavnika.UseVisualStyleBackColor = true;
            btnDodajNastavnika.Click += button1_Click;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "JMBG";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Prezime";
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
            // NastavniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Komande);
            Controls.Add(listViewNastavnici);
            Name = "NastavniciForm";
            Text = "NastavniciForm";
            Load += NastavniciForm_Load;
            Komande.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewNastavnici;
        private GroupBox Komande;
        private Button btnIzmeniNastavnika;
        private Button btnObrisiNastavnika;
        private Button btnDodajNastavnika;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
    }
}