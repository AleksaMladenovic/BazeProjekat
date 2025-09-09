using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class StaloZapMapiranja : ClassMap<StalnoZaposlen>
    {
        public StaloZapMapiranja()
        {
            
            Table("STALNO_ZAP");

            Id(x => x.Id)
                .Column("ID_OSOBE")
                .GeneratedBy.Foreign("OsnovniPodaci");

            HasOne(x => x.OsnovniPodaci)
                .Constrained()
                .Cascade.All();

            Map(p => p.RadnoVreme, "RADNO_VREME");

            HasMany(x => x.JeMentor).KeyColumn("ID_MENTORA").Inverse().Cascade.All();
        }
    }
}
