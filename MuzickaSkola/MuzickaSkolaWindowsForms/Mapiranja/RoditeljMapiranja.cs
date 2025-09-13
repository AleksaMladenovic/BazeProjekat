using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja 
{
    class RoditeljMapiranja : ClassMap<Roditelj>
    {
        public RoditeljMapiranja()
        {
            Table("OSOBA");
            Id(x => x.Id).Column("ID_OSOBE").GeneratedBy.Assigned(); 

        

            HasMany(x => x.Deca)
                .KeyColumn("ID_RODITELJA")
                .Inverse()
                .Cascade.All();
        }
    }
}
