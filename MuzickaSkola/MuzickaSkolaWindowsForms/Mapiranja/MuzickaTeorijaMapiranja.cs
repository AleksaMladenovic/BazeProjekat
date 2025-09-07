using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class MuzickaTeorijaMapiranja:SubclassMap<MuzickaTeorijaKurs>
    {
        MuzickaTeorijaMapiranja()
        {
            DiscriminatorValue("MUZICKA_TEORIJA");

            Map(p => p.NazivPredmeta, "NAZIV_PREDMETA");
        }
    }
}
