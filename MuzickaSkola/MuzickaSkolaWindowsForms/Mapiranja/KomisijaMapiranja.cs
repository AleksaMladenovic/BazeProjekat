using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class KomisijaMapiranja:ClassMap<Komisija>
    {
        public KomisijaMapiranja()
        {
            Table("KOMISIJA");
            Id(p => p.Id, "ID_KOMISIJE").GeneratedBy.SequenceIdentity("KOMISIJA_ID_SEQ");

            HasManyToMany(x => x.ClanoviKomisije)
                .Table("SE_SASTOJI")
                .ParentKeyColumn("ID_KOMISIJE")
                .ChildKeyColumn("ID_NASTAVNIKA")
                .Cascade.All();

            HasMany(x => x.IspitiKojeOcenjuje)
                .KeyColumn("ID_KOMISIJE")
                .Cascade.All()
                .Inverse();
        }
    }
}
