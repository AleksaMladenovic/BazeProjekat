using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Lokacija
    {
        public virtual required string Adresa {  get; set; }
        public virtual required string RadnoVreme { get; set; }
    }
}
