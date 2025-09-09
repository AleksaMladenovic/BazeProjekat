using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class HonoraracMapiranja :ClassMap<Honorarac>
    {
        public HonoraracMapiranja()
        {
           
            Table("HONORARAC");

            Id(x => x.Id)
                .Column("ID_OSOBE")
                .GeneratedBy.Foreign("OsnovniPodaci");

            HasOne(x => x.OsnovniPodaci)
                .Constrained()
                .Cascade.All();

            Map(p => p.BrojUgovora, "BROJ_UGOVORA");
            Map(p => p.TrajanjeUgovora, "TRAJANJE_UGOVORA");
            Map(p => p.BrojCasova, "BROJ_CASOVA");
        }
    }
}
