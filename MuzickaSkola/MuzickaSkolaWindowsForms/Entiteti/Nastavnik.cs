using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Nastavnik:Osoba
    {
        public virtual DateOnly DatumZaposlenja{ get; set; }

        public virtual string? StrucnaSprema { get; set; }
    }
}
