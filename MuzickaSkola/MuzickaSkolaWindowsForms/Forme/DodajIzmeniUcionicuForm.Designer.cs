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
            cmdSacuvajUcionicu.BackColor = Color.MidnightBlue;
            cmdSacuvajUcionicu.ForeColor = Color.White;
            cmdSacuvajUcionicu.Location = new Point(13, 172);
            cmdSacuvajUcionicu.Name = "cmdSacuvajUcionicu";
            cmdSacuvajUcionicu.Size = new Size(290, 33);
            cmdSacuvajUcionicu.TabIndex = 9;
            cmdSacuvajUcionicu.Text = "Sačuvaj";
            cmdSacuvajUcionicu.UseVisualStyleBackColor = false;
            cmdSacuvajUcionicu.Click += cmdSacuvajUcionicu_Click;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(114, 12);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(188, 25);
            txtNaziv.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(40, 43);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 6;
            label2.Text = "Kapacitet:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(63, 15);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 5;
            label1.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(14, 73);
            label3.Name = "label3";
            label3.Size = new Size(93, 17);
            label3.TabIndex = 10;
            label3.Text = "Opremljenost:";
            // 
            // numKapacitet
            // 
            numKapacitet.Location = new Point(114, 41);
            numKapacitet.Name = "numKapacitet";
            numKapacitet.Size = new Size(137, 25);
            numKapacitet.TabIndex = 11;
            // 
            // txtOpremljenost
            // 
            txtOpremljenost.Location = new Point(114, 70);
            txtOpremljenost.Name = "txtOpremljenost";
            txtOpremljenost.Size = new Size(188, 96);
            txtOpremljenost.TabIndex = 12;
            txtOpremljenost.Text = "";
            // 
            // DodajIzmeniUcionicuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 208);
            Controls.Add(txtOpremljenost);
            Controls.Add(numKapacitet);
            Controls.Add(label3);
            Controls.Add(cmdSacuvajUcionicu);
            Controls.Add(txtNaziv);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.MidnightBlue;
            Name = "DodajIzmeniUcionicuForm";
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