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
    public partial class DodajIzmenLokacijuForm : Form
    {
        private LokacijaBasic lokacijaDto;
        public DodajIzmenLokacijuForm()
        {
            InitializeComponent();
            this.lokacijaDto = null;
            this.Text = "Dodavanje Nove Lokacije";
        }

        public DodajIzmenLokacijuForm(LokacijaBasic lokacijaZaIzmenu)
        {
            InitializeComponent();
            this.lokacijaDto = lokacijaZaIzmenu;
            this.Text = "Izmena Podataka o Lokaciji";
            this.PopuniPolja();
        }

        private void PopuniPolja()
        {
            if (this.lokacijaDto == null)
                return;

            txtAdresa.Text = this.lokacijaDto.Adresa;
            txtRadnoVreme.Text = this.lokacijaDto.RadnoVreme;

            txtAdresa.Enabled = false;
        }

        private void cmdSacuvajLokaciju_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                MessageBox.Show("Polje 'Adresa' ne sme biti prazno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (string.IsNullOrWhiteSpace(txtRadnoVreme.Text))
            {
                MessageBox.Show("Polje 'Radno vreme' ne sme biti prazno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.lokacijaDto == null)
            {
                var novaLokacija = new LokacijaBasic
                {
                    Adresa = txtAdresa.Text,
                    RadnoVreme = txtRadnoVreme.Text
                };

                try
                {
                    if (DTOManager.DaLiLokacijaPostoji(novaLokacija.Adresa))
                    {
                        MessageBox.Show($"Lokacija '{novaLokacija.Adresa}' vec postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DTOManager.DodajLokaciju(novaLokacija);
                    MessageBox.Show("Uspešno dodata nova lokacija!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.FormatExceptionMessage());
                }
            }
            else
            {
                this.lokacijaDto.RadnoVreme = txtRadnoVreme.Text;

                try
                {
                    DTOManager.IzmeniLokaciju(this.lokacijaDto);
                    MessageBox.Show("Uspešno izmenjeni podaci o lokaciji!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.FormatExceptionMessage());
                }
            }
        }
    }
}
