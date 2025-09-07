using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class KursMapiranja : ClassMap<Kurs>
    {
        public KursMapiranja()
        {
            Table("KURS");

            Id(p => p.Id, "ID_KURSA").GeneratedBy.TriggerIdentity();

            DiscriminateSubClassesOnColumn("TIP_KURSA");

            Map(p => p.Nivo, "NIVO");
            Map(p => p.Naziv, "NAZIV_KURSA");

        }
    }


    class GrupaInstrumenataKursMapiranja : SubclassMap<GrupaInstrumenataKurs>
    {
        public GrupaInstrumenataKursMapiranja()
        {
            DiscriminatorValue("GRUPA_INSTRUMENATA");
            Map(x => x.GrupaInstrumenata, "GRUPA_INSTRUMENATA");
        }
    }

    class HorskoPevanjeKursMapiranja : SubclassMap<HorskoPevanjeKurs>
    {
        public HorskoPevanjeKursMapiranja()
        {
            DiscriminatorValue("HORSKO_PEVANJE");

        }
    }

    class IndividualnoPevanjeKursMapiranja : SubclassMap<IndividualnoPevanje>
    {
        public IndividualnoPevanjeKursMapiranja()
        {
            DiscriminatorValue("GRUPA_INSTRUMENATA");

        }

    }

    class InstrumentKursMapiranja : SubclassMap<InstrumentKurs>
    {

        public InstrumentKursMapiranja()
        {
            DiscriminatorValue("INSTRUMENT");

            Map(p => p.Instrument, "INSTRUMENT");

        }
    }

    class MuzickaTeorijaKursMapiranja : SubclassMap<MuzickaTeorijaKurs>
    {
        MuzickaTeorijaKursMapiranja()
        {
            DiscriminatorValue("MUZICKA_TEORIJA");

            Map(p => p.NazivPredmeta, "NAZIV_PREDMETA");
        }
    }

    
}
