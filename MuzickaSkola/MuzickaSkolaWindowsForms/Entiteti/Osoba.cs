using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; protected set; }
        public virtual string Jmbg { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }

        // Flegovi ostaju da znamo koje uloge postoje
        public virtual bool FPolaznik { get; set; }
        public virtual bool FRoditelj { get; set; }
        public virtual bool FNastavnik { get; set; }

        // REFERENCE NA ULOGE (One-to-One)
        // Ove reference će biti NULL ako osoba nema tu ulogu.
        public virtual Polaznik UlogaPolaznik { get; set; }
        public virtual Nastavnik UlogaNastavnik { get; set; }
        public virtual Roditelj UlogaRoditelj { get; set; }
    }
}
