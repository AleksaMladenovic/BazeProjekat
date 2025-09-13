using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using NHibernate.Mapping.ByCode.Conformist;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class OdrasliPolaznikMapiranja : ClassMap<OdrasliPolaznik>
    {
        public OdrasliPolaznikMapiranja()
        {
            Table("ODRASLI_POLAZNIK");

            Id(x => x.Id)
                .Column("ID_OSOBE")
                .GeneratedBy.Foreign("OsnovniPodaci");

            
            HasOne(x => x.OsnovniPodaci)
                .Constrained()
                .Cascade.All();

            Map(p => p.Zanimanje, "ZANIMANJE");

            HasMany(x => x.PrisustvoNaCasovima)
                .KeyColumn("ID_POLAZNIKA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x => x.PrijavljeniKursevi)
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
