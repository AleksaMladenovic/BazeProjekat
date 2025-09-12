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
            splitContainer1.Panel2.Controls.Add(cmdObrisiCas);
            splitContainer1.Panel2.Controls.Add(cmdIzmeniCas);
            splitContainer1.Panel2.Controls.Add(cmdDodajCas);
            splitContainer1.Panel2.Controls.Add(listViewCasovi);
            splitContainer1.Panel2.Controls.Add(lblInfoNastava);
            splitContainer1.Size = new Size(931, 450);
            splitContainer1.SplitterDistance = 386;
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
            groupBox1.Size = new Size(365, 420);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nastavni blokovi";
            // 
            // cmdObrisiNastavu
            // 
            cmdObrisiNastavu.Location = new Point(249, 391);
            cmdObrisiNastavu.Name = "cmdObrisiNastavu";
            cmdObrisiNastavu.Size = new Size(75, 23);
            cmdObrisiNastavu.TabIndex = 3;
            cmdObrisiNastavu.Text = "Obriši";
            cmdObrisiNastavu.UseVisualStyleBackColor = true;
            cmdObrisiNastavu.Click += cmdObrisiNastavu_Click;
            // 
            // cmdIzmeniNastavu
            // 
            cmdIzmeniNastavu.Location = new Point(153, 391);
            cmdIzmeniNastavu.Name = "cmdIzmeniNastavu";
            cmdIzmeniNastavu.Size = new Size(75, 23);
            cmdIzmeniNastavu.TabIndex = 2;
            cmdIzmeniNastavu.Text = "Izmeni";
            cmdIzmeniNastavu.UseVisualStyleBackColor = true;
            cmdIzmeniNastavu.Click += cmdIzmeniNastavu_Click;
            // 
            // cmdDodajNastavu
            // 
            cmdDodajNastavu.Location = new Point(59, 391);
            cmdDodajNastavu.Name = "cmdDodajNastavu";
            cmdDodajNastavu.Size = new Size(75, 23);
            cmdDodajNastavu.TabIndex = 1;
            cmdDodajNastavu.Text = "Dodaj";
            cmdDodajNastavu.UseVisualStyleBackColor = true;
            cmdDodajNastavu.Click += cmdDodajNastavu_Click;
            // 
            // listViewNastava
            // 
            listViewNastava.Columns.AddRange(new ColumnHeader[] { chId, chDatumOd, chDatumDo, Tip });
            listViewNastava.FullRowSelect = true;
            listViewNastava.Location = new Point(9, 0);
            listViewNastava.Name = "listViewNastava";
            listViewNastava.Size = new Size(350, 389);
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
            lblInfoKursa.Location = new Point(12, 9);
            lblInfoKursa.Name = "lblInfoKursa";
            lblInfoKursa.Size = new Size(59, 15);
            lblInfoKursa.TabIndex = 0;
            lblInfoKursa.Text = "Info kursa";
            // 
            // cmdObrisiCas
            // 
            cmdObrisiCas.Location = new Point(346, 418);
            cmdObrisiCas.Name = "cmdObrisiCas";
            cmdObrisiCas.Size = new Size(75, 23);
            cmdObrisiCas.TabIndex = 6;
            cmdObrisiCas.Text = "Obriši";
            cmdObrisiCas.UseVisualStyleBackColor = true;
            cmdObrisiCas.Click += cmdObrisiCas_Click;
            // 
            // cmdIzmeniCas
            // 
            cmdIzmeniCas.Location = new Point(245, 418);
            cmdIzmeniCas.Name = "cmdIzmeniCas";
            cmdIzmeniCas.Size = new Size(75, 23);
            cmdIzmeniCas.TabIndex = 5;
            cmdIzmeniCas.Text = "Izmeni";
            cmdIzmeniCas.UseVisualStyleBackColor = true;
            cmdIzmeniCas.Click += cmdIzmeniCas_Click;
            // 
            // cmdDodajCas
            // 
            cmdDodajCas.Location = new Point(137, 418);
            cmdDodajCas.Name = "cmdDodajCas";
            cmdDodajCas.Size = new Size(75, 23);
            cmdDodajCas.TabIndex = 4;
            cmdDodajCas.Text = "Dodaj";
            cmdDodajCas.UseVisualStyleBackColor = true;
            cmdDodajCas.Click += cmdDodajCas_Click;
            // 
            // listViewCasovi
            // 
            listViewCasovi.Columns.AddRange(new ColumnHeader[] { chIdCasa, chTermin, chTema, chNastavnik, chUcionica });
            listViewCasovi.FullRowSelect = true;
            listViewCasovi.Location = new Point(3, 27);
            listViewCasovi.Name = "listViewCasovi";
            listViewCasovi.Size = new Size(526, 389);
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
            lblInfoNastava.Location = new Point(3, 9);
            lblInfoNastava.Name = "lblInfoNastava";
            lblInfoNastava.Size = new Size(73, 15);
            lblInfoNastava.TabIndex = 0;
            lblInfoNastava.Text = "Info Nastava";
            // 
            // NastavaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 450);
            Controls.Add(splitContainer1);
            Name = "NastavaForm";
            Text = "NastavaForm";
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
    }
}