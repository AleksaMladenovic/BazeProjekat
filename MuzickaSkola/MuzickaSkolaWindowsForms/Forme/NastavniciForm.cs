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
    public partial class NastavniciForm : BaseForm
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
            this.listViewNastavnici.Items.Clear();

            List<NastavnikPregled> podaci = DTOManager.VratiSveNastavnike();

            foreach (NastavnikPregled n in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { n.Jmbg, n.Ime, n.Prezime, n.StrucnaSprema, n.TipZaposlenja });

                item.Tag = n.Id;

                this.listViewNastavnici.Items.Add(item);
            }

            this.listViewNastavnici.Refresh();
        }

        private void btnDodajNastavnika_Click(object sender, EventArgs e)
        {
            DodajNastavnikaForm formaZaDodavanje = new DodajNastavnikaForm();

            formaZaDodavanje.ShowDialog();

            this.PopuniPodacima();
        }

        private void btnObrisiNastavnika_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika kojeg želite da obrišete.");
                return;
            }

            DialogResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranog nastavnika?",
                                                    "Potvrda brisanja",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

            if (rezultat == DialogResult.Yes)
            {
                int idZaBrisanje = (int)listViewNastavnici.SelectedItems[0].Tag;

                DTOManager.ObrisiNastavnika(idZaBrisanje);

                MessageBox.Show("Nastavnik uspešno obrisan!");

                this.PopuniPodacima();
            }
        }

        private void btnIzmeniNastavnika_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika kojeg želite da izmenite.");
                return;
            }

            int idZaIzmenu = (int)listViewNastavnici.SelectedItems[0].Tag;
            Nastavnik nastavnik = DTOManager.VratiNastavnika(idZaIzmenu);

            if (nastavnik != null)
            {
                DodajNastavnikaForm formaZaIzmenu = new DodajNastavnikaForm(nastavnik);
                formaZaIzmenu.ShowDialog();
                this.PopuniPodacima();
            }
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika.");
                return;
            }

            int id = (int)listViewNastavnici.SelectedItems[0].Tag;

            List<NastavnikPregled> sviNastavnici = DTOManager.VratiSveNastavnike();
            NastavnikPregled selektovaniNastavnik = sviNastavnici.FirstOrDefault(n => n.Id == id);

            if (selektovaniNastavnik != null)
            {
                DetaljiNastavnikForm forma = new DetaljiNastavnikForm(selektovaniNastavnik);
                forma.ShowDialog();
            }
        }

        private void btnPrikaziKurseve_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika.");
                return;
            }

            int idNastavnika = (int)listViewNastavnici.SelectedItems[0].Tag;

            KurseviNastavnikForm forma = new KurseviNastavnikForm(idNastavnika);
            forma.ShowDialog();
        }

        private void btnDodeliMentora_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika kojem želite da dodelite mentora.");
                return;
            }

            int idNastavnika = (int)listViewNastavnici.SelectedItems[0].Tag;
            Nastavnik selektovaniNastavnik = DTOManager.VratiNastavnika(idNastavnika);

            if (selektovaniNastavnik != null)
            {
                DodeliMentoraForm forma = new DodeliMentoraForm(selektovaniNastavnik);
                forma.ShowDialog();
            }
        }

        private void btnPrikaziCasove_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika.");
                return;
            }

            int idNastavnika = (int)listViewNastavnici.SelectedItems[0].Tag;

            CasoviNastavnikaForm forma = new CasoviNastavnikaForm(idNastavnika);
            forma.ShowDialog();
        }

        private void btnUpravljajKomisijama_Click(object sender, EventArgs e)
        {
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika.");
                return;
            }

            int idNastavnika = (int)listViewNastavnici.SelectedItems[0].Tag;
            Nastavnik selektovaniNastavnik = DTOManager.VratiNastavnika(idNastavnika);

            if (selektovaniNastavnik != null)
            {
                UpravljanjeKomisijamaForm forma = new UpravljanjeKomisijamaForm(selektovaniNastavnik);
                forma.ShowDialog();
            }
        }

        private void btnKomisije_Click(object sender, EventArgs e)
        {
            KomisijeIspitiForm forma = new KomisijeIspitiForm();
            forma.ShowDialog();
        }

        private void labelNaslov_Click(object sender, EventArgs e)
        {

        }
        #region dizajn
        private void listViewNastavnici_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewNastavnici_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion
    }
}
