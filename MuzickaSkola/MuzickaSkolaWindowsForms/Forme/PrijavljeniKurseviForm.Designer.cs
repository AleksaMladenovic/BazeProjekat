namespace MuzickaSkolaWindowsForms.Forme
{
    partial class PrijavljeniKurseviForm
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
            lvKursevi = new ListView();
            btnZatvori = new Button();
            btnDodajNaKurs = new Button();
            gbInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gbInfo
            // 
            gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInfo.Controls.Add(lblZaPolaznikaCaption);
            gbInfo.Controls.Add(lblPolaznikValue);
            gbInfo.Location = new Point(12, 12);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(796, 62);
            gbInfo.TabIndex = 0;
            gbInfo.TabStop = false;
            gbInfo.Text = "Informacije";
            // 
            // lblZaPolaznikaCaption
            // 
            lblZaPolaznikaCaption.AutoSize = true;
            lblZaPolaznikaCaption.Location = new Point(12, 27);
            lblZaPolaznikaCaption.Name = "lblZaPolaznikaCaption";
            lblZaPolaznikaCaption.Size = new Size(76, 15);
            lblZaPolaznikaCaption.TabIndex = 0;
            lblZaPolaznikaCaption.Text = "Za polaznika:";
            // 
            // lblPolaznikValue
            // 
            lblPolaznikValue.AutoSize = true;
            lblPolaznikValue.Location = new Point(100, 27);
            lblPolaznikValue.Name = "lblPolaznikValue";
            lblPolaznikValue.Size = new Size(12, 15);
            lblPolaznikValue.TabIndex = 1;
            lblPolaznikValue.Text = "-";
            // 
            // lvKursevi
            // 
            lvKursevi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvKursevi.BorderStyle = BorderStyle.FixedSingle;
            lvKursevi.FullRowSelect = true;
            lvKursevi.GridLines = true;
            lvKursevi.Location = new Point(12, 88);
            lvKursevi.MultiSelect = false;
            lvKursevi.Name = "lvKursevi";
            lvKursevi.Size = new Size(796, 365);
            lvKursevi.TabIndex = 1;
            lvKursevi.UseCompatibleStateImageBehavior = false;
            lvKursevi.View = View.Details;
            // 
            // btnZatvori
            // 
            btnZatvori.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnZatvori.Location = new Point(698, 459);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(110, 34);
            btnZatvori.TabIndex = 2;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = true;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // btnDodajNaKurs
            // 
            btnDodajNaKurs.Location = new Point(12, 461);
            btnDodajNaKurs.Name = "btnDodajNaKurs";
            btnDodajNaKurs.Size = new Size(123, 32);
            btnDodajNaKurs.TabIndex = 3;
            btnDodajNaKurs.Text = "Dodaj na kurs";
            btnDodajNaKurs.UseVisualStyleBackColor = true;
            btnDodajNaKurs.Click += btnDodajNaKurs_Click;
            // 
            // PrijavljeniKurseviForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 500);
            Controls.Add(btnDodajNaKurs);
            Controls.Add(gbInfo);
            Controls.Add(lvKursevi);
            Controls.Add(btnZatvori);
            MinimumSize = new Size(820, 500);
            Name = "PrijavljeniKurseviForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Prijavljeni kursevi";
            Load += PrijavljeniKurseviForm_Load;
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbInfo;
        private Label lblZaPolaznikaCaption;
        private Label lblPolaznikValue;
        private ListView lvKursevi;
        private Button btnZatvori;
        private Button btnDodajNaKurs;
    }
}