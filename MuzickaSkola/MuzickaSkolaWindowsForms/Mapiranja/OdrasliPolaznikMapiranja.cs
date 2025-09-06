using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class OdrasliPolaznikMapiranja:ClassMap<OdrasliPolaznik>
    {
        OdrasliPolaznikMapiranja()
        {
            Table("ODRASLI_POLAZNIK");

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.Zanimanje, "ZANIMANJE");
        }
    }
}
