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
            SuspendLayout();
            // 
            // listViewKursevi
            // 
            listViewKursevi.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewKursevi.FullRowSelect = true;
            listViewKursevi.GridLines = true;
            listViewKursevi.Location = new Point(12, 11);
            listViewKursevi.Name = "listViewKursevi";
            listViewKursevi.Size = new Size(558, 256);
            listViewKursevi.TabIndex = 0;
            listViewKursevi.UseCompatibleStateImageBehavior = false;
            listViewKursevi.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Naziv kursa";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nivo";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tip Kursa";
            columnHeader3.Width = 200;
            // 
            // KurseviNastavnikForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 279);
            Controls.Add(listViewKursevi);
            Name = "KurseviNastavnikForm";
            Text = "KurseviNastavnikForm";
            Load += KurseviNastavnikaForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewKursevi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}