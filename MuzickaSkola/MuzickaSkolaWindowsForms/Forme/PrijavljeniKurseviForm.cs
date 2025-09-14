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
    public partial class PrijavljeniKurseviForm : BaseForm
    {
        private readonly int _idOsobe;
        private readonly string _punoIme;
        public PrijavljeniKurseviForm()
        {
            InitializeComponent();
        }


        public PrijavljeniKurseviForm(int idOsobe, string punoIme)
        {
            _idOsobe = idOsobe;
            _punoIme = punoIme ?? "-";
            InitializeComponent();
        }

        private void PrijavljeniKurseviForm_Load(object sender, EventArgs e)
        {
            lblPolaznikValue.Text = $"{_punoIme} (ID: {_idOsobe})";

            lvKursevi.Columns.Clear();
            lvKursevi.Columns.Add("ID kursa", 90);
            lvKursevi.Columns.Add("Naziv", 380);
            lvKursevi.Columns.Add("Nivo", 100);

            try
            {
                var lista = DTOManager.VratiPrijavljeneKurseve(_idOsobe);
                lvKursevi.BeginUpdate();
                lvKursevi.Items.Clear();

                foreach (var k in lista)
                {
                    var nivo = k.Nivo;
                    var item = new ListViewItem(new[]
                    {
                        k.Id.ToString(),
                        k.Naziv ?? "",
                        nivo
                    });
                    lvKursevi.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lvKursevi.EndUpdate();
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e) => this.Close();

        private void btnDodajNaKurs_Click(object sender, EventArgs e)
        {


            var forma = new dodajPolaznikaNaKursForm(_idOsobe);
            forma.ShowDialog();
            try
            {
                var lista = DTOManager.VratiPrijavljeneKurseve(_idOsobe);
                lvKursevi.BeginUpdate();
                lvKursevi.Items.Clear();

                foreach (var k in lista)
                {
                    var nivo = k.Nivo;
                    var item = new ListViewItem(new[]
                    {
                        k.Id.ToString(),
                        k.Naziv ?? "",
                        nivo
                    });
                    lvKursevi.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lvKursevi.EndUpdate();
            }
        }
    }
}

