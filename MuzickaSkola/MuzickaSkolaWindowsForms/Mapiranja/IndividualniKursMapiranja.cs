using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class IndividualniKursMapiranja:ClassMap<IndividualniKurs>
    {
        IndividualniKursMapiranja()
        {
            Table("INDIVIDUALNI_KURS");

            Map(p => p.IdKursa, "ID_KURSA");
        }
    }
}
