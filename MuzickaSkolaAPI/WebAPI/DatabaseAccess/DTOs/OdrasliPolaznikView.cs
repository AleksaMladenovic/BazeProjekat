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

        internal OdrasliPolaznikView(OdrasliPolaznik? op) : base(op) 
        {
            if (op != null)
            {
                this.Zanimanje = op.Zanimanje;
            }
        }
    }
    public class OdrasliPolaznikCreateView
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }

        public string? Zanimanje { get; set; }
    }
    public class OdrasliPolaznikUpdateView
    {
        public int IdOsobe { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public string? Zanimanje { get; set; }
    }
}
