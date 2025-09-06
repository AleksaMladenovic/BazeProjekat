using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Prijavljen
    {
        public virtual required string jmbgPolaznika { get; set; }
        public virtual int IdKursa { get; set; }
    }
}
