namespace MuzickaSkolaWindowsForms.Forme
{
    partial class DodajIzmeniNastavuForm
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
            label1 = new Label();
            dtpDatumOd = new DateTimePicker();
            label2 = new Label();
            dtpDatumDo = new DateTimePicker();
            cbxDatumDo = new CheckBox();
            cmdSnimi = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Datum početka:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Format = DateTimePickerFormat.Short;
            dtpDatumOd.Location = new Point(109, 3);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(132, 23);
            dtpDatumOd.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 2;
            label2.Text = "Datum završetka:";
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Format = DateTimePickerFormat.Short;
            dtpDatumDo.Location = new Point(130, 33);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(111, 23);
            dtpDatumDo.TabIndex = 3;
            // 
            // cbxDatumDo
            // 
            cbxDatumDo.AutoSize = true;
            cbxDatumDo.Location = new Point(109, 40);
            cbxDatumDo.Name = "cbxDatumDo";
            cbxDatumDo.Size = new Size(15, 14);
            cbxDatumDo.TabIndex = 4;
            cbxDatumDo.UseVisualStyleBackColor = true;
            cbxDatumDo.CheckedChanged += cbxDatumDo_CheckedChanged;
            // 
            // cmdSnimi
            // 
            cmdSnimi.Location = new Point(12, 62);
            cmdSnimi.Name = "cmdSnimi";
            cmdSnimi.Size = new Size(229, 23);
            cmdSnimi.TabIndex = 5;
            cmdSnimi.Text = "Snimi";
            cmdSnimi.UseVisualStyleBackColor = true;
            cmdSnimi.Click += cmdSnimi_Click;
            // 
            // DodajIzmeniNastavuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 97);
            Controls.Add(cmdSnimi);
            Controls.Add(cbxDatumDo);
            Controls.Add(dtpDatumDo);
            Controls.Add(label2);
            Controls.Add(dtpDatumOd);
            Controls.Add(label1);
            Name = "DodajIzmeniNastavuForm";
            Text = "DodajIzmeniNastavuForm";
            Load += DodajIzmeniNastavuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDatumOd;
        private Label label2;
        private DateTimePicker dtpDatumDo;
        private CheckBox cbxDatumDo;
        private Button cmdSnimi;
    }
}