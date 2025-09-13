using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class NastavnikMapiranja : ClassMap<Nastavnik>
    {
        public NastavnikMapiranja()
        {

            UseUnionSubclassForInheritanceMapping();

            Table("OSOBA");
            // Definišemo ključ i kažemo da je strani ključ koji pokazuje na Osobu
            Id(x => x.Id).Column("ID_OSOBE").GeneratedBy.Foreign("OsnovniPodaci");

            // Definišemo one-to-one vezu nazad ka Osobi
            HasOne(x => x.OsnovniPodaci).Constrained();

            // Mapiramo atribute koji logički pripadaju Nastavniku, ali se fizički nalaze u OSOBA tabeli


            // Veze ka drugim tabelama ostaju iste
            HasMany(x => x.DrziCasove)
                .KeyColumn("ID_NASTAVNIKA")
                .Cascade.All()
                .Inverse();

            HasMany(x => x.VodiKurseve)
                .KeyColumn("ID_NASTAVNIKA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x => x.KomisijeCijiJeClan)
                .Table("SE_SASTOJI")
                .ParentKeyColumn("ID_NASTAVNIKA")
                .ChildKeyColumn("ID_KOMISIJE")
                .Cascade.All();
        }
    }
}