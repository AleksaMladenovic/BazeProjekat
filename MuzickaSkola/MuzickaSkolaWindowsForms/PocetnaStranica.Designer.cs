namespace MuzickaSkolaWindowsForms
{
    partial class PocetnaStranica
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
            cmdKursevi = new Button();
            cmdNastavnici = new Button();
            cmdPolaznici = new Button();
            SuspendLayout();
            // 
            // cmdKursevi
            // 
            cmdKursevi.Location = new Point(303, 321);
            cmdKursevi.Name = "cmdKursevi";
            cmdKursevi.Size = new Size(196, 42);
            cmdKursevi.TabIndex = 0;
            cmdKursevi.Text = "Kursevi";
            cmdKursevi.UseVisualStyleBackColor = true;
            cmdKursevi.Click += cmdKursevi_Click;
            // 
            // cmdNastavnici
            // 
            cmdNastavnici.Location = new Point(303, 241);
            cmdNastavnici.Name = "cmdNastavnici";
            cmdNastavnici.Size = new Size(196, 37);
            cmdNastavnici.TabIndex = 1;
            cmdNastavnici.Text = "Nastavnici";
            cmdNastavnici.UseVisualStyleBackColor = true;
            cmdNastavnici.Click += cmdNastavnici_Click;
            // 
            // cmdPolaznici
            // 
            cmdPolaznici.Location = new Point(305, 158);
            cmdPolaznici.Name = "cmdPolaznici";
            cmdPolaznici.Size = new Size(194, 42);
            cmdPolaznici.TabIndex = 2;
            cmdPolaznici.Text = "Polaznici";
            cmdPolaznici.UseVisualStyleBackColor = true;
            cmdPolaznici.Click += cmdPolaznici_Click;
            // 
            // PocetnaStranica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmdPolaznici);
            Controls.Add(cmdNastavnici);
            Controls.Add(cmdKursevi);
            Name = "PocetnaStranica";
            Text = "PocetnaStranica";
            ResumeLayout(false);
        }

        #endregion

        private Button cmdKursevi;
        private Button cmdNastavnici;
        private Button cmdPolaznici;
    }
}