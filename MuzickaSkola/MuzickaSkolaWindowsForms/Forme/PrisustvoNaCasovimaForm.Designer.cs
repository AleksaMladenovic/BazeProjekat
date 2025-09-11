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
            this.components = new System.ComponentModel.Container();

            this.gbInfo = new GroupBox();
            this.lblZaPolaznikaCaption = new Label();
            this.lblPolaznikValue = new Label();
            this.lvPrisustvo = new ListView();
            this.btnZatvori = new Button();

            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 500);
            this.MinimumSize = new Size(820, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "PrisustvoForm";
            this.Text = "Prisustvo na časovima";
            this.Load += new System.EventHandler(this.PrisustvoNaCasovimaForm_Load);

            // gbInfo
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Text = "Informacije";
            this.gbInfo.Location = new Point(12, 12);
            this.gbInfo.Size = new Size(796, 62);
            this.gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // caption
            this.lblZaPolaznikaCaption.AutoSize = true;
            this.lblZaPolaznikaCaption.Location = new Point(12, 27);
            this.lblZaPolaznikaCaption.Name = "lblZaPolaznikaCaption";
            this.lblZaPolaznikaCaption.Size = new Size(74, 15);
            this.lblZaPolaznikaCaption.Text = "Za polaznika:";

            // value
            this.lblPolaznikValue.AutoSize = true;
            this.lblPolaznikValue.Location = new Point(100, 27);
            this.lblPolaznikValue.Name = "lblPolaznikValue";
            this.lblPolaznikValue.Size = new Size(12, 15);
            this.lblPolaznikValue.Text = "-";

            this.gbInfo.Controls.Add(this.lblZaPolaznikaCaption);
            this.gbInfo.Controls.Add(this.lblPolaznikValue);

            // lvPrisustvo
            this.lvPrisustvo.Name = "lvPrisustvo";
            this.lvPrisustvo.Location = new Point(12, 88);
            this.lvPrisustvo.Size = new Size(796, 365);
            this.lvPrisustvo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lvPrisustvo.BorderStyle = BorderStyle.FixedSingle;
            this.lvPrisustvo.FullRowSelect = true;
            this.lvPrisustvo.GridLines = true;
            this.lvPrisustvo.HideSelection = false;
            this.lvPrisustvo.MultiSelect = false;
            this.lvPrisustvo.View = View.Details;

            // btnZatvori
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.Size = new Size(110, 34);
            this.btnZatvori.Location = new Point(698, 459);
            this.btnZatvori.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);

            // to form
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.lvPrisustvo);
            this.Controls.Add(this.btnZatvori);

            this.ResumeLayout(false);
        }

        #endregion
        private GroupBox gbInfo;
        private Label lblZaPolaznikaCaption;
        private Label lblPolaznikValue;
        private ListView lvPrisustvo;
        private Button btnZatvori;
    }
}