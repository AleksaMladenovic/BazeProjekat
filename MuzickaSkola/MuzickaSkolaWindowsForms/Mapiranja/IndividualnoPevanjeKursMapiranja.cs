using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class IndividualnoPevanjeKursMapiranja : SubclassMap<IndividualnoPevanje>
    {
        public IndividualnoPevanjeKursMapiranja()
        {
            DiscriminatorValue("GRUPA_INSTRUMENATA");

        }

    }
}
