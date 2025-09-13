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
    public partial class DodajIzmeniPrisustvoForm : Form
    {
        private int casId;
        private PrisustvoPregled prisustvoZaIzmenu;
        public DodajIzmeniPrisustvoForm()
        {
            InitializeComponent();
        }
        public DodajIzmeniPrisustvoForm(int casid)
        {
            InitializeComponent();
            this.casId = casid;
            this.prisustvoZaIzmenu = null;
            this.Text = "Dodaj Prisustvo na Čas";
        }

        public DodajIzmeniPrisustvoForm(PrisustvoPregled prisustvo)
        {
            InitializeComponent();
            this.casId = prisustvo.IdCasa;
            this.prisustvoZaIzmenu = prisustvo;
            this.Text = "Izmeni Ocenu za Prisustvo";
        }
        private void DodajIzmeniPrisustvoForm_Load(object sender, EventArgs e)
        {
            if (this.prisustvoZaIzmenu == null)
            {
                cmbPolaznici.Visible = true;
                txtPolaznik.Visible = false;
                this.PopuniPolaznikeComboBox();
            }
            else
            {
                cmbPolaznici.Visible = false;
                txtPolaznik.Visible = true;
                txtPolaznik.Enabled = false;
                txtPolaznik.Text = $"{this.prisustvoZaIzmenu.ImePolaznika} {this.prisustvoZaIzmenu.PrezimePolaznika}";
                this.Text = $"Polaznik: {this.prisustvoZaIzmenu.ImePolaznika} {this.prisustvoZaIzmenu.PrezimePolaznika}";

                numOcena.Value = this.prisustvoZaIzmenu.Ocena;
            }
        }

        private void PopuniPolaznikeComboBox()
        {
            List<PolaznikPregled> polaznici = DTOManager.VratiPolaznikeZaEvidenciju(this.casId);

            if (polaznici.Count == 0)
            {
                MessageBox.Show("Svi polaznici sa kursa su već evidentirani za ovaj čas.");
                cmdSnimi.Enabled = false;
            }

            cmbPolaznici.DataSource = polaznici;
            cmbPolaznici.DisplayMember = "PunoIme";
            cmbPolaznici.ValueMember = "IdOsobe";
        }

        private void cmdSnimi_Click(object sender, EventArgs e)
        {
            
            var dto = new PrisustvoPregled();
            dto.IdCasa = this.casId;
            dto.Ocena = (int)numOcena.Value;

            if (this.prisustvoZaIzmenu == null) // DODAVANJE
            {
                if (cmbPolaznici.SelectedItem == null)
                {
                    MessageBox.Show("Morate izabrati polaznika.");
                    return;
                }
                dto.IdPolaznika = (int)cmbPolaznici.SelectedValue;

                try
                {
                    DTOManager.DodajPrisustvo(dto);
                    MessageBox.Show("Uspešno evidentirano prisustvo!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else 
            {
                dto.IdPolaznika = this.prisustvoZaIzmenu.IdPolaznika;

                try
                {
                    DTOManager.IzmeniPrisustvo(dto); 
                    MessageBox.Show("Uspešno izmenjena ocena!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
