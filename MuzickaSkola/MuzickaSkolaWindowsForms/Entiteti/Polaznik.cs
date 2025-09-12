using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Polaznik 
    {
        public virtual int Id { get; protected set; } 

        public virtual Osoba OsnovniPodaci { get; set; } 

        public virtual IList<Prisustvo> PrisustvoNaCasovima { get; set; }

        public virtual IList<Kurs> PrijavljeniKursevi { get; set; }

        public virtual IList<ZavrsniIspit> PolozeniIspiti { get; set; }
        protected Polaznik() { 
            PrijavljeniKursevi = new List<Kurs>();
            PolozeniIspiti = new List<ZavrsniIspit>();
            PrisustvoNaCasovima = new List<Prisustvo>();
        }
    }
}
