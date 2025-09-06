using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class InstrumentalniKursMapiranja:ClassMap<InstrumentalniKurs>
    {
        InstrumentalniKursMapiranja()
        {
            Table("INSTRUMENTALNI_KURS");
            //Ne znam da li je ovo ID mislim da je foreign sa KURS
            //Id(p=>p.Id,"ID_KURSA").GeneratedBy.TriggerIdentity();
            Map(p => p.IdKursa, "ID_KURSA");
            Map(p => p.FInstrument, "FINSTRUMENT");
            Map(p => p.Instrument, "INSTRUMENT");
            Map(p => p.FGrupaInstrumenata, "FGRUPA_INSTRUMENATA");
            Map(p => p.GrupaInstrumenata, "GRUPA_INSTRUMENATA");
              
            
        }
    }
}
