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

            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.Datum, "DATUM");
            Map(p => p.Ocena, "OCENA");
            Map(p => p.Sertifikat, "SERTIFIKAT");
            Map(p => p.IdKomisije, "ID_KOMISIJE");
            Map(p => p.JmbgPolaznika, "JMBG_POLAZNIKA");
        }
    }
}
