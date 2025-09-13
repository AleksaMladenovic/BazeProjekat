using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    // KORISTIMO SubclassMap DA KAŽEMO DA JE OVO PODKLASA NASTAVNIKA
    class HonoraracMapiranja : SubclassMap<Honorarac>
    {
        public HonoraracMapiranja()
        {
            Table("HONORARAC");
            KeyColumn("ID_OSOBE");

            Map(p => p.BrojUgovora, "BROJ_UGOVORA");
            Map(p => p.TrajanjeUgovora, "TRAJANJE_UGOVORA");
            Map(p => p.BrojCasova, "BROJ_CASOVA");
        }
    }
}