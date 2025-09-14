namespace MuzickaSkolaWindowsForms
{
    partial class DodeliMentoraForm
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
            listViewMentori = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnDodeli = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNastavnikInfo
            // 
            lblNastavnikInfo.AutoSize = true;
            lblNastavnikInfo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblNastavnikInfo.ForeColor = Color.White;
            lblNastavnikInfo.Location = new Point(3, 9);
            lblNastavnikInfo.Name = "lblNastavnikInfo";
            lblNastavnikInfo.Size = new Size(156, 17);
            lblNastavnikInfo.TabIndex = 0;
            lblNastavnikInfo.Text = "Mentor za:[Ime Prezime]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 37);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 1;
            label1.Text = "Izaberite mentora:";
            // 
            // listViewMentori
            // 
            listViewMentori.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewMentori.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewMentori.FullRowSelect = true;
            listViewMentori.GridLines = true;
            listViewMentori.Location = new Point(3, 70);
            listViewMentori.Name = "listViewMentori";
            listViewMentori.OwnerDraw = true;
            listViewMentori.Size = new Size(255, 80);
            listViewMentori.TabIndex = 2;
            listViewMentori.UseCompatibleStateImageBehavior = false;
            listViewMentori.View = View.Details;
            listViewMentori.DrawColumnHeader += listViewMentori_DrawColumnHeader;
            listViewMentori.DrawItem += listViewMentori_DrawItem;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Ime";
            columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Prezime";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 125;
            // 
            // btnDodeli
            // 
            btnDodeli.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDodeli.BackColor = Color.MidnightBlue;
            btnDodeli.FlatAppearance.BorderSize = 0;
            btnDodeli.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnDodeli.FlatStyle = FlatStyle.Flat;
            btnDodeli.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnDodeli.ForeColor = Color.White;
            btnDodeli.Location = new Point(3, 156);
            btnDodeli.Name = "btnDodeli";
            btnDodeli.Size = new Size(75, 28);
            btnDodeli.TabIndex = 3;
            btnDodeli.Text = "Dodeli";
            btnDodeli.UseVisualStyleBackColor = false;
            btnDodeli.Click += btnDodeli_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(lblNastavnikInfo);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(258, 64);
            panel1.TabIndex = 4;
            // 
            // DodeliMentoraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 187);
            Controls.Add(panel1);
            Controls.Add(btnDodeli);
            Controls.Add(listViewMentori);
            Name = "DodeliMentoraForm";
            Load += DodeliMentoraForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNastavnikInfo;
        private Label label1;
        private ListView listViewMentori;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnDodeli;
        private Panel panel1;
    }
}