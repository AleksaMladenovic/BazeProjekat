namespace MuzickaSkolaWindowsForms.Forme
{
    partial class PrisustvoNaCasovimaForm
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
            lvPrisustvo = new ListView();
            btnZatvori = new Button();
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
            gbInfo.Location = new Point(12, 66);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(780, 62);
            gbInfo.TabIndex = 0;
            gbInfo.TabStop = false;
            gbInfo.Text = "Informacije";
            gbInfo.Enter += gbInfo_Enter;
            // 
            // lblZaPolaznikaCaption
            // 
            lblZaPolaznikaCaption.AutoSize = true;
            lblZaPolaznikaCaption.Location = new Point(12, 27);
            lblZaPolaznikaCaption.Name = "lblZaPolaznikaCaption";
            lblZaPolaznikaCaption.Size = new Size(87, 17);
            lblZaPolaznikaCaption.TabIndex = 0;
            lblZaPolaznikaCaption.Text = "Za polaznika:";
            // 
            // lblPolaznikValue
            // 
            lblPolaznikValue.AutoSize = true;
            lblPolaznikValue.Location = new Point(100, 27);
            lblPolaznikValue.Name = "lblPolaznikValue";
            lblPolaznikValue.Size = new Size(13, 17);
            lblPolaznikValue.TabIndex = 1;
            lblPolaznikValue.Text = "-";
            // 
            // lvPrisustvo
            // 
            lvPrisustvo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvPrisustvo.BorderStyle = BorderStyle.FixedSingle;
            lvPrisustvo.FullRowSelect = true;
            lvPrisustvo.GridLines = true;
            lvPrisustvo.Location = new Point(12, 134);
            lvPrisustvo.MultiSelect = false;
            lvPrisustvo.Name = "lvPrisustvo";
            lvPrisustvo.Size = new Size(780, 275);
            lvPrisustvo.TabIndex = 1;
            lvPrisustvo.UseCompatibleStateImageBehavior = false;
            lvPrisustvo.View = View.Details;
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
            btnZatvori.Location = new Point(682, 415);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(110, 34);
            btnZatvori.TabIndex = 2;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = false;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(labelNaslov);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.AliceBlue;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 60);
            panel1.TabIndex = 3;
            // 
            // labelNaslov
            // 
            labelNaslov.Anchor = AnchorStyles.None;
            labelNaslov.AutoSize = true;
            labelNaslov.BackColor = Color.Transparent;
            labelNaslov.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelNaslov.ForeColor = Color.White;
            labelNaslov.Location = new Point(288, 14);
            labelNaslov.Name = "labelNaslov";
            labelNaslov.Size = new Size(265, 33);
            labelNaslov.TabIndex = 2;
            labelNaslov.Text = "Prisustvo na časovima\r\n";
            labelNaslov.TextAlign = ContentAlignment.TopCenter;
            // 
            // PrisustvoNaCasovimaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
            Controls.Add(panel1);
            Controls.Add(gbInfo);
            Controls.Add(lvPrisustvo);
            Controls.Add(btnZatvori);
            MinimumSize = new Size(820, 500);
            Name = "PrisustvoNaCasovimaForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += PrisustvoNaCasovimaForm_Load;
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
        private ListView lvPrisustvo;
        private Button btnZatvori;
        private Panel panel1;
        private Label labelNaslov;
    }
}