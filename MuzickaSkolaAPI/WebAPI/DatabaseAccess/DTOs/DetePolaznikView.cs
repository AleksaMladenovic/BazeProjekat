using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class DetePolaznikView : PolaznikView
    {
        public string? Jbd { get; set; }

        public string? RoditeljPunoIme { get; set; }

        public DetePolaznikView() { }

        internal DetePolaznikView(DetePolaznik? dp) : base(dp) 
        {
            if (dp != null)
            {
                this.Jbd = dp.Jbd;

                if (dp.PrijavioRoditelj?.OsnovniPodaci != null)
                {
                    this.RoditeljPunoIme = $"{dp.PrijavioRoditelj.OsnovniPodaci.Ime} {dp.PrijavioRoditelj.OsnovniPodaci.Prezime}";
                }
            }
        }
    }
    public class DetePolaznikCreateView
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }

        public string? Jbd { get; set; }
        public int IdRoditelja { get; set; }
    }

    public class DetePolaznikUpdateView
    {
        public int IdOsobe { get; set; } 

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public string? Jbd { get; set; }
        public int IdRoditelja { get; set; }
    }
}
