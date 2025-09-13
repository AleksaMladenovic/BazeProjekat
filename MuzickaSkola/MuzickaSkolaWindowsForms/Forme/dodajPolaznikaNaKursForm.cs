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
    public partial class dodajPolaznikaNaKursForm : Form
    {
        private int _idPolaznika;
        private List<KursPregled> _sviKursevi;
        private List<KursPregled> _prijavljeniKursevi;

        public dodajPolaznikaNaKursForm(int idPolaznika)
        {
            InitializeComponent();
            _idPolaznika = idPolaznika;
        }

        private void dodajPolaznikaNaKursForm_Load(object sender, EventArgs e)
        {
            // Učitaj sve kurseve
            _sviKursevi = DTOManager.VratiSveKurseve();

            // Popuni comboBox
            cmbKursevi.DataSource = _sviKursevi;
            cmbKursevi.DisplayMember = "Naziv";
            cmbKursevi.ValueMember = "Id";

            // Učitaj već prijavljene kurseve za polaznika
            _prijavljeniKursevi = DTOManager.VratiPrijavljeneKurseve(_idPolaznika);
            PopuniPrijavljeneKurseve();
        }

        private void PopuniPrijavljeneKurseve()
        {
            lwPrijavljeniKursevi.Items.Clear();
            foreach (var k in _prijavljeniKursevi)
            {
                var item = new ListViewItem(new string[]
                {
                    k.Id.ToString(),
                    k.Naziv,
                    k.Nivo
                });
                lwPrijavljeniKursevi.Items.Add(item);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbKursevi.SelectedItem == null)
            {
                MessageBox.Show("Izaberite kurs.");
                return;
            }

            var odabraniKurs = (KursPregled)cmbKursevi.SelectedItem;

            
            if (_prijavljeniKursevi.Any(k => k.Id == odabraniKurs.Id))
            {
                MessageBox.Show("Polaznik je već prijavljen na ovaj kurs.");
                return;
            }

         
            DTOManager.DodajPolaznikaNaKurs(_idPolaznika, odabraniKurs.Id);

           
            _prijavljeniKursevi = DTOManager.VratiPrijavljeneKurseve(_idPolaznika);
            PopuniPrijavljeneKurseve();

            MessageBox.Show("Polaznik je uspešno dodat na kurs.");
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

