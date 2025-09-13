using MuzickaSkolaWindowsForms.Entiteti;
using ProdavnicaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public abstract class NastavnikView
    {
        public OsobaView OsnovniPodaci { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string StrucnaSprema { get; set; }
        public string? MentorPunoIme { get; set; }

        public int BrojCasovaKojeDrzi { get; set; }
        public int BrojKursevaKojeVodi { get; set; }

        public NastavnikView() { }

        internal NastavnikView(Nastavnik? n)
        {
            if (n != null)
            {
                this.OsnovniPodaci = new OsobaView(n.OsnovniPodaci);

                this.DatumZaposlenja = n.OsnovniPodaci.DatumZaposlenja;
                this.StrucnaSprema = n.OsnovniPodaci.StrucnaSprema;
                this.MentorPunoIme = n.OsnovniPodaci.Mentor!= null ? $"{n.OsnovniPodaci.Mentor.OsnovniPodaci.Ime} {n.OsnovniPodaci.Prezime}" : "Nema mentora";

                this.BrojCasovaKojeDrzi = n.DrziCasove?.Count ?? 0;
                this.BrojKursevaKojeVodi = n.VodiKurseve?.Count ?? 0;
            }
        }

        public static NastavnikView KreirajNastavnikView(Nastavnik? nastavnikEntitet)
        {
            if (nastavnikEntitet == null)
            {
                return null;
            }

            if (nastavnikEntitet is StalnoZaposlen sz)
            {
                return new StalnoZaposlenView(sz);
            }
            else if (nastavnikEntitet is Honorarac h)
            {
                return new HonoraracView(h);
            }
            else
            {
                throw new ArgumentException("Nepoznat tip nastavnika.", nameof(nastavnikEntitet));
            }
        }


        public static NastavnikView VratiNastavnika(int nastavnikId)
        {
            NastavnikView nastavnikView = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Nastavnik nastavnikEntitet = s.Get<Nastavnik>(nastavnikId);

                if (nastavnikEntitet != null)
                {
                    if (nastavnikEntitet is StalnoZaposlen sz)
                    {
                        NHibernateUtil.Initialize(sz.JeMentor);

                        nastavnikView = new StalnoZaposlenView(sz);
                    }
                    else if (nastavnikEntitet is Honorarac h)
                    {
                        nastavnikView = new HonoraracView(h);
                    }
                }
            }
            catch (Exception ex) { throw; }
            finally { s?.Close(); }

            return nastavnikView;
        }
    }


}
