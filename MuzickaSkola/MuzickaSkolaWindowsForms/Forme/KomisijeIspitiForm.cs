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
    public partial class KomisijeIspitiForm : BaseForm
    {

        public KomisijeIspitiForm()
        {
            InitializeComponent();
            this.Text = "Pregled Komisija i Članova"; // Promenimo naslov
        }

        private void KomisijeIspitiForm_Load(object sender, EventArgs e)
        {
            PopuniListuKomisija();
        }

        private void PopuniListuKomisija()
        {
            listViewKomisije.Items.Clear();
            List<KomisijaPregled> komisije = DTOManager.VratiSveKomisije();
            foreach (var k in komisije)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Opis });
                item.Tag = k.Id;
                listViewKomisije.Items.Add(item);
            }
            listViewKomisije.Refresh();
        }

        private void listViewKomisije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewKomisije.SelectedItems.Count > 0)
            {
                int komisijaId = (int)listViewKomisije.SelectedItems[0].Tag;
                PopuniListuClanova(komisijaId);
            }
            else
            {
                listViewClanovi.Items.Clear(); // Koristimo novo ime
            }
        }

        // NOVA METODA
        private void PopuniListuClanova(int komisijaId)
        {
            listViewClanovi.Items.Clear(); // Koristimo novo ime
            List<NastavnikPregled> clanovi = DTOManager.VratiClanoveKomisije(komisijaId);
            foreach (var clan in clanovi)
            {
                ListViewItem item = new ListViewItem(new string[] { clan.Ime, clan.Prezime, clan.TipZaposlenja });
                listViewClanovi.Items.Add(item);
            }
            listViewClanovi.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewKomisije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite komisiju koju želite da obrišete.");
                return;
            }

            DialogResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu komisiju? Sve veze sa članovima.",
                                                    "Potvrda brisanja",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

            if (rezultat == DialogResult.Yes)
            {

                int idZaBrisanje = (int)listViewKomisije.SelectedItems[0].Tag;

                DTOManager.ObrisiKomisiju(idZaBrisanje);


                this.PopuniListuKomisija();

                this.listViewClanovi.Items.Clear();

                MessageBox.Show("Komisija je uspešno obrisana.");
            }
        }


        #region dizajn

        private void listViewKomisije_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewKomisije_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }


        private void listViewClanovi_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewClanovi_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion

    }
}
