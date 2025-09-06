using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Kurs
    {
        public virtual int Id { get; set; }

        public virtual string? Nivo { get; set; }

        public virtual required string NazivKursa { get; set; }

        public virtual required string JMBGNastavnika { get; set; }

    }
}
