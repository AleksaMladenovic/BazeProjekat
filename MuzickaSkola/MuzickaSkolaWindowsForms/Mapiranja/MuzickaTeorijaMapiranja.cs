using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class MuzickaTeorijaMapiranja:ClassMap<MuzickaTeorija>
    {
        MuzickaTeorijaMapiranja()
        {
            Table("MUZICKA_TEORIJA");

            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.NazivPredmeta, "NAZIV_PREDMETA");
        }
    }
}
