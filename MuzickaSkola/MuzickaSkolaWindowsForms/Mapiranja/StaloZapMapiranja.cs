using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class StaloZapMapiranja : ClassMap<StalnoZap>
    {
        StaloZapMapiranja()
        {
            Table("STALNO_ZAP");
            Map(p => p.Jmbg, "JMBG");
            Map(p => p.RadnoVreme, "RADNO_VREME");
        }
    }
}
