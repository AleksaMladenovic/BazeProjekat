using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class NastavaView
    {
        public int Id { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public bool FIndividualna { get; set; }
        public bool FGrupna { get; set; }

        public string TipNastave
        {
            get
            {
                if (FIndividualna) return "Individualna";
                if (FGrupna) return "Grupna";
                return "Nedefinisan";
            }
        }

        public KursView? PripadaKursu { get; set; }

        public IList<CasView> Casovi { get; set; }

        public NastavaView()
        {
            Casovi = new List<CasView>();
        }

        internal NastavaView(Nastava? n)
        {
            if (n != null)
            {
                this.Id = n.Id;
                this.DatumOd = n.DatumOd;
                this.DatumDo = n.DatumDo;
                this.FIndividualna = n.FIndividualna;
                this.FGrupna = n.FGrupna;

                if (n.PripadaKursu != null)
                {
                    this.PripadaKursu = new KursView(n.PripadaKursu);
                }

                if (n.Casovi != null)
                {
                    this.Casovi = n.Casovi.Select(c => new CasView(c)).ToList();
                }
            }
        }
    }
}
