namespace MuzickaSkolaWindowsForms
{
    partial class CasoviNastavnikaForm
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
            listViewCasovi = new ListView();
            ColumnHeader = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel1 = new Panel();
            labelNaslov = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewCasovi
            // 
            listViewCasovi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewCasovi.Columns.AddRange(new ColumnHeader[] { ColumnHeader, columnHeader2, columnHeader3 });
            listViewCasovi.FullRowSelect = true;
            listViewCasovi.GridLines = true;
            listViewCasovi.Location = new Point(12, 58);
            listViewCasovi.Name = "listViewCasovi";
            listViewCasovi.OwnerDraw = true;
            listViewCasovi.Size = new Size(604, 202);
            listViewCasovi.TabIndex = 0;
            listViewCasovi.UseCompatibleStateImageBehavior = false;
            listViewCasovi.View = View.Details;
            listViewCasovi.DrawColumnHeader += listViewCasovi_DrawColumnHeader;
            listViewCasovi.DrawItem += listViewCasovi_DrawItem;
            // 
            // ColumnHeader
            // 
            ColumnHeader.Text = "Termin";
            ColumnHeader.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tema casa";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ucionica";
            columnHeader3.Width = 250;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 52);
            panel1.TabIndex = 1;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(223, 9);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(161, 31);
            labelNaslov.TabIndex = 2;
            labelNaslov.Text = "Prikaz časova";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // CasoviNastavnikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 272);
            Controls.Add(panel1);
            Controls.Add(listViewCasovi);
            Name = "CasoviNastavnikaForm";
            Load += CasoviNastavnikaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewCasovi;
        private ColumnHeader ColumnHeader;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel1;
        private Label labelNaslov;
    }
}