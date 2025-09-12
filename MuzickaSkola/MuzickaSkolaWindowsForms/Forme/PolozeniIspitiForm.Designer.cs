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
            gbInfo.SuspendLayout();
            SuspendLayout();
            // 
            // gbInfo
            // 
            gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInfo.Controls.Add(lblZaPolaznikaCaption);
            gbInfo.Controls.Add(lblPolaznikValue);
            gbInfo.Location = new Point(14, 16);
            gbInfo.Margin = new Padding(3, 4, 3, 4);
            gbInfo.Name = "gbInfo";
            gbInfo.Padding = new Padding(3, 4, 3, 4);
            gbInfo.Size = new Size(910, 83);
            gbInfo.TabIndex = 0;
            gbInfo.TabStop = false;
            gbInfo.Text = "Informacije";
            // 
            // lblZaPolaznikaCaption
            // 
            lblZaPolaznikaCaption.AutoSize = true;
            lblZaPolaznikaCaption.Location = new Point(14, 36);
            lblZaPolaznikaCaption.Name = "lblZaPolaznikaCaption";
            lblZaPolaznikaCaption.Size = new Size(97, 20);
            lblZaPolaznikaCaption.TabIndex = 0;
            lblZaPolaznikaCaption.Text = "Za polaznika:";
            // 
            // lblPolaznikValue
            // 
            lblPolaznikValue.AutoSize = true;
            lblPolaznikValue.Location = new Point(114, 36);
            lblPolaznikValue.Name = "lblPolaznikValue";
            lblPolaznikValue.Size = new Size(15, 20);
            lblPolaznikValue.TabIndex = 1;
            lblPolaznikValue.Text = "-";
            // 
            // lvIspiti
            // 
            lvIspiti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvIspiti.BorderStyle = BorderStyle.FixedSingle;
            lvIspiti.FullRowSelect = true;
            lvIspiti.GridLines = true;
            lvIspiti.Location = new Point(14, 117);
            lvIspiti.Margin = new Padding(3, 4, 3, 4);
            lvIspiti.MultiSelect = false;
            lvIspiti.Name = "lvIspiti";
            lvIspiti.Size = new Size(909, 486);
            lvIspiti.TabIndex = 1;
            lvIspiti.UseCompatibleStateImageBehavior = false;
            lvIspiti.View = View.Details;
            // 
            // btnZatvori
            // 
            btnZatvori.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnZatvori.Location = new Point(798, 612);
            btnZatvori.Margin = new Padding(3, 4, 3, 4);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(126, 45);
            btnZatvori.TabIndex = 2;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = true;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // btnDodajIspit
            // 
            btnDodajIspit.Location = new Point(14, 614);
            btnDodajIspit.Name = "btnDodajIspit";
            btnDodajIspit.Size = new Size(129, 43);
            btnDodajIspit.TabIndex = 3;
            btnDodajIspit.Text = "Dodaj ispit";
            btnDodajIspit.UseVisualStyleBackColor = true;
            btnDodajIspit.Click += btnDodajIspit_Click;
            // 
            // PolozeniIspitiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 667);
            Controls.Add(btnDodajIspit);
            Controls.Add(gbInfo);
            Controls.Add(lvIspiti);
            Controls.Add(btnZatvori);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(935, 651);
            Name = "PolozeniIspitiForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Položeni ispiti";
            Load += PolozeniIspitiForm_Load;
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInfo;
        private Label lblZaPolaznikaCaption;
        private Label lblPolaznikValue;
        private ListView lvIspiti;
        private Button btnZatvori;
        private Button btnDodajIspit;
    }
}