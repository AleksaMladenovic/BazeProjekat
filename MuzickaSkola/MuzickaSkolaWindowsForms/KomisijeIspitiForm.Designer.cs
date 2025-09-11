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
            listViewIspiti = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            SuspendLayout();
            // 
            // listViewKomisije
            // 
            listViewKomisije.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewKomisije.FullRowSelect = true;
            listViewKomisije.Location = new Point(12, 12);
            listViewKomisije.Name = "listViewKomisije";
            listViewKomisije.Size = new Size(156, 287);
            listViewKomisije.TabIndex = 0;
            listViewKomisije.UseCompatibleStateImageBehavior = false;
            listViewKomisije.View = View.Details;
            listViewKomisije.SelectedIndexChanged += listViewKomisije_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Komisija";
            columnHeader1.Width = 150;
            // 
            // listViewIspiti
            // 
            listViewIspiti.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listViewIspiti.FullRowSelect = true;
            listViewIspiti.Location = new Point(221, 12);
            listViewIspiti.Name = "listViewIspiti";
            listViewIspiti.Size = new Size(484, 287);
            listViewIspiti.TabIndex = 1;
            listViewIspiti.UseCompatibleStateImageBehavior = false;
            listViewIspiti.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Kurs";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Datum";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Ocena";
            columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Polaznik";
            columnHeader6.Width = 150;
            // 
            // KomisijeIspitiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 316);
            Controls.Add(listViewIspiti);
            Controls.Add(listViewKomisije);
            Name = "KomisijeIspitiForm";
            Text = "KomisijeIspitiForm";
            Load += KomisijeIspitiForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewKomisije;
        private ColumnHeader columnHeader1;
        private ListView listViewIspiti;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}