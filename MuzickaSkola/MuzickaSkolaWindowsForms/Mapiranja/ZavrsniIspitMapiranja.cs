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

            Id(x => x.Id, "ID_ISPITA").GeneratedBy.SequenceIdentity("ISPIT_ID_SEQ");

            Map(p => p.Ocena, "OCENA");
            Map(p => p.Sertifikat, "SERTIFIKAT");
            Map(p => p.Datum, "DATUM");

            References(x => x.OcenjujeKomisija, "ID_KOMISIJE");
            References(x => x.PolazePolaznik, "ID_POLAZNIKA");
            References(x => x.KursKojiSePolaze, "ID_KURSA");
        }
    }
}
