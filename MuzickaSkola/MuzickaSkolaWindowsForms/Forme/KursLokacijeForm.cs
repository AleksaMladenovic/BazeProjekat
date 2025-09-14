using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzickaSkolaWindowsForms.Forme
{
    public partial class KursLokacijeForm : BaseForm
    {
        private int kursId;
        public KursLokacijeForm()
        {
            InitializeComponent();
        }

        public KursLokacijeForm(int kursId)
        {
            InitializeComponent();
            this.kursId = kursId;
        }

        private void KursLokacijeForm_Load(object sender, EventArgs e)
        {
            List<LokacijaPregled> sveLokacije = DTOManager.VratiSveLokacije();
            List<LokacijaPregled> dodeljeneLokacije = DTOManager.VratiSveLokacijeZaKurs(kursId);
            List<LokacijaPregled> nedodeljeneLokacije = sveLokacije.Except(dodeljeneLokacije).ToList();
            cmdUkloniLokaciju.Enabled = false;
            cmdDodajLokaciju.Enabled = false;

            listViewNedodeljeneLokacije.Items.Clear();
            listViewDodeljeneLokacije.Items.Clear();
            foreach (var lok in nedodeljeneLokacije)
            {
                ListViewItem item = new ListViewItem(new string[] { lok.Adresa, lok.RadnoVreme, lok.Kapacitet.ToString() });
                item.Tag = lok;
                listViewNedodeljeneLokacije.Items.Add(item);
            }
            foreach (var lok in dodeljeneLokacije)
            {
                ListViewItem item = new ListViewItem(new string[] { lok.Adresa, lok.RadnoVreme, lok.Kapacitet.ToString() });
                item.Tag = lok;
                listViewDodeljeneLokacije.Items.Add(item);
            }


        }

        private void listViewNedodeljeneLokacije_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewNedodeljeneLokacije.SelectedItems.Count > 0)
            {
                cmdDodajLokaciju.Enabled = true;
            }
            else
            {
                cmdDodajLokaciju.Enabled = false;
            }
        }

        private void listViewDodeljeneLokacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDodeljeneLokacije.SelectedItems.Count > 0)
            {
                cmdUkloniLokaciju.Enabled = true;
            }
            else
            {
                cmdUkloniLokaciju.Enabled = false;
            }
        }

        private void cmdDodajLokaciju_Click(object sender, EventArgs e)
        {
            ListViewItem selektovaniItem = listViewNedodeljeneLokacije.SelectedItems[0];

            listViewNedodeljeneLokacije.Items.Remove(selektovaniItem);

            listViewDodeljeneLokacije.Items.Add(selektovaniItem);
        }

        private void cmdUkloniLokaciju_Click(object sender, EventArgs e)
        {
            var selektovanaLokacija = (LokacijaPregled)listViewDodeljeneLokacije.SelectedItems[0].Tag;
            if (DTOManager.DaLiPostojeCasoviZaKursNaLokaciji(this.kursId, selektovanaLokacija.Adresa))
            {
                MessageBox.Show($"Postoji čas na lokaciji koju želite da uklonite!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem selektovanItem = listViewDodeljeneLokacije.SelectedItems[0];
            listViewDodeljeneLokacije.Items.Remove(selektovanItem);
            listViewNedodeljeneLokacije.Items.Add(selektovanItem);
        }

        private void listViewNedodeljeneLokacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmdDodajLokaciju_Click(sender, e);
        }

        private void listViewDodeljeneLokacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmdUkloniLokaciju_Click(sender, e);
        }

        private void cmdSacuvaj_Click(object sender, EventArgs e)
        {
            List<string> finalneAdrese = new List<string>();
            foreach (ListViewItem item in listViewDodeljeneLokacije.Items)
            {
                LokacijaPregled lok = (LokacijaPregled)item.Tag;
                finalneAdrese.Add(lok.Adresa);
            }
            try
            {
                DTOManager.AzurirajLokacijeZaKurs(this.kursId, finalneAdrese);
                MessageBox.Show("Uspešno ažurirane lokacije");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Došlo je do greške!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region dizajn

        private void listViewNedodeljeneLokacije_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Iscrtaj pozadinu hedera u našoj primarnoj boji
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewNedodeljeneLokacije_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
        }

        private void listViewDodeljeneLokacije_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Iscrtaj pozadinu hedera u našoj primarnoj boji
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewDodeljeneLokacije_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
       

        private void listViewNedodeljeneLokacije_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion
    }
}
