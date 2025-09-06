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

            Map(p => p.JmbgPolaznika, "JMBG_POLAZNIKA");
            Map(p => p.IdCasa, "ID_CASA");
            Map(p => p.Ocena, "OCENA");
        }
    }
}
