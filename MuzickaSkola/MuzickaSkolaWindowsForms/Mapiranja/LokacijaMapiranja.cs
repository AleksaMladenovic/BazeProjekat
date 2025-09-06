using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class LokacijaMapiranja:ClassMap<Lokacija>
    {
        LokacijaMapiranja()
        {
            Table("LOKACIJA");

            Map(p => p.Adresa, "ADRESA");
            Map(p => p.RadnoVreme, "RADNO_VREME");
        }
    }
}
