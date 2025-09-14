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
    public partial class IzmeniRoditeljaForm : BaseForm
    {
        private readonly int _idOsobe;

        public IzmeniRoditeljaForm(int idOsobe)
        {
            _idOsobe = idOsobe;
            InitializeComponent();
        }
        public IzmeniRoditeljaForm()
        {
            InitializeComponent();
        }

        private void IzmeniRoditeljaForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dto = DTOManager.VratiRoditeljaDetalji(_idOsobe); // koristi metodu koju smo već pisali
                tbJmbg.Text = dto.Jmbg ?? "";
                tbIme.Text = dto.Ime ?? "";
                tbPrezime.Text = dto.Prezime ?? "";
                tbTelefon.Text = dto.Telefon ?? "";
                tbEmail.Text = dto.Email ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                var j = (tbJmbg.Text ?? "").Trim();
                if (!string.IsNullOrEmpty(j) && (j.Length != 13 || !j.All(char.IsDigit)))
                {
                    MessageBox.Show("JMBG mora imati tačno 13 cifara.");
                    return;
                }

                var updated = new RoditeljListItem
                {
                    IdOsobe = _idOsobe,
                    Jmbg = j,
                    Ime = tbIme.Text?.Trim(),
                    Prezime = tbPrezime.Text?.Trim(),
                    Telefon = tbTelefon.Text?.Trim(),
                    Email = tbEmail.Text?.Trim()
                };

                DTOManager.IzmeniRoditelja(updated); 
                MessageBox.Show("Izmene su sačuvane.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e) => this.Close();
    }
}

