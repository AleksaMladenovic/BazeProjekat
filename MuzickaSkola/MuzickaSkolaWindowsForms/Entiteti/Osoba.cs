using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; set; }
        public virtual required string Jmbg { get; set; }
        public virtual required string Ime { get; set; }
        public virtual required string Prezime { get; set; }
        public virtual string? Adresa { get; set; }
        public virtual string? Telefon { get; set; }
        public virtual string? Email { get; set; }
        public virtual DateTime? DatumZaposlenja { get; set; }
        public virtual string StrucnaSprema { get; set; }
        public virtual StalnoZaposlen? Mentor { get; set; }
        public virtual bool FPolaznik { get; set; }
        public virtual bool FRoditelj { get; set; }
        public virtual bool FNastavnik { get; set; }

        public virtual Polaznik? UlogaPolaznik { get; set; }
        public virtual Nastavnik? UlogaNastavnik { get; set; }
        public virtual Roditelj? UlogaRoditelj { get; set; }
    }
}