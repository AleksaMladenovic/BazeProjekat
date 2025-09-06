using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class DetePolaznik
    {
        public virtual required string Jmbg { get; set; }
        public virtual string? Jbd { get; set; }
        public virtual required string JmbgRoditelja { get; set; }
    }
}
