using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class VokalniKursMapiranja : ClassMap<VokalniKurs>
    {
        VokalniKursMapiranja()
        {
            Table("VOKALNI_KURS");

            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.FIndividualnoPevanje, "FINDIVIDUALNO_PEVANJE");
            Map(p => p.FHorskoPevanje, "FHORSKO_PEVANJE");
        }
    }
}
