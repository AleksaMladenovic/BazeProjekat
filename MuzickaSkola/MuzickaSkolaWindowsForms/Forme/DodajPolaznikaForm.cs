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

    public partial class DodajPolaznikaForm : BaseForm
    {
       
        public DodajPolaznikaForm()
        {
            InitializeComponent();
        }
        private void DodajPolaznikaForm_Load(object sender, EventArgs e)
        {
          
            
            rbOdrasli.CheckedChanged += rbOdrasli_CheckedChanged;
            rbDete.CheckedChanged += rbDete_CheckedChanged;

            rbOdrasli.Checked = true; 
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Zajednička validacija
                string jmbg = tbJMBG.Text?.Trim() ?? "";
                string ime = tbIme.Text?.Trim() ?? "";
                string prezime = tbPrezime.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime))
                {
                    MessageBox.Show("Ime i Prezime su obavezni."); return;
                }
                if (string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13 || !jmbg.All(char.IsDigit))
                {
                    MessageBox.Show("JMBG mora imati tačno 13 cifara."); return;
                }

                // 2) Grananje po tipu
                if (rbOdrasli.Checked)
                {
                    var dto = new OdrasliPolaznikBasic
                    {
                        Ime = ime,
                        Prezime = prezime,
                        Jmbg = jmbg,
                        Adresa = tbAdresa.Text?.Trim(),
                        Telefon = tbTelefon.Text?.Trim(),
                        Email = tbEmail.Text?.Trim(),
                        Zanimanje = this.Controls.Find("tbZanimanje", true).FirstOrDefault() is TextBox tbZ ? tbZ.Text.Trim() : null
                    };

                    DTOManager.DodajOdraslogPolaznika(dto);
                    MessageBox.Show("Odrasli polaznik dodat.");
                }
                else
                {
                    string jbd = GetTb("tbJbd");
                    string rIme = GetTb("tbRoditeljIme");
                    string rPrez = GetTb("tbRoditeljPrezime");
                    string rJmbg = GetTb("tbRoditeljJmbg");

                    int idRoditelja = 0;
                    if (!string.IsNullOrWhiteSpace(rJmbg))
                    {
                        if (rJmbg.Length != 13 || !rJmbg.All(char.IsDigit))
                        {
                            MessageBox.Show("JMBG roditelja mora imati tačno 13 cifara.");
                            return;
                        }
                        idRoditelja = DTOManager.NadjiIliKreirajRoditeljaId(rJmbg, rIme, rPrez);
                    }

                    var dto = new DetePolaznikBasic
                    {
                        Ime = ime,
                        Prezime = prezime,
                        Jmbg = jmbg,
                        Adresa = tbAdresa.Text?.Trim(),
                        Telefon = tbTelefon.Text?.Trim(),
                        Email = tbEmail.Text?.Trim(),
                        Jbd = jbd,
                        IdRoditelja = idRoditelja // 0 ako ništa nije uneseno
                    };

                    DTOManager.DodajDetePolaznika(dto);
                    MessageBox.Show("Dete polaznik dodat.");
                }

                OcistiPolja();
                this.DialogResult = DialogResult.OK; this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OcistiPolja()
        {
            tbJMBG.Clear();
            tbIme.Clear();
            tbPrezime.Clear();
            tbAdresa.Clear();
            tbTelefon.Clear();
            tbEmail.Clear();
            (this.Controls.Find("tbRoditeljIme", true).FirstOrDefault() as TextBox)?.Clear();
            (this.Controls.Find("tbRoditeljPrezime", true).FirstOrDefault() as TextBox)?.Clear();
            (this.Controls.Find("tbRoditeljJmbg", true).FirstOrDefault() as TextBox)?.Clear();
            var tbZ = this.Controls.Find("tbZanimanje", true).FirstOrDefault() as TextBox;
            tbZ?.Clear();

            var tbJ = this.Controls.Find("tbJbd", true).FirstOrDefault() as TextBox;
            tbJ?.Clear();

            var cb = this.Controls.Find("cbRoditelj", true).FirstOrDefault() as ComboBox;
            if (cb != null && cb.Items.Count > 0) cb.SelectedIndex = 0;

            rbOdrasli.Checked = true;
        }

        private void rbOdrasli_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbOdrasli.Checked) return;

            ClearDynamic();
            AddField("Zanimanje", "tbZanimanje", 0,0);
        }
        private string GetTb(string name) =>
         (pnlDynamic.Controls.Find(name, true).FirstOrDefault() as TextBox)?.Text?.Trim();
        private void rbDete_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbDete.Checked) return;

            ClearDynamic();
            AddField("JBD", "tbJbd", 0,0);
            AddField("Ime roditelja", "tbRoditeljIme", 0,1);
            AddField("Prezime rod.", "tbRoditeljPrezime", 1,0);
            AddField("JMBG roditelja", "tbRoditeljJmbg", 1,1);
        }
        private void ClearDynamic()
        {
            pnlDynamic.Controls.Clear();
        }

        private void AddField(string labelText, string textBoxName, int rowIndex, int colIndex)
        {
            // layout konstante
            int rowHeight = 32;
            int y = 8 + rowIndex * rowHeight;

            // kolone: 0 (levo), 1 (desno)
            int labelLeft = (colIndex == 0) ? 10 : 320;
            int boxLeft = (colIndex == 0) ? 130 : 440;

            var lbl = new Label
            {
                AutoSize = true,
                Left = labelLeft,
                Top = y + 4,
                Text = labelText
            };

            var tb = new TextBox
            {
                Name = textBoxName,
                Left = boxLeft,
                Top = y,
                Width = 160
            };

            // praktično: JMBG polja ograniči na 13 cifara
            if (textBoxName.Equals("tbRoditeljJmbg", StringComparison.OrdinalIgnoreCase))
                tb.MaxLength = 13;

            pnlDynamic.Controls.Add(lbl);
            pnlDynamic.Controls.Add(tb);
        }
    }
}
