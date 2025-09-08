namespace MuzickaSkolaWindowsForms.Forme
{
    partial class PolazniciForm
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
            btnDodajPolaznika = new Button();
            btnObrisiPolaznika = new Button();
            btnIzmeniPol = new Button();
            gbPodaciOPolazniku = new GroupBox();
            gbDetaljiPolaznik = new GroupBox();
            btnPolozeniIspiti = new Button();
            btnPrisustvo = new Button();
            btnPrijavljeniKursevi = new Button();
            gbRoditelj = new GroupBox();
            btnPodaciRoditelj = new Button();
            lwSviPolaznici = new ListView();
            Id = new ColumnHeader();
            JMBG = new ColumnHeader();
            Ime = new ColumnHeader();
            Prezime = new ColumnHeader();
            Tip = new ColumnHeader();
            gbSviPolaznici = new GroupBox();
            gbPodaciOPolazniku.SuspendLayout();
            gbDetaljiPolaznik.SuspendLayout();
            gbRoditelj.SuspendLayout();
            gbSviPolaznici.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajPolaznika
            // 
            btnDodajPolaznika.Location = new Point(6, 22);
            btnDodajPolaznika.Name = "btnDodajPolaznika";
            btnDodajPolaznika.Size = new Size(168, 28);
            btnDodajPolaznika.TabIndex = 3;
            btnDodajPolaznika.Text = "Dodaj Polaznika";
            btnDodajPolaznika.UseVisualStyleBackColor = true;
            btnDodajPolaznika.Click += btnDodajPolaznika_Click;
            // 
            // btnObrisiPolaznika
            // 
            btnObrisiPolaznika.Location = new Point(6, 56);
            btnObrisiPolaznika.Name = "btnObrisiPolaznika";
            btnObrisiPolaznika.Size = new Size(168, 28);
            btnObrisiPolaznika.TabIndex = 4;
            btnObrisiPolaznika.Text = "Obrisi Polaznika";
            btnObrisiPolaznika.UseVisualStyleBackColor = true;
            btnObrisiPolaznika.Click += btnObrisiPolaznika_Click;
            // 
            // btnIzmeniPol
            // 
            btnIzmeniPol.Location = new Point(6, 90);
            btnIzmeniPol.Name = "btnIzmeniPol";
            btnIzmeniPol.Size = new Size(168, 28);
            btnIzmeniPol.TabIndex = 5;
            btnIzmeniPol.Text = "Izmeni Polaznika";
            btnIzmeniPol.UseVisualStyleBackColor = true;
            btnIzmeniPol.Click += btnIzmeniPol_Click;
            // 
            // gbPodaciOPolazniku
            // 
            gbPodaciOPolazniku.Controls.Add(btnDodajPolaznika);
            gbPodaciOPolazniku.Controls.Add(btnIzmeniPol);
            gbPodaciOPolazniku.Controls.Add(btnObrisiPolaznika);
            gbPodaciOPolazniku.Location = new Point(592, 12);
            gbPodaciOPolazniku.Name = "gbPodaciOPolazniku";
            gbPodaciOPolazniku.Size = new Size(196, 134);
            gbPodaciOPolazniku.TabIndex = 6;
            gbPodaciOPolazniku.TabStop = false;
            gbPodaciOPolazniku.Text = "Podaci o polazniku";
            // 
            // gbDetaljiPolaznik
            // 
            gbDetaljiPolaznik.Controls.Add(btnPolozeniIspiti);
            gbDetaljiPolaznik.Controls.Add(btnPrisustvo);
            gbDetaljiPolaznik.Controls.Add(btnPrijavljeniKursevi);
            gbDetaljiPolaznik.Location = new Point(592, 161);
            gbDetaljiPolaznik.Name = "gbDetaljiPolaznik";
            gbDetaljiPolaznik.Size = new Size(200, 140);
            gbDetaljiPolaznik.TabIndex = 8;
            gbDetaljiPolaznik.TabStop = false;
            gbDetaljiPolaznik.Text = "Detalji o Polazniku";
            // 
            // btnPolozeniIspiti
            // 
            btnPolozeniIspiti.Location = new Point(10, 102);
            btnPolozeniIspiti.Name = "btnPolozeniIspiti";
            btnPolozeniIspiti.Size = new Size(164, 28);
            btnPolozeniIspiti.TabIndex = 2;
            btnPolozeniIspiti.Text = "Polozeni ispiti";
            btnPolozeniIspiti.UseVisualStyleBackColor = true;
            btnPolozeniIspiti.Click += btnPolozeniIspiti_Click;
            // 
            // btnPrisustvo
            // 
            btnPrisustvo.Location = new Point(10, 65);
            btnPrisustvo.Name = "btnPrisustvo";
            btnPrisustvo.Size = new Size(164, 28);
            btnPrisustvo.TabIndex = 1;
            btnPrisustvo.Text = "Prisustvo na casovima";
            btnPrisustvo.UseVisualStyleBackColor = true;
            btnPrisustvo.Click += btnPrisustvo_Click;
            // 
            // btnPrijavljeniKursevi
            // 
            btnPrijavljeniKursevi.Location = new Point(6, 28);
            btnPrijavljeniKursevi.Name = "btnPrijavljeniKursevi";
            btnPrijavljeniKursevi.Size = new Size(168, 28);
            btnPrijavljeniKursevi.TabIndex = 0;
            btnPrijavljeniKursevi.Text = "Prijavljeni Kursevi";
            btnPrijavljeniKursevi.UseVisualStyleBackColor = true;
            btnPrijavljeniKursevi.Click += btnPrijavljeniKursevi_Click;
            // 
            // gbRoditelj
            // 
            gbRoditelj.Controls.Add(btnPodaciRoditelj);
            gbRoditelj.Location = new Point(592, 307);
            gbRoditelj.Name = "gbRoditelj";
            gbRoditelj.Size = new Size(200, 100);
            gbRoditelj.TabIndex = 9;
            gbRoditelj.TabStop = false;
            gbRoditelj.Text = "Podaci o roditelju";
            // 
            // btnPodaciRoditelj
            // 
            btnPodaciRoditelj.Location = new Point(10, 29);
            btnPodaciRoditelj.Name = "btnPodaciRoditelj";
            btnPodaciRoditelj.Size = new Size(164, 28);
            btnPodaciRoditelj.TabIndex = 0;
            btnPodaciRoditelj.Text = "Prikazi roditelja";
            btnPodaciRoditelj.UseVisualStyleBackColor = true;
            btnPodaciRoditelj.Click += btnPodaciRoditelj_Click;
            // 
            // lwSviPolaznici
            // 
            lwSviPolaznici.Columns.AddRange(new ColumnHeader[] { Id, JMBG, Ime, Prezime, Tip });
            lwSviPolaznici.Location = new Point(9, 22);
            lwSviPolaznici.Name = "lwSviPolaznici";
            lwSviPolaznici.Size = new Size(555, 373);
            lwSviPolaznici.TabIndex = 0;
            lwSviPolaznici.UseCompatibleStateImageBehavior = false;
            lwSviPolaznici.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "Id";
            // 
            // JMBG
            // 
            JMBG.Text = "JMBG";
            JMBG.Width = 120;
            // 
            // Ime
            // 
            Ime.Text = "Ime";
            Ime.Width = 120;
            // 
            // Prezime
            // 
            Prezime.Text = "Prezime";
            Prezime.Width = 120;
            // 
            // Tip
            // 
            Tip.Text = "Tip";
            Tip.Width = 80;
            // 
            // gbSviPolaznici
            // 
            gbSviPolaznici.Controls.Add(lwSviPolaznici);
            gbSviPolaznici.Location = new Point(3, 12);
            gbSviPolaznici.Name = "gbSviPolaznici";
            gbSviPolaznici.Size = new Size(583, 412);
            gbSviPolaznici.TabIndex = 7;
            gbSviPolaznici.TabStop = false;
            gbSviPolaznici.Text = "Svi Polaznici";
            // 
            // PolazniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbRoditelj);
            Controls.Add(gbDetaljiPolaznik);
            Controls.Add(gbSviPolaznici);
            Controls.Add(gbPodaciOPolazniku);
            Name = "PolazniciForm";
            Text = "PolazniciForm";
            Load += PolazniciForm_Load;
            gbPodaciOPolazniku.ResumeLayout(false);
            gbDetaljiPolaznik.ResumeLayout(false);
            gbRoditelj.ResumeLayout(false);
            gbSviPolaznici.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnDodajPolaznika;
        private Button btnObrisiPolaznika;
        private Button btnIzmeniPol;
        private GroupBox gbPodaciOPolazniku;
        private GroupBox gbDetaljiPolaznik;
        private Button btnPolozeniIspiti;
        private Button btnPrisustvo;
        private Button btnPrijavljeniKursevi;
        private GroupBox gbRoditelj;
        private Button btnPodaciRoditelj;
        private ListView lwSviPolaznici;
        private GroupBox gbSviPolaznici;
        private ColumnHeader Id;
        private ColumnHeader JMBG;
        private ColumnHeader Ime;
        private ColumnHeader Prezime;
        private ColumnHeader Tip;
    }
}