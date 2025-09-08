using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class PolaznikMapiranja : ClassMap<Polaznik>
    {
        public PolaznikMapiranja()
        {
            Id(x => x.Id).GeneratedBy.Foreign("OsnovniPodaci");

            HasOne(x => x.OsnovniPodaci).Constrained();

            HasMany(x => x.PrisustvoNaCasovima)
                .KeyColumn("ID_POLAZNIKA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x=>x.PrijavljeniKursevi)
                .Table("PRIJAVLJEN")
                .ParentKeyColumn("ID_POLAZNIKA")
                .ChildKeyColumn("ID_KURSA")
                .Cascade.All();

            HasMany(x => x.PolozeniIspiti)
                .KeyColumn("ID_POLAZNIKA")
                .Cascade.All()
                .Inverse();
                
        }
    }
}
