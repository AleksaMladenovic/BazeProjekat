namespace MuzickaSkolaWindowsForms.Forme
{
    partial class RoditeljiForm
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
            gbRoditelji = new GroupBox();
            lvRoditelji = new ListView();
            chId = new ColumnHeader();
            chJmbg = new ColumnHeader();
            chIme = new ColumnHeader();
            chPrezime = new ColumnHeader();
            chTelefon = new ColumnHeader();
            chEmail = new ColumnHeader();
            gbAkcije = new GroupBox();
            btnObrisiRoditelja = new Button();
            btnIzmeniRoditelja = new Button();
            panel1 = new Panel();
            labelNaslov = new Label();
            gbRoditelji.SuspendLayout();
            gbAkcije.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbRoditelji
            // 
            gbRoditelji.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbRoditelji.Controls.Add(lvRoditelji);
            gbRoditelji.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            gbRoditelji.ForeColor = Color.MidnightBlue;
            gbRoditelji.Location = new Point(6, 66);
            gbRoditelji.Name = "gbRoditelji";
            gbRoditelji.Size = new Size(685, 383);
            gbRoditelji.TabIndex = 0;
            gbRoditelji.TabStop = false;
            gbRoditelji.Text = "Svi roditelji";
            // 
            // lvRoditelji
            // 
            lvRoditelji.Anchor = AnchorStyles.None;
            lvRoditelji.BorderStyle = BorderStyle.FixedSingle;
            lvRoditelji.Columns.AddRange(new ColumnHeader[] { chId, chJmbg, chIme, chPrezime, chTelefon, chEmail });
            lvRoditelji.FullRowSelect = true;
            lvRoditelji.GridLines = true;
            lvRoditelji.Location = new Point(5, 21);
            lvRoditelji.MultiSelect = false;
            lvRoditelji.Name = "lvRoditelji";
            lvRoditelji.OwnerDraw = true;
            lvRoditelji.Size = new Size(675, 359);
            lvRoditelji.TabIndex = 0;
            lvRoditelji.UseCompatibleStateImageBehavior = false;
            lvRoditelji.View = View.Details;
            lvRoditelji.DrawColumnHeader += lvRoditelji_DrawColumnHeader;
            lvRoditelji.DrawItem += lvRoditelji_DrawItem;
            // 
            // chId
            // 
            chId.Text = "Id";
            // 
            // chJmbg
            // 
            chJmbg.Text = "JMBG";
            chJmbg.TextAlign = HorizontalAlignment.Center;
            chJmbg.Width = 110;
            // 
            // chIme
            // 
            chIme.Text = "Ime";
            chIme.TextAlign = HorizontalAlignment.Center;
            chIme.Width = 120;
            // 
            // chPrezime
            // 
            chPrezime.Text = "Prezime";
            chPrezime.TextAlign = HorizontalAlignment.Center;
            chPrezime.Width = 120;
            // 
            // chTelefon
            // 
            chTelefon.Text = "Telefon";
            chTelefon.TextAlign = HorizontalAlignment.Center;
            chTelefon.Width = 110;
            // 
            // chEmail
            // 
            chEmail.Text = "Email";
            chEmail.TextAlign = HorizontalAlignment.Center;
            chEmail.Width = 150;
            // 
            // gbAkcije
            // 
            gbAkcije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbAkcije.Controls.Add(btnObrisiRoditelja);
            gbAkcije.Controls.Add(btnIzmeniRoditelja);
            gbAkcije.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            gbAkcije.ForeColor = Color.MidnightBlue;
            gbAkcije.Location = new Point(697, 183);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(173, 108);
            gbAkcije.TabIndex = 1;
            gbAkcije.TabStop = false;
            gbAkcije.Text = "Akcije";
            // 
            // btnObrisiRoditelja
            // 
            btnObrisiRoditelja.BackColor = Color.MidnightBlue;
            btnObrisiRoditelja.FlatAppearance.BorderSize = 0;
            btnObrisiRoditelja.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnObrisiRoditelja.FlatStyle = FlatStyle.Flat;
            btnObrisiRoditelja.ForeColor = Color.White;
            btnObrisiRoditelja.Location = new Point(6, 70);
            btnObrisiRoditelja.Name = "btnObrisiRoditelja";
            btnObrisiRoditelja.Size = new Size(161, 30);
            btnObrisiRoditelja.TabIndex = 1;
            btnObrisiRoditelja.Text = "Obrisi roditelja";
            btnObrisiRoditelja.UseVisualStyleBackColor = false;
            btnObrisiRoditelja.Click += btnObrisiRoditelja_Click_1;
            // 
            // btnIzmeniRoditelja
            // 
            btnIzmeniRoditelja.BackColor = Color.MidnightBlue;
            btnIzmeniRoditelja.FlatAppearance.BorderSize = 0;
            btnIzmeniRoditelja.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnIzmeniRoditelja.FlatStyle = FlatStyle.Flat;
            btnIzmeniRoditelja.ForeColor = Color.White;
            btnIzmeniRoditelja.Location = new Point(6, 24);
            btnIzmeniRoditelja.Name = "btnIzmeniRoditelja";
            btnIzmeniRoditelja.Size = new Size(161, 33);
            btnIzmeniRoditelja.TabIndex = 0;
            btnIzmeniRoditelja.Text = "Izmeni roditelja";
            btnIzmeniRoditelja.UseVisualStyleBackColor = false;
            btnIzmeniRoditelja.Click += btnIzmeniRoditelja_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 60);
            panel1.TabIndex = 2;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(372, 9);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(115, 33);
            labelNaslov.TabIndex = 4;
            labelNaslov.Text = "Roditelji";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // RoditeljiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 461);
            Controls.Add(panel1);
            Controls.Add(gbAkcije);
            Controls.Add(gbRoditelji);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.MidnightBlue;
            MinimumSize = new Size(820, 500);
            Name = "RoditeljiForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += RoditeljiForm_Load;
            gbRoditelji.ResumeLayout(false);
            gbAkcije.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox gbRoditelji;
        private System.Windows.Forms.ListView lvRoditelji;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chJmbg;
        private System.Windows.Forms.ColumnHeader chIme;
        private System.Windows.Forms.ColumnHeader chPrezime;
        private System.Windows.Forms.ColumnHeader chTelefon;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.GroupBox gbAkcije;
        private System.Windows.Forms.Button btnIzmeniRoditelja;
        private Button btnObrisiRoditelja;
        private Panel panel1;
        private Label labelNaslov;
    }
}