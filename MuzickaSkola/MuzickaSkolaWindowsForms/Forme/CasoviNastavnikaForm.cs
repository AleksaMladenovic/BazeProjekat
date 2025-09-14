using NHibernate.Linq.ReWriters;
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
    public partial class CasoviNastavnikaForm : BaseForm
    {
        public CasoviNastavnikaForm()
        {
            InitializeComponent();
        }
        private int idNastavnika;

        public CasoviNastavnikaForm(int nastavnikId)
        {
            InitializeComponent();
            this.idNastavnika = nastavnikId;
        }

        private void CasoviNastavnikaForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            this.listViewCasovi.Items.Clear();
            List<CasPregled> casovi = DTOManager.VratiSveCasoveNastavnika(this.idNastavnika);

            foreach (CasPregled c in casovi)
            {
                ListViewItem item = new ListViewItem(new string[] { c.Termin.ToString("dd.MM.yyyy HH:mm"), c.Tema, c.Ucionica });
                this.listViewCasovi.Items.Add(item);
            }
            this.listViewCasovi.Refresh();
        }
        #region dizajn
        private void listViewCasovi_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.MidnightBlue), e.Bounds);

            // Iscrtaj tekst hedera belom bojom
            TextRenderer.DrawText(e.Graphics, e.Header.Text, new Font("Segoe UI", 10, FontStyle.Bold), e.Bounds, Color.White);
        }

        private void listViewCasovi_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion
    }
}
