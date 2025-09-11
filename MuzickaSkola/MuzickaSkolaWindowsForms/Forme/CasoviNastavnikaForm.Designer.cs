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
            SuspendLayout();
            // 
            // listViewCasovi
            // 
            listViewCasovi.Columns.AddRange(new ColumnHeader[] { ColumnHeader, columnHeader2, columnHeader3 });
            listViewCasovi.FullRowSelect = true;
            listViewCasovi.GridLines = true;
            listViewCasovi.Location = new Point(5, 10);
            listViewCasovi.Name = "listViewCasovi";
            listViewCasovi.Size = new Size(548, 202);
            listViewCasovi.TabIndex = 0;
            listViewCasovi.UseCompatibleStateImageBehavior = false;
            listViewCasovi.View = View.Details;
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
            // CasoviNastavnikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 221);
            Controls.Add(listViewCasovi);
            Name = "CasoviNastavnikaForm";
            Text = "CasoviNastavnikaForm";
            Load += CasoviNastavnikaForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewCasovi;
        private ColumnHeader ColumnHeader;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}