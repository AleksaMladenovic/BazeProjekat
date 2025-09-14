using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzickaSkolaWindowsForms
{
    public partial class DodeliMentoraForm : BaseForm
    {
        public DodeliMentoraForm()
        {
            InitializeComponent();
        }
        private Nastavnik nastavnik;

        public DodeliMentoraForm(Nastavnik n)
        {
            InitializeComponent();
            this.nastavnik = n;
        }

        private void DodeliMentoraForm_Load(object sender, EventArgs e)
        {
            lblNastavnikInfo.Text = $"Dodeljujete mentora za: {nastavnik.OsnovniPodaci.Ime} {nastavnik.OsnovniPodaci.Prezime}";

            PopuniListuMentora();
        }

        private void PopuniListuMentora()
        {
            listViewMentori.Items.Clear();
            List<MentorPregled> mentori = DTOManager.VratiSveMoguceMentore();

            foreach (var mentor in mentori)
            {
                if (mentor.Id == this.nastavnik.Id) continue;

                ListViewItem item = new ListViewItem(new string[] { mentor.PunoIme.Split(' ')[0], mentor.PunoIme.Split(' ')[1] });
                item.Tag = mentor.Id;
                listViewMentori.Items.Add(item);
            }
            listViewMentori.Refresh();
        }

        private void btnDodeli_Click(object sender, EventArgs e)
        {
            if (listViewMentori.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati mentora iz liste.");
                return;
            }

            int idMentora = (int)listViewMentori.SelectedItems[0].Tag;

            DTOManager.DodeliMentora(this.nastavnik.Id, idMentora);

            MessageBox.Show("Mentor je uspešno dodeljen!");
            this.Close();
        }
        #region dizajn
        private void listViewMentori_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

       

        private void listViewMentori_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion
    }
}
