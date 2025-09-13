using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;
using System.Linq;

namespace DatabaseAccess.DTOs
{
    public class UcionicaView
    {
        public string AdresaLokacije { get; set; }
        public string Naziv { get; set; }

        public string? Opremljenost { get; set; }
        public int Kapacitet { get; set; }

        public int BrojZakazanihCasova { get; set; }

        public string PunoImeUcionice
        {
            get { return $"{Naziv} ({AdresaLokacije})"; }
        }

        public UcionicaView() { }

        internal UcionicaView(Ucionica? u)
        {
            if (u != null)
            {
                if (u.Id != null)
                {
                    this.Naziv = u.Id.Naziv;

                    if (u.Id.PripadaLokaciji != null)
                    {
                        this.AdresaLokacije = u.Id.PripadaLokaciji.Adresa;
                    }
                }

                this.Opremljenost = u.Opremljenost;
                this.Kapacitet = u.Kapacitet;

                this.BrojZakazanihCasova = u.CasoviKojiSeOdrzavaju?.Count ?? 0;
            }
        }
    }
}
