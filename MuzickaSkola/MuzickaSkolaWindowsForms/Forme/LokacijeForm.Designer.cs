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
            // listViewLokacije
            // 
            listViewLokacije.Columns.AddRange(new ColumnHeader[] { chAdresa, chRadnoVreme, chKapacitet });
            listViewLokacije.Dock = DockStyle.Fill;
            listViewLokacije.FullRowSelect = true;
            listViewLokacije.Location = new Point(0, 0);
            listViewLokacije.Name = "listViewLokacije";
            listViewLokacije.Size = new Size(573, 450);
            listViewLokacije.TabIndex = 0;
            listViewLokacije.UseCompatibleStateImageBehavior = false;
            listViewLokacije.View = View.Details;
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
            chKapacitet.Width = 80;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdPrikaziUcionice);
            groupBox1.Controls.Add(cmdObrisiLokaciju);
            groupBox1.Controls.Add(cmdIzmeniLokaciju);
            groupBox1.Controls.Add(cmdDodajLokaciju);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 147);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o lokaciji";
            // 
            // cmdPrikaziUcionice
            // 
            cmdPrikaziUcionice.Location = new Point(6, 108);
            cmdPrikaziUcionice.Name = "cmdPrikaziUcionice";
            cmdPrikaziUcionice.Size = new Size(202, 23);
            cmdPrikaziUcionice.TabIndex = 3;
            cmdPrikaziUcionice.Text = "Prikazi ucionice";
            cmdPrikaziUcionice.UseVisualStyleBackColor = true;
            cmdPrikaziUcionice.Click += cmdPrikaziUcionice_Click;
            // 
            // cmdObrisiLokaciju
            // 
            cmdObrisiLokaciju.Location = new Point(6, 79);
            cmdObrisiLokaciju.Name = "cmdObrisiLokaciju";
            cmdObrisiLokaciju.Size = new Size(202, 23);
            cmdObrisiLokaciju.TabIndex = 2;
            cmdObrisiLokaciju.Text = "Obrisi lokaciju";
            cmdObrisiLokaciju.UseVisualStyleBackColor = true;
            cmdObrisiLokaciju.Click += cmdObrisiLokaciju_Click;
            // 
            // cmdIzmeniLokaciju
            // 
            cmdIzmeniLokaciju.Location = new Point(6, 50);
            cmdIzmeniLokaciju.Name = "cmdIzmeniLokaciju";
            cmdIzmeniLokaciju.Size = new Size(202, 23);
            cmdIzmeniLokaciju.TabIndex = 1;
            cmdIzmeniLokaciju.Text = "Izmeni lokaciju";
            cmdIzmeniLokaciju.UseVisualStyleBackColor = true;
            cmdIzmeniLokaciju.Click += cmdIzmeniLokaciju_Click;
            // 
            // cmdDodajLokaciju
            // 
            cmdDodajLokaciju.Location = new Point(6, 21);
            cmdDodajLokaciju.Name = "cmdDodajLokaciju";
            cmdDodajLokaciju.Size = new Size(202, 23);
            cmdDodajLokaciju.TabIndex = 0;
            cmdDodajLokaciju.Text = "Dodaj lokaciju";
            cmdDodajLokaciju.UseVisualStyleBackColor = true;
            cmdDodajLokaciju.Click += cmdDodajLokaciju_Click;
            // 
            // LokacijeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "LokacijeForm";
            Text = "LokacijeForm";
            Load += LokacijeForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}