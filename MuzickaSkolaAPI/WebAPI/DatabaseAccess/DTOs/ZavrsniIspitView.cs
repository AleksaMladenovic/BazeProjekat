using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class ZavrsniIspitView
    {
        public int Id { get; set; }
        public int? Ocena { get; set; } 
        public bool Sertifikat { get; set; }
        public DateTime Datum { get; set; }

        public string PolaznikPunoIme { get; set; }
        public string NazivKursa { get; set; }
        public int IdKomisije { get; set; } 
        public ZavrsniIspitView() { }

        internal ZavrsniIspitView(ZavrsniIspit? zi)
        {
            if (zi != null)
            {
                this.Id = zi.Id;
                this.Ocena = zi.Ocena;
                this.Sertifikat = zi.Sertifikat;
                this.Datum = zi.Datum;

                // Izvlačimo podatke iz povezanih entiteta, uz provere za null
                if (zi.PolazePolaznik?.OsnovniPodaci != null)
                {
                    this.PolaznikPunoIme = $"{zi.PolazePolaznik.OsnovniPodaci.Ime} {zi.PolazePolaznik.OsnovniPodaci.Prezime}";
                }
                else
                {
                    this.PolaznikPunoIme = "N/A";
                }

                if (zi.KursKojiSePolaze != null)
                {
                    this.NazivKursa = zi.KursKojiSePolaze.Naziv;
                }
                else
                {
                    this.NazivKursa = "N/A";
                }

                if (zi.OcenjujeKomisija != null)
                {
                    this.IdKomisije = zi.OcenjujeKomisija.Id;
                }
            }
        }

    }
    public class ZavrsniIspitCreateView
    {
        public int IdKursa { get; set; }
        public int IdKomisije { get; set; }

        public DateTime Datum { get; set; }
        public int Ocena { get; set; }
        public bool Sertifikat { get; set; }
    }
}
