namespace MuzickaSkolaWindowsForms.Forme
{
    partial class dodajPolaznikaNaKursForm
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
            cmbKursevi = new ComboBox();
            btnDodaj = new Button();
            lwPrijavljeniKursevi = new ListView();
            colId = new ColumnHeader();
            colNaziv = new ColumnHeader();
            colNivo = new ColumnHeader();
            btnZatvori = new Button();
            SuspendLayout();
            // 
            // cmbKursevi
            // 
            cmbKursevi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKursevi.FormattingEnabled = true;
            cmbKursevi.Location = new Point(18, 19);
            cmbKursevi.Name = "cmbKursevi";
            cmbKursevi.Size = new Size(219, 23);
            cmbKursevi.TabIndex = 0;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(254, 19);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(88, 22);
            btnDodaj.TabIndex = 1;
            btnDodaj.Text = "Dodaj kurs";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // lwPrijavljeniKursevi
            // 
            lwPrijavljeniKursevi.Columns.AddRange(new ColumnHeader[] { colId, colNaziv, colNivo });
            lwPrijavljeniKursevi.FullRowSelect = true;
            lwPrijavljeniKursevi.GridLines = true;
            lwPrijavljeniKursevi.Location = new Point(18, 66);
            lwPrijavljeniKursevi.Name = "lwPrijavljeniKursevi";
            lwPrijavljeniKursevi.Size = new Size(324, 188);
            lwPrijavljeniKursevi.TabIndex = 2;
            lwPrijavljeniKursevi.UseCompatibleStateImageBehavior = false;
            lwPrijavljeniKursevi.View = View.Details;
            // 
            // colId
            // 
            colId.Text = "ID";
            colId.Width = 50;
            // 
            // colNaziv
            // 
            colNaziv.Text = "Naziv";
            colNaziv.Width = 200;
            // 
            // colNivo
            // 
            colNivo.Text = "Nivo";
            colNivo.Width = 100;
            // 
            // btnZatvori
            // 
            btnZatvori.Location = new Point(243, 260);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(114, 32);
            btnZatvori.TabIndex = 3;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = true;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // dodajPolaznikaNaKursForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 295);
            Controls.Add(btnZatvori);
            Controls.Add(lwPrijavljeniKursevi);
            Controls.Add(btnDodaj);
            Controls.Add(cmbKursevi);
            Name = "dodajPolaznikaNaKursForm";
            Text = "Dodaj polaznika na kurs";
            Load += dodajPolaznikaNaKursForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ComboBox cmbKursevi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.ListView lwPrijavljeniKursevi;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colNaziv;
        private System.Windows.Forms.ColumnHeader colNivo;
        private Button btnZatvori;
    }
}