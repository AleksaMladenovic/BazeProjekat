using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
    public class NastavnikPregled
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string RadnoVreme { get; set; }
        public string TrajanjeUgovora { get; set; }
        public string StrucnaSprema { get; set; }
        public string TipZaposlenja { get; set; } // Ovde će pisati "Stalno zaposlen" ili "Honorarac"

        public NastavnikPregled(int id, string jmbg, string ime, string prezime, string tipZaposlenja)
        {
            Id = id;
            Jmbg = jmbg;
            Ime = ime;
            Prezime = prezime;
            TipZaposlenja = tipZaposlenja;
        }

        public abstract class NastavnikBasic
        {
            public int IdOsobe { get; set; }
            public string? Jmbg { get; set; }
            public string? Ime { get; set; }
            public string? Prezime { get; set; }
            public string? Adresa { get; set; }
            public string? Telefon { get; set; }
            public string? Email { get; set; }
        }
    }


}
