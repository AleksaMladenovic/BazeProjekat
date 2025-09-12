using MuzickaSkolaWindowsForms.Mapiranja;
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
    public partial class KurseviForm : Form
    {
        public KurseviForm()
        {
            InitializeComponent();
        }

        private void KurseviForm_Load(object sender, EventArgs e)
        {
            OnemoguciDugmice();
            this.PopuniPodacima();
        }

        private void OnemoguciDugmice()
        {

            cmdIzmeniKurs.Enabled = false;
            cmdObrisiKurs.Enabled = false;
            cmdNastavniBlokovi.Enabled = false;
        }

        private void OmoguciDugmice()
        {
            cmdIzmeniKurs.Enabled = true;
            cmdObrisiKurs.Enabled = true;
            cmdNastavniBlokovi.Enabled = true;
        }
        private void PopuniPodacima()
        {
            listViewKursevi.Items.Clear();

            List<KursPregled> podaci = DTOManager.VratiSveKurseve();

            foreach (var k in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] {
                k.Id.ToString(),
                k.Naziv,
                k.Nivo,
                k.TipKursa,
                k.ImeNastavnika,
                });
                item.Tag = k;
                listViewKursevi.Items.Add(item);
            }
            listViewKursevi.Refresh();
            OnemoguciDugmice();
        }

        private void listViewKursevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewKursevi.SelectedItems.Count != 0)
            {
                OmoguciDugmice();
            }
            else
            {
                OnemoguciDugmice();
            }
        }

        private void cmdDodajKurs_Click(object sender, EventArgs e)
        {
            var forma = new DodajIzmeniKursForm();
            forma.ShowDialog();
            this.PopuniPodacima();
        }

        private void cmdIzmeniKurs_Click(object sender, EventArgs e)
        {
            var forma = new DodajIzmeniKursForm(((KursPregled)listViewKursevi.SelectedItems[0].Tag).Id);
            forma.ShowDialog();
            this.PopuniPodacima();
            OnemoguciDugmice();
        }

        private void cmdObrisiKurs_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da obrisete izabrani kurs?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                KursPregled selektovaniKursPregled = (KursPregled)this.listViewKursevi.SelectedItems[0].Tag;
                if (DTOManager.ObrisiKurs(selektovaniKursPregled.Id))
                    this.PopuniPodacima();
            }

        }

        private void cmdNastavniBlokovi_Click(object sender, EventArgs e)
        {
            KursPregled k = (KursPregled)listViewKursevi.SelectedItems[0].Tag;
            var form = new NastavaForm(k);
            form.ShowDialog();
        }
    }
}
