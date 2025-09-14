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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnaStranica));
            cmdKursevi = new Button();
            cmdNastavnici = new Button();
            cmdPolaznici = new Button();
            panelHeader = new Panel();
            labelNaslov = new Label();
            pictureBoxLogo = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // cmdKursevi
            // 
            cmdKursevi.BackColor = Color.MidnightBlue;
            cmdKursevi.FlatAppearance.BorderSize = 0;
            cmdKursevi.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdKursevi.FlatStyle = FlatStyle.Flat;
            cmdKursevi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            cmdKursevi.ForeColor = Color.White;
            cmdKursevi.Location = new Point(172, 269);
            cmdKursevi.Name = "cmdKursevi";
            cmdKursevi.Size = new Size(196, 42);
            cmdKursevi.TabIndex = 0;
            cmdKursevi.TabStop = false;
            cmdKursevi.Text = "Kursevi";
            cmdKursevi.UseVisualStyleBackColor = false;
            cmdKursevi.Click += cmdKursevi_Click;
            // 
            // cmdNastavnici
            // 
            cmdNastavnici.BackColor = Color.MidnightBlue;
            cmdNastavnici.FlatAppearance.BorderSize = 0;
            cmdNastavnici.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdNastavnici.FlatStyle = FlatStyle.Flat;
            cmdNastavnici.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            cmdNastavnici.ForeColor = Color.White;
            cmdNastavnici.Location = new Point(172, 212);
            cmdNastavnici.Name = "cmdNastavnici";
            cmdNastavnici.Size = new Size(196, 42);
            cmdNastavnici.TabIndex = 1;
            cmdNastavnici.TabStop = false;
            cmdNastavnici.Text = "Nastavnici";
            cmdNastavnici.UseVisualStyleBackColor = false;
            cmdNastavnici.Click += cmdNastavnici_Click;
            // 
            // cmdPolaznici
            // 
            cmdPolaznici.BackColor = Color.MidnightBlue;
            cmdPolaznici.FlatAppearance.BorderSize = 0;
            cmdPolaznici.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            cmdPolaznici.FlatStyle = FlatStyle.Flat;
            cmdPolaznici.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            cmdPolaznici.ForeColor = Color.White;
            cmdPolaznici.Location = new Point(174, 155);
            cmdPolaznici.Name = "cmdPolaznici";
            cmdPolaznici.Size = new Size(194, 42);
            cmdPolaznici.TabIndex = 2;
            cmdPolaznici.TabStop = false;
            cmdPolaznici.Text = "Polaznici";
            cmdPolaznici.UseVisualStyleBackColor = false;
            cmdPolaznici.Click += cmdPolaznici_Click;
            cmdPolaznici.Enter += cmdPolaznici_Leave;
            cmdPolaznici.Leave += cmdPolaznici_Leave;
            cmdPolaznici.MouseEnter += cmdPolaznici_MouseEnter;
            cmdPolaznici.MouseLeave += cmdPolaznici_MouseLeave;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.MidnightBlue;
            panelHeader.Controls.Add(labelNaslov);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(517, 80);
            panelHeader.TabIndex = 3;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(174, 23);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(185, 33);
            labelNaslov.TabIndex = 0;
            labelNaslov.Text = "Muzička Škola";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(229, 82);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(71, 67);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 4;
            pictureBoxLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(96, 155);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 42);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(96, 269);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(96, 212);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(49, 42);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // PocetnaStranica
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 372);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxLogo);
            Controls.Add(panelHeader);
            Controls.Add(cmdPolaznici);
            Controls.Add(cmdNastavnici);
            Controls.Add(cmdKursevi);
            Name = "PocetnaStranica";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button cmdKursevi;
        private Button cmdNastavnici;
        private Button cmdPolaznici;
        private Panel panelHeader;
        private Label labelNaslov;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}