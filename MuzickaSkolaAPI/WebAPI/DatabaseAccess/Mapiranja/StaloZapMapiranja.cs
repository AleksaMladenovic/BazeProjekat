using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class StaloZapMapiranja : SubclassMap<StalnoZaposlen>
    {
        public StaloZapMapiranja()
        {
            Table("STALNO_ZAP");
            KeyColumn("ID_OSOBE");

            Map(p => p.RadnoVreme, "RADNO_VREME");
            HasMany(x => x.JeMentor).KeyColumn("ID_MENTORA").Inverse().Cascade.All();
        }
    }
}