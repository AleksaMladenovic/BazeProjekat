using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class OsobaView
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }

        public bool FPolaznik { get; set; }
        public bool FRoditelj { get; set; }
        public bool FNastavnik { get; set; }

        public DateTime? DatumZaposlenja { get; set; }
        public string? StrucnaSprema { get; set; }

        public string? MentorPunoIme { get; set; }

        public PolaznikView? UlogaPolaznik { get; set; }
        public NastavnikView? UlogaNastavnik { get; set; }
        public RoditeljView? UlogaRoditelj { get; set; }

        public OsobaView() { }

        internal OsobaView(Osoba? o)
        {
            if (o != null)
            {
                this.Id = o.Id;
                this.Jmbg = o.Jmbg;
                this.Ime = o.Ime;
                this.Prezime = o.Prezime;
                this.Adresa = o.Adresa;
                this.Telefon = o.Telefon;
                this.Email = o.Email;

                this.FPolaznik = o.FPolaznik;
                this.FRoditelj = o.FRoditelj;
                this.FNastavnik = o.FNastavnik;

                this.DatumZaposlenja = o.DatumZaposlenja;
                this.StrucnaSprema = o.StrucnaSprema;

                if (o.Mentor != null)
                {
                    this.MentorPunoIme = $"{o.Mentor.OsnovniPodaci.Ime} {o.Mentor.OsnovniPodaci.Prezime}";
                }

                if (o.UlogaPolaznik != null)
                {
                    if (o.UlogaPolaznik is DetePolaznik dp)
                    {
                        this.UlogaPolaznik = new DetePolaznikView(dp);
                    }
                    else if (o.UlogaPolaznik is OdrasliPolaznik op)
                    {
                        this.UlogaPolaznik = new OdrasliPolaznikView(op);
                    }
                }

                if (o.UlogaNastavnik != null)
                {
                    if (o.UlogaNastavnik is StalnoZaposlen sz)
                    {
                        this.UlogaNastavnik = new StalnoZaposlenView(sz);
                    }
                    else if (o.UlogaNastavnik is Honorarac h)
                    {
                        this.UlogaNastavnik = new HonoraracView(h);
                    }
                }

                if (o.UlogaRoditelj != null)
                {
                    this.UlogaRoditelj = new RoditeljView(o.UlogaRoditelj);
                }
            }
        }
    }
}
