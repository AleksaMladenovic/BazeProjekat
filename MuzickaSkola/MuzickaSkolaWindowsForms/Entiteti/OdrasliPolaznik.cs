using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class OdrasliPolaznik
    {
        public virtual required string Jmbg { get; set; }
        public virtual string? Zanimanje { get; set; }
    }
}
