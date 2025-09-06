using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class HonoraracMapiranja :ClassMap<Honorarac>
    {
        public HonoraracMapiranja()
        {
            //Ovo mora proverimo
            Table("HONORARAC");

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.BrojUgovora, "BROJ_UGOVORA");
            Map(p => p.TrajanjeUgovora, "TRAJANJE_UGOVORA");
            Map(p => p.BrojCasova, "BROJ_CASOVA");
        }
    }
}
