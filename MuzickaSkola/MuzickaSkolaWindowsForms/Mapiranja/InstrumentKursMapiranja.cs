using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class InstrumentKursMapiranja : SubclassMap<InstrumentKurs>
    {

        public InstrumentKursMapiranja()
        {
            DiscriminatorValue("INSTRUMENT");

            Map(p => p.Instrument, "INSTRUMENT");

        }
    }
}
