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
}
