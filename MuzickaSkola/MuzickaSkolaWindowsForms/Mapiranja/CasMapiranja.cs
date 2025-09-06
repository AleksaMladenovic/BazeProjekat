using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class CasMapiranja:ClassMap<Cas>
    {
        public CasMapiranja()
        {
            Table("CAS");
            Id(p => p.Id,"ID_CASA").GeneratedBy.TriggerIdentity();

            Map(p => p.Datum, "DATUM");
            Map(p => p.Vreme, "VREME");
            Map(p => p.Tema, "TEMA");
            Map(p => p.JmbgNastavnika, "JMBG_NASTAVNIKA");
            Map(p => p.NazivUcionice, "NAZIV_UCIONICE");
            Map(p => p.AdresaLokacije, "ADRESA_LOKACIJE");
            Map(p => p.IdNastave, "ID_NASTAVE");
            
        }
    }
}
