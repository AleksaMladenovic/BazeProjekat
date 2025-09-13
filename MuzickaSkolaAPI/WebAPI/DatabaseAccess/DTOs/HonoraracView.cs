using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class HonoraracView : NastavnikView
    {
        public string BrojUgovora { get; set; }
        public string TrajanjeUgovora { get; set; }
        public int? BrojCasova { get; set; }

        public HonoraracView() { }

        internal HonoraracView(Honorarac? h) : base(h) 
        {
            if (h != null)
            {
                this.BrojUgovora = h.BrojUgovora;
                this.TrajanjeUgovora = h.TrajanjeUgovora;
                this.BrojCasova = h.BrojCasova;
            }
        }
    }
}
