using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class DetePolaznikMapiranja : SubclassMap<DetePolaznik>
    {
        public DetePolaznikMapiranja()
        {
            Extends<Polaznik>();

            Table("DETE_POLAZNIK");

            KeyColumn("ID_OSOBE");

            Map(x => x.Jbd, "JBD");
            References(x => x.PrijavioRoditelj, "ID_RODITELJA");
        }
    }
}
