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
}
