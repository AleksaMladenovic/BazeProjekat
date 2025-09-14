namespace MuzickaSkolaWindowsForms.Forme
{
    partial class KursLokacijeForm
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
            listViewNedodeljeneLokacije = new ListView();
            chAdresa = new ColumnHeader();
            chRadnoVreme = new ColumnHeader();
            chKapacitet = new ColumnHeader();
            listViewDodeljeneLokacije = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            cmdDodajLokaciju = new Button();
            cmdUkloniLokaciju = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmdSacuvaj = new Button();
            SuspendLayout();
            // 
            // listViewNedodeljeneLokacije
            // 
            listViewNedodeljeneLokacije.Columns.AddRange(new ColumnHeader[] { chAdresa, chRadnoVreme, chKapacitet });
            listViewNedodeljeneLokacije.FullRowSelect = true;
            listViewNedodeljeneLokacije.GridLines = true;
            listViewNedodeljeneLokacije.Location = new Point(14, 38);
            listViewNedodeljeneLokacije.Name = "listViewNedodeljeneLokacije";
            listViewNedodeljeneLokacije.OwnerDraw = true;
            listViewNedodeljeneLokacije.Size = new Size(495, 321);
            listViewNedodeljeneLokacije.TabIndex = 1;
            listViewNedodeljeneLokacije.UseCompatibleStateImageBehavior = false;
            listViewNedodeljeneLokacije.View = View.Details;
            listViewNedodeljeneLokacije.DrawColumnHeader += listViewNedodeljeneLokacije_DrawColumnHeader;
            listViewNedodeljeneLokacije.DrawItem += listViewNedodeljeneLokacije_DrawItem;
            listViewNedodeljeneLokacije.RetrieveVirtualItem += listViewNedodeljeneLokacije_RetrieveVirtualItem;
            listViewNedodeljeneLokacije.SelectedIndexChanged += listViewNedodeljeneLokacije_SelectedIndexChanged;
            listViewNedodeljeneLokacije.MouseDoubleClick += listViewNedodeljeneLokacije_MouseDoubleClick;
            // 
            // chAdresa
            // 
            chAdresa.Text = "Adresa";
            chAdresa.Width = 200;
            // 
            // chRadnoVreme
            // 
            chRadnoVreme.Text = "Radno vreme";
            chRadnoVreme.Width = 150;
            // 
            // chKapacitet
            // 
            chKapacitet.Text = "Kapacitet";
            chKapacitet.Width = 80;
            // 
            // listViewDodeljeneLokacije
            // 
            listViewDodeljeneLokacije.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewDodeljeneLokacije.FullRowSelect = true;
            listViewDodeljeneLokacije.GridLines = true;
            listViewDodeljeneLokacije.Location = new Point(571, 38);
            listViewDodeljeneLokacije.Name = "listViewDodeljeneLokacije";
            listViewDodeljeneLokacije.OwnerDraw = true;
            listViewDodeljeneLokacije.Size = new Size(495, 321);
            listViewDodeljeneLokacije.TabIndex = 2;
            listViewDodeljeneLokacije.UseCompatibleStateImageBehavior = false;
            listViewDodeljeneLokacije.View = View.Details;
            listViewDodeljeneLokacije.DrawColumnHeader += listViewDodeljeneLokacije_DrawColumnHeader;
            listViewDodeljeneLokacije.DrawItem += listViewDodeljeneLokacije_DrawItem;
            listViewDodeljeneLokacije.SelectedIndexChanged += listViewDodeljeneLokacije_SelectedIndexChanged;
            listViewDodeljeneLokacije.MouseDoubleClick += listViewDodeljeneLokacije_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Adresa";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Radno vreme";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Kapacitet";
            columnHeader3.Width = 80;
            // 
            // cmdDodajLokaciju
            // 
            cmdDodajLokaciju.BackColor = SystemColors.ActiveBorder;
            cmdDodajLokaciju.Location = new Point(517, 140);
            cmdDodajLokaciju.Name = "cmdDodajLokaciju";
            cmdDodajLokaciju.Size = new Size(48, 31);
            cmdDodajLokaciju.TabIndex = 3;
            cmdDodajLokaciju.Text = ">>";
            cmdDodajLokaciju.UseVisualStyleBackColor = false;
            cmdDodajLokaciju.Click += cmdDodajLokaciju_Click;
            // 
            // cmdUkloniLokaciju
            // 
            cmdUkloniLokaciju.BackColor = SystemColors.ActiveBorder;
            cmdUkloniLokaciju.Location = new Point(517, 206);
            cmdUkloniLokaciju.Name = "cmdUkloniLokaciju";
            cmdUkloniLokaciju.Size = new Size(48, 31);
            cmdUkloniLokaciju.TabIndex = 4;
            cmdUkloniLokaciju.Text = "<<";
            cmdUkloniLokaciju.UseVisualStyleBackColor = false;
            cmdUkloniLokaciju.Click += cmdUkloniLokaciju_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(517, 122);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 5;
            label1.Text = "Dodaj";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(517, 188);
            label2.Name = "label2";
            label2.Size = new Size(46, 17);
            label2.TabIndex = 6;
            label2.Text = "Ukloni";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(23, 9);
            label3.Name = "label3";
            label3.Size = new Size(135, 17);
            label3.TabIndex = 7;
            label3.Text = "Nedodeljene lokacije:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(583, 9);
            label4.Name = "label4";
            label4.Size = new Size(119, 17);
            label4.TabIndex = 8;
            label4.Text = "Dodeljene lokacije:";
            // 
            // cmdSacuvaj
            // 
            cmdSacuvaj.BackColor = Color.MidnightBlue;
            cmdSacuvaj.FlatAppearance.BorderSize = 0;
            cmdSacuvaj.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdSacuvaj.FlatStyle = FlatStyle.Flat;
            cmdSacuvaj.ForeColor = Color.White;
            cmdSacuvaj.Location = new Point(432, 365);
            cmdSacuvaj.Name = "cmdSacuvaj";
            cmdSacuvaj.Size = new Size(223, 29);
            cmdSacuvaj.TabIndex = 9;
            cmdSacuvaj.Text = "Sačuvaj";
            cmdSacuvaj.UseVisualStyleBackColor = false;
            cmdSacuvaj.Click += cmdSacuvaj_Click;
            // 
            // KursLokacijeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 398);
            Controls.Add(cmdSacuvaj);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmdUkloniLokaciju);
            Controls.Add(cmdDodajLokaciju);
            Controls.Add(listViewDodeljeneLokacije);
            Controls.Add(listViewNedodeljeneLokacije);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.White;
            Name = "KursLokacijeForm";
            Load += KursLokacijeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewNedodeljeneLokacije;
        private ColumnHeader chAdresa;
        private ColumnHeader chRadnoVreme;
        private ColumnHeader chKapacitet;
        private ListView listViewDodeljeneLokacije;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button cmdDodajLokaciju;
        private Button cmdUkloniLokaciju;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button cmdSacuvaj;
    }
}