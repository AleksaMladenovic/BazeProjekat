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
    public partial class DodajNastavnikaForm : Form
    {
        private Nastavnik nastavnikZaIzmenu;

        // Konstruktor za DODAVANJE
        public DodajNastavnikaForm()
        {
            InitializeComponent();
        }

        // Konstruktor za IZMENU
        public DodajNastavnikaForm(Nastavnik nastavnik)
        {
            InitializeComponent();
            this.nastavnikZaIzmenu = nastavnik;
            this.Text = "Izmeni Nastavnika";
        }

        private void DodajNastavnikaForm_Load(object sender, EventArgs e)
        {
            if (this.nastavnikZaIzmenu != null)
            {
                PopuniPodacimaZaIzmenu();
            }
        }

        private void PopuniPodacimaZaIzmenu()
        {
            txtJmbg.Text = nastavnikZaIzmenu.OsnovniPodaci.Jmbg;
            txtIme.Text = nastavnikZaIzmenu.OsnovniPodaci.Ime;
            txtPrezime.Text = nastavnikZaIzmenu.OsnovniPodaci.Prezime;
            txtAdresa.Text = nastavnikZaIzmenu.OsnovniPodaci.Adresa;
            txtTelefon.Text = nastavnikZaIzmenu.OsnovniPodaci.Telefon;
            txtEmail.Text = nastavnikZaIzmenu.OsnovniPodaci.Email;
            txtStrucnaSprema.Text = nastavnikZaIzmenu.OsnovniPodaci.StrucnaSprema;
            dtpDatumZaposlenja.Value = nastavnikZaIzmenu.OsnovniPodaci.DatumZaposlenja ?? DateTime.Now;

            if (nastavnikZaIzmenu is StalnoZaposlen sz)
            {
                rbStalnoZaposlen.Checked = true;
                txtRadnoVreme.Text = sz.RadnoVreme;
            }
            else if (nastavnikZaIzmenu is Honorarac h)
            {
                rbHonorarac.Checked = true;
                txtBrojUgovora.Text = h.BrojUgovora;
                txtTrajanjeUgovora.Text = h.TrajanjeUgovora;
                numBrojCasova.Value = h.BrojCasova ?? 0;
            }
        }

        private void rbStalnoZaposlen_CheckedChanged(object sender, EventArgs e)
        {
            panelStalnoZaposlen.Visible = true;
            panelHonorarac.Visible = false;
        }

        private void rbHonorarac_CheckedChanged(object sender, EventArgs e)
        {
            panelStalnoZaposlen.Visible = false;
            panelHonorarac.Visible = true;
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJmbg.Text) || txtJmbg.Text.Length != 13)
            {
                MessageBox.Show("JMBG mora imati tačno 13 cifara!");
                return; // Prekida se dalje izvršavanje metode
            }
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                MessageBox.Show("Polje Ime ne sme biti prazno!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                MessageBox.Show("Polje Prezime ne sme biti prazno!");
                return;
            }
            if (!rbStalnoZaposlen.Checked && !rbHonorarac.Checked)
            {
                MessageBox.Show("Morate izabrati tip zaposlenja!");
                return;
            }

            // --- KORAK 2: ODLUČIVANJE (DODAVANJE ILI IZMENA) ---
            // Proveravamo da li je `nastavnikZaIzmenu` null.
            // Ako jeste, znači da smo formu otvorili preko dugmeta "Dodaj".
            // Ako nije, znači da smo je otvorili preko dugmeta "Izmeni".

            if (this.nastavnikZaIzmenu == null)
            {
                // --- LOGIKA ZA DODAVANJE NOVOG NASTAVNIKA ---

                // Kreiramo potpuno novi Osoba objekat
                Osoba o = new Osoba()
                {
                    Jmbg = txtJmbg.Text,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    Telefon = txtTelefon.Text,
                    Email = txtEmail.Text,
                    StrucnaSprema = txtStrucnaSprema.Text,
                    DatumZaposlenja = dtpDatumZaposlenja.Value,
                    FNastavnik = true,
                    FPolaznik = false,
                    FRoditelj = false
                };

                // Proveravamo koji je tip zaposlenja izabran
                if (rbStalnoZaposlen.Checked)
                {
                    // Kreiramo novi StalnoZaposlen objekat
                    StalnoZaposlen sz = new StalnoZaposlen()
                    {
                        RadnoVreme = txtRadnoVreme.Text
                    };
                    // Šaljemo oba nova objekta DataProvider-u na snimanje
                    DTOManager.DodajNastavnika(o, sz);
                }
                else // Mora biti Honorarac
                {
                    // Kreiramo novi Honorarac objekat
                    Honorarac h = new Honorarac()
                    {
                        BrojUgovora = txtBrojUgovora.Text,
                        TrajanjeUgovora = txtTrajanjeUgovora.Text,
                        BrojCasova = (int)numBrojCasova.Value
                    };
                    // Šaljemo oba nova objekta DataProvider-u na snimanje
                    DTOManager.DodajNastavnika(o, h);
                }
                MessageBox.Show("Nastavnik je uspešno dodat!");
            }
            else // Ako nije null, MENJAMO
            {
                // --- ISPRAVNA LOGIKA ZA IZMENU ---

                // 1. Ažuriramo podatke na postojećem Osoba objektu
                Osoba o = this.nastavnikZaIzmenu.OsnovniPodaci;
                o.Jmbg = txtJmbg.Text;
                o.Ime = txtIme.Text;
                // ... popunite sve ostale Osoba propertije ...

                // 2. Proveravamo da li se tip promenio
                bool bioJeStalnoZaposlen = this.nastavnikZaIzmenu is StalnoZaposlen;
                bool biceStalnoZaposlen = rbStalnoZaposlen.Checked;

                Nastavnik finalniNastavnik;

                if (bioJeStalnoZaposlen == biceStalnoZaposlen)
                {
                    // Tip se NIJE promenio, samo ažuriramo postojeći objekat
                    finalniNastavnik = this.nastavnikZaIzmenu;
                    if (finalniNastavnik is StalnoZaposlen sz)
                    {
                        sz.RadnoVreme = txtRadnoVreme.Text;
                    }
                    else if (finalniNastavnik is Honorarac h)
                    {
                        h.BrojUgovora = txtBrojUgovora.Text;
                        h.TrajanjeUgovora = txtTrajanjeUgovora.Text;
                        h.BrojCasova = (int)numBrojCasova.Value;
                    }
                }
                else
                {
                    // Tip SE PROMENIO, kreiramo NOVI objekat odgovarajućeg tipa
                    if (biceStalnoZaposlen)
                    {
                        finalniNastavnik = new StalnoZaposlen
                        {
                            RadnoVreme = txtRadnoVreme.Text
                        };
                    }
                    else // Biće Honorarac
                    {
                        finalniNastavnik = new Honorarac
                        {
                            BrojUgovora = txtBrojUgovora.Text,
                            TrajanjeUgovora = txtTrajanjeUgovora.Text,
                            BrojCasova = (int)numBrojCasova.Value
                        };
                    }
                    // Povezujemo novi objekat sa postojećom Osobom
                    finalniNastavnik.Id = o.Id;
                    finalniNastavnik.OsnovniPodaci = o;
                }

                // 3. Prosleđujemo finalni objekat (stari ili novi) DataProvider-u
                DTOManager.IzmeniNastavnika(finalniNastavnik);
                MessageBox.Show("Nastavnik je uspešno izmenjen!");
            }
            this.Close();
        }
    }
}
