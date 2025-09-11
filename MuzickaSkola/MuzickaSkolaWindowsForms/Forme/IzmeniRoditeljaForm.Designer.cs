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
            this.components = new System.ComponentModel.Container();

            this.gb = new System.Windows.Forms.GroupBox();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbJmbg = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();

            this.SuspendLayout();
            this.gb.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 260);
            this.MinimumSize = new System.Drawing.Size(520, 260);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "IzmeniRoditeljaForm";
            this.Text = "Izmeni roditelja";
            this.Load += new System.EventHandler(this.IzmeniRoditeljaForm_Load);

            // GroupBox
            this.gb.Name = "gb";
            this.gb.Text = "Podaci o roditelju";
            this.gb.Location = new System.Drawing.Point(12, 12);
            this.gb.Size = new System.Drawing.Size(496, 200);
            this.gb.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.gb.TabIndex = 0;

            // TableLayoutPanel
            this.tlp.Name = "tlp";
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.Padding = new System.Windows.Forms.Padding(8);
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F)); // label
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // input
            this.tlp.RowCount = 5;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp.TabIndex = 0;

            // Labels
            
            this.lblJmbg.Text = "JMBG";
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblJmbg.TabIndex = 0;

            
            this.lblIme.Text = "Ime";
            this.lblIme.AutoSize = true;
            this.lblIme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIme.TabIndex = 2;

            
            this.lblPrezime.Text = "Prezime";
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrezime.TabIndex = 4;

            
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTelefon.TabIndex = 6;

            
            this.lblEmail.Text = "Email";
            this.lblEmail.AutoSize = true;
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.TabIndex = 8;

            // TextBoxes
            this.tbJmbg.Name = "tbJmbg";
            this.tbJmbg.MaxLength = 13;
            this.tbJmbg.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbJmbg.TabIndex = 1;

            this.tbIme.Name = "tbIme";
            this.tbIme.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbIme.TabIndex = 3;

            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbPrezime.TabIndex = 5;

            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbTelefon.TabIndex = 7;

            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbEmail.TabIndex = 9;

            // Add rows to TLP (label, input)
            this.tlp.Controls.Add(this.lblJmbg, 0, 0); this.tlp.Controls.Add(this.tbJmbg, 1, 0);
            this.tlp.Controls.Add(this.lblIme, 0, 1); this.tlp.Controls.Add(this.tbIme, 1, 1);
            this.tlp.Controls.Add(this.lblPrezime, 0, 2); this.tlp.Controls.Add(this.tbPrezime, 1, 2);
            this.tlp.Controls.Add(this.lblTelefon, 0, 3); this.tlp.Controls.Add(this.tbTelefon, 1, 3);
            this.tlp.Controls.Add(this.lblEmail, 0, 4); this.tlp.Controls.Add(this.tbEmail, 1, 4);

            // Add TLP to GroupBox
            this.gb.Controls.Add(this.tlp);

            // Buttons
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(100, 34);
            this.btnSacuvaj.Location = new System.Drawing.Point(this.ClientSize.Width - 220, 212);
            this.btnSacuvaj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSacuvaj.TabIndex = 10;
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);

            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Text = "Otkaži";
            this.btnOdustani.Size = new System.Drawing.Size(100, 34);
            this.btnOdustani.Location = new System.Drawing.Point(this.ClientSize.Width - 110, 212);
            this.btnOdustani.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnOdustani.TabIndex = 11;
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);

            this.AcceptButton = this.btnSacuvaj;
            this.CancelButton = this.btnOdustani;

            // Add to form
            this.Controls.Add(this.gb);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnOdustani);

            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
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