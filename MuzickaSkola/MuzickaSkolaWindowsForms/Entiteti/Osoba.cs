using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Osoba
    {
        public virtual required string Jmbg { get; set; }
        public virtual required string Ime { get; set; }
        public virtual required string Prezime { get; set; }        
        public virtual string? Telefon {  get; set; }
        public virtual string? Email {  set; get; }
        public virtual string? Adresa {  set; get; }
        public virtual int FPolaznik {  set; get; }
        public virtual int FNastavnik {  set; get; }
        public virtual DateTime DatumZaposlenja { set; get; }
        public virtual string? StrucnaSprema {  set; get; }
        public virtual string? JmbgMentora {  set; get; }
    }
}
