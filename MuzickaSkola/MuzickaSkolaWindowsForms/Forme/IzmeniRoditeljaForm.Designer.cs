namespace MuzickaSkolaWindowsForms.Forme
{
    partial class IzmeniRoditeljaForm
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
            gb = new GroupBox();
            tlp = new TableLayoutPanel();
            lblJmbg = new Label();
            tbJmbg = new TextBox();
            lblIme = new Label();
            tbIme = new TextBox();
            lblPrezime = new Label();
            tbPrezime = new TextBox();
            lblTelefon = new Label();
            tbTelefon = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            btnSacuvaj = new Button();
            btnOdustani = new Button();
            gb.SuspendLayout();
            tlp.SuspendLayout();
            SuspendLayout();
            // 
            // gb
            // 
            gb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb.Controls.Add(tlp);
            gb.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            gb.ForeColor = Color.MidnightBlue;
            gb.Location = new Point(12, 12);
            gb.Name = "gb";
            gb.Size = new Size(496, 200);
            gb.TabIndex = 0;
            gb.TabStop = false;
            gb.Text = "Podaci o roditelju";
            // 
            // tlp
            // 
            tlp.AutoSize = true;
            tlp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.Controls.Add(lblJmbg, 0, 0);
            tlp.Controls.Add(tbJmbg, 1, 0);
            tlp.Controls.Add(lblIme, 0, 1);
            tlp.Controls.Add(tbIme, 1, 1);
            tlp.Controls.Add(lblPrezime, 0, 2);
            tlp.Controls.Add(tbPrezime, 1, 2);
            tlp.Controls.Add(lblTelefon, 0, 3);
            tlp.Controls.Add(tbTelefon, 1, 3);
            tlp.Controls.Add(lblEmail, 0, 4);
            tlp.Controls.Add(tbEmail, 1, 4);
            tlp.Dock = DockStyle.Top;
            tlp.Location = new Point(3, 21);
            tlp.Name = "tlp";
            tlp.Padding = new Padding(8);
            tlp.RowCount = 5;
            tlp.RowStyles.Add(new RowStyle());
            tlp.RowStyles.Add(new RowStyle());
            tlp.RowStyles.Add(new RowStyle());
            tlp.RowStyles.Add(new RowStyle());
            tlp.RowStyles.Add(new RowStyle());
            tlp.Size = new Size(490, 171);
            tlp.TabIndex = 0;
            // 
            // lblJmbg
            // 
            lblJmbg.Anchor = AnchorStyles.Left;
            lblJmbg.AutoSize = true;
            lblJmbg.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblJmbg.ForeColor = Color.MidnightBlue;
            lblJmbg.Location = new Point(11, 15);
            lblJmbg.Name = "lblJmbg";
            lblJmbg.Size = new Size(42, 17);
            lblJmbg.TabIndex = 0;
            lblJmbg.Text = "JMBG";
            // 
            // tbJmbg
            // 
            tbJmbg.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbJmbg.Location = new Point(131, 11);
            tbJmbg.MaxLength = 13;
            tbJmbg.Name = "tbJmbg";
            tbJmbg.Size = new Size(348, 25);
            tbJmbg.TabIndex = 1;
            // 
            // lblIme
            // 
            lblIme.Anchor = AnchorStyles.Left;
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblIme.ForeColor = Color.MidnightBlue;
            lblIme.Location = new Point(11, 46);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(31, 17);
            lblIme.TabIndex = 2;
            lblIme.Text = "Ime";
            // 
            // tbIme
            // 
            tbIme.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbIme.Location = new Point(131, 42);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(348, 25);
            tbIme.TabIndex = 3;
            // 
            // lblPrezime
            // 
            lblPrezime.Anchor = AnchorStyles.Left;
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPrezime.ForeColor = Color.MidnightBlue;
            lblPrezime.Location = new Point(11, 77);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(56, 17);
            lblPrezime.TabIndex = 4;
            lblPrezime.Text = "Prezime";
            // 
            // tbPrezime
            // 
            tbPrezime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbPrezime.Location = new Point(131, 73);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(348, 25);
            tbPrezime.TabIndex = 5;
            // 
            // lblTelefon
            // 
            lblTelefon.Anchor = AnchorStyles.Left;
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblTelefon.ForeColor = Color.MidnightBlue;
            lblTelefon.Location = new Point(11, 108);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(51, 17);
            lblTelefon.TabIndex = 6;
            lblTelefon.Text = "Telefon";
            // 
            // tbTelefon
            // 
            tbTelefon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbTelefon.Location = new Point(131, 104);
            tbTelefon.Name = "tbTelefon";
            tbTelefon.Size = new Size(348, 25);
            tbTelefon.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblEmail.ForeColor = Color.MidnightBlue;
            lblEmail.Location = new Point(11, 139);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(40, 17);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbEmail.Location = new Point(131, 135);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(348, 25);
            tbEmail.TabIndex = 9;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSacuvaj.Location = new Point(715, 173);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(100, 34);
            btnSacuvaj.TabIndex = 10;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnOdustani
            // 
            btnOdustani.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOdustani.Location = new Point(715, 173);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(100, 34);
            btnOdustani.TabIndex = 11;
            btnOdustani.Text = "Otkaži";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // IzmeniRoditeljaForm
            // 
            AcceptButton = btnSacuvaj;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnOdustani;
            ClientSize = new Size(520, 221);
            Controls.Add(gb);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnOdustani);
            MinimumSize = new Size(520, 260);
            Name = "IzmeniRoditeljaForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += IzmeniRoditeljaForm_Load;
            gb.ResumeLayout(false);
            gb.PerformLayout();
            tlp.ResumeLayout(false);
            tlp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbJmbg;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
    }
}