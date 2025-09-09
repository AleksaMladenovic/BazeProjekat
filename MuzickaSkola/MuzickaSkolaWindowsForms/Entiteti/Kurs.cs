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

        public virtual string Naziv { get; set; }

        public virtual IList<Nastava> NastavniBlokovi { get; set; }

        //public virtual IList<Polaznik> PrijavljeniPolaznici { get; set; }

        //public virtual Nastavnik VodiNastavnik { get; set; }

        public virtual IList<Lokacija> LokacijeOdrzavanja { get; set; }

        public virtual IList<ZavrsniIspit> ZavrsniIspiti { get; set; }
        public Kurs()
        {
            NastavniBlokovi = new List<Nastava>();
            LokacijeOdrzavanja = new List<Lokacija>();
            //PrijavljeniPolaznici = new List<Polaznik>();
            ZavrsniIspiti = new List<ZavrsniIspit>();
        }
    }

    public class GrupaInstrumenataKurs : InstrumentalniKurs
    {
        public virtual string? GrupaInstrumenata { get; set; }
    }
    public class HorskoPevanjeKurs : VokalniKurs
    {
    }

    public class IndividualnoPevanjeKurs : VokalniKurs
    {
    }

    public abstract class InstrumentalniKurs : Kurs
    {
    }

    public class InstrumentKurs : InstrumentalniKurs
    {
        public virtual string? Instrument { get; set; }
    }

    public class MuzickaTeorijaKurs : Kurs
    {
        public virtual string? NazivPredmeta { get; set; }
    }
    public abstract class VokalniKurs : Kurs
    {

    }
}
