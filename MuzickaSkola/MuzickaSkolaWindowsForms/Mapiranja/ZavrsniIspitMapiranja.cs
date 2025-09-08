using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class ZavrsniIspitMapiranja:ClassMap<ZavrsniIspit>
    {
        ZavrsniIspitMapiranja()
        {
            Table("ZAVRSNI_ISPIT");

            CompositeId(p => p.Id)
                .KeyReference(p => p.IspitIzKursa, "ID_KURSA")
                .KeyProperty(p => p.Datum, "DATUM");

            Map(p => p.Ocena, "OCENA");
            Map(p => p.Sertifikat, "SERTIFIKAT");

            References(x => x.OcenjujeKomisija, "ID_KOMISIJE");
            References(x => x.PolazePolaznik, "ID_POLAZNIKA");
        }
    }
}
