namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmeniUcionicuForm
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
            cmdSacuvajUcionicu = new Button();
            txtNaziv = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            numKapacitet = new NumericUpDown();
            txtOpremljenost = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numKapacitet).BeginInit();
            SuspendLayout();
            // 
            // cmdSacuvajUcionicu
            // 
            cmdSacuvajUcionicu.Location = new Point(11, 172);
            cmdSacuvajUcionicu.Name = "cmdSacuvajUcionicu";
            cmdSacuvajUcionicu.Size = new Size(254, 23);
            cmdSacuvajUcionicu.TabIndex = 9;
            cmdSacuvajUcionicu.Text = "Sačuvaj";
            cmdSacuvajUcionicu.UseVisualStyleBackColor = true;
            cmdSacuvajUcionicu.Click += cmdSacuvajUcionicu_Click;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(100, 12);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(165, 23);
            txtNaziv.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 43);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 6;
            label2.Text = "Kapacitet:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 15);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 10;
            label3.Text = "Opremljenost:";
            // 
            // numKapacitet
            // 
            numKapacitet.Location = new Point(100, 41);
            numKapacitet.Name = "numKapacitet";
            numKapacitet.Size = new Size(120, 23);
            numKapacitet.TabIndex = 11;
            // 
            // txtOpremljenost
            // 
            txtOpremljenost.Location = new Point(100, 70);
            txtOpremljenost.Name = "txtOpremljenost";
            txtOpremljenost.Size = new Size(165, 96);
            txtOpremljenost.TabIndex = 12;
            txtOpremljenost.Text = "";
            // 
            // DodajIzmeniUcionicuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 208);
            Controls.Add(txtOpremljenost);
            Controls.Add(numKapacitet);
            Controls.Add(label3);
            Controls.Add(cmdSacuvajUcionicu);
            Controls.Add(txtNaziv);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DodajIzmeniUcionicuForm";
            Text = "DodajIzmeniUcionicuForm";
            ((System.ComponentModel.ISupportInitialize)numKapacitet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdSacuvajUcionicu;
        private TextBox txtNaziv;
        private Label label2;
        private Label label1;
        private Label label3;
        private NumericUpDown numKapacitet;
        private RichTextBox txtOpremljenost;
    }
}