using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class HorskoPevanjeKursMapiranja : SubclassMap<HorskoPevanjeKurs>
    {
        public HorskoPevanjeKursMapiranja()
        {
            DiscriminatorValue("HORSKO_PEVANJE");

        }
    }
}
