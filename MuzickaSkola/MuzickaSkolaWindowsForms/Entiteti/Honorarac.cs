using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Honorarac
    {
        public virtual required string Jmbg { get; set; }
        public virtual required string BrojUgovora { get; set; }
        public virtual string? TrajanjeUgovora { get; set; }
        public virtual int BrojCasova { get; set; }
    }
}
