using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class OsobaMapiranja : ClassMap<Osoba>
    {
        OsobaMapiranja()
        {
            Table("OSOBA");
            Id(p => p.Id,"ID_OSOBE").GeneratedBy.TriggerIdentity();

            DiscriminateSubClassesOnColumn("FPOLAZNIK", 0);
            DiscriminateSubClassesOnColumn("FNASTAVNIK", 0);

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.Ime, "IME");
            Map(p => p.Prezime, "PREZIME");
            Map(p => p.Telefon, "TELEFON");
            Map(p => p.Email, "EMAIL");
            Map(p => p.Adresa, "ADRESA");
            Map(p => p.Polaznik, "FPOLAZNIK");
            Map(p => p.Nastavnik, "FNASTAVNIK");
            //Map(p => p.FPolaznik, "FPOLAZNIK");
            //Map(p => p.FNastavnik, "FNASTAVNIK");
            
            //Map(p => p.JmbgMentora, "JMBG_MENTORA");
        }
    }
}
