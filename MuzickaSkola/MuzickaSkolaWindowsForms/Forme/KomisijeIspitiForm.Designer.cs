namespace MuzickaSkolaWindowsForms
{
    partial class KomisijeIspitiForm
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
            listViewKomisije = new ListView();
            columnHeader1 = new ColumnHeader();
            listViewClanovi = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            button1 = new Button();
            oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            labelNaslov = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewKomisije
            // 
            listViewKomisije.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewKomisije.FullRowSelect = true;
            listViewKomisije.GridLines = true;
            listViewKomisije.Location = new Point(12, 66);
            listViewKomisije.Name = "listViewKomisije";
            listViewKomisije.OwnerDraw = true;
            listViewKomisije.Size = new Size(156, 204);
            listViewKomisije.TabIndex = 0;
            listViewKomisije.UseCompatibleStateImageBehavior = false;
            listViewKomisije.View = View.Details;
            listViewKomisije.DrawColumnHeader += listViewKomisije_DrawColumnHeader;
            listViewKomisije.DrawItem += listViewKomisije_DrawItem;
            listViewKomisije.SelectedIndexChanged += listViewKomisije_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Komisija";
            columnHeader1.Width = 150;
            // 
            // listViewClanovi
            // 
            listViewClanovi.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
            listViewClanovi.FullRowSelect = true;
            listViewClanovi.GridLines = true;
            listViewClanovi.Location = new Point(221, 66);
            listViewClanovi.Name = "listViewClanovi";
            listViewClanovi.OwnerDraw = true;
            listViewClanovi.Size = new Size(404, 233);
            listViewClanovi.TabIndex = 1;
            listViewClanovi.UseCompatibleStateImageBehavior = false;
            listViewClanovi.View = View.Details;
            listViewClanovi.DrawColumnHeader += listViewClanovi_DrawColumnHeader;
            listViewClanovi.DrawItem += listViewClanovi_DrawItem;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ime";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Prezime";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Strucna Sprema";
            columnHeader5.Width = 150;
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 276);
            button1.Name = "button1";
            button1.Size = new Size(156, 28);
            button1.TabIndex = 2;
            button1.Text = "Obrisi Komisiju";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(174, 23);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(185, 33);
            labelNaslov.TabIndex = 0;
            labelNaslov.Text = "Muzička Škola";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(638, 60);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(150, 9);
            label1.Name = "label1";
            label1.Size = new Size(326, 33);
            label1.TabIndex = 1;
            label1.Text = "Pregled Komisija i Članova";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // KomisijeIspitiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 316);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(listViewClanovi);
            Controls.Add(listViewKomisije);
            Name = "KomisijeIspitiForm";
            Load += KomisijeIspitiForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewKomisije;
        private ColumnHeader columnHeader1;
        private ListView listViewClanovi;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button button1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private Label labelNaslov;
        private Panel panel1;
        private Label label1;
    }
}