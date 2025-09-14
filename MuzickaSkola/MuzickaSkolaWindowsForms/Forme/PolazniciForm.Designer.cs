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
            panelNastavnici = new Panel();
            labelNaslov = new Label();
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
            panelNastavnici.SuspendLayout();
            gbSviPolaznici.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajPolaznika
            // 
            btnDodajPolaznika.BackColor = Color.MidnightBlue;
            btnDodajPolaznika.FlatAppearance.BorderSize = 0;
            btnDodajPolaznika.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDodajPolaznika.FlatStyle = FlatStyle.Flat;
            btnDodajPolaznika.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDodajPolaznika.ForeColor = Color.White;
            btnDodajPolaznika.Location = new Point(6, 22);
            btnDodajPolaznika.Name = "btnDodajPolaznika";
            btnDodajPolaznika.Size = new Size(168, 28);
            btnDodajPolaznika.TabIndex = 3;
            btnDodajPolaznika.Text = "Dodaj Polaznika";
            btnDodajPolaznika.UseVisualStyleBackColor = false;
            btnDodajPolaznika.Click += btnDodajPolaznika_Click;
            // 
            // btnObrisiPolaznika
            // 
            btnObrisiPolaznika.BackColor = Color.MidnightBlue;
            btnObrisiPolaznika.FlatAppearance.BorderSize = 0;
            btnObrisiPolaznika.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnObrisiPolaznika.FlatStyle = FlatStyle.Flat;
            btnObrisiPolaznika.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnObrisiPolaznika.ForeColor = Color.White;
            btnObrisiPolaznika.Location = new Point(6, 56);
            btnObrisiPolaznika.Name = "btnObrisiPolaznika";
            btnObrisiPolaznika.Size = new Size(168, 28);
            btnObrisiPolaznika.TabIndex = 4;
            btnObrisiPolaznika.Text = "Obriši Polaznika";
            btnObrisiPolaznika.UseVisualStyleBackColor = false;
            btnObrisiPolaznika.Click += btnObrisiPolaznika_Click;
            // 
            // btnIzmeniPol
            // 
            btnIzmeniPol.BackColor = Color.MidnightBlue;
            btnIzmeniPol.FlatAppearance.BorderSize = 0;
            btnIzmeniPol.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnIzmeniPol.FlatStyle = FlatStyle.Flat;
            btnIzmeniPol.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnIzmeniPol.ForeColor = Color.White;
            btnIzmeniPol.Location = new Point(6, 90);
            btnIzmeniPol.Name = "btnIzmeniPol";
            btnIzmeniPol.Size = new Size(168, 28);
            btnIzmeniPol.TabIndex = 5;
            btnIzmeniPol.Text = "Izmeni Polaznika";
            btnIzmeniPol.UseVisualStyleBackColor = false;
            btnIzmeniPol.Click += btnIzmeniPol_Click;
            // 
            // gbPodaciOPolazniku
            // 
            gbPodaciOPolazniku.Controls.Add(btnDodajPolaznika);
            gbPodaciOPolazniku.Controls.Add(btnIzmeniPol);
            gbPodaciOPolazniku.Controls.Add(btnObrisiPolaznika);
            gbPodaciOPolazniku.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            gbPodaciOPolazniku.ForeColor = Color.MidnightBlue;
            gbPodaciOPolazniku.Location = new Point(592, 68);
            gbPodaciOPolazniku.Name = "gbPodaciOPolazniku";
            gbPodaciOPolazniku.Size = new Size(196, 356);
            gbPodaciOPolazniku.TabIndex = 6;
            gbPodaciOPolazniku.TabStop = false;
            gbPodaciOPolazniku.Text = "Podaci o Polazniku";
            // 
            // gbDetaljiPolaznik
            // 
            gbDetaljiPolaznik.Controls.Add(btnPolozeniIspiti);
            gbDetaljiPolaznik.Controls.Add(btnPrisustvo);
            gbDetaljiPolaznik.Controls.Add(btnPrijavljeniKursevi);
            gbDetaljiPolaznik.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            gbDetaljiPolaznik.ForeColor = Color.MidnightBlue;
            gbDetaljiPolaznik.Location = new Point(592, 210);
            gbDetaljiPolaznik.Name = "gbDetaljiPolaznik";
            gbDetaljiPolaznik.Size = new Size(200, 369);
            gbDetaljiPolaznik.TabIndex = 8;
            gbDetaljiPolaznik.TabStop = false;
            gbDetaljiPolaznik.Text = "Detalji o Polazniku";
            // 
            // btnPolozeniIspiti
            // 
            btnPolozeniIspiti.BackColor = Color.MidnightBlue;
            btnPolozeniIspiti.FlatAppearance.BorderSize = 0;
            btnPolozeniIspiti.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPolozeniIspiti.FlatStyle = FlatStyle.Flat;
            btnPolozeniIspiti.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPolozeniIspiti.ForeColor = Color.White;
            btnPolozeniIspiti.Location = new Point(10, 102);
            btnPolozeniIspiti.Name = "btnPolozeniIspiti";
            btnPolozeniIspiti.Size = new Size(164, 28);
            btnPolozeniIspiti.TabIndex = 2;
            btnPolozeniIspiti.Text = "Položeni ispiti";
            btnPolozeniIspiti.UseVisualStyleBackColor = false;
            btnPolozeniIspiti.Click += btnPolozeniIspiti_Click;
            // 
            // btnPrisustvo
            // 
            btnPrisustvo.BackColor = Color.MidnightBlue;
            btnPrisustvo.FlatAppearance.BorderSize = 0;
            btnPrisustvo.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPrisustvo.FlatStyle = FlatStyle.Flat;
            btnPrisustvo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrisustvo.ForeColor = Color.White;
            btnPrisustvo.Location = new Point(10, 65);
            btnPrisustvo.Name = "btnPrisustvo";
            btnPrisustvo.Size = new Size(164, 28);
            btnPrisustvo.TabIndex = 1;
            btnPrisustvo.Text = "Prisustvo na časovima";
            btnPrisustvo.UseVisualStyleBackColor = false;
            btnPrisustvo.Click += btnPrisustvo_Click;
            // 
            // btnPrijavljeniKursevi
            // 
            btnPrijavljeniKursevi.BackColor = Color.MidnightBlue;
            btnPrijavljeniKursevi.FlatAppearance.BorderSize = 0;
            btnPrijavljeniKursevi.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPrijavljeniKursevi.FlatStyle = FlatStyle.Flat;
            btnPrijavljeniKursevi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrijavljeniKursevi.ForeColor = Color.White;
            btnPrijavljeniKursevi.Location = new Point(10, 28);
            btnPrijavljeniKursevi.Name = "btnPrijavljeniKursevi";
            btnPrijavljeniKursevi.Size = new Size(164, 28);
            btnPrijavljeniKursevi.TabIndex = 0;
            btnPrijavljeniKursevi.Text = "Prijavljeni Kursevi";
            btnPrijavljeniKursevi.UseVisualStyleBackColor = false;
            btnPrijavljeniKursevi.Click += btnPrijavljeniKursevi_Click;
            // 
            // gbRoditelj
            // 
            gbRoditelj.Controls.Add(btnPodaciRoditelj);
            gbRoditelj.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            gbRoditelj.ForeColor = Color.MidnightBlue;
            gbRoditelj.Location = new Point(592, 363);
            gbRoditelj.Name = "gbRoditelj";
            gbRoditelj.Size = new Size(200, 322);
            gbRoditelj.TabIndex = 9;
            gbRoditelj.TabStop = false;
            gbRoditelj.Text = "Podaci o Roditelju";
            // 
            // btnPodaciRoditelj
            // 
            btnPodaciRoditelj.BackColor = Color.MidnightBlue;
            btnPodaciRoditelj.FlatAppearance.BorderSize = 0;
            btnPodaciRoditelj.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnPodaciRoditelj.FlatStyle = FlatStyle.Flat;
            btnPodaciRoditelj.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPodaciRoditelj.ForeColor = Color.White;
            btnPodaciRoditelj.Location = new Point(10, 29);
            btnPodaciRoditelj.Name = "btnPodaciRoditelj";
            btnPodaciRoditelj.Size = new Size(164, 28);
            btnPodaciRoditelj.TabIndex = 0;
            btnPodaciRoditelj.Text = "Prikaži roditelja";
            btnPodaciRoditelj.UseVisualStyleBackColor = false;
            btnPodaciRoditelj.Click += btnPodaciRoditelj_Click;
            // 
            // panelNastavnici
            // 
            panelNastavnici.BackColor = Color.MidnightBlue;
            panelNastavnici.Controls.Add(labelNaslov);
            panelNastavnici.Dock = DockStyle.Top;
            panelNastavnici.Location = new Point(0, 0);
            panelNastavnici.Name = "panelNastavnici";
            panelNastavnici.Size = new Size(800, 60);
            panelNastavnici.TabIndex = 10;
            // 
            // labelNaslov
            // 
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(318, 9);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(219, 33);
            labelNaslov.TabIndex = 1;
            labelNaslov.Text = "Pregled Polaznika";
            labelNaslov.TextAlign = ContentAlignment.MiddleCenter;
            labelNaslov.Click += labelNaslov_Click;
            // 
            // lwSviPolaznici
            // 
            lwSviPolaznici.Columns.AddRange(new ColumnHeader[] { Id, JMBG, Ime, Prezime, Tip });
            lwSviPolaznici.GridLines = true;
            lwSviPolaznici.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lwSviPolaznici.Location = new Point(6, 20);
            lwSviPolaznici.Name = "lwSviPolaznici";
            lwSviPolaznici.OwnerDraw = true;
            lwSviPolaznici.Size = new Size(574, 332);
            lwSviPolaznici.TabIndex = 0;
            lwSviPolaznici.UseCompatibleStateImageBehavior = false;
            lwSviPolaznici.View = View.Details;
            lwSviPolaznici.DrawColumnHeader += lwSviPolaznici_DrawColumnHeader;
            lwSviPolaznici.DrawItem += lwSviPolaznici_DrawItem;
            // 
            // Id
            // 
            Id.Text = "ID";
            // 
            // JMBG
            // 
            JMBG.Text = "JMBG";
            JMBG.TextAlign = HorizontalAlignment.Center;
            JMBG.Width = 130;
            // 
            // Ime
            // 
            Ime.Text = "Ime";
            Ime.TextAlign = HorizontalAlignment.Center;
            Ime.Width = 130;
            // 
            // Prezime
            // 
            Prezime.Text = "Prezime";
            Prezime.TextAlign = HorizontalAlignment.Center;
            Prezime.Width = 130;
            // 
            // Tip
            // 
            Tip.Text = "Tip";
            Tip.TextAlign = HorizontalAlignment.Center;
            Tip.Width = 120;
            // 
            // gbSviPolaznici
            // 
            gbSviPolaznici.Controls.Add(lwSviPolaznici);
            gbSviPolaznici.Location = new Point(0, 68);
            gbSviPolaznici.Name = "gbSviPolaznici";
            gbSviPolaznici.Size = new Size(586, 370);
            gbSviPolaznici.TabIndex = 7;
            gbSviPolaznici.TabStop = false;
            // 
            // PolazniciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelNastavnici);
            Controls.Add(gbRoditelj);
            Controls.Add(gbDetaljiPolaznik);
            Controls.Add(gbSviPolaznici);
            Controls.Add(gbPodaciOPolazniku);
            Name = "PolazniciForm";
            Load += PolazniciForm_Load;
            gbPodaciOPolazniku.ResumeLayout(false);
            gbDetaljiPolaznik.ResumeLayout(false);
            gbRoditelj.ResumeLayout(false);
            panelNastavnici.ResumeLayout(false);
            panelNastavnici.PerformLayout();
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
        private Panel panelNastavnici;
        private Label labelNaslov;
        private ListView lwSviPolaznici;
        private ColumnHeader Id;
        private ColumnHeader JMBG;
        private ColumnHeader Ime;
        private ColumnHeader Prezime;
        private ColumnHeader Tip;
        private GroupBox gbSviPolaznici;
    }
}