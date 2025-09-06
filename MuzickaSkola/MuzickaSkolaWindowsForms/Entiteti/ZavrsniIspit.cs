using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class ZavrsniIspit
    {
        public virtual int IdKursa { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual int Ocena { get; set; }
        public virtual int Sertifikat { get; set; }
        public virtual int IdKomisije { get; set; }
        public virtual required string JmbgPolaznika {  get; set; }
    }
}
