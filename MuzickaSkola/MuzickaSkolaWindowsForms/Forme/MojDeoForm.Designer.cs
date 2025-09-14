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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MojDeoForm));
            cmdPrikaziSveKurseve = new Button();
            cmdPrikaziSveLokacije = new Button();
            pictureBox_Kursevi = new PictureBox();
            pictureBox_Lokacije = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Kursevi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Lokacije).BeginInit();
            SuspendLayout();
            // 
            // cmdPrikaziSveKurseve
            // 
            cmdPrikaziSveKurseve.BackColor = Color.MidnightBlue;
            cmdPrikaziSveKurseve.FlatAppearance.BorderSize = 0;
            cmdPrikaziSveKurseve.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdPrikaziSveKurseve.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            cmdPrikaziSveKurseve.ForeColor = Color.White;
            cmdPrikaziSveKurseve.Location = new Point(39, 79);
            cmdPrikaziSveKurseve.Name = "cmdPrikaziSveKurseve";
            cmdPrikaziSveKurseve.Size = new Size(141, 32);
            cmdPrikaziSveKurseve.TabIndex = 0;
            cmdPrikaziSveKurseve.TabStop = false;
            cmdPrikaziSveKurseve.Text = "Prikazi sve kurseve";
            cmdPrikaziSveKurseve.UseVisualStyleBackColor = false;
            cmdPrikaziSveKurseve.Click += cmdPrikaziSveKurseve_Click;
            cmdPrikaziSveKurseve.MouseEnter += cmdPrikaziSveKurseve_MouseEnter;
            cmdPrikaziSveKurseve.MouseLeave += cmdPrikaziSveKurseve_MouseLeave;
            // 
            // cmdPrikaziSveLokacije
            // 
            cmdPrikaziSveLokacije.BackColor = Color.MidnightBlue;
            cmdPrikaziSveLokacije.FlatAppearance.BorderSize = 0;
            cmdPrikaziSveLokacije.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdPrikaziSveLokacije.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            cmdPrikaziSveLokacije.ForeColor = Color.White;
            cmdPrikaziSveLokacije.Location = new Point(220, 79);
            cmdPrikaziSveLokacije.Name = "cmdPrikaziSveLokacije";
            cmdPrikaziSveLokacije.Size = new Size(141, 32);
            cmdPrikaziSveLokacije.TabIndex = 1;
            cmdPrikaziSveLokacije.TabStop = false;
            cmdPrikaziSveLokacije.Text = "Prikazi sve lokacije";
            cmdPrikaziSveLokacije.UseVisualStyleBackColor = false;
            cmdPrikaziSveLokacije.Click += cmdPrikaziSveLokacije_Click;
            cmdPrikaziSveLokacije.MouseEnter += cmdPrikaziSveLokacije_MouseEnter;
            cmdPrikaziSveLokacije.MouseLeave += cmdPrikaziSveLokacije_MouseLeave;
            // 
            // pictureBox_Kursevi
            // 
            pictureBox_Kursevi.BackColor = Color.Transparent;
            pictureBox_Kursevi.Image = (Image)resources.GetObject("pictureBox_Kursevi.Image");
            pictureBox_Kursevi.Location = new Point(65, 17);
            pictureBox_Kursevi.Name = "pictureBox_Kursevi";
            pictureBox_Kursevi.Size = new Size(86, 46);
            pictureBox_Kursevi.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Kursevi.TabIndex = 2;
            pictureBox_Kursevi.TabStop = false;
            pictureBox_Kursevi.Visible = false;
            // 
            // pictureBox_Lokacije
            // 
            pictureBox_Lokacije.BackColor = Color.Transparent;
            pictureBox_Lokacije.Image = (Image)resources.GetObject("pictureBox_Lokacije.Image");
            pictureBox_Lokacije.Location = new Point(249, 17);
            pictureBox_Lokacije.Name = "pictureBox_Lokacije";
            pictureBox_Lokacije.Size = new Size(86, 47);
            pictureBox_Lokacije.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Lokacije.TabIndex = 3;
            pictureBox_Lokacije.TabStop = false;
            pictureBox_Lokacije.Visible = false;
            // 
            // MojDeoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 150);
            Controls.Add(pictureBox_Lokacije);
            Controls.Add(pictureBox_Kursevi);
            Controls.Add(cmdPrikaziSveLokacije);
            Controls.Add(cmdPrikaziSveKurseve);
            Name = "MojDeoForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox_Kursevi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Lokacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button cmdPrikaziSveKurseve;
        private Button cmdPrikaziSveLokacije;
        private PictureBox pictureBox_Kursevi;
        private PictureBox pictureBox_Lokacije;
    }
}