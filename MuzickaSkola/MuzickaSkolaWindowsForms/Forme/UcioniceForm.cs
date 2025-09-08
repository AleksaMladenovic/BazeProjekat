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
    public partial class UcioniceForm : Form
    {
        private string? adresaLokacije;
        public UcioniceForm()
        {
            InitializeComponent();
        }
        public UcioniceForm(string adresaLokacije)
        {
            InitializeComponent();
            this.adresaLokacije = adresaLokacije;
        }

        private void cmdDodajUcionicu_Click(object sender, EventArgs e)
        {
            var forma = new DodajIzmeniUcionicuForm(this.adresaLokacije);
            forma.ShowDialog();
            this.PopuniPodacima();
        }

        private void cmdIzmeniUcionicu_Click(object sender, EventArgs e)
        {
            if (listViewUcionice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite učionicu koju zelite da obrišete");
                return;
            }
            var selektovanaUcionicaPregled = (UcionicaPregled)listViewUcionice.SelectedItems[0].Tag;
            UcionicaBasic ucionicaZaIzmenu = DTOManager.vratiUcionicuZaIzmenu(selektovanaUcionicaPregled);

            var forma = new DodajIzmeniUcionicuForm(ucionicaZaIzmenu);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void cmdObrisiUcionicu_Click(object sender, EventArgs e)
        {
            if (listViewUcionice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite učionicu koju zelite da obrišete");
                return;
            }
            string poruka = "Da li zelite da obrisete izabranu učionicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                UcionicaPregled selektovanaLokacijaPregled = (UcionicaPregled)this.listViewUcionice.SelectedItems[0].Tag;
                if (DTOManager.ObrisiUcionicu(this.adresaLokacije,selektovanaLokacijaPregled.Naziv))
                    this.PopuniPodacima();
            }
        }

        private void UcioniceForm_Load(object sender, EventArgs e)
        {
            this.lblInfoLokacije.Text = $"Učionice za lokaciju: {this.adresaLokacije}";
            this.PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            this.listViewUcionice.Items.Clear();
            List<UcionicaPregled> ucionicePregled = DTOManager.VratiSveUcioniceZaLokaciju(this.adresaLokacije);

            foreach(var u in ucionicePregled)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    u.Naziv,
                    u.Opremljenost,
                    u.Kapacitet.ToString(),
                });
                item.Tag = u;
                this.listViewUcionice.Items.Add(item);

            }
            this.listViewUcionice.Refresh();
        }
    }
}
