using FluentNHibernate.Conventions;
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
    public partial class DodajIzmeniUcionicuForm : Form
    {
        private string adresaLokacije;
        private UcionicaBasic? ucionicaDto;
        public DodajIzmeniUcionicuForm()
        {
            InitializeComponent();
        }

        public DodajIzmeniUcionicuForm(string adresaLokacije)
        {
            InitializeComponent();
            this.adresaLokacije = adresaLokacije;
            this.Text = "Dodavanje Nove Učionice";
            ucionicaDto = null;
        }

        public DodajIzmeniUcionicuForm(UcionicaBasic ucionicaZaIzmenu)
        {
            InitializeComponent();

            this.ucionicaDto = ucionicaZaIzmenu;
            PopuniPolja();
        }
        private void PopuniPolja()
        {
            if (this.ucionicaDto == null)
                return;

            txtNaziv.Text = this.ucionicaDto.Naziv;
            txtNaziv.Enabled = false;

            txtOpremljenost.Text = this.ucionicaDto.Opremljenost;
            numKapacitet.Value = this.ucionicaDto.Kapacitet;
        }
        

        private void cmdSacuvajUcionicu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                MessageBox.Show("Polje 'Naziv' ne sme biti prazno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ucionicaDto == null)
            {
                try
                {
                    if (DTOManager.DaLiUcionicaPostoji(adresaLokacije, txtNaziv.Text))
                    {
                        MessageBox.Show($"Učionica sa nazivom '{txtNaziv.Text}' već postoji na ovoj lokaciji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ucionicaDto = new UcionicaBasic
                    {
                        AdresaLokacije = this.adresaLokacije,
                        Kapacitet = (int)numKapacitet.Value,
                        Naziv = txtNaziv.Text,
                        Opremljenost = txtOpremljenost.Text,
                    };
                    
                    DTOManager.DodajUcionicu(ucionicaDto);
                    MessageBox.Show("Uspešno dodata nova učionica!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.FormatExceptionMessage());

                }

            }
            else
            {
                try
                {
                    ucionicaDto.Kapacitet = (int)numKapacitet.Value;
                    ucionicaDto.Opremljenost = txtOpremljenost.Text;

                    DTOManager.IzmeniUcionicu(ucionicaDto);
                    MessageBox.Show("Uspešno izmenjeni podaci o učionici!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
