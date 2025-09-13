using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzickaSkolaWindowsForms
{
    public partial class KurseviNastavnikForm : Form
    {
        public KurseviNastavnikForm()
        {
            InitializeComponent();
        }

        private int idNastavnika;

        public KurseviNastavnikForm(int nastavnikId)
        {
            InitializeComponent();
            this.idNastavnika = nastavnikId;
        }

        private void KurseviNastavnikaForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            this.listViewKursevi.Items.Clear();
            List<KursPregled> kursevi = DTOManager.VratiSveKurseveNastavnika(this.idNastavnika);

            foreach (KursPregled k in kursevi)
            {
                ListViewItem item = new ListViewItem(new string[] { k.Naziv, k.Nivo,k.TipKursa });
                this.listViewKursevi.Items.Add(item);
            }
            this.listViewKursevi.Refresh();
        }
    }
}
