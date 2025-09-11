namespace MuzickaSkolaWindowsForms.Forme
{
    partial class MojDeoForm
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
            cmdPrikaziSveKurseve = new Button();
            cmdPrikaziSveLokacije = new Button();
            SuspendLayout();
            // 
            // cmdPrikaziSveKurseve
            // 
            cmdPrikaziSveKurseve.Location = new Point(269, 64);
            cmdPrikaziSveKurseve.Name = "cmdPrikaziSveKurseve";
            cmdPrikaziSveKurseve.Size = new Size(229, 23);
            cmdPrikaziSveKurseve.TabIndex = 0;
            cmdPrikaziSveKurseve.Text = "Prikazi sve kurseve";
            cmdPrikaziSveKurseve.UseVisualStyleBackColor = true;
            cmdPrikaziSveKurseve.Click += cmdPrikaziSveKurseve_Click;
            // 
            // cmdPrikaziSveLokacije
            // 
            cmdPrikaziSveLokacije.Location = new Point(269, 109);
            cmdPrikaziSveLokacije.Name = "cmdPrikaziSveLokacije";
            cmdPrikaziSveLokacije.Size = new Size(229, 23);
            cmdPrikaziSveLokacije.TabIndex = 1;
            cmdPrikaziSveLokacije.Text = "Prikazi sve lokacije";
            cmdPrikaziSveLokacije.UseVisualStyleBackColor = true;
            cmdPrikaziSveLokacije.Click += cmdPrikaziSveLokacije_Click;
            // 
            // MojDeoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmdPrikaziSveLokacije);
            Controls.Add(cmdPrikaziSveKurseve);
            Name = "MojDeoForm";
            Text = "KurseviForm";
            ResumeLayout(false);
        }

        #endregion

        private Button cmdPrikaziSveKurseve;
        private Button cmdPrikaziSveLokacije;
    }
}