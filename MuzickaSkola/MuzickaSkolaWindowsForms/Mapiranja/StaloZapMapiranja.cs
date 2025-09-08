using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class StaloZapMapiranja : SubclassMap<StalnoZaposlen>
    {
        public StaloZapMapiranja()
        {
            Extends<Nastavnik>();
            Table("STALNO_ZAP");
            KeyColumn("ID_OSOBE");
            Map(p => p.RadnoVreme, "RADNO_VREME");

            HasMany(x => x.JeMentor).KeyColumn("ID_MENTORA").Inverse().Cascade.All();
        }
    }
}
