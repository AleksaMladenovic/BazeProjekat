using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class DetePolaznikMapiranja : ClassMap<DetePolaznik>
    {
        public DetePolaznikMapiranja()
        {
            //OVO MORA PROVERIMO
            Table("DETE_POLAZNIK");

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.Jbd, "JBD");
            Map(p => p.JmbgRoditelja, "JMBG_RODITELJA");
        }
    }
}
