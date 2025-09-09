using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class PrisustvoMapiranja:ClassMap<Prisustvo>
    {
        public PrisustvoMapiranja()
        {
            Table("PRISUSTVO");

            CompositeId(p => p.Id)
                .KeyProperty(p => p.PolaznikId, "ID_POLAZNIKA")
                .KeyReference(p => p.CasKomePrisustvuje, "ID_CASA");

            Map(p => p.Ocena, "OCENA");
        }
    }
}
