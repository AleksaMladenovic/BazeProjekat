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
    public partial class RoditeljiForm : Form
    {
        public RoditeljiForm()
        {
            InitializeComponent();
        }
        private void RoditeljiForm_Load(object sender, EventArgs e) { UcitajRoditelje(); }
        private void UcitajRoditelje()
        {
            lvRoditelji.Items.Clear();
            var podaci = DTOManager.VratiSveRoditeljeDetalji(); // vidi DTOManager dole

            foreach (var r in podaci)
            {
                var item = new ListViewItem(new[]
                {
                    r.IdOsobe.ToString(),
                    r.Jmbg ?? "",
                    r.Ime ?? "",
                    r.Prezime ?? "",
                    r.Telefon ?? "",
                    r.Email ?? ""
                });
                lvRoditelji.Items.Add(item);
            }
        }
        private void btnIzmeniRoditelja_Click(object sender, EventArgs e) {
            if (lvRoditelji.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite roditelja za izmenu.");
                return;
            }

            int id = int.Parse(lvRoditelji.SelectedItems[0].SubItems[0].Text);

            using (var f = new IzmeniRoditeljaForm(id))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    UcitajRoditelje(); // osveži
            }
        }
        private void btnObrisiRoditelja_Click(object sender, EventArgs e) { /* obrisi izabrani */ }
    }
}
