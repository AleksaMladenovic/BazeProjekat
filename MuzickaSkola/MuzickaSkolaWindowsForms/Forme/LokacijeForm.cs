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
    public partial class LokacijeForm : BaseForm
    {
        public LokacijeForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LokacijeForm_Load(object sender, EventArgs e)
        {
            this.PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            List<LokacijaPregled> lokacije = DTOManager.VratiSveLokacije();

            this.listViewLokacije.Items.Clear();

            foreach (var l in lokacije)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    l.Adresa,
                    l.RadnoVreme,
                    l.Kapacitet.ToString(),
                });
                item.Tag = l;
                this.listViewLokacije.Items.Add(item);
            }
            this.listViewLokacije.Refresh();

        }
        private void cmdDodajLokaciju_Click(object sender, EventArgs e)
        {
            DodajIzmenLokacijuForm dodajForma = new DodajIzmenLokacijuForm();
            dodajForma.ShowDialog();
            this.PopuniPodacima();
        }

        private void cmdIzmeniLokaciju_Click(object sender, EventArgs e)
        {
            if (this.listViewLokacije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lokaciju koju zelite da izmenite");
                return;
            }

            LokacijaPregled selektovanaLokacijaPregled = (LokacijaPregled)this.listViewLokacije.SelectedItems[0].Tag;

            LokacijaBasic lokacijaZaIzmenu = DTOManager.VratiLokacijuZaIzmenu(selektovanaLokacijaPregled.Adresa);

            DodajIzmenLokacijuForm forma = new DodajIzmenLokacijuForm(lokacijaZaIzmenu);
            forma.ShowDialog();
            this.PopuniPodacima();
        }

        private void cmdObrisiLokaciju_Click(object sender, EventArgs e)
        {
            if (this.listViewLokacije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lokaciju koju zelite da obrisete");
                return;
            }
            string poruka = "Da li zelite da obrisete izabranu lokaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                LokacijaPregled selektovanaLokacijaPregled = (LokacijaPregled)this.listViewLokacije.SelectedItems[0].Tag;
                if (DTOManager.ObrisiLokaciju(selektovanaLokacijaPregled.Adresa))
                    this.PopuniPodacima();
            }
        }

        private void cmdPrikaziUcionice_Click(object sender, EventArgs e)
        {
            if (this.listViewLokacije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lokaciju za koju zelite da upravljate učionicama");
                return;
            }
            var formaUcionice = new UcioniceForm(((LokacijaPregled)listViewLokacije.SelectedItems[0].Tag).Adresa);
            formaUcionice.ShowDialog();
            this.PopuniPodacima();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        #region dizajn
        private void listViewLokacije_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Iscrtaj pozadinu hedera u našoj primarnoj boji
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewLokacije_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion
    }


}

