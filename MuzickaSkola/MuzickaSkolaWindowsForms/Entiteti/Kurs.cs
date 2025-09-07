using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public abstract class Kurs
    {
        public virtual int Id { get; set; }

        public virtual string? Nivo { get; set; }

        public virtual required string Naziv { get; set; }

        //public virtual required string JMBGNastavnika { get; set; }

    }

    public class GrupaInstrumenataKurs : InstrumentalniKurs
    {
        public string? GrupaInstrumenata { get; set; }
    }
}
