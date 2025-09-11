namespace MuzickaSkolaWindowsForms.Forme
{
    partial class UcioniceForm
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
            listViewUcionice = new ListView();
            chNaziv = new ColumnHeader();
            chOpremljenost = new ColumnHeader();
            chKapacitet = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            lblInfoLokacije = new Label();
            groupBox1 = new GroupBox();
            cmdObrisiUcionicu = new Button();
            cmdIzmeniUcionicu = new Button();
            cmdDodajUcionicu = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewUcionice
            // 
            listViewUcionice.Columns.AddRange(new ColumnHeader[] { chNaziv, chOpremljenost, chKapacitet });
            listViewUcionice.FullRowSelect = true;
            listViewUcionice.Location = new Point(0, 24);
            listViewUcionice.Name = "listViewUcionice";
            listViewUcionice.Size = new Size(573, 426);
            listViewUcionice.TabIndex = 0;
            listViewUcionice.UseCompatibleStateImageBehavior = false;
            listViewUcionice.View = View.Details;
            // 
            // chNaziv
            // 
            chNaziv.Text = "Naziv";
            chNaziv.Width = 250;
            // 
            // chOpremljenost
            // 
            chOpremljenost.Text = "Opremljenost";
            chOpremljenost.Width = 250;
            // 
            // chKapacitet
            // 
            chKapacitet.Text = "Kapacitet";
            chKapacitet.Width = 80;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblInfoLokacije);
            splitContainer1.Panel1.Controls.Add(listViewUcionice);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 573;
            splitContainer1.TabIndex = 1;
            // 
            // lblInfoLokacije
            // 
            lblInfoLokacije.AutoSize = true;
            lblInfoLokacije.Location = new Point(12, 6);
            lblInfoLokacije.Name = "lblInfoLokacije";
            lblInfoLokacije.Size = new Size(99, 15);
            lblInfoLokacije.TabIndex = 1;
            lblInfoLokacije.Text = "label info lokacije";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdObrisiUcionicu);
            groupBox1.Controls.Add(cmdIzmeniUcionicu);
            groupBox1.Controls.Add(cmdDodajUcionicu);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o ucionici";
            // 
            // cmdObrisiUcionicu
            // 
            cmdObrisiUcionicu.Location = new Point(6, 79);
            cmdObrisiUcionicu.Name = "cmdObrisiUcionicu";
            cmdObrisiUcionicu.Size = new Size(202, 23);
            cmdObrisiUcionicu.TabIndex = 2;
            cmdObrisiUcionicu.Text = "Obrisi ucionicu";
            cmdObrisiUcionicu.UseVisualStyleBackColor = true;
            cmdObrisiUcionicu.Click += cmdObrisiUcionicu_Click;
            // 
            // cmdIzmeniUcionicu
            // 
            cmdIzmeniUcionicu.Location = new Point(6, 50);
            cmdIzmeniUcionicu.Name = "cmdIzmeniUcionicu";
            cmdIzmeniUcionicu.Size = new Size(202, 23);
            cmdIzmeniUcionicu.TabIndex = 1;
            cmdIzmeniUcionicu.Text = "Izmeni ucionicu";
            cmdIzmeniUcionicu.UseVisualStyleBackColor = true;
            cmdIzmeniUcionicu.Click += cmdIzmeniUcionicu_Click;
            // 
            // cmdDodajUcionicu
            // 
            cmdDodajUcionicu.Location = new Point(6, 21);
            cmdDodajUcionicu.Name = "cmdDodajUcionicu";
            cmdDodajUcionicu.Size = new Size(202, 23);
            cmdDodajUcionicu.TabIndex = 0;
            cmdDodajUcionicu.Text = "Dodaj ucionicu";
            cmdDodajUcionicu.UseVisualStyleBackColor = true;
            cmdDodajUcionicu.Click += cmdDodajUcionicu_Click;
            // 
            // UcioniceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "UcioniceForm";
            Text = "UcioniceForm";
            Load += UcioniceForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected ListView listViewUcionice;
        private ColumnHeader chNaziv;
        private ColumnHeader chOpremljenost;
        private ColumnHeader chKapacitet;
        private SplitContainer splitContainer1;
        private Label lblInfoLokacije;
        private GroupBox groupBox1;
        private Button cmdObrisiUcionicu;
        private Button cmdIzmeniUcionicu;
        private Button cmdDodajUcionicu;
    }
}