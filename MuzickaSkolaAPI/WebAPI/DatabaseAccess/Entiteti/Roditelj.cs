using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Roditelj
    {
        public virtual int Id { get; protected set; }
        public virtual  Osoba OsnovniPodaci { get; set; }
        public virtual IList<DetePolaznik> Deca { get; set; }

        public Roditelj()
        {
            Deca = new List<DetePolaznik>();
        }
    }
}
