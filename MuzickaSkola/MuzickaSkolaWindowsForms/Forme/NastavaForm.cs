using FluentNHibernate.Utils;
using MuzickaSkolaWindowsForms.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    public partial class NastavaForm : Form
    {
        private KursPregled kurs;
        public NastavaForm()
        {
            InitializeComponent();
        }
        public NastavaForm(KursPregled k)
        {
            InitializeComponent();
            this.kurs = k;
        }

        private void NastavaForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Nastava za kurs: {kurs.Naziv}";
            lblInfoKursa.Text = $"Prikaz nastavnih blokova za kurs: {kurs.Naziv} (ID: {kurs.Id})";
            OnemoguciDugmice();
            PopuniListuNastave();
        }
        private void OnemoguciDugmice()
        {
            cmdDodajCas.Enabled = false;
            cmdIzmeniCas.Enabled = false;
            cmdObrisiCas.Enabled = false;
        }

        private void OmoguciDugmice()
        {
            cmdDodajCas.Enabled = true;
            cmdIzmeniCas.Enabled = true;
            cmdObrisiCas.Enabled = true;
        }

        private void PopuniListuNastave()
        {
            this.listViewNastava.Items.Clear();
            List<NastavaPregled> podaci = DTOManager.VratiSvuNastavuZaKurs(this.kurs.Id, this.kurs.TipKursa);
            foreach (var nastava in podaci)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    nastava.Id.ToString(),
                    nastava.DatumOdString,
                    nastava.DatumDoString,
                    nastava.TipNastave
                });
                item.Tag = nastava;
                listViewNastava.Items.Add(item);
            }
        }

        private void cmdDodajNastavu_Click(object sender, EventArgs e)
        {
            var form = new DodajIzmeniNastavuForm(kurs.Id);
            form.ShowDialog();
            this.PopuniListuNastave();
        }

        private void cmdIzmeniNastavu_Click(object sender, EventArgs e)
        {
            var SelektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;
            NastavaBasic nastavaDto = new NastavaBasic()
            {
                Id = SelektovanaNastava.Id,
                DatumOd = SelektovanaNastava.DatumOd,
                DatumDo = SelektovanaNastava.DatumDo,
                FIndividualna = SelektovanaNastava.TipNastave == "Individualna",
                FGrupna = SelektovanaNastava.TipNastave =="Grupna",
                IdKursa = kurs.Id,
            };
            var form = new DodajIzmeniNastavuForm(nastavaDto);
            form.ShowDialog();
            this.PopuniListuNastave();
        }

        private void cmdObrisiNastavu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da obrisete izabrani nastavni blok?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                var SelektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;
                if (DTOManager.ObrisiNastavu(SelektovanaNastava.Id))
                {
                    MessageBox.Show("Uspešno obrisan nastavni blok!");
                }
            }
        }
    }
}
