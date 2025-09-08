using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MuzickaSkolaWindowsForms.Forme;

namespace MuzickaSkolaWindowsForms
{
    public partial class PocetnaStranica : Form
    {
        public PocetnaStranica()
        {
            InitializeComponent();
        }

        private void cmdPolaznici_Click(object sender, EventArgs e)
        {
            Form polazniciForm = new PolazniciForm();
            polazniciForm.ShowDialog();
        }

        private void cmdNastavnici_Click(object sender, EventArgs e)
        {
            Form nastavniciForm = new NastavniciForm();
            nastavniciForm.ShowDialog();

        }

        private void cmdKursevi_Click(object sender, EventArgs e)
        {
            Form kurseviForm = new KurseviForm();
            kurseviForm.ShowDialog();

        }
    }
}
