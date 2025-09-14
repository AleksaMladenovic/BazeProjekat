using MuzickaSkolaWindowsForms.Entiteti;
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
    public partial class DodajIzmeniCasForm : BaseForm
    {
        private int idNastave;
        private CasBasic? cas;
        public DodajIzmeniCasForm()
        {
            InitializeComponent();
        }
        public DodajIzmeniCasForm(int idNastave)
        {
            InitializeComponent();
            this.idNastave = idNastave;
            cas = null;
            this.Text = "Dodavanje Novog Časa";
        }

        public DodajIzmeniCasForm(CasBasic cas)
        {
            InitializeComponent();
            this.cas = cas;
            this.idNastave = cas.NastavaId;
            this.Text = "Izmena Podataka o Času";
        }

        private void DodajIzmeniCasForm_Load(object sender, EventArgs e)
        {
            this.PopuniPodatke();
        }

        private void PopuniPodatke()
        {
            List<NastavnikPregled> nastavnici = DTOManager.VratiSveNastavnike();
            cmbNastavnici.DataSource = nastavnici;
            cmbNastavnici.ValueMember = "Id";
            cmbNastavnici.DisplayMember = "PunoIme";

            List<UcionicaPregled> ucionice = DTOManager.VratiSveUcioniceNastavu(idNastave); 
            cmbUcionice.DataSource = ucionice;
            cmbUcionice.DisplayMember = "PunoImeUcionice";

            if (cas != null)
            {
                txtTema.Text = cas.Tema;
                dtpTermin.Value = cas.Termin;

                cmbNastavnici.SelectedValue = this.cas.NastavnikId;

                foreach (UcionicaPregled u in cmbUcionice.Items)
                {
                    if (u.AdresaLokacije == this.cas.Lokacija && u.Naziv == this.cas.Ucionica)
                    {
                        cmbUcionice.SelectedItem = u;
                        break;
                    }
                }
            }
        }

        private void cmdSacuvaj_Click(object sender, EventArgs e)
        {
            if (!DTOManager.TerminObuhvataNastava(dtpTermin.Value, idNastave))
            {
                MessageBox.Show($"Dati termin se ne slaze sa datumima nastave!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UcionicaPregled selektovanaUcionica = (UcionicaPregled)cmbUcionice.SelectedItem;

            if (cas == null)
            {
                cas = new CasBasic()
                {
                    Termin = dtpTermin.Value,
                    Tema = txtTema.Text,
                    NastavnikId = (int)cmbNastavnici.SelectedValue,
                    Ucionica = selektovanaUcionica.Naziv,
                    Lokacija = selektovanaUcionica.AdresaLokacije,
                    NastavaId = this.idNastave
                };

                DTOManager.DodajCas(cas);
                MessageBox.Show("Uspešno dodat čas");
            }
            else
            {
                cas.Termin = dtpTermin.Value;
                cas.Tema = txtTema.Text;
                cas.NastavnikId = (int)cmbNastavnici.SelectedValue;
                cas.Ucionica = selektovanaUcionica.Naziv;
                cas.Lokacija = selektovanaUcionica.AdresaLokacije;
                cas.NastavaId = this.idNastave;
            
                DTOManager.IzmeniCas(cas);
                MessageBox.Show("Uspešno izmenjen čas");
            }

            this.Close();
        }
    }
}
