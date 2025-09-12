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
            SuspendLayout();
            // 
            // listViewKomisije
            // 
            listViewKomisije.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewKomisije.FullRowSelect = true;
            listViewKomisije.Location = new Point(12, 12);
            listViewKomisije.Name = "listViewKomisije";
            listViewKomisije.Size = new Size(156, 258);
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
            // listViewClanovi
            // 
            listViewClanovi.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
            listViewClanovi.FullRowSelect = true;
            listViewClanovi.Location = new Point(221, 12);
            listViewClanovi.Name = "listViewClanovi";
            listViewClanovi.Size = new Size(484, 287);
            listViewClanovi.TabIndex = 1;
            listViewClanovi.UseCompatibleStateImageBehavior = false;
            listViewClanovi.View = View.Details;
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
            button1.Location = new Point(12, 276);
            button1.Name = "button1";
            button1.Size = new Size(156, 23);
            button1.TabIndex = 2;
            button1.Text = "Obrisi Komisiju";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // KomisijeIspitiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 316);
            Controls.Add(button1);
            Controls.Add(listViewClanovi);
            Controls.Add(listViewKomisije);
            Name = "KomisijeIspitiForm";
            Text = "KomisijeClanoviForm";
            Load += KomisijeIspitiForm_Load;
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
    }
}