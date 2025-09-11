using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    // KORISTIMO SubclassMap DA KAŽEMO DA JE OVO PODKLASA NASTAVNIKA
    class StaloZapMapiranja : SubclassMap<StalnoZaposlen>
    {
        public StaloZapMapiranja()
        {
            // Kažemo gde se nalaze podaci specifični za StalnoZaposlenog
            Table("STALNO_ZAP");
            // Kažemo preko koje kolone se spaja sa OSOBA tabelom
            KeyColumn("ID_OSOBE");

            // Mapiramo samo atribute specifične za StalnoZaposlenog
            Map(p => p.RadnoVreme, "RADNO_VREME");
            HasMany(x => x.JeMentor).KeyColumn("ID_MENTORA").Inverse().Cascade.All();
        }
    }
}