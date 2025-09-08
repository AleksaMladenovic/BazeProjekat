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
        public NastavnikMapiranja(){
            
            Id(x => x.Id).GeneratedBy.Foreign("OsnovniPodaci");
            HasOne(x => x.OsnovniPodaci).Constrained();

            // Atributi koji su u tabeli OSOBA, ali pripadaju logički Nastavniku
            Map(x => x.DatumZaposlenja, "DATUM_ZAPOSLENJA");
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");
            References(x => x.Mentor, "ID_MENTORA");

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
