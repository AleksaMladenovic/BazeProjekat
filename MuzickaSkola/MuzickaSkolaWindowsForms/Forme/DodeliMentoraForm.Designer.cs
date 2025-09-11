namespace MuzickaSkolaWindowsForms
{
    partial class DodeliMentoraForm
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
            lblNastavnikInfo = new Label();
            label1 = new Label();
            listViewMentori = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnDodeli = new Button();
            SuspendLayout();
            // 
            // lblNastavnikInfo
            // 
            lblNastavnikInfo.AutoSize = true;
            lblNastavnikInfo.Location = new Point(12, 9);
            lblNastavnikInfo.Name = "lblNastavnikInfo";
            lblNastavnikInfo.Size = new Size(136, 15);
            lblNastavnikInfo.TabIndex = 0;
            lblNastavnikInfo.Text = "Mentor za:[Ime Prezime]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 1;
            label1.Text = "Izaberite mentora:";
            // 
            // listViewMentori
            // 
            listViewMentori.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewMentori.FullRowSelect = true;
            listViewMentori.Location = new Point(12, 42);
            listViewMentori.Name = "listViewMentori";
            listViewMentori.Size = new Size(207, 97);
            listViewMentori.TabIndex = 2;
            listViewMentori.UseCompatibleStateImageBehavior = false;
            listViewMentori.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Ime";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Prezime";
            columnHeader2.Width = 100;
            // 
            // btnDodeli
            // 
            btnDodeli.Location = new Point(73, 145);
            btnDodeli.Name = "btnDodeli";
            btnDodeli.Size = new Size(75, 23);
            btnDodeli.TabIndex = 3;
            btnDodeli.Text = "Dodeli";
            btnDodeli.UseVisualStyleBackColor = true;
            btnDodeli.Click += btnDodeli_Click;
            // 
            // DodeliMentoraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 176);
            Controls.Add(btnDodeli);
            Controls.Add(listViewMentori);
            Controls.Add(label1);
            Controls.Add(lblNastavnikInfo);
            Name = "DodeliMentoraForm";
            Text = "DodeliMentoraForm";
            Load += DodeliMentoraForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNastavnikInfo;
        private Label label1;
        private ListView listViewMentori;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnDodeli;
    }
}