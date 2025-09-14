namespace MuzickaSkolaWindowsForms.Forme
{
    partial class PolozeniIspitiForm
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
            gbInfo = new GroupBox();
            lblZaPolaznikaCaption = new Label();
            lblPolaznikValue = new Label();
            lvIspiti = new ListView();
            btnZatvori = new Button();
            btnDodajIspit = new Button();
            panel1 = new Panel();
            labelNaslov = new Label();
            gbInfo.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbInfo
            // 
            gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInfo.Controls.Add(lblZaPolaznikaCaption);
            gbInfo.Controls.Add(lblPolaznikValue);
            gbInfo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            gbInfo.ForeColor = Color.MidnightBlue;
            gbInfo.Location = new Point(15, 67);
            gbInfo.Margin = new Padding(3, 4, 3, 4);
            gbInfo.Name = "gbInfo";
            gbInfo.Padding = new Padding(3, 4, 3, 4);
            gbInfo.Size = new Size(773, 83);
            gbInfo.TabIndex = 0;
            gbInfo.TabStop = false;
            gbInfo.Text = "Informacije";
            // 
            // lblZaPolaznikaCaption
            // 
            lblZaPolaznikaCaption.AutoSize = true;
            lblZaPolaznikaCaption.Location = new Point(16, 36);
            lblZaPolaznikaCaption.Name = "lblZaPolaznikaCaption";
            lblZaPolaznikaCaption.Size = new Size(87, 17);
            lblZaPolaznikaCaption.TabIndex = 0;
            lblZaPolaznikaCaption.Text = "Za polaznika:";
            // 
            // lblPolaznikValue
            // 
            lblPolaznikValue.AutoSize = true;
            lblPolaznikValue.Location = new Point(130, 36);
            lblPolaznikValue.Name = "lblPolaznikValue";
            lblPolaznikValue.Size = new Size(13, 17);
            lblPolaznikValue.TabIndex = 1;
            lblPolaznikValue.Text = "-";
            // 
            // lvIspiti
            // 
            lvIspiti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvIspiti.BorderStyle = BorderStyle.FixedSingle;
            lvIspiti.FullRowSelect = true;
            lvIspiti.GridLines = true;
            lvIspiti.Location = new Point(16, 158);
            lvIspiti.Margin = new Padding(3, 4, 3, 4);
            lvIspiti.MultiSelect = false;
            lvIspiti.Name = "lvIspiti";
            lvIspiti.Size = new Size(772, 248);
            lvIspiti.TabIndex = 1;
            lvIspiti.UseCompatibleStateImageBehavior = false;
            lvIspiti.View = View.Details;
            // 
            // btnZatvori
            // 
            btnZatvori.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnZatvori.BackColor = Color.MidnightBlue;
            btnZatvori.FlatAppearance.BorderSize = 0;
            btnZatvori.FlatAppearance.MouseOverBackColor = Color.FromArgb(109, 92, 246);
            btnZatvori.FlatStyle = FlatStyle.Flat;
            btnZatvori.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnZatvori.ForeColor = Color.White;
            btnZatvori.Location = new Point(682, 414);
            btnZatvori.Margin = new Padding(3, 4, 3, 4);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(110, 34);
            btnZatvori.TabIndex = 2;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = false;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // btnDodajIspit
            // 
            btnDodajIspit.Location = new Point(16, 614);
            btnDodajIspit.Name = "btnDodajIspit";
            btnDodajIspit.Size = new Size(147, 43);
            btnDodajIspit.TabIndex = 3;
            btnDodajIspit.Text = "Dodaj ispit";
            btnDodajIspit.UseVisualStyleBackColor = true;
            btnDodajIspit.Click += btnDodajIspit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 60);
            panel1.TabIndex = 4;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(282, 9);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(179, 33);
            labelNaslov.TabIndex = 3;
            labelNaslov.Text = "Položeni ispiti";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // PolozeniIspitiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
            Controls.Add(panel1);
            Controls.Add(btnDodajIspit);
            Controls.Add(gbInfo);
            Controls.Add(lvIspiti);
            Controls.Add(btnZatvori);
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(820, 500);
            Name = "PolozeniIspitiForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += PolozeniIspitiForm_Load;
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInfo;
        private Label lblZaPolaznikaCaption;
        private Label lblPolaznikValue;
        private ListView lvIspiti;
        private Button btnZatvori;
        private Button btnDodajIspit;
        private Panel panel1;
        private Label labelNaslov;
    }
}