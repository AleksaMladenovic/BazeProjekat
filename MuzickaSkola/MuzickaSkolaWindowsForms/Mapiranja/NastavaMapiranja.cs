using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class NastavaMapiranja : ClassMap<Nastava>
    {
        NastavaMapiranja()
        {
            Table("NASTAVA");
            Id(p => p.Id,"ID_NASTAVE").GeneratedBy.TriggerIdentity();

            Map(p => p.DatumOd, "DATUM_OD");
            Map(p => p.DatumDo, "DATUM_DO");
            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.FIndividualna, "FINDIVIDUALNA");
            Map(p => p.FGrupna, "FGRUPNA");

        }
    }
}
