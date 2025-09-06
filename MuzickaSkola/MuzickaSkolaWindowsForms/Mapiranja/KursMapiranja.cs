using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class KursMapiranja : ClassMap<Kurs>
    {
        public KursMapiranja()
        {
            Table("KURS");

            Id(p => p.Id, "ID_KURSA").GeneratedBy.TriggerIdentity();

            Map(p => p.Nivo, "NIVO");
            Map(p => p.NazivKursa, "NAZIV_KURSA");
            Map(p => p.JMBGNastavnika, "JMBG_NASTAVNIKA");
        }
    }

}
