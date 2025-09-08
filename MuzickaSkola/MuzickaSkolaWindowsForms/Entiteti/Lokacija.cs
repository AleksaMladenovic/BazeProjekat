using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Lokacija
    {
        public virtual string Adresa {  get; set; }
        public virtual string RadnoVreme { get; set; }
        public virtual IList<Ucionica> Ucionice { get; set; }

        public virtual IList<Kurs> KurseviKojiSeOdrzavaju { get; set; }
        public Lokacija() {
            KurseviKojiSeOdrzavaju = new List<Kurs>();
            Ucionice = new List<Ucionica>();
        }
    }
}
