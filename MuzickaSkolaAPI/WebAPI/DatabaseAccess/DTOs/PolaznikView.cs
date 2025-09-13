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
    }
}
