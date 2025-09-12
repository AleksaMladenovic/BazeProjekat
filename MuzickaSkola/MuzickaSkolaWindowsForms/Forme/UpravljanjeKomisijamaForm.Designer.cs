namespace MuzickaSkolaWindowsForms
{
    partial class UpravljanjeKomisijamaForm
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
            lblNastavnikInfo = new Label();
            label1 = new Label();
            listViewClan = new ListView();
            columnHeader1 = new ColumnHeader();
            btnUkloniUcesce = new Button();
            btnDodajUcesce = new Button();
            label2 = new Label();
            listViewNijeClan = new ListView();
            columnHeader2 = new ColumnHeader();
            btnSnimiPromene = new Button();
            btnDodajKomisiju = new Button();
            SuspendLayout();
            // 
            // lblNastavnikInfo
            // 
            lblNastavnikInfo.AutoSize = true;
            lblNastavnikInfo.Location = new Point(69, 9);
            lblNastavnikInfo.Name = "lblNastavnikInfo";
            lblNastavnikInfo.Size = new Size(217, 15);
            lblNastavnikInfo.TabIndex = 0;
            lblNastavnikInfo.Text = "Upravljanje članstvom za: [Ime Prezime]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 1;
            label1.Text = "Clan u komisijama";
            // 
            // listViewClan
            // 
            listViewClan.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewClan.FullRowSelect = true;
            listViewClan.Location = new Point(12, 70);
            listViewClan.Name = "listViewClan";
            listViewClan.Size = new Size(105, 151);
            listViewClan.TabIndex = 2;
            listViewClan.UseCompatibleStateImageBehavior = false;
            listViewClan.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Komisija";
            columnHeader1.Width = 100;
            // 
            // btnUkloniUcesce
            // 
            btnUkloniUcesce.Location = new Point(155, 130);
            btnUkloniUcesce.Name = "btnUkloniUcesce";
            btnUkloniUcesce.Size = new Size(75, 23);
            btnUkloniUcesce.TabIndex = 3;
            btnUkloniUcesce.Text = "<-";
            btnUkloniUcesce.UseVisualStyleBackColor = true;
            btnUkloniUcesce.Click += btnDodajUcesce_Click;
            // 
            // btnDodajUcesce
            // 
            btnDodajUcesce.Location = new Point(155, 89);
            btnDodajUcesce.Name = "btnDodajUcesce";
            btnDodajUcesce.Size = new Size(75, 23);
            btnDodajUcesce.TabIndex = 4;
            btnDodajUcesce.Text = "->";
            btnDodajUcesce.UseVisualStyleBackColor = true;
            btnDodajUcesce.Click += btnUkloniUcesce_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 52);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 5;
            label2.Text = "Dostupne komisije";
            // 
            // listViewNijeClan
            // 
            listViewNijeClan.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listViewNijeClan.FullRowSelect = true;
            listViewNijeClan.Location = new Point(258, 70);
            listViewNijeClan.Name = "listViewNijeClan";
            listViewNijeClan.Size = new Size(105, 151);
            listViewNijeClan.TabIndex = 6;
            listViewNijeClan.UseCompatibleStateImageBehavior = false;
            listViewNijeClan.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Komisija";
            columnHeader2.Width = 100;
            // 
            // btnSnimiPromene
            // 
            btnSnimiPromene.Location = new Point(127, 198);
            btnSnimiPromene.Name = "btnSnimiPromene";
            btnSnimiPromene.Size = new Size(125, 23);
            btnSnimiPromene.TabIndex = 7;
            btnSnimiPromene.Text = "Sačuvaj promene";
            btnSnimiPromene.UseVisualStyleBackColor = true;
            btnSnimiPromene.Click += btnSnimiPromene_Click;
            // 
            // btnDodajKomisiju
            // 
            btnDodajKomisiju.Location = new Point(127, 169);
            btnDodajKomisiju.Name = "btnDodajKomisiju";
            btnDodajKomisiju.Size = new Size(125, 23);
            btnDodajKomisiju.TabIndex = 8;
            btnDodajKomisiju.Text = "Dodaj novu komisiju";
            btnDodajKomisiju.UseVisualStyleBackColor = true;
            btnDodajKomisiju.Click += btnDodajKomisiju_Click;
            // 
            // UpravljanjeKomisijamaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 230);
            Controls.Add(btnDodajKomisiju);
            Controls.Add(btnSnimiPromene);
            Controls.Add(listViewNijeClan);
            Controls.Add(label2);
            Controls.Add(btnDodajUcesce);
            Controls.Add(btnUkloniUcesce);
            Controls.Add(listViewClan);
            Controls.Add(label1);
            Controls.Add(lblNastavnikInfo);
            Name = "UpravljanjeKomisijamaForm";
            Text = "UpravljanjeKomisijamaForm";
            Load += UpravljanjeKomisijamaForm_Load;
            Click += UpravljanjeKomisijamaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNastavnikInfo;
        private Label label1;
        private ListView listViewClan;
        private ColumnHeader columnHeader1;
        private Button btnUkloniUcesce;
        private Button btnDodajUcesce;
        private Label label2;
        private ListView listViewNijeClan;
        private ColumnHeader columnHeader2;
        private Button btnSnimiPromene;
        private Button btnDodajKomisiju;
    }
}