using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
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
    public class KursPregled
    {
        public int IdKursa { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; } 
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
