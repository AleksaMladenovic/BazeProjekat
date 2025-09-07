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
    public class HorskoPevanjeKurs : VokalniKurs
    {
    }

    public class IndividualnoPevanje : VokalniKurs
    {
    }

    public abstract class InstrumentalniKurs : Kurs
    {
    }

    public class InstrumentKurs : InstrumentalniKurs
    {
        public string? Instrument { get; set; }
    }

    public class MuzickaTeorijaKurs : Kurs
    {
        public virtual string? NazivPredmeta { get; set; }
    }
    public abstract class VokalniKurs : Kurs
    {

    }
}
