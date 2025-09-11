using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()
        {
            Table("OSOBA");
            Id(p => p.Id, "ID_OSOBE").GeneratedBy.SequenceIdentity("OSOBA_ID_SEQ");

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.Ime, "IME");
            Map(p => p.Prezime, "PREZIME");
            Map(p => p.Telefon, "TELEFON");
            Map(p => p.Email, "EMAIL");
            Map(p => p.Adresa, "ADRESA");
            Map(p => p.FPolaznik, "FPOLAZNIK");
            Map(p => p.FRoditelj, "FRODITELJ");
            Map(p => p.FNastavnik, "FNASTAVNIK");
            Map(x => x.DatumZaposlenja, "DATUM_ZAPOSLENJA");
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");
            References(x => x.Mentor, "ID_MENTORA");
            // Veza je ispravno definisana sa PropertyRef da bi se izbegao konflikt.
            // Ovo ostaje kako jeste.
            //HasOne(p => p.UlogaNastavnik)
            //    .Cascade.All()
            //    .LazyLoad()
            //    .PropertyRef(x => x.OsnovniPodaci); 

            // Kada budete radili sa drugarom, otkomentarisaćete i ove linije
            // i primeniti istu logiku na njegova mapiranja.
            // HasOne(p => p.UlogaPolaznik).Cascade.All().LazyLoad().PropertyRef(x => x.OsnovniPodaci);
            // HasOne(p => p.UlogaRoditelj).Cascade.All().LazyLoad().PropertyRef(x => x.OsnovniPodaci);
        }
    }
}