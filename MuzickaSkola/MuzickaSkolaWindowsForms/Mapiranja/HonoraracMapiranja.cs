using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    // KORISTIMO SubclassMap DA KAŽEMO DA JE OVO PODKLASA NASTAVNIKA
    class HonoraracMapiranja : SubclassMap<Honorarac>
    {
        public HonoraracMapiranja()
        {
            // Kažemo gde se nalaze podaci specifični za Honorarca
            Table("HONORARAC");
            // Kažemo preko koje kolone se spaja sa OSOBA tabelom
            KeyColumn("ID_OSOBE");

            // Mapiramo samo atribute specifične za Honorarca
            Map(p => p.BrojUgovora, "BROJ_UGOVORA");
            Map(p => p.TrajanjeUgovora, "TRAJANJE_UGOVORA");
            Map(p => p.BrojCasova, "BROJ_CASOVA");
        }
    }
}