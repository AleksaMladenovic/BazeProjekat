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
            listViewNedodeljeneLokacije.Location = new Point(12, 38);
            listViewNedodeljeneLokacije.Name = "listViewNedodeljeneLokacije";
            listViewNedodeljeneLokacije.Size = new Size(434, 321);
            listViewNedodeljeneLokacije.TabIndex = 1;
            listViewNedodeljeneLokacije.UseCompatibleStateImageBehavior = false;
            listViewNedodeljeneLokacije.View = View.Details;
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
            listViewDodeljeneLokacije.Location = new Point(500, 38);
            listViewDodeljeneLokacije.Name = "listViewDodeljeneLokacije";
            listViewDodeljeneLokacije.Size = new Size(434, 321);
            listViewDodeljeneLokacije.TabIndex = 2;
            listViewDodeljeneLokacije.UseCompatibleStateImageBehavior = false;
            listViewDodeljeneLokacije.View = View.Details;
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
            cmdDodajLokaciju.Location = new Point(452, 140);
            cmdDodajLokaciju.Name = "cmdDodajLokaciju";
            cmdDodajLokaciju.Size = new Size(42, 31);
            cmdDodajLokaciju.TabIndex = 3;
            cmdDodajLokaciju.Text = ">>";
            cmdDodajLokaciju.UseVisualStyleBackColor = true;
            cmdDodajLokaciju.Click += cmdDodajLokaciju_Click;
            // 
            // cmdUkloniLokaciju
            // 
            cmdUkloniLokaciju.Location = new Point(452, 206);
            cmdUkloniLokaciju.Name = "cmdUkloniLokaciju";
            cmdUkloniLokaciju.Size = new Size(42, 31);
            cmdUkloniLokaciju.TabIndex = 4;
            cmdUkloniLokaciju.Text = "<<";
            cmdUkloniLokaciju.UseVisualStyleBackColor = true;
            cmdUkloniLokaciju.Click += cmdUkloniLokaciju_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 122);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "Dodaj";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(452, 188);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 6;
            label2.Text = "Ukoni";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 9);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 7;
            label3.Text = "Nedodeljene lokacije:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 9);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 8;
            label4.Text = "Dodeljene lokacije:";
            // 
            // cmdSacuvaj
            // 
            cmdSacuvaj.Location = new Point(378, 365);
            cmdSacuvaj.Name = "cmdSacuvaj";
            cmdSacuvaj.Size = new Size(195, 23);
            cmdSacuvaj.TabIndex = 9;
            cmdSacuvaj.Text = "Sačuvaj";
            cmdSacuvaj.UseVisualStyleBackColor = true;
            cmdSacuvaj.Click += cmdSacuvaj_Click;
            // 
            // KursLokacijeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 393);
            Controls.Add(cmdSacuvaj);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmdUkloniLokaciju);
            Controls.Add(cmdDodajLokaciju);
            Controls.Add(listViewDodeljeneLokacije);
            Controls.Add(listViewNedodeljeneLokacije);
            Name = "KursLokacijeForm";
            Text = "KursLokacijeForm";
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