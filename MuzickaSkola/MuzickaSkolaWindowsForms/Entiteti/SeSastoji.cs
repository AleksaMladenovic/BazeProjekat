using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class SeSastoji
    {
        public virtual int IdKomisije { get; set; }
        public virtual required string JmbgNastavnika {  get; set; }
    }
}
