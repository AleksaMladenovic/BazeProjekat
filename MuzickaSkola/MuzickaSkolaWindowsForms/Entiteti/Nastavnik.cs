using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Nastavnik
    {
        public virtual int Id { get;  set; }
        public virtual Osoba OsnovniPodaci { get; set; }


        public virtual IList<Cas> DrziCasove { get; set; }

        public virtual IList<Kurs> VodiKurseve { get; set; }

        public virtual IList<Komisija> KomisijeCijiJeClan { get; set; }
        protected Nastavnik()
        {
            DrziCasove = new List<Cas>();
            VodiKurseve = new List<Kurs>();
            KomisijeCijiJeClan = new List<Komisija>();
        }


    }
}