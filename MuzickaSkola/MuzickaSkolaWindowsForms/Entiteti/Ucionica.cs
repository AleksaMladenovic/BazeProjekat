using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Ucionica
    {
        public virtual string? Naziv { get; set; }
        public virtual string? Adresa {  get; set; }
        public virtual string? Opremljenost {  get; set; }
        public virtual int Kapacitet {  get; set; }
    }
}
