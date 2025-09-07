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
            //OVO MORA PROVERIMO
            Table("DETE_POLAZNIK");

            DiscriminatorValue( 1);

        }
    }
}
