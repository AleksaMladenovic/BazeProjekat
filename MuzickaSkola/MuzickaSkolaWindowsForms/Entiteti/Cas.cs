using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Cas
    {
        public virtual int Id { get; set; }
        public virtual DateTime Termin{ get; set;}
        public virtual string? Tema { get; set; }

        public virtual IList<Prisustvo> PrisutniPolaznici { get; set; }
        public virtual Nastavnik DrziNastavnik { get; set; }

        public virtual Nastava PripadaNastavi { get; set; }

        public virtual Ucionica UcionicaOdrzavnja { get; set; }
        public Cas()
        {
            PrisutniPolaznici = new List<Prisustvo>();
        }
    }
}
