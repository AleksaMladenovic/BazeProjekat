using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class GrupniKursMapiranja:ClassMap<GrupniKurs>
    {
        GrupniKursMapiranja()
        {
            //MORA DA SE PROVERI,NE ZNAM DA LI BI TREBALO KAO ID DA IDE
            Table("GRUPNI_KURS");
            Map(p => p.IdKursa, "ID_KURSA");
        }
    }
}
