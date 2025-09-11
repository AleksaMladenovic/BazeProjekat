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

            Id(p => p.Id, "ID_KURSA").GeneratedBy.SequenceIdentity("KURS_ID_SEQ");

            DiscriminateSubClassesOnColumn("TIP_KURSA");

            Map(p => p.Nivo, "NIVO");
            Map(p => p.Naziv, "NAZIV_KURSA");

            HasMany(x => x.NastavniBlokovi)
                .KeyColumn("ID_KURSA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x => x.PrijavljeniPolaznici)
                .Table("PRIJAVLJEN")
                .ParentKeyColumn("ID_KURSA")
                .ChildKeyColumn("ID_POLAZNIKA")
                .Cascade.All()
                .Inverse();

            HasManyToMany(x=>x.LokacijeOdrzavanja)
                .Table("ODVIJA_NA")
                .ParentKeyColumn("ID_KURSA")
                .ChildKeyColumn("ADRESA")
                .Cascade.All();

            HasMany(x=>x.ZavrsniIspiti)
                .KeyColumn("ID_KURSA")
                .Cascade.All().Inverse();

            References(x => x.VodiNastavnik, "ID_NASTAVNIKA");
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

    class IndividualnoPevanjeKursMapiranja : SubclassMap<IndividualnoPevanje>//OVDE SAM NAPRAVIO IZMENU JER MISLIM DA JE GRESKA 
    {
        public IndividualnoPevanjeKursMapiranja()
        {
            DiscriminatorValue("INDIVIDUALNO_PEVANJE");

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
