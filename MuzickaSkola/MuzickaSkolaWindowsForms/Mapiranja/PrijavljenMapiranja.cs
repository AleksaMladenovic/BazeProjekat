using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class PrijavljenMapiranja : ClassMap<Prijavljen>
    {
        PrijavljenMapiranja()
        {
            Table("PRIJAVLJEN");

            Map(p => p.jmbgPolaznika, "JMBG_POLAZNIKA");
            Map(p => p.IdKursa, "ID_KURSA");
        }
    }
}
