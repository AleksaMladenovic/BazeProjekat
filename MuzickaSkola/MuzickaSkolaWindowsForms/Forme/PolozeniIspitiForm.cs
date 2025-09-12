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
    public partial class PolozeniIspitiForm : Form
    {
        private readonly int _idOsobe;
        private readonly string _punoIme;

        public PolozeniIspitiForm(int idOsobe, string punoIme)
        {
            _idOsobe = idOsobe;
            _punoIme = punoIme ?? "-";
            InitializeComponent();
        }
        public PolozeniIspitiForm()
        {
            InitializeComponent();
        }
        private void PolozeniIspitiForm_Load(object sender, EventArgs e)
        {
            lblPolaznikValue.Text = $"{_punoIme} (ID: {_idOsobe})";

            lvIspiti.Columns.Clear();
            lvIspiti.Columns.Add("ID kursa", 90);
            lvIspiti.Columns.Add("Naziv kursa", 300);
            lvIspiti.Columns.Add("Datum", 120);
            lvIspiti.Columns.Add("Ocena", 80);
            lvIspiti.Columns.Add("Sertifikat", 90);

            try
            {
                var lista = DTOManager.VratiPolozeneIspite(_idOsobe);
                lvIspiti.BeginUpdate();
                lvIspiti.Items.Clear();

                foreach (var i in lista)
                {
                    var item = new ListViewItem(new[]
                    {
                        i.IdKursa.ToString(),
                        i.NazivKursa ?? "",
                        i.Datum.ToString("dd.MM.yyyy"),
                        i.Ocena?.ToString() ?? "-",
                        (i.Sertifikat == true) ? "DA" : "NE"
                    });
                    lvIspiti.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lvIspiti.EndUpdate();
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e) => this.Close();

        private void btnDodajIspit_Click(object sender, EventArgs e)
        {
            DodajPolozeniIspitForm dodajFormu = new DodajPolozeniIspitForm(_idOsobe);
            dodajFormu.ShowDialog();
            try
            {
                var lista = DTOManager.VratiPolozeneIspite(_idOsobe);
                lvIspiti.BeginUpdate();
                lvIspiti.Items.Clear();

                foreach (var i in lista)
                {
                    var item = new ListViewItem(new[]
                    {
                        i.IdKursa.ToString(),
                        i.NazivKursa ?? "",
                        i.Datum.ToString("dd.MM.yyyy"),
                        i.Ocena?.ToString() ?? "-",
                        (i.Sertifikat == true) ? "DA" : "NE"
                    });
                    lvIspiti.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lvIspiti.EndUpdate();
            }
        }
    }
}

