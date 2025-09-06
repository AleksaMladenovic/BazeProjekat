using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class KomisijaMapiranja:ClassMap<Komisija>
    {
        KomisijaMapiranja()
        {
            Table("KOMISIJA");
            Id(p => p.IdKomisije, "ID_KOMISIJE").GeneratedBy.TriggerIdentity();
        }
    }
}
