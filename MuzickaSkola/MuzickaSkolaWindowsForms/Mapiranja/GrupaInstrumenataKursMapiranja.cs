using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class GrupaInstrumenataKursMapiranja : SubclassMap<GrupaInstrumenataKurs>
    {
        public GrupaInstrumenataKursMapiranja()
        {
            DiscriminatorValue("GRUPA_INSTRUMENATA");
            Map(x => x.GrupaInstrumenata, "GRUPA_INSTRUMENATA");
        }
    }
}
