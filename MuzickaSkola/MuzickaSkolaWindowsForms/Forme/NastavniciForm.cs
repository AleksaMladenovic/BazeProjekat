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

        private void btnDodajNastavnika_Click(object sender, EventArgs e)
        {
            DodajNastavnikaForm formaZaDodavanje = new DodajNastavnikaForm();

            formaZaDodavanje.ShowDialog();

            this.PopuniPodacima();
        }

        private void btnObrisiNastavnika_Click(object sender, EventArgs e)
        {
            // 1. Proveravamo da li je neki red uopšte selektovan
            if (listViewNastavnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite nastavnika kojeg želite da obrišete.");
                return;
            }

            // 2. Pitamo korisnika za potvrdu
            DialogResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranog nastavnika?",
                                                    "Potvrda brisanja",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

            if (rezultat == DialogResult.Yes)
            {
                // 3. Ako je korisnik potvrdio, uzimamo ID iz Tag-a
                //    Setite se, sačuvali smo ID u Tag property kada smo punili listu.
                int idZaBrisanje = (int)listViewNastavnici.SelectedItems[0].Tag;

                // 4. Pozivamo našu metodu iz DataProvider-a
                DataProvider.ObrisiNastavnika(idZaBrisanje);

                MessageBox.Show("Nastavnik uspešno obrisan!");

                // 5. Osvežavamo listu da se obrisani nastavnik više ne prikazuje
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
            Nastavnik nastavnik = DataProvider.VratiNastavnika(idZaIzmenu);

            if (nastavnik != null)
            {
                // Otvaramo formu i prosleđujemo joj objekat
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

            // Sada moramo da nađemo kompletan DTO objekat za selektovani ID
            int id = (int)listViewNastavnici.SelectedItems[0].Tag;

            // Ponovo pozivamo DataProvider da dobijemo sve podatke
            // Ovo nije najefikasnije, ali je najjednostavnije za sada
            List<NastavnikPregled> sviNastavnici = DataProvider.VratiSveNastavnike();
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
            Nastavnik selektovaniNastavnik = DataProvider.VratiNastavnika(idNastavnika);

            if (selektovaniNastavnik != null)
            {
                DodeliMentoraForm forma = new DodeliMentoraForm(selektovaniNastavnik);
                forma.ShowDialog();
                // Nije neophodno osvežiti listu, jer se mentor ne vidi u glavnom prikazu
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
            Nastavnik selektovaniNastavnik = DataProvider.VratiNastavnika(idNastavnika);

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
    }
}
