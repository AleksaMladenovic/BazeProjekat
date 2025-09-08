using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class HonoraracMapiranja :SubclassMap<Honorarac>
    {
        public HonoraracMapiranja()
        {
            //Ovo mora proverimo
            Extends<Nastavnik>();

            Table("HONORARAC");
            KeyColumn("ID_OSOBE");

            Map(p => p.BrojUgovora, "BROJ_UGOVORA");
            Map(p => p.TrajanjeUgovora, "TRAJANJE_UGOVORA");
            Map(p => p.BrojCasova, "BROJ_CASOVA");
        }
    }
}
