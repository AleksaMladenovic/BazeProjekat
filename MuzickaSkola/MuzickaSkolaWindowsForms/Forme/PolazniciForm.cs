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
    public partial class PolazniciForm : Form
    {
        public PolazniciForm()
        {
            InitializeComponent();
        }
        private void PolazniciForm_Load(object sender, EventArgs e)
        {
            lwSviPolaznici.View = View.Details;
            lwSviPolaznici.FullRowSelect = true;
            lwSviPolaznici.GridLines = true;
            lwSviPolaznici.HideSelection = false;
            lwSviPolaznici.Columns.Clear();
            lwSviPolaznici.Columns.Add("ID", 60);
            lwSviPolaznici.Columns.Add("JMBG", 120);
            lwSviPolaznici.Columns.Add("Ime", 120);
            lwSviPolaznici.Columns.Add("Prezime", 120);
            lwSviPolaznici.Columns.Add("Tip", 80);

            popuniPodacima();
        }
        public void popuniPodacima()
        {
            lwSviPolaznici.Items.Clear();
            List<PolaznikPregled> podaci = DTOManager.VratiSvePolaznike();

            foreach (PolaznikPregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.IdOsobe.ToString(), p.Jmbg, p.Ime, p.Prezime, p.TipPolaznika });
                lwSviPolaznici.Items.Add(item);

            }
            lwSviPolaznici.Refresh();
        }

        private void btnDodajPolaznika_Click(object sender, EventArgs e)
        {
            Form dodajPolaznikaForm = new DodajPolaznikaForm();
            dodajPolaznikaForm.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiPolaznika_Click(object sender, EventArgs e)
        {
            if (lwSviPolaznici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite polaznika kog želite da obrišete!");
                return;
            }

            int idOsobe = int.Parse(lwSviPolaznici.SelectedItems[0].SubItems[0].Text);

            var poruka = "Da li želite da obrišete izabranog polaznika?";
            var title = "Potvrda brisanja";
            var result = MessageBox.Show(poruka, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiPolaznika(idOsobe, obrisiISamuOsobu: false);

                MessageBox.Show("Brisanje je uspešno obavljeno.");
                popuniPodacima();
            }
        }

        private void btnIzmeniPol_Click(object sender, EventArgs e)
        {
            if (lwSviPolaznici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite polaznika za izmenu.");
                return;
            }

            int idOsobe = int.Parse(lwSviPolaznici.SelectedItems[0].SubItems[0].Text);
            string tip = lwSviPolaznici.SelectedItems[0].SubItems[4].Text;

            using (var f = new IzmeniPolaznika(idOsobe, tip))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    popuniPodacima();
            }
        }

        private void btnPodaciRoditelj_Click(object sender, EventArgs e)
        {
            Form roditeljiForm = new RoditeljiForm();
            roditeljiForm.ShowDialog();
        }

        private void btnPolozeniIspiti_Click(object sender, EventArgs e)
        {
            if (lwSviPolaznici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite polaznika.");
                return;
            }

            var li = lwSviPolaznici.SelectedItems[0];
            if (!int.TryParse(li.SubItems[0].Text, out int idOsobe))
            {
                MessageBox.Show("Nevažeći ID polaznika.");
                return;
            }
            string punoIme = $"{li.SubItems[2].Text} {li.SubItems[3].Text}";

            using (var f = new PolozeniIspitiForm(idOsobe, punoIme))
                f.ShowDialog(this);
        }

        private void btnPrisustvo_Click(object sender, EventArgs e)
        {
            if (lwSviPolaznici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite polaznika.");
                return;
            }

            var li = lwSviPolaznici.SelectedItems[0];
            if (!int.TryParse(li.SubItems[0].Text, out int idOsobe))
            {
                MessageBox.Show("Nevažeći ID polaznika.");
                return;
            }
            string punoIme = $"{li.SubItems[2].Text} {li.SubItems[3].Text}";

            using (var f = new PrisustvoNaCasovimaForm(idOsobe, punoIme))
                f.ShowDialog(this);
        }

        private void btnPrijavljeniKursevi_Click(object sender, EventArgs e)
        {
            if (lwSviPolaznici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite polaznika.");
                return;
            }

            var li = lwSviPolaznici.SelectedItems[0];
            if (!int.TryParse(li.SubItems[0].Text, out int idOsobe))
            {
                MessageBox.Show("Nevažeći ID polaznika.");
                return;
            }
            string punoIme = $"{li.SubItems[2].Text} {li.SubItems[3].Text}";

            using (var f = new PrijavljeniKurseviForm(idOsobe, punoIme))
                f.ShowDialog(this);
        }
       

        private string GetPunoIme(string ime, string prezime) => $"{ime} {prezime}";
    }
}
