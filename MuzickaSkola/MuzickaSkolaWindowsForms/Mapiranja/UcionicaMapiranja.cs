using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class UcionicaMapiranja:ClassMap<Ucionica>
    {
        UcionicaMapiranja()
        {
            Table("UCIONICA");

            Map(p => p.Naziv, "NAZIV");
            Map(p => p.Adresa, "ADRESA");
            Map(p => p.Opremljenost, "OPREMLJENOST");
            Map(p => p.Kapacitet, "KAPACITET");
        }
    }
}
