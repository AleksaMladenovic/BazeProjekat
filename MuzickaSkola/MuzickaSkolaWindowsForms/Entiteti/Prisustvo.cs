using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Prisustvo
    {
        public virtual required string JmbgPolaznika {  get; set; }
        public virtual int IdCasa {  get; set; }
        public virtual int Ocena {  get; set; }
    }
}
