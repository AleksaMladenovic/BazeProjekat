using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
     class CasMapiranja:ClassMap<Cas>
    {
        public CasMapiranja()
        {
            Table("CAS");
            Id(p => p.Id,"ID_CASA").GeneratedBy.SequenceIdentity("CAS_ID_SEQ");

            Map(p => p.Termin, "TERMIN");
            Map(p => p.Tema, "TEMA");
           

            HasMany(x => x.PrisutniPolaznici)
                .KeyColumn("ID_CASA")
                .Cascade.All()
                .Inverse();

            References(x => x.DrziNastavnik, "ID_NASTAVNIKA");
            References(x => x.PripadaNastavi, "ID_NASTAVE");
            References(x => x.UcionicaOdrzavnja).Columns("ADRESA_LOKACIJE", "NAZIV_UCIONICE");
        }
    }
}
