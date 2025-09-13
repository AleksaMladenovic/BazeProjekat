using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseAccess.DTOs
{
    public class StalnoZaposlenView : NastavnikView
    {
        public string RadnoVreme { get; set; }

        public List<OsobaView> NastavniciKojimaJeMentor { get; set; }

        public StalnoZaposlenView()
        {
            NastavniciKojimaJeMentor = new List<OsobaView>();
        }

        internal StalnoZaposlenView(StalnoZaposlen? sz) : base(sz)
        {
            if (sz != null)
            {
                this.RadnoVreme = sz.RadnoVreme;

                if (sz.JeMentor != null)
                {
                    this.NastavniciKojimaJeMentor = sz.JeMentor
                        .Select(osoba=>new OsobaView(osoba)).ToList();
                }
            }
        }
    }
}
