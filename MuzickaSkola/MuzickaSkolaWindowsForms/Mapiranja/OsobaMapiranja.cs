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
            Id(p => p.Id,"ID_OSOBE").GeneratedBy.SequenceIdentity("OSOBA_ID_SEQ");

            Map(p => p.Jmbg, "JMBG");
            Map(p => p.Ime, "IME");
            Map(p => p.Prezime, "PREZIME");
            Map(p => p.Telefon, "TELEFON");
            Map(p => p.Email, "EMAIL");
            Map(p => p.Adresa, "ADRESA");
            Map(p => p.FPolaznik, "FPOLAZNIK");
            Map(p => p.FRoditelj, "FRODITELJ");
            Map(p => p.StrucnaSprema, "STRUCNA_SPREMA");
            Map(p => p.DatumZaposlenja, "DATUM_ZAPOSLENJA");
            Map(p => p.FNastavnik, "FNASTAVNIK");
        }
    }
}