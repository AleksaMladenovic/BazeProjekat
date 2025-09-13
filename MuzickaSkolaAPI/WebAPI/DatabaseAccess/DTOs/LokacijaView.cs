using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class LokacijaView
    {
        public string Adresa { get; set; }
        public string RadnoVreme { get; set; }

        public IList<UcionicaView> Ucionice { get; set; }
        public IList<KursView> KurseviKojiSeOdrzavaju { get; set; }

        public LokacijaView()
        {
            Ucionice = new List<UcionicaView>();
            KurseviKojiSeOdrzavaju = new List<KursView>();
        }

        internal LokacijaView(Lokacija? l)
        {
            if (l != null)
            {
                this.Adresa = l.Adresa;
                this.RadnoVreme = l.RadnoVreme;

                if (l.Ucionice != null)
                {
                    this.Ucionice = l.Ucionice.Select(u => new UcionicaView(u)).ToList();
                }

                if (l.KurseviKojiSeOdrzavaju != null)
                {
                    this.KurseviKojiSeOdrzavaju = l.KurseviKojiSeOdrzavaju.Select(k => new KursView(k)).ToList();
                }
            }
        }
    }
}
