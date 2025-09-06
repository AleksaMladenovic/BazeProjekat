using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class OdvijaNaMapiranja:ClassMap<OdvijaNa>
    {
        OdvijaNaMapiranja()
        {
            Table("ODVIJA_NA");

            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.Adresa, "ADRESA");
        }
    }
}
