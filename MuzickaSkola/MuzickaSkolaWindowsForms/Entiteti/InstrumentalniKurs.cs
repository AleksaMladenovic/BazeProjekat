using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class InstrumentalniKurs
    {
        public virtual int IdKursa { get; set; }
        public virtual int FInstrument {  get; set; }
        public virtual string? Instrument {  get; set; }
        public virtual int FGrupaInstrumenata {  get; set; }
        public virtual string? GrupaInstrumenata { get; set; }
    }
}
