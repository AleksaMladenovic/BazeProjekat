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
    public partial class PocetnaStranica : BaseForm
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
            Form kurseviForm = new MojDeoForm();
            kurseviForm.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void cmdPolaznici_MouseEnter(object sender, EventArgs e)
        {
            
        }
        private void cmdPolaznici_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void cmdPolaznici_Leave(object sender, EventArgs e)
        {

        }

    }
}
