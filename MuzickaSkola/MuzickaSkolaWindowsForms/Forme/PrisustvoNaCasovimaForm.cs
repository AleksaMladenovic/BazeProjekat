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
    public partial class PrisustvoNaCasovimaForm : BaseForm
    {
        private readonly int _idOsobe;
        private readonly string _punoIme;

        public PrisustvoNaCasovimaForm(int idOsobe, string punoIme)
        {
            _idOsobe = idOsobe;
            _punoIme = punoIme ?? "-";
            InitializeComponent();
        }
        public PrisustvoNaCasovimaForm()
        {
            InitializeComponent();
        }

        private void PrisustvoNaCasovimaForm_Load(object sender, EventArgs e)
        {
            lblPolaznikValue.Text = $"{_punoIme} (ID: {_idOsobe})";

            lvPrisustvo.Columns.Clear();
            lvPrisustvo.Columns.Add("ID časa", 90);
            lvPrisustvo.Columns.Add("Termin", 180);
            lvPrisustvo.Columns.Add("Tema", 360);
            lvPrisustvo.Columns.Add("Ocena", 80);

            try
            {
                var lista = DTOManager.VratiPrisustva(_idOsobe);
                lvPrisustvo.BeginUpdate();
                lvPrisustvo.Items.Clear();

                foreach (var p in lista)
                {
                    var item = new ListViewItem(new[]
                    {
                        p.IdCasa.ToString(),
                        p.Termin.HasValue ? p.Termin.Value.ToString("dd.MM.yyyy HH:mm") : "",
                        p.Tema ?? "",
                        p.Ocena.ToString()
                    });
                    lvPrisustvo.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lvPrisustvo.EndUpdate();
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e) => this.Close();

        private void gbInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}

