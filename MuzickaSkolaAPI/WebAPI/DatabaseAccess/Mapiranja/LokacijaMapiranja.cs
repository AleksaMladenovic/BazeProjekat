using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class LokacijaMapiranja:ClassMap<Lokacija>
    {
        LokacijaMapiranja()
        {
            Table("LOKACIJA");

            Id(p => p.Adresa, "ADRESA").GeneratedBy.Assigned();

            Map(p => p.RadnoVreme, "RADNO_VREME");

            HasMany(x => x.Ucionice)
                .KeyColumn("ADRESA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x => x.KurseviKojiSeOdrzavaju)
                .Table("ODVIJA_NA")
                .ParentKeyColumn("ADRESA")
                .ChildKeyColumn("ID_KURSA")
                .Cascade.All()
                .Inverse();
        }
    }
}
