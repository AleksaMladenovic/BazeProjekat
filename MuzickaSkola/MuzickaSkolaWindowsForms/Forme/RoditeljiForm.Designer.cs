namespace MuzickaSkolaWindowsForms.Forme
{
    partial class RoditeljiForm
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
            gbRoditelji = new GroupBox();
            lvRoditelji = new ListView();
            chId = new ColumnHeader();
            chJmbg = new ColumnHeader();
            chIme = new ColumnHeader();
            chPrezime = new ColumnHeader();
            chTelefon = new ColumnHeader();
            chEmail = new ColumnHeader();
            gbAkcije = new GroupBox();
            btnIzmeniRoditelja = new Button();
            gbRoditelji.SuspendLayout();
            gbAkcije.SuspendLayout();
            SuspendLayout();
            // 
            // gbRoditelji
            // 
            gbRoditelji.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbRoditelji.Controls.Add(lvRoditelji);
            gbRoditelji.Location = new Point(12, 12);
            gbRoditelji.Name = "gbRoditelji";
            gbRoditelji.Size = new Size(610, 426);
            gbRoditelji.TabIndex = 0;
            gbRoditelji.TabStop = false;
            gbRoditelji.Text = "Svi roditelji";
            // 
            // lvRoditelji
            // 
            lvRoditelji.BorderStyle = BorderStyle.FixedSingle;
            lvRoditelji.Columns.AddRange(new ColumnHeader[] { chId, chJmbg, chIme, chPrezime, chTelefon, chEmail });
            lvRoditelji.Dock = DockStyle.Fill;
            lvRoditelji.FullRowSelect = true;
            lvRoditelji.GridLines = true;
            lvRoditelji.Location = new Point(3, 19);
            lvRoditelji.MultiSelect = false;
            lvRoditelji.Name = "lvRoditelji";
            lvRoditelji.Size = new Size(604, 404);
            lvRoditelji.TabIndex = 0;
            lvRoditelji.UseCompatibleStateImageBehavior = false;
            lvRoditelji.View = View.Details;
            // 
            // chId
            // 
            chId.Text = "Id";
            // 
            // chJmbg
            // 
            chJmbg.Text = "JMBG";
            chJmbg.Width = 110;
            // 
            // chIme
            // 
            chIme.Text = "Ime";
            chIme.Width = 120;
            // 
            // chPrezime
            // 
            chPrezime.Text = "Prezime";
            chPrezime.Width = 120;
            // 
            // chTelefon
            // 
            chTelefon.Text = "Telefon";
            chTelefon.Width = 110;
            // 
            // chEmail
            // 
            chEmail.Text = "Email";
            chEmail.Width = 150;
            // 
            // gbAkcije
            // 
            gbAkcije.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbAkcije.Controls.Add(btnIzmeniRoditelja);
            gbAkcije.Location = new Point(628, 142);
            gbAkcije.Name = "gbAkcije";
            gbAkcije.Size = new Size(180, 120);
            gbAkcije.TabIndex = 1;
            gbAkcije.TabStop = false;
            gbAkcije.Text = "Akcije";
            // 
            // btnIzmeniRoditelja
            // 
            btnIzmeniRoditelja.Location = new Point(20, 22);
            btnIzmeniRoditelja.Name = "btnIzmeniRoditelja";
            btnIzmeniRoditelja.Size = new Size(142, 74);
            btnIzmeniRoditelja.TabIndex = 0;
            btnIzmeniRoditelja.Text = "Izmeni roditelja";
            btnIzmeniRoditelja.UseVisualStyleBackColor = true;
            btnIzmeniRoditelja.Click += btnIzmeniRoditelja_Click;
            // 
            // RoditeljiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 450);
            Controls.Add(gbAkcije);
            Controls.Add(gbRoditelji);
            Name = "RoditeljiForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Roditelji";
            Load += RoditeljiForm_Load;
            gbRoditelji.ResumeLayout(false);
            gbAkcije.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox gbRoditelji;
        private System.Windows.Forms.ListView lvRoditelji;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chJmbg;
        private System.Windows.Forms.ColumnHeader chIme;
        private System.Windows.Forms.ColumnHeader chPrezime;
        private System.Windows.Forms.ColumnHeader chTelefon;
        private System.Windows.Forms.ColumnHeader chEmail;
        private System.Windows.Forms.GroupBox gbAkcije;
        private System.Windows.Forms.Button btnIzmeniRoditelja;
    }
}