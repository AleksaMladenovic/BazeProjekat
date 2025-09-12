using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class ZavrsniIspit
    {
        public virtual int Id { get; set; }
        public virtual int Ocena { get; set; }
        public virtual bool Sertifikat { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual Komisija OcenjujeKomisija { get; set; }
        public virtual Polaznik PolazePolaznik { get; set; }
        public virtual Kurs KursKojiSePolaze{ get; set; }
        public ZavrsniIspit()
        {
            
        }
    }


}
