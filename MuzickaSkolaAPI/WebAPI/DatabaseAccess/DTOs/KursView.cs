using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class KursView
    {
        public int Id { get; set; }
        public string? Nivo { get; set; }
        public string Naziv { get; set; }

        public NastavnikView? VodiNastavnik { get; set; }
        public int BrojPrijavljenihPolaznika { get; set; }

        public string TipKursa { get; set; }

        public KursView() { }

        internal KursView(Kurs? k)
        {
            if (k != null)
            {
                this.Id = k.Id;
                this.Nivo = k.Nivo;
                this.Naziv = k.Naziv;

                if (k.VodiNastavnik != null)
                {
                    this.VodiNastavnik = NastavnikView.KreirajNastavnikView(k.VodiNastavnik);
                }

                this.BrojPrijavljenihPolaznika = k.PrijavljeniPolaznici?.Count ?? 0;

                // Prepoznavanje tipa i postavljanje stringa
                if (k is InstrumentKurs) this.TipKursa = "Instrument (pojedinačni)";
                else if (k is GrupaInstrumenataKurs) this.TipKursa = "Instrument (grupni)";
                else if (k is IndividualnoPevanjeKurs) this.TipKursa = "Pevanje (individualno)";
                else if (k is HorskoPevanjeKurs) this.TipKursa = "Pevanje (horsko)";
                else if (k is MuzickaTeorijaKurs) this.TipKursa = "Muzička teorija";
                else this.TipKursa = "Nedefinisan";
            }
        }
    }

    public class GrupaInstrumenataKursView : KursView
    {
        public string? GrupaInstrumenata { get; set; }

        public GrupaInstrumenataKursView() { }

        internal GrupaInstrumenataKursView(GrupaInstrumenataKurs? gik) : base(gik)
        {
            if (gik != null)
            {
                this.GrupaInstrumenata = gik.GrupaInstrumenata;
            }
        }
    }

    public class InstrumentKursView : KursView
    {
        public string? Instrument { get; set; }

        public InstrumentKursView() { }

        internal InstrumentKursView(InstrumentKurs? ik) : base(ik)
        {
            if (ik != null)
            {
                this.Instrument = ik.Instrument;
            }
        }
    }

    public class MuzickaTeorijaKursView : KursView
    {
        public string? NazivPredmeta { get; set; }

        public MuzickaTeorijaKursView() { }

        internal MuzickaTeorijaKursView(MuzickaTeorijaKurs? mtk) : base(mtk)
        {
            if (mtk != null)
            {
                this.NazivPredmeta = mtk.NazivPredmeta;
            }
        }
    }
}
