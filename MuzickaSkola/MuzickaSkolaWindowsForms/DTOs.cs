using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
    #region Lokacija
    public class LokacijaPregled {
        public string Adresa { get; set; }
        public int Kapacitet { get; set; }
        public string RadnoVreme { get; set; }

        public LokacijaPregled()
        {

        }
        public LokacijaPregled(string adresa, int kapacitet, string radnoVreme)
        {
            Adresa = adresa;
            Kapacitet = kapacitet;
            RadnoVreme = radnoVreme;
        }
    }

    public class LokacijaBasic {
        public string Adresa { get; set; }
        public string RadnoVreme { get; set; }

        public LokacijaBasic() { }

        public LokacijaBasic(string adresa, string radnoVreme)
        {
            Adresa = adresa;
            RadnoVreme = radnoVreme;
        }
    }

    #endregion

    #region Ucionica

    public class UcionicaPregled() {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public string Opremljenost{ get; set; }
        public string AdresaLokacije{ get; set; }
    }

    public class UcionicaBasic() 
    {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public string Opremljenost { get; set; }
        public string AdresaLokacije { get; set; }
    }

    #endregion

    #region Kurs

    public class KursPregled
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string ImeNastavnika { get; set; }
        public string TipKursa { get; set; }
    }

    public class KursBasic
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string ImeNastavnika { get; set; }
        public string TipKursa { get; set; }

        public string? Instrument { get; set; }
        public string? GrupaInstrumenata { get; set; }
        public string? NazivPredmeta { get; set; }
    }
    #endregion Kurs

    #region Nastavnik
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

    #endregion
    #region Polaznik

    public class PolaznikPregled
    {
        public int IdOsobe { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string TipPolaznika { get; set; } 

        
        public string? Zanimanje { get; set; }
        public string? Jbd { get; set; }
        public string? ImeRoditelja { get; set; } 

        // Konstruktor za lakše kreiranje
        public PolaznikPregled(int id, string jmbg, string ime, string prezime, string tip)
        {
            this.IdOsobe = id;
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
            this.TipPolaznika = tip;
        }

        public PolaznikPregled() { }
    }

    public abstract class PolaznikBasic
    {
        // Osnovni podaci o osobi
        public int IdOsobe { get; set; }
        public string? Jmbg { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }

   
        //public IList<KursPregled> PrijavljeniKursevi { get; set; }
        //public IList<PrisustvoPregled> PrisustvaNaCasovima { get; set; }

        //protected PolaznikBasic()
        //{
        //    PrijavljeniKursevi = new List<KursPregled>();
        //    PrisustvaNaCasovima = new List<PrisustvoPregled>();
        //}
    }

    public class OdrasliPolaznikBasic : PolaznikBasic
    {
        public string? Zanimanje { get; set; }
    }

    public class DetePolaznikBasic : PolaznikBasic
    {
        public string? Jbd { get; set; }

        
        public int IdRoditelja { get; set; }
        public string? PunoImeRoditelja { get; set; } 
    }

    
    public class RoditeljPregled
    {
        public int IdOsobe { get; set; }
        public string? PunoIme { get; set; } // "Ime Prezime"

        public override string ToString()
        {
            return PunoIme; 
        }
    }
    public class RoditeljListItem
    {
        public int IdOsobe { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }

    public class PrisustvoPregled
    {
        public int IdPolaznika { get; set; }
        public int IdCasa { get; set; }
        public DateTime? Termin { get; set; }
        public string Tema { get; set; }
        public int Ocena { get; set; }
    }

    public class ZavrsniIspitPregled
    {
        public int IdKursa { get; set; }
        public string NazivKursa { get; set; }
        public DateTime Datum { get; set; }   
        public int? Ocena { get; set; }
        public bool? Sertifikat { get; set; }
    }
    #endregion
}
