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
    public partial class DodajIzmeniKursForm : Form
    {
        private KursBasic? kurs;
        public DodajIzmeniKursForm()
        {
            InitializeComponent();
            kurs = null;
            this.Text = "Dodavanje Novog Kursa";
        }

        public DodajIzmeniKursForm(int kursId)
        {
            InitializeComponent();
            this.kurs = DTOManager.VratiKursBasic(kursId);
            
            if (this.kurs == null)
            {
                this.Close();
                return;
            }
            this.Text = "Izmena Podataka o Kursu";
        }
        private void DodajIzmeniKursForm_Load(object sender, EventArgs e)
        {
            this.PopuniPodatke();
        }

        private void PopuniPodatke()
        {
            //potrebno implementirati za nastavnika
            cmbTipKursa.Items.AddRange(new string[]
            {
                "INSTRUMENT",
                "GRUPA_INSTRUMENATA",
                "INDIVIDUALNO_PEVANJE",
                "HORSKO_PEVANJE",
                "MUZICKA_TEORIJA"
            });

            var sviNastavnici = DTOManager.VratiSveNastavnike();
            foreach(var nastavnik in sviNastavnici)
            {
                cmbNastavnici.Items.Add(new NastavnikComboBox { Id = nastavnik.Id, PunoIme = $"{nastavnik.OsnovniPodaci.Ime} {nastavnik.OsnovniPodaci.Prezime}" });
            }

            if (this.kurs != null)
            {
                txtNaziv.Text = this.kurs.Naziv;
                txtNivo.Text = this.kurs.Nivo;

                string tip = kurs.TipKursa;
                cmbTipKursa.SelectedItem = tip;

                cmbTipKursa.Enabled = false;
                foreach(var i in cmbNastavnici.Items)
                {
                    if (((NastavnikComboBox)i).Id == this.kurs.NastavnikId)
                    {
                        cmbNastavnici.SelectedItem = i;
                        break;
                    }
                }
                if (tip == "INSTRUMENT")
                {
                    txtInstrument.Text = this.kurs.Instrument;
                }
                else if (tip == "GRUPA_INSTRUMENATA")
                {
                    txtGrupaInstrumenata.Text = this.kurs.GrupaInstrumenata;
                }
                else if (tip == "MUZICKA_TEORIJA")
                {
                    txtNazivPredmeta.Text = this.kurs.NazivPredmeta;
                }
            }
            else
            {
                cmbTipKursa.SelectedIndex = 0;
                cmbNastavnici.SelectedIndex = 0;
            }
        }
        private void cmdSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text)  || cmbTipKursa.SelectedItem == null)
            {
                MessageBox.Show("Molimo vas popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var kursDto = this.kurs ?? new KursBasic();
            kursDto.Naziv = txtNaziv.Text;
            kursDto.Nivo = txtNivo.Text;
            kursDto.NastavnikId = ((NastavnikComboBox)cmbNastavnici.SelectedItem).Id;
            
            string tipKursa = cmbTipKursa.SelectedItem.ToString();

            if (tipKursa == "INSTRUMENT")
            {
                kursDto.Instrument = txtInstrument.Text;
            }
            else if (tipKursa== "GRUPA_INSTRUMENATA")
            {
                kursDto.GrupaInstrumenata = txtGrupaInstrumenata.Text;
            }
            else if (tipKursa== "MUZICKA_TEORIJA")
            {
                kursDto.NazivPredmeta = txtNazivPredmeta.Text;
            }

            try
            {
                if (kursDto.Id == 0)
                {
                    DTOManager.DodajKurs(kursDto, tipKursa);
                    MessageBox.Show("Uspesno dodat novi kurs");
                }
                else
                {
                    DTOManager.IzmeniKurs(kursDto);
                    MessageBox.Show("Uspesno izmenjeni podaci");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        private void cmbTipKursa_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlInstrument.Visible = false;
            pnlGrupaInstrumenata.Visible = false;
            pnlMuzickaTeorija.Visible = false;

            string selektovanTip = cmbTipKursa.SelectedItem.ToString();

            switch (selektovanTip)
            {
                case "INSTRUMENT":
                    pnlInstrument.Visible = true;
                    break;
                case "GRUPA_INSTRUMENATA":
                    pnlGrupaInstrumenata.Visible=true;
                    break;
                case "MUZICKA_TEORIJA":
                    pnlMuzickaTeorija.Visible=true;
                    break;
            }
        }
    }
}
