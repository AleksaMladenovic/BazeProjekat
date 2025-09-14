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
    public partial class IzmeniPolaznika : BaseForm
    {
        private readonly int _idOsobe;
        private readonly string _tip;
        public IzmeniPolaznika()
        {
            InitializeComponent();
        }


        public IzmeniPolaznika(int idOsobe, string tip)
        {
            _idOsobe = idOsobe;
            _tip = tip;
            InitializeComponent();
        }


        private void ClearDynamic() => pnlDynamic.Controls.Clear();

        private void AddField(string labelText, string textBoxName, int rowIndex, int colIndex)
        {
            int rowHeight = 32;
            int y = 8 + rowIndex * rowHeight;
            int labelLeft = (colIndex == 0) ? 10 : 330;
            int boxLeft = (colIndex == 0) ? 130 : 450;

            var lbl = new Label { AutoSize = true, Left = labelLeft, Top = y + 4, Text = labelText };
            var tb = new TextBox { Name = textBoxName, Left = boxLeft, Top = y, Width = 160 };

            if (textBoxName.Equals("tbRoditeljJmbg", StringComparison.OrdinalIgnoreCase))
                tb.MaxLength = 13;

            pnlDynamic.Controls.Add(lbl);
            pnlDynamic.Controls.Add(tb);
        }


        private void IzmeniPolaznikaForm_Load(object sender, EventArgs e)
        {

            bool odrasli = string.Equals(_tip, "Odrasli", StringComparison.OrdinalIgnoreCase);
            rbOdrasli.Checked = odrasli;
            rbDete.Checked = !odrasli;

            if (odrasli)
            {
                ClearDynamic();
                AddField("Zanimanje", "tbZanimanje", 0, 0);
                pnlDynamic.Height = 60;

                var dto = DTOManager.VratiOdraslogPolaznika(_idOsobe);
                tbJMBG.Text = dto.Jmbg;
                tbIme.Text = dto.Ime;
                tbPrezime.Text = dto.Prezime;
                tbAdresa.Text = dto.Adresa;
                tbTelefon.Text = dto.Telefon;
                tbEmail.Text = dto.Email;
                (pnlDynamic.Controls["tbZanimanje"] as TextBox)!.Text = dto.Zanimanje;
            }
            else
            {
                ClearDynamic();

                AddField("JBD", "tbJbd", 0, 0);
                AddField("JMBG roditelja", "tbRoditeljJmbg", 0, 1);
                AddField("Ime roditelja", "tbRoditeljIme", 1, 0);
                AddField("Prezime roditelja", "tbRoditeljPrezime", 1, 1);
                pnlDynamic.Height = 100;

                var dto = DTOManager.VratiDetePolaznika(_idOsobe);

                tbJMBG.Text = dto.Jmbg;
                tbIme.Text = dto.Ime;
                tbPrezime.Text = dto.Prezime;
                tbAdresa.Text = dto.Adresa;
                tbTelefon.Text = dto.Telefon;
                tbEmail.Text = dto.Email;

                (pnlDynamic.Controls["tbJbd"] as TextBox)!.Text = dto.Jbd;

                if (dto.IdRoditelja > 0)
                {
                    try
                    {
                        var r = DTOManager.VratiRoditeljaDetalji(dto.IdRoditelja);

                        (pnlDynamic.Controls["tbRoditeljJmbg"] as TextBox)!.Text = r.Jmbg?.Trim();
                        (pnlDynamic.Controls["tbRoditeljIme"] as TextBox)!.Text = r.Ime?.Trim();
                        (pnlDynamic.Controls["tbRoditeljPrezime"] as TextBox)!.Text = r.Prezime?.Trim();
                    }
                    catch
                    {

                        var imePrez = dto.PunoImeRoditelja?
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        (pnlDynamic.Controls["tbRoditeljIme"] as TextBox)!.Text =
                            (imePrez != null && imePrez.Length > 0) ? imePrez[0] : string.Empty;

                        (pnlDynamic.Controls["tbRoditeljPrezime"] as TextBox)!.Text =
                            (imePrez != null && imePrez.Length > 1) ? string.Join(" ", imePrez.Skip(1)) : string.Empty;


                    }
                }
                else
                {

                    var imePrez = dto.PunoImeRoditelja?
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    (pnlDynamic.Controls["tbRoditeljIme"] as TextBox)!.Text =
                        (imePrez != null && imePrez.Length > 0) ? imePrez[0] : string.Empty;

                    (pnlDynamic.Controls["tbRoditeljPrezime"] as TextBox)!.Text =
                        (imePrez != null && imePrez.Length > 1) ? string.Join(" ", imePrez.Skip(1)) : string.Empty;
                }
            }
        }


        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (rbOdrasli.Checked)
                {
                    var dto = new OdrasliPolaznikBasic
                    {
                        IdOsobe = _idOsobe,
                        Ime = ime,
                        Prezime = prezime,
                        Jmbg = jmbg,
                        Adresa = tbAdresa.Text?.Trim(),
                        Telefon = tbTelefon.Text?.Trim(),
                        Email = tbEmail.Text?.Trim(),
                        Zanimanje = (pnlDynamic.Controls["tbZanimanje"] as TextBox)?.Text?.Trim()
                    };

                    DTOManager.IzmeniOdraslogPolaznika(dto);
                }
                else
                {
                    string jbd = (pnlDynamic.Controls["tbJbd"] as TextBox)?.Text?.Trim();
                    string rJmbg = (pnlDynamic.Controls["tbRoditeljJmbg"] as TextBox)?.Text?.Trim();
                    string rIme = (pnlDynamic.Controls["tbRoditeljIme"] as TextBox)?.Text?.Trim();
                    string rPrez = (pnlDynamic.Controls["tbRoditeljPrezime"] as TextBox)?.Text?.Trim();

                    int idR = 0;
                    if (!string.IsNullOrWhiteSpace(rJmbg))
                    {
                        if (rJmbg.Length != 13 || !rJmbg.All(char.IsDigit))
                        {
                            MessageBox.Show("JMBG roditelja mora imati tačno 13 cifara.");
                            return;
                        }
                        idR = DTOManager.NadjiIliKreirajRoditeljaId(rJmbg, rIme, rPrez);
                    }

                    var dto = new DetePolaznikBasic
                    {
                        IdOsobe = _idOsobe,
                        Ime = ime,
                        Prezime = prezime,
                        Jmbg = jmbg,
                        Adresa = tbAdresa.Text?.Trim(),
                        Telefon = tbTelefon.Text?.Trim(),
                        Email = tbEmail.Text?.Trim(),
                        Jbd = jbd,
                        IdRoditelja = idR
                    };


                    DTOManager.IzmeniDetePolaznika(dto, roditeljJmbg: rJmbg, roditeljIme: rIme, roditeljPrezime: rPrez);
                }

                MessageBox.Show("Izmene su sačuvane.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

