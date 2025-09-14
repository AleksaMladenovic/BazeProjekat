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
            lblNastavnikInfo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblNastavnikInfo.ForeColor = Color.MidnightBlue;
            lblNastavnikInfo.Location = new Point(79, 9);
            lblNastavnikInfo.Name = "lblNastavnikInfo";
            lblNastavnikInfo.Size = new Size(248, 17);
            lblNastavnikInfo.TabIndex = 0;
            lblNastavnikInfo.Text = "Upravljanje članstvom za: [Ime Prezime]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(14, 52);
            label1.Name = "label1";
            label1.Size = new Size(118, 17);
            label1.TabIndex = 1;
            label1.Text = "Clan u komisijama";
            label1.Click += label1_Click;
            // 
            // listViewClan
            // 
            listViewClan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewClan.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewClan.FullRowSelect = true;
            listViewClan.GridLines = true;
            listViewClan.Location = new Point(14, 70);
            listViewClan.Name = "listViewClan";
            listViewClan.Size = new Size(116, 154);
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
            btnUkloniUcesce.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUkloniUcesce.BackColor = Color.LightSteelBlue;
            btnUkloniUcesce.FlatStyle = FlatStyle.Flat;
            btnUkloniUcesce.Location = new Point(191, 137);
            btnUkloniUcesce.Name = "btnUkloniUcesce";
            btnUkloniUcesce.Size = new Size(44, 26);
            btnUkloniUcesce.TabIndex = 3;
            btnUkloniUcesce.TabStop = false;
            btnUkloniUcesce.Text = "<-";
            btnUkloniUcesce.UseVisualStyleBackColor = false;
            btnUkloniUcesce.Click += btnDodajUcesce_Click;
            // 
            // btnDodajUcesce
            // 
            btnDodajUcesce.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDodajUcesce.BackColor = Color.LightSteelBlue;
            btnDodajUcesce.FlatStyle = FlatStyle.Flat;
            btnDodajUcesce.Location = new Point(191, 94);
            btnDodajUcesce.Name = "btnDodajUcesce";
            btnDodajUcesce.Size = new Size(44, 26);
            btnDodajUcesce.TabIndex = 4;
            btnDodajUcesce.TabStop = false;
            btnDodajUcesce.Text = "->";
            btnDodajUcesce.UseVisualStyleBackColor = false;
            btnDodajUcesce.Click += btnUkloniUcesce_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(295, 50);
            label2.Name = "label2";
            label2.Size = new Size(120, 17);
            label2.TabIndex = 5;
            label2.Text = "Dostupne komisije";
            // 
            // listViewNijeClan
            // 
            listViewNijeClan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewNijeClan.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            listViewNijeClan.FullRowSelect = true;
            listViewNijeClan.GridLines = true;
            listViewNijeClan.Location = new Point(295, 70);
            listViewNijeClan.Name = "listViewNijeClan";
            listViewNijeClan.Size = new Size(116, 154);
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
            btnSnimiPromene.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSnimiPromene.BackColor = Color.MidnightBlue;
            btnSnimiPromene.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnSnimiPromene.FlatStyle = FlatStyle.Flat;
            btnSnimiPromene.ForeColor = Color.White;
            btnSnimiPromene.Location = new Point(144, 198);
            btnSnimiPromene.Name = "btnSnimiPromene";
            btnSnimiPromene.Size = new Size(140, 26);
            btnSnimiPromene.TabIndex = 7;
            btnSnimiPromene.TabStop = false;
            btnSnimiPromene.Text = "Sačuvaj promene";
            btnSnimiPromene.UseVisualStyleBackColor = false;
            btnSnimiPromene.Click += btnSnimiPromene_Click;
            // 
            // btnDodajKomisiju
            // 
            btnDodajKomisiju.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDodajKomisiju.BackColor = Color.MidnightBlue;
            btnDodajKomisiju.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDodajKomisiju.FlatStyle = FlatStyle.Flat;
            btnDodajKomisiju.ForeColor = Color.White;
            btnDodajKomisiju.Location = new Point(144, 169);
            btnDodajKomisiju.Name = "btnDodajKomisiju";
            btnDodajKomisiju.Size = new Size(140, 26);
            btnDodajKomisiju.TabIndex = 8;
            btnDodajKomisiju.TabStop = false;
            btnDodajKomisiju.Text = "Dodaj novu komisiju";
            btnDodajKomisiju.UseVisualStyleBackColor = false;
            btnDodajKomisiju.Click += btnDodajKomisiju_Click;
            // 
            // UpravljanjeKomisijamaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 233);
            Controls.Add(btnDodajKomisiju);
            Controls.Add(btnSnimiPromene);
            Controls.Add(listViewNijeClan);
            Controls.Add(label2);
            Controls.Add(btnDodajUcesce);
            Controls.Add(btnUkloniUcesce);
            Controls.Add(listViewClan);
            Controls.Add(label1);
            Controls.Add(lblNastavnikInfo);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Name = "UpravljanjeKomisijamaForm";
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