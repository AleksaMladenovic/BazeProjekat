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
    public partial class KomisijeIspitiForm : Form
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
    
    }
}
