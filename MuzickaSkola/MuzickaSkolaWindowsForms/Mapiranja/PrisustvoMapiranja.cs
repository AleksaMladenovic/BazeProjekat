using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class PrisustvoMapiranja:ClassMap<Prisustvo>
    {
        PrisustvoMapiranja()
        {
            Table("PRISUSTVO");

            CompositeId(p => p.Id)
                .KeyReference(p => p.PolaznikNaCasu, "ID_POLAZNIKA")
                .KeyReference(p => p.CasKomePrisustvuje, "ID_CASA");

            Map(p => p.Ocena, "OCENA");
        }
    }
}
