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
        public string StrucnaSprema { get; set; }
        public string TipZaposlenja { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string DetaljiZaposlenja { get; set; } // Nova kolona za detalje
        public string RadnoVreme { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public  string? BrojUgovora { get; set; }
        public   string? TrajanjeUgovora { get; set; }
        public  int? BrojCasova { get; set; }

        // Konstruktor koji prima sve potrebne podatke za prikaz
        public NastavnikPregled(int id, string jmbg, string ime, string prezime,string strucnasprema,string tipZaposlenja)
        {
            Id = id;
            Jmbg = jmbg;
            Ime = ime;
            Prezime = prezime;
            StrucnaSprema= strucnasprema;
            TipZaposlenja = tipZaposlenja;
          
        }
        public NastavnikPregled() { }
    }
}