using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class PolaznikMapiranja : SubclassMap<Polaznik>
    {
        public PolaznikMapiranja()
        {
            DiscriminatorValue(1);
        }
    }
}
