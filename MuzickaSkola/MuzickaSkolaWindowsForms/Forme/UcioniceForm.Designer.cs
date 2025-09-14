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
            panel1 = new Panel();
            labelNaslov = new Label();
            lblInfoLokacije = new Label();
            groupBox1 = new GroupBox();
            cmdObrisiUcionicu = new Button();
            cmdIzmeniUcionicu = new Button();
            cmdDodajUcionicu = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewUcionice
            // 
            listViewUcionice.Columns.AddRange(new ColumnHeader[] { chNaziv, chOpremljenost, chKapacitet });
            listViewUcionice.FullRowSelect = true;
            listViewUcionice.GridLines = true;
            listViewUcionice.Location = new Point(0, 66);
            listViewUcionice.Name = "listViewUcionice";
            listViewUcionice.Size = new Size(573, 384);
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
            splitContainer1.Panel1.Controls.Add(panel1);
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
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            panel1.ForeColor = Color.MidnightBlue;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 60);
            panel1.TabIndex = 2;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(227, 12);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(117, 33);
            labelNaslov.TabIndex = 2;
            labelNaslov.Text = "Učionice";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblInfoLokacije
            // 
            lblInfoLokacije.AutoSize = true;
            lblInfoLokacije.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblInfoLokacije.ForeColor = Color.MidnightBlue;
            lblInfoLokacije.Location = new Point(3, 68);
            lblInfoLokacije.Name = "lblInfoLokacije";
            lblInfoLokacije.Size = new Size(0, 17);
            lblInfoLokacije.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdObrisiUcionicu);
            groupBox1.Controls.Add(cmdIzmeniUcionicu);
            groupBox1.Controls.Add(cmdDodajUcionicu);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 129);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o ucionici";
            // 
            // cmdObrisiUcionicu
            // 
            cmdObrisiUcionicu.BackColor = Color.MidnightBlue;
            cmdObrisiUcionicu.FlatAppearance.BorderSize = 0;
            cmdObrisiUcionicu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdObrisiUcionicu.FlatStyle = FlatStyle.Flat;
            cmdObrisiUcionicu.ForeColor = Color.White;
            cmdObrisiUcionicu.Location = new Point(3, 92);
            cmdObrisiUcionicu.Name = "cmdObrisiUcionicu";
            cmdObrisiUcionicu.Size = new Size(202, 30);
            cmdObrisiUcionicu.TabIndex = 2;
            cmdObrisiUcionicu.Text = "Obrisi ucionicu";
            cmdObrisiUcionicu.UseVisualStyleBackColor = false;
            cmdObrisiUcionicu.Click += cmdObrisiUcionicu_Click;
            // 
            // cmdIzmeniUcionicu
            // 
            cmdIzmeniUcionicu.BackColor = Color.MidnightBlue;
            cmdIzmeniUcionicu.FlatAppearance.BorderSize = 0;
            cmdIzmeniUcionicu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdIzmeniUcionicu.FlatStyle = FlatStyle.Flat;
            cmdIzmeniUcionicu.ForeColor = Color.White;
            cmdIzmeniUcionicu.Location = new Point(3, 57);
            cmdIzmeniUcionicu.Name = "cmdIzmeniUcionicu";
            cmdIzmeniUcionicu.Size = new Size(202, 30);
            cmdIzmeniUcionicu.TabIndex = 1;
            cmdIzmeniUcionicu.Text = "Izmeni ucionicu";
            cmdIzmeniUcionicu.UseVisualStyleBackColor = false;
            cmdIzmeniUcionicu.Click += cmdIzmeniUcionicu_Click;
            // 
            // cmdDodajUcionicu
            // 
            cmdDodajUcionicu.BackColor = Color.MidnightBlue;
            cmdDodajUcionicu.FlatAppearance.BorderSize = 0;
            cmdDodajUcionicu.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdDodajUcionicu.FlatStyle = FlatStyle.Flat;
            cmdDodajUcionicu.ForeColor = Color.White;
            cmdDodajUcionicu.Location = new Point(3, 21);
            cmdDodajUcionicu.Name = "cmdDodajUcionicu";
            cmdDodajUcionicu.Size = new Size(202, 30);
            cmdDodajUcionicu.TabIndex = 0;
            cmdDodajUcionicu.Text = "Dodaj ucionicu";
            cmdDodajUcionicu.UseVisualStyleBackColor = false;
            cmdDodajUcionicu.Click += cmdDodajUcionicu_Click;
            // 
            // UcioniceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "UcioniceForm";
            Load += UcioniceForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected ListView listViewUcionice;
        private ColumnHeader chNaziv;
        private ColumnHeader chOpremljenost;
        private ColumnHeader chKapacitet;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Button cmdObrisiUcionicu;
        private Button cmdIzmeniUcionicu;
        private Button cmdDodajUcionicu;
        private Panel panel1;
        private Label lblInfoLokacije;
        private Label labelNaslov;
    }
}