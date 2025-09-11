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
    public partial class DetaljiNastavnikForm : Form
    {
        public DetaljiNastavnikForm()
        {
            InitializeComponent();
        }

        private NastavnikPregled nastavnik;

        public DetaljiNastavnikForm(NastavnikPregled n)
        {
            InitializeComponent();
            this.nastavnik = n;
            this.Text = $"Detalji za: {n.Ime} {n.Prezime}"; // Postavi naslov prozora
        }

        // U DetaljiNastavnikaForm.cs
        private void DetaljiNastavnikaForm_Load(object sender, EventArgs e)
        {
            lblAdresa.Text = $"Adresa: {nastavnik.Adresa ?? "N/A"}";
            lblEmail.Text = $"Email: {nastavnik.Email ?? "N/A"}";
            lblTelefon.Text = $"Telefon: {nastavnik.Telefon ?? "N/A"}";
            lblZaposlenje.Text = $"Zaposlenje: {nastavnik.TipZaposlenja} od {nastavnik.DatumZaposlenja:dd.MM.yyyy}";

            if (nastavnik.TipZaposlenja == "Honorarac")
            {
                lblDetalji.Text = $"Ugovor: {nastavnik.BrojUgovora} ({nastavnik.TrajanjeUgovora}), {nastavnik.BrojCasova} časova";
            }
            else
            {
                lblDetalji.Text = $"Radno vreme: {nastavnik.RadnoVreme}";
            }
        }
    }
}
