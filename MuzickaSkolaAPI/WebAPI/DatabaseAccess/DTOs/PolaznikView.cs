using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public abstract class PolaznikView
    {
        public OsobaView OsnovniPodaci { get; set; }

        public int BrojPrijavljenihKurseva { get; set; }
        public int BrojPolozenihIspita { get; set; }
        public int BrojPrisustvaNaCasovima { get; set; }

        public string TipPolaznika { get; set; }

        public PolaznikView() { }

        internal PolaznikView(Polaznik? p)
        {
            if (p != null)
            {
                this.OsnovniPodaci = new OsobaView(p.OsnovniPodaci);

                this.BrojPrijavljenihKurseva = p.PrijavljeniKursevi?.Count ?? 0;
                this.BrojPolozenihIspita = p.PolozeniIspiti?.Count ?? 0;
                this.BrojPrisustvaNaCasovima = p.PrisustvoNaCasovima?.Count ?? 0;

                if (p is OdrasliPolaznik) this.TipPolaznika = "Odrasli polaznik";
                else if (p is DetePolaznik) this.TipPolaznika = "Dete";
                else this.TipPolaznika = "Nedefinisan";
            }
        }
        public class PolaznikUpdateView
        {
            public int IdOsobe { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Jmbg { get; set; }
            public string? Adresa { get; set; }
            public string? Telefon { get; set; }
            public string? Email { get; set; }
            public string? Zanimanje { get; set; }
            public string? Jbd { get; set; }
            public int? IdRoditelja { get; set; }
        }
    }
}
