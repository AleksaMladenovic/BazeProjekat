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
    public partial class UpravljanjeKomisijamaForm : Form
    {
        public UpravljanjeKomisijamaForm()
        {
            InitializeComponent();
        }

        private void UpravljanjeKomisijamaForm_Load(object sender, EventArgs e)
        {
            lblNastavnikInfo.Text = $"Upravljanje članstvom za: {nastavnik.OsnovniPodaci.Ime} {nastavnik.OsnovniPodaci.Prezime}";
            PopuniListe();
        }
        private Nastavnik nastavnik;

        public UpravljanjeKomisijamaForm(Nastavnik n)
        {
            InitializeComponent();
            this.nastavnik = n;
        }


        private void PopuniListe()
        {
            listViewClan.Items.Clear();
            listViewNijeClan.Items.Clear();

            // Učitavamo sve komisije koje postoje u sistemu
            List<KomisijaPregled> sveKomisije = DataProvider.VratiSveKomisije();

            // "Budimo" kolekciju da izbegnemo LazyInitializationException
            NHibernateUtil.Initialize(nastavnik.KomisijeCijiJeClan);

            // Pravimo listu ID-jeva komisija u kojima je nastavnik već član
            List<int> clanKomisijaIds = nastavnik.KomisijeCijiJeClan.Select(k => k.Id).ToList();

            foreach (var k in sveKomisije)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Opis });
                item.Tag = k.Id;

                if (clanKomisijaIds.Contains(k.Id))
                {
                    // Ako je član, dodaj u levu listu
                    listViewClan.Items.Add(item);
                }
                else
                {
                    // Ako nije član, dodaj u desnu listu
                    listViewNijeClan.Items.Add(item);
                }
            }
        }

        // Dugme '->' (dodaj u članstvo)
        private void btnDodajUcesce_Click(object sender, EventArgs e)
        {
            if (listViewNijeClan.SelectedItems.Count > 0)
            {
                ListViewItem selektovani = listViewNijeClan.SelectedItems[0];
                listViewNijeClan.Items.Remove(selektovani);
                listViewClan.Items.Add(selektovani);
            }
        }

        // Dugme '<-' (ukloni iz članstva)
        private void btnUkloniUcesce_Click(object sender, EventArgs e)
        {
            if (listViewClan.SelectedItems.Count > 0)
            {
                ListViewItem selektovani = listViewClan.SelectedItems[0];
                listViewClan.Items.Remove(selektovani);
                listViewNijeClan.Items.Add(selektovani);
            }
        }

        // Dugme "Sačuvaj promene"
        private void btnSnimiPromene_Click(object sender, EventArgs e)
        {
            // Skupljamo ID-jeve svih komisija iz leve liste (gde je sada član)
            List<int> finalniIdjevi = new List<int>();
            foreach (ListViewItem item in listViewClan.Items)
            {
                finalniIdjevi.Add((int)item.Tag);
            }

            DataProvider.SacuvajIzmeneZaKomisije(this.nastavnik.Id, finalniIdjevi);
            MessageBox.Show("Promene u članstvu su uspešno sačuvane!");
            this.Close();
        }

    }
}
