using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class OdrasliPolaznikView : PolaznikView
    {
        public string? Zanimanje { get; set; }

        public OdrasliPolaznikView() { }

        internal OdrasliPolaznikView(OdrasliPolaznik? op) : base(op) // Poziva konstruktor bazne klase PolaznikView
        {
            if (op != null)
            {
                this.Zanimanje = op.Zanimanje;
            }
        }
    }
}
