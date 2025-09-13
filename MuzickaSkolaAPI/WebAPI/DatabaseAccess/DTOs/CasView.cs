using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class CasView
    {
        public int Id { get; set; }
        public DateTime Termin { get; set; }
        public string? Tema { get; set; }

        public NastavnikView? DrziNastavnik { get; set; }
        public UcionicaView? UcionicaOdrzavanja { get; set; }

        public int BrojPrisutnihPolaznika { get; set; }

        public CasView() { }

        internal CasView(Cas? c)
        {
            if (c != null)
            {
                this.Id = c.Id;
                this.Termin = c.Termin;
                this.Tema = c.Tema;

                if (c.DrziNastavnik != null)
                { 
                    this.DrziNastavnik = NastavnikView.KreirajNastavnikView(c.DrziNastavnik);
                }

                if (c.UcionicaOdrzavnja != null)
                {
                    this.UcionicaOdrzavanja = new UcionicaView(c.UcionicaOdrzavnja);
                }

                this.BrojPrisutnihPolaznika = c.PrisutniPolaznici?.Count ?? 0;
            }
        }
    }
}
