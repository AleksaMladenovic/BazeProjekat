using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class UcionicaMapiranja:ClassMap<Ucionica>
    {
        UcionicaMapiranja()
        {
            Table("UCIONICA");
            CompositeId(x => x.Id)
                .KeyReference(p => p.PripadaLokaciji, "ADRESA")
                .KeyProperty(p => p.Naziv, "NAZIV");

            Map(p => p.Opremljenost, "OPREMLJENOST");
            Map(p => p.Kapacitet, "KAPACITET");

            HasMany(x => x.CasoviKojiSeOdrzavaju)
                .KeyColumns.Add("ADRESA_LOKACIJE", "NAZIV_UCIONICE")
                .Cascade.All()
                .Inverse();
        }
    }
}
