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
            listViewKursevi = new ListView();
            chId = new ColumnHeader();
            chNazivKursa = new ColumnHeader();
            chNivo = new ColumnHeader();
            chTipKursa = new ColumnHeader();
            chNastavnik = new ColumnHeader();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            cmdObrisiKurs = new Button();
            cmdIzmeniKurs = new Button();
            cmdDodajKurs = new Button();
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
            splitContainer1.Panel1.Controls.Add(listViewKursevi);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(920, 450);
            splitContainer1.SplitterDistance = 703;
            splitContainer1.TabIndex = 0;
            // 
            // listViewKursevi
            // 
            listViewKursevi.Columns.AddRange(new ColumnHeader[] { chId, chNazivKursa, chNivo, chTipKursa, chNastavnik });
            listViewKursevi.Dock = DockStyle.Bottom;
            listViewKursevi.FullRowSelect = true;
            listViewKursevi.Location = new Point(0, 0);
            listViewKursevi.Name = "listViewKursevi";
            listViewKursevi.Size = new Size(703, 450);
            listViewKursevi.TabIndex = 1;
            listViewKursevi.UseCompatibleStateImageBehavior = false;
            listViewKursevi.View = View.Details;
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
            chNazivKursa.Width = 250;
            // 
            // chNivo
            // 
            chNivo.Text = "Nivo";
            chNivo.Width = 100;
            // 
            // chTipKursa
            // 
            chTipKursa.Text = "Tip kursa";
            chTipKursa.Width = 150;
            // 
            // chNastavnik
            // 
            chNastavnik.Text = "Nastavnik";
            chNastavnik.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(3, 180);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(207, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalji o selektovanom kursu";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdObrisiKurs);
            groupBox1.Controls.Add(cmdIzmeniKurs);
            groupBox1.Controls.Add(cmdDodajKurs);
            groupBox1.Location = new Point(3, 12);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 450);
            Controls.Add(splitContainer1);
            Name = "KurseviForm";
            Text = "KurseviForm";
            Load += KurseviForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}