using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class SeSastojiMapiranja : ClassMap<SeSastoji>
    {
        SeSastojiMapiranja()
        {
            Table("SE_SASTOJI");

            Map(p => p.IdKomisije, "ID_KOMISIJE");
            Map(p => p.JmbgNastavnika, "JMBG_NASTAVNIKA");
        }
    }
}
