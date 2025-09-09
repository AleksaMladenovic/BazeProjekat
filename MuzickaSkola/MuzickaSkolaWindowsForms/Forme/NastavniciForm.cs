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
    public partial class NastavniciForm : Form
    {
        public NastavniciForm()
        {
            InitializeComponent();
        }

        private void NastavniciForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            // Prvo, uvek obrišemo sve što je možda od ranije bilo u listi
            this.listViewNastavnici.Items.Clear();

            // Pozivamo našu metodu iz DataProvider-a koja vraća listu nastavnika
            List<NastavnikPregled> podaci = DataProvider.VratiSveNastavnike();

            // Sada, za svakog nastavnika iz te liste, pravimo jedan red u ListView-u
            foreach (NastavnikPregled n in podaci)
            {
                // Kreiramo red
                ListViewItem item = new ListViewItem(new string[] { n.Jmbg, n.Ime, n.Prezime, n.StrucnaSprema, n.TipZaposlenja });

                // Ovde radimo jedan trik: u "nevidljivu etiketu" (Tag) svakog reda
                // sačuvamo ID nastavnika. Ovo će nam trebati kasnije kada budemo radili
                // izmenu i brisanje, da znamo na kog nastavnika se misli.
                item.Tag = n.Id;

                // Dodajemo popunjen red u listu
                this.listViewNastavnici.Items.Add(item);
            }

            // Na kraju, osvežimo prikaz liste
            this.listViewNastavnici.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
