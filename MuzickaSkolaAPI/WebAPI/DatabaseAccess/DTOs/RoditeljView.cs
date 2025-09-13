using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class RoditeljView
    {
        public OsobaView OsnovniPodaci { get; set; }

        public IList<DetePolaznikView> Deca { get; set; }

        public int BrojDece { get; set; }

        public RoditeljView()
        {
            Deca = new List<DetePolaznikView>();
        }
        internal RoditeljView(Roditelj? r)
        {
            if (r != null)
            {
                this.OsnovniPodaci = new OsobaView(r.OsnovniPodaci);

                if (r.Deca != null)
                {
                    this.Deca = r.Deca.Select(dete => new DetePolaznikView(dete)).ToList();
                }
                this.BrojDece = r.Deca?.Count ?? 0;
            }
        }
    }
}
