using FluentNHibernate.Conventions;
using FluentNHibernate.Utils;
using MuzickaSkolaWindowsForms.Entiteti;
using MuzickaSkolaWindowsForms.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
            OnemoguciDugmiceZaNastavu();
            OnemoguciDugmiceZaCasove();
            PopuniListuNastave();
        }
        private void OnemoguciDugmiceZaNastavu()
        {
            cmdDodajCas.Enabled = false;
            cmdIzmeniNastavu.Enabled = false;
        }

        private void OmoguciDugmiceZaNastavu()
        {
            cmdDodajCas.Enabled = true;
            cmdIzmeniNastavu.Enabled = true;
        }

        private void OmoguciDugmiceZaCasove()
        {
            if (listViewNastava.SelectedItems.Count > 0 && listViewCasovi.SelectedItems.Count > 0)
            {
                cmdIzmeniCas.Enabled = true;
                cmdObrisiCas.Enabled = true;
            }
        }

        private void OnemoguciDugmiceZaCasove()
        {
            cmdIzmeniCas.Enabled = false;
            cmdObrisiCas.Enabled = false;
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
                FGrupna = SelektovanaNastava.TipNastave == "Grupna",
                IdKursa = kurs.Id,
            };
            var form = new DodajIzmeniNastavuForm(nastavaDto);
            form.ShowDialog();
            this.PopuniListuNastave();
            this.OnemoguciDugmiceZaNastavu();
            this.OnemoguciDugmiceZaCasove();
        }

        private void cmdObrisiNastavu_Click(object sender, EventArgs e)
        {
            var SelektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;

            string poruka = "Da li zelite da obrisete izabrani nastavni blok?";
            if (DTOManager.VratiSveCasoveZaNastavu(SelektovanaNastava.Id).IsNotEmpty())
                poruka = "Izabrna nastava ima časove, da li ste sigurni da želite da je obrišete?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                if (DTOManager.ObrisiNastavu(SelektovanaNastava.Id))
                {
                    MessageBox.Show("Uspešno obrisan nastavni blok!");
                    this.PopuniListuNastave();
                    this.PopuniListuCasova();
                }
            }
        }

        private void listViewNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopuniListuCasova();
        }

        private void PopuniListuCasova()
        {
            if (listViewNastava.SelectedItems.Count == 0)
            {
                listViewCasovi.Items.Clear();
                lblInfoNastava.Text = "Izaberite nastavni blok da vidite casove.";

                OnemoguciDugmiceZaNastavu();
                OnemoguciDugmiceZaCasove();
                return;
            }

            var selektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;

            lblInfoNastava.Text = $"Časovi za blok od {selektovanaNastava.DatumOdString}";

            List<CasPregled> casovi = DTOManager.VratiSveCasoveZaNastavu(selektovanaNastava.Id);

            this.listViewCasovi.Items.Clear();

            foreach (var cas in casovi)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    cas.Id.ToString(),
                    cas.Termin.ToString("dd.MM.yyyy HH:mm"),
                    cas.Tema,
                    cas.ImeNastavnika,
                    cas.Ucionica,
                });
                item.Tag = cas;
                listViewCasovi.Items.Add(item);
            }
            this.listViewCasovi.Refresh();
            OmoguciDugmiceZaNastavu();
        }
        private void cmdIzmeniCas_Click(object sender, EventArgs e)
        {
            var selektovanCas = (CasPregled)listViewCasovi.SelectedItems[0].Tag;
            var selektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;

            var casDto = new CasBasic() { Id = selektovanCas.Id, NastavaId = selektovanaNastava.Id, NastavnikId = selektovanCas.IdNastavnika, Tema = selektovanCas.Tema, Termin = selektovanCas.Termin, Ucionica = selektovanCas.Ucionica, Lokacija = selektovanCas.Lokacija };
            var form = new DodajIzmeniCasForm(casDto);
            form.ShowDialog();
            this.PopuniListuCasova();
            OnemoguciDugmiceZaCasove();
        }

        private void cmdDodajCas_Click(object sender, EventArgs e)
        {
            var selektovanaNastava = (NastavaPregled)listViewNastava.SelectedItems[0].Tag;
            var PostojeUcioniceZaKurs = DTOManager.DaLiPostojeUcioniceZaKurs(this.kurs.Id);
            if (!PostojeUcioniceZaKurs)
            {
                MessageBox.Show($"Ne postoje definisane učionice za kurs!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new DodajIzmeniCasForm(selektovanaNastava.Id);
            form.ShowDialog();
            this.PopuniListuCasova();
            OnemoguciDugmiceZaCasove();
        }

        private void listViewCasovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCasovi.SelectedItems.Count > 0)
            {
                OmoguciDugmiceZaCasove();
            }
            else
            {
                OnemoguciDugmiceZaCasove();
            }
        }

        private void cmdObrisiCas_Click(object sender, EventArgs e)
        {
            var selektovanCas = (CasPregled)listViewCasovi.SelectedItems[0].Tag;
            string poruka = "Da li zelite da obrišete izabrani čas?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                if (DTOManager.ObrisiCas(selektovanCas.Id))
                {
                    MessageBox.Show("Uspešno obrisan čas!");
                    this.PopuniListuNastave();
                    this.PopuniListuCasova();
                }
            }
        }
    }
}
