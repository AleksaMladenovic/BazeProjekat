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
    public partial class MojDeoForm : BaseForm
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

        private void cmdPrikaziSveKurseve_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Kursevi.Visible = true;
        }

        private void cmdPrikaziSveKurseve_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Kursevi.Visible = false;
        }

        private void cmdPrikaziSveLokacije_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Lokacije.Visible = true;
        }

        private void cmdPrikaziSveLokacije_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Lokacije.Visible = false;
        }
    }
}
