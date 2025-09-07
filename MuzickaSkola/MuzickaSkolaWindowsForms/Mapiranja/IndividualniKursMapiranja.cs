using FluentNHibernate.Mapping;
using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class IndividualniKursMapiranja : SubclassMap<IndividualniKurs>
    {
        public IndividualniKursMapiranja()
        {
            Table("INDIVIDUALNI_KURS");

            KeyColumn("ID_KURSA");
            
        }
    }
}
