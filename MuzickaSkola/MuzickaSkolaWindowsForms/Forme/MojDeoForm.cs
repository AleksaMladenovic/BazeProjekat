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
    public partial class MojDeoForm : Form
    {
        public MojDeoForm()
        {
            InitializeComponent();
        }

        private void cmdPrikaziSveLokacije_Click(object sender, EventArgs e)
        {
            LokacijeForm lokacijeForm = new LokacijeForm();
            lokacijeForm.Show();
        }

        private void cmdPrikaziSveKurseve_Click(object sender, EventArgs e)
        {
            KurseviForm forma = new KurseviForm();
            forma.Show();
        }
    }
}
