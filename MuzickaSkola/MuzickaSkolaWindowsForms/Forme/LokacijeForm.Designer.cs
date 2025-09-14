namespace MuzickaSkolaWindowsForms.Forme
{
    partial class LokacijeForm
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
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            labelNaslov = new Label();
            listViewLokacije = new ListView();
            chAdresa = new ColumnHeader();
            chRadnoVreme = new ColumnHeader();
            chKapacitet = new ColumnHeader();
            groupBox1 = new GroupBox();
            cmdPrikaziUcionice = new Button();
            cmdObrisiLokaciju = new Button();
            cmdIzmeniLokaciju = new Button();
            cmdDodajLokaciju = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(listViewLokacije);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 573;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 65);
            panel1.TabIndex = 1;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(216, 11);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(113, 33);
            labelNaslov.TabIndex = 1;
            labelNaslov.Text = "Lokacije";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // listViewLokacije
            // 
            listViewLokacije.Columns.AddRange(new ColumnHeader[] { chAdresa, chRadnoVreme, chKapacitet });
            listViewLokacije.FullRowSelect = true;
            listViewLokacije.GridLines = true;
            listViewLokacije.Location = new Point(0, 66);
            listViewLokacije.Name = "listViewLokacije";
            listViewLokacije.Size = new Size(573, 384);
            listViewLokacije.TabIndex = 0;
            listViewLokacije.UseCompatibleStateImageBehavior = false;
            listViewLokacije.View = View.Details;
            listViewLokacije.DrawColumnHeader += listViewLokacije_DrawColumnHeader;
            listViewLokacije.DrawItem += listViewLokacije_DrawItem;
            // 
            // chAdresa
            // 
            chAdresa.Text = "Adresa";
            chAdresa.Width = 250;
            // 
            // chRadnoVreme
            // 
            chRadnoVreme.Text = "Radno vreme";
            chRadnoVreme.Width = 150;
            // 
            // chKapacitet
            // 
            chKapacitet.Text = "Kapacitet";
            chKapacitet.Width = 165;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdPrikaziUcionice);
            groupBox1.Controls.Add(cmdObrisiLokaciju);
            groupBox1.Controls.Add(cmdIzmeniLokaciju);
            groupBox1.Controls.Add(cmdDodajLokaciju);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 181);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o lokaciji";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cmdPrikaziUcionice
            // 
            cmdPrikaziUcionice.BackColor = Color.MidnightBlue;
            cmdPrikaziUcionice.FlatAppearance.BorderSize = 0;
            cmdPrikaziUcionice.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdPrikaziUcionice.FlatStyle = FlatStyle.Flat;
            cmdPrikaziUcionice.ForeColor = Color.White;
            cmdPrikaziUcionice.Location = new Point(6, 107);
            cmdPrikaziUcionice.Name = "cmdPrikaziUcionice";
            cmdPrikaziUcionice.Size = new Size(202, 33);
            cmdPrikaziUcionice.TabIndex = 3;
            cmdPrikaziUcionice.Text = "Prikazi ucionice";
            cmdPrikaziUcionice.UseVisualStyleBackColor = false;
            cmdPrikaziUcionice.Click += cmdPrikaziUcionice_Click;
            // 
            // cmdObrisiLokaciju
            // 
            cmdObrisiLokaciju.BackColor = Color.MidnightBlue;
            cmdObrisiLokaciju.FlatAppearance.BorderSize = 0;
            cmdObrisiLokaciju.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdObrisiLokaciju.FlatStyle = FlatStyle.Flat;
            cmdObrisiLokaciju.ForeColor = Color.White;
            cmdObrisiLokaciju.Location = new Point(6, 146);
            cmdObrisiLokaciju.Name = "cmdObrisiLokaciju";
            cmdObrisiLokaciju.Size = new Size(202, 29);
            cmdObrisiLokaciju.TabIndex = 2;
            cmdObrisiLokaciju.Text = "Obrisi lokaciju";
            cmdObrisiLokaciju.UseVisualStyleBackColor = false;
            cmdObrisiLokaciju.Click += cmdObrisiLokaciju_Click;
            // 
            // cmdIzmeniLokaciju
            // 
            cmdIzmeniLokaciju.BackColor = Color.MidnightBlue;
            cmdIzmeniLokaciju.FlatAppearance.BorderSize = 0;
            cmdIzmeniLokaciju.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdIzmeniLokaciju.FlatStyle = FlatStyle.Flat;
            cmdIzmeniLokaciju.ForeColor = Color.White;
            cmdIzmeniLokaciju.Location = new Point(6, 68);
            cmdIzmeniLokaciju.Name = "cmdIzmeniLokaciju";
            cmdIzmeniLokaciju.Size = new Size(202, 33);
            cmdIzmeniLokaciju.TabIndex = 1;
            cmdIzmeniLokaciju.Text = "Izmeni lokaciju";
            cmdIzmeniLokaciju.UseVisualStyleBackColor = false;
            cmdIzmeniLokaciju.Click += cmdIzmeniLokaciju_Click;
            // 
            // cmdDodajLokaciju
            // 
            cmdDodajLokaciju.BackColor = Color.MidnightBlue;
            cmdDodajLokaciju.FlatAppearance.BorderSize = 0;
            cmdDodajLokaciju.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdDodajLokaciju.FlatStyle = FlatStyle.Flat;
            cmdDodajLokaciju.ForeColor = Color.White;
            cmdDodajLokaciju.Location = new Point(6, 26);
            cmdDodajLokaciju.Name = "cmdDodajLokaciju";
            cmdDodajLokaciju.Size = new Size(202, 36);
            cmdDodajLokaciju.TabIndex = 0;
            cmdDodajLokaciju.Text = "Dodaj lokaciju";
            cmdDodajLokaciju.UseVisualStyleBackColor = false;
            cmdDodajLokaciju.Click += cmdDodajLokaciju_Click;
            // 
            // LokacijeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "LokacijeForm";
            Load += LokacijeForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListView listViewLokacije;
        private ColumnHeader chAdresa;
        private ColumnHeader chRadnoVreme;
        private ColumnHeader chKapacitet;
        private GroupBox groupBox1;
        private Button cmdObrisiLokaciju;
        private Button cmdIzmeniLokaciju;
        private Button cmdDodajLokaciju;
        private Button cmdPrikaziUcionice;
        private Panel panel1;
        private Label labelNaslov;
    }
}