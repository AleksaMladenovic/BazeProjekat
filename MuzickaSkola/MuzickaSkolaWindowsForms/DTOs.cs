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

    public class KursPregled
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string TipKursa { get; set; }

        public KursPregled(int id, string naziv, string nivo, string tipKursa)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Nivo = nivo;
            this.TipKursa = tipKursa;
        }
    }

    public class MentorPregled
    {
        public int Id { get; set; }
        public string PunoIme { get; set; }

        public MentorPregled(int id, string punoIme)
        {
            this.Id = id;
            this.PunoIme = punoIme;
        }

        // Ovo je važno da bi ComboBox znao šta da prikaže
        public override string ToString()
        {
            return this.PunoIme;
        }
    }

    public class CasPregled
    {
        public int Id { get; set; }
        public DateTime Termin { get; set; }
        public string Tema { get; set; }
        public string Ucionica { get; set; } // Prikazaćemo i u kojoj je učionici

        public CasPregled(int id, DateTime termin, string tema, string ucionica)
        {
            this.Id = id;
            this.Termin = termin;
            this.Tema = tema;
            this.Ucionica = ucionica;
        }
    }

    public class KomisijaPregled
    {
        public int Id { get; set; }
        public string Opis { get; set; } // Da bi bilo lakše za prikaz

        public KomisijaPregled(int id)
        {
            this.Id = id;
            this.Opis = $"Komisija (ID: {id})";
        }
    }
}