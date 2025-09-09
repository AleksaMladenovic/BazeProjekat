using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
    #region Lokacija
    public class LokacijaPregled {
        public string Adresa { get; set; }
        public int Kapacitet { get; set; }
        public string RadnoVreme { get; set; }

        public LokacijaPregled()
        {

        }
        public LokacijaPregled(string adresa, int kapacitet, string radnoVreme)
        {
            Adresa = adresa;
            Kapacitet = kapacitet;
            RadnoVreme = radnoVreme;
        }
    }

    public class LokacijaBasic {
        public string Adresa { get; set; }
        public string RadnoVreme { get; set; }

        public LokacijaBasic() { }

        public LokacijaBasic(string adresa, string radnoVreme)
        {
            Adresa = adresa;
            RadnoVreme = radnoVreme;
        }
    }

    #endregion

    #region Ucionica

    public class UcionicaPregled() {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public string Opremljenost{ get; set; }
        public string AdresaLokacije{ get; set; }
    }

    public class UcionicaBasic() 
    {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public string Opremljenost { get; set; }
        public string AdresaLokacije { get; set; }
    }

    #endregion

    #region Kurs

    public class KursPregled
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string ImeNastavnika { get; set; }
        public string TipKursa { get; set; }
    }

    public class KursBasic
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string ImeNastavnika { get; set; }
        public string TipKursa { get; set; }

        public string? Instrument { get; set; }
        public string? GrupaInstrumenata { get; set; }
        public string? NazivPredmeta { get; set; }
    }
    #endregion Kurs
}
