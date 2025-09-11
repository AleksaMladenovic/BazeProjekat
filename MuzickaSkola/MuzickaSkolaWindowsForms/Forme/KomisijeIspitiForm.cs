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
        }

        // Događaj koji se okida kada se forma učita
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

        // Događaj koji se okida KADA SE PROMENI SELEKCIJA u levoj listi
        private void listViewKomisije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewKomisije.SelectedItems.Count > 0)
            {
                int komisijaId = (int)listViewKomisije.SelectedItems[0].Tag;
                PopuniListuIspita(komisijaId);
            }
            else
            {
                listViewIspiti.Items.Clear();
            }
        }

        private void PopuniListuIspita(int komisijaId)
        {
            listViewIspiti.Items.Clear();
            List<ZavrsniIspitPregled> ispiti = DTOManager.VratiIspiteZaKomisiju(komisijaId);
            foreach (var i in ispiti)
            {
                ListViewItem item = new ListViewItem(new string[] { i.NazivKursa, i.Datum.ToString("dd.MM.yyyy"), i.Ocena.ToString(), i.PunoImePolaznika });
                listViewIspiti.Items.Add(item);
            }
            listViewIspiti.Refresh();
        }
    }
}
