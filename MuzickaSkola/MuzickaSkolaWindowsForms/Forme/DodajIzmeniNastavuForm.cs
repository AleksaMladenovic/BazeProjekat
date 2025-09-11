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
    public partial class DodajIzmeniNastavuForm : Form
    {
        private int idKursa;
        private NastavaBasic nastava;
        public DodajIzmeniNastavuForm()
        {
            InitializeComponent();
        }

        public DodajIzmeniNastavuForm(int idKursa)
        {
            InitializeComponent();
            this.idKursa = idKursa;
            this.nastava = null;
            this.Text = "Dodavanje Novog Nastavnog Bloka";
        }
        public DodajIzmeniNastavuForm(NastavaBasic nastavaZaIzmenu)
        {
            InitializeComponent();
            this.idKursa = nastavaZaIzmenu.IdKursa;
            this.nastava = nastavaZaIzmenu;
            this.Text = "Izmena Nastavnog Bloka";
        }

        private void DodajIzmeniNastavuForm_Load(object sender, EventArgs e)
        {
            cbxDatumDo.Checked = true;

            if (this.nastava != null)
            {
                dtpDatumOd.Value = this.nastava.DatumOd;
                if (this.nastava.DatumDo.HasValue)
                {
                    dtpDatumDo.Value = this.nastava.DatumDo.Value;
                    cbxDatumDo.Checked = true;
                }
                else
                {
                    cbxDatumDo.Checked = false;
                    dtpDatumDo.Enabled = false;
                }
            }
        }

        private void cbxDatumDo_CheckedChanged(object sender, EventArgs e)
        {
            dtpDatumDo.Enabled = cbxDatumDo.Checked;
        }

        private void cmdSnimi_Click(object sender, EventArgs e)
        {
            if (dtpDatumOd.Value >= dtpDatumDo.Value && cbxDatumDo.Checked)
            {
                MessageBox.Show("Datum početka mora biti pre datuma završetka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nastavaDto = this.nastava ?? new NastavaBasic();
            nastavaDto.IdKursa = this.idKursa;
            nastavaDto.DatumOd = dtpDatumOd.Value;

            if (cbxDatumDo.Checked)
            {
                nastavaDto.DatumDo = dtpDatumDo.Value;
            }
            else
            {
                nastavaDto.DatumDo = null;
            }


            try
            {
                if (nastavaDto.Id == 0) // Novi
                {
                    if (DTOManager.DodajNastavu(nastavaDto))
                    {
                        MessageBox.Show("Uspešno dodat novi nastavni blok!");
                        this.Close();
                    }
                }
                else 
                {
                    if (DTOManager.IzmeniNastavu(nastavaDto))
                    {
                        MessageBox.Show("Uspešno izmenjeni podaci!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške: {ex.Message}");
            }
        }

    }
}
