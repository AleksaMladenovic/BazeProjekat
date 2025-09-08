using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class DetePolaznik : Polaznik
    {
        public virtual string? Jbd { get; set; }
        public virtual required Roditelj PrijavioRoditelj { get; set; }
        //public virtual required string JmbgRoditelja { get; set; }
    }
}
