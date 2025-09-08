using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Komisija
    {
        public virtual int Id { get; set; }

        public virtual IList<Nastavnik> ClanoviKomisije { get; set; }

        public virtual IList<ZavrsniIspit> IspitiKojeOcenjuje { get; set; }
        public Komisija()
        {
            IspitiKojeOcenjuje = new List<ZavrsniIspit>();
            ClanoviKomisije = new List<Nastavnik>();
        }
    }
}
