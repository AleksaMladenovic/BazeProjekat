using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class OdrasliPolaznikMapiranja:SubclassMap<OdrasliPolaznik>
    {
        public OdrasliPolaznikMapiranja()
        {
            Extends<Polaznik>();
            Table("ODRASLI_POLAZNIK");

            KeyColumn("ID_OSOBE");

            Map(p => p.Zanimanje, "ZANIMANJE");
        }
    }
}
