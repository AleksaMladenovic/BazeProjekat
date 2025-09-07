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

            DiscriminateSubClassesOnColumn("TIP_KURSA");

            Map(p => p.Nivo, "NIVO");
            Map(p => p.Naziv, "NAZIV_KURSA");
            //Map(p => p.JMBGNastavnika, "JMBG_NASTAVNIKA");


            

        }
    }

}
