using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MuzickaSkolaWindowsForms.Forme
{
    public partial class DodajPolozeniIspitForm : BaseForm
    {
        private readonly int _idPolaznika;
        private List<int> _polozeniIds;
        public DodajPolozeniIspitForm(int idPolaznika, List<int> polozeniIds)
        {
            InitializeComponent();
            _idPolaznika = idPolaznika;
            _polozeniIds = polozeniIds;
        }

        private void DodajPolozeniIspitForm_Load(object sender, EventArgs e)
        {
            UcitajKurseve();
            UcitajKomisije();
        }

        private void UcitajKurseve()
        {
            try
            {
                var kursevi = DTOManager.VratiPrijavljeneKurseve(_idPolaznika);

                // izbacujemo već položene
                var filtrirani = kursevi
                    .Where(k => !_polozeniIds.Contains(k.Id))
                    .ToList();

                cmbKursevi.DataSource = filtrirani;
                cmbKursevi.DisplayMember = "Naziv";
                cmbKursevi.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom učitavanja kurseva: {ex.Message}");
            }
        }

        private void UcitajKomisije()
        {
            try
            {
                var komisije = DTOManager.VratiSveKomisije();
                cmbKomisije.DataSource = komisije;
                cmbKomisije.DisplayMember = "Id"; 
                cmbKomisije.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom učitavanja komisija: {ex.Message}");
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbKursevi.SelectedItem == null || cmbKomisije.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati kurs i komisiju.");
                return;
            }

            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                var polaznik = s.Load<Polaznik>(_idPolaznika);
                var kurs = s.Load<Kurs>((int)cmbKursevi.SelectedValue);
                var komisija = s.Load<Komisija>((int)cmbKomisije.SelectedValue);

                var noviIspit = new ZavrsniIspit
                {
                    PolazePolaznik = polaznik,
                    KursKojiSePolaze = kurs,
                    OcenjujeKomisija = komisija,
                    Datum = dtpDatum.Value,
                    Ocena = (int)numOcena.Value,
                    Sertifikat = chkSertifikat.Checked
                };

                s.Save(noviIspit);
                s.Transaction.Commit();

                MessageBox.Show("Uspešno ste dodali novi položeni ispit.");
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                if (s != null && s.Transaction.IsActive)
                {
                    s.Transaction.Rollback();
                }
                MessageBox.Show($"Došlo je do greške prilikom dodavanja ispita: {ex.Message}");
            }
            finally
            {
                s?.Close();
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

