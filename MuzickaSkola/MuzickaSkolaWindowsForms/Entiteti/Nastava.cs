using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Nastava
    {
        public virtual int Id { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }

        public virtual bool FIndividualna { get; set; }
        public virtual bool FGrupna{ get; set; }

        public virtual Kurs PripadaKursu { get; set; }

        public virtual IList<Cas> Casovi{ get; set; }

        public Nastava()
        {
            Casovi = new List<Cas>();
        }

    }
}
