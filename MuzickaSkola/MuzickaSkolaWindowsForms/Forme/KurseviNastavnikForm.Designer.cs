namespace MuzickaSkolaWindowsForms
{
    partial class KurseviNastavnikForm
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
            listViewKursevi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel1 = new Panel();
            labelNaslov = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewKursevi
            // 
            listViewKursevi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewKursevi.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewKursevi.FullRowSelect = true;
            listViewKursevi.GridLines = true;
            listViewKursevi.Location = new Point(12, 46);
            listViewKursevi.Name = "listViewKursevi";
            listViewKursevi.OwnerDraw = true;
            listViewKursevi.Size = new Size(558, 221);
            listViewKursevi.TabIndex = 0;
            listViewKursevi.UseCompatibleStateImageBehavior = false;
            listViewKursevi.View = View.Details;
            listViewKursevi.DrawColumnHeader += listViewKursevi_DrawColumnHeader;
            listViewKursevi.DrawItem += listViewKursevi_DrawItem;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Naziv kursa";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nivo";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tip Kursa";
            columnHeader3.Width = 200;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(583, 40);
            panel1.TabIndex = 1;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(160, 9);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(242, 23);
            labelNaslov.TabIndex = 2;
            labelNaslov.Text = "Kursevi koje vodi nastavnik";
            labelNaslov.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KurseviNastavnikForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 279);
            Controls.Add(panel1);
            Controls.Add(listViewKursevi);
            Name = "KurseviNastavnikForm";
            Load += KurseviNastavnikaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewKursevi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel1;
        private Label labelNaslov;
    }
}