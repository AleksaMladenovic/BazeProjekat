using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class StalnoZaposlen : Nastavnik
    {
        public virtual required string RadnoVreme { get; set; }

        public virtual IList<Nastavnik> JeMentor { get; set; }

        public StalnoZaposlen()
        {
            JeMentor = new List<Nastavnik>();
        }
    }
}
