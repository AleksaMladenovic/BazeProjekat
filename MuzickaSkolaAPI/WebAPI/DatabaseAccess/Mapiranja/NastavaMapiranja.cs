using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class NastavaMapiranja : ClassMap<Nastava>
    {
        NastavaMapiranja()
        {
            Table("NASTAVA");
            Id(p => p.Id,"ID_NASTAVE").GeneratedBy.SequenceIdentity("NASTAVA_ID_SEQ");

            Map(p => p.DatumOd, "DATUM_OD");
            Map(p => p.DatumDo, "DATUM_DO");
            Map(p => p.FIndividualna, "FINDIVIDUALNA");
            Map(p => p.FGrupna, "FGRUPNA");

            References(x => x.PripadaKursu, "ID_KURSA");

            HasMany(x => x.Casovi)
                .KeyColumn("ID_NASTAVE")
                .Cascade.All()
                .Inverse();

        }
    }
}
