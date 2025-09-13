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
            Table("DETE_POLAZNIK");

            Id(x => x.Id)
                .Column("ID_OSOBE")
                .GeneratedBy.Foreign("OsnovniPodaci");

            HasOne(x => x.OsnovniPodaci)
                .Constrained()
                .Cascade.All();

            Map(x => x.Jbd, "JBD");
            References(x => x.PrijavioRoditelj, "ID_RODITELJA");

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
