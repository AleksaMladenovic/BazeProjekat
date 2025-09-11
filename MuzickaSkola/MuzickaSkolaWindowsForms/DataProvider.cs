using MuzickaSkolaWindowsForms.Entiteti; // Možda vam treba i ovaj
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MuzickaSkolaWindowsForms
{
    public static class DataProvider
    {
        /*public static List<NastavnikPregled> VratiSveNastavnike()
        {


            List<NastavnikPregled> rezultat = new List<NastavnikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();


                IEnumerable<Honorarac> honorarac = s.Query<Honorarac>().ToList();

                foreach (var op in honorarac)
                {
                    // SQL query – vrati strucnu spremu iz OSOBA


                    rezultat.Add(new NastavnikPregled(
                        op.OsnovniPodaci.Id,
                        op.OsnovniPodaci.Jmbg,
                        op.OsnovniPodaci.Ime,
                        op.OsnovniPodaci.Prezime,
                        op.OsnovniPodaci.StrucnaSprema,
                        "Honorarac")
                    {
                        BrojCasova = op.BrojCasova,
                        StrucnaSprema = op.OsnovniPodaci.StrucnaSprema,
                        TrajanjeUgovora = op.TrajanjeUgovora,
                        BrojUgovora = op.BrojUgovora,
                        DatumZaposlenja = op.OsnovniPodaci.DatumZaposlenja,
                    });
                }


                IEnumerable<StalnoZaposlen> stalno = s.Query<StalnoZaposlen>().ToList();

                foreach (var dp in stalno)
                {


                    rezultat.Add(new NastavnikPregled(dp.OsnovniPodaci.Id, dp.OsnovniPodaci.Jmbg, dp.OsnovniPodaci.Ime, dp.OsnovniPodaci.Prezime, dp.OsnovniPodaci.StrucnaSprema, "Stalno Zaposleni")
                    {
                        RadnoVreme = dp.RadnoVreme,

                        DatumZaposlenja = dp.OsnovniPodaci.DatumZaposlenja,

                    });
                }

                s.Close();
            }
            catch (Exception ec)
            {
                string errorMessage = "Došlo je do greške:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }

            return rezultat;


        }*/

        // U DataProvider.cs

        public static List<NastavnikPregled> VratiSveNastavnike()
        {
            List<NastavnikPregled> rezultat = new List<NastavnikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                // Učitavamo sve honorarce
                var honorarci = s.Query<Honorarac>().ToList();
                foreach (var h in honorarci)
                {
                    // Koristimo inicijalizator objekta da popunimo SVE propertije
                    rezultat.Add(new NastavnikPregled()
                    {
                        Id = h.Id,
                        Jmbg = h.OsnovniPodaci.Jmbg,
                        Ime = h.OsnovniPodaci.Ime,
                        Prezime = h.OsnovniPodaci.Prezime,
                        Adresa = h.OsnovniPodaci.Adresa,     
                        Telefon = h.OsnovniPodaci.Telefon,   
                        Email = h.OsnovniPodaci.Email,       
                        StrucnaSprema = h.OsnovniPodaci.StrucnaSprema,
                        DatumZaposlenja = h.OsnovniPodaci.DatumZaposlenja,
                        TipZaposlenja = "Honorarac",
                        BrojUgovora = h.BrojUgovora,
                        TrajanjeUgovora = h.TrajanjeUgovora,
                        BrojCasova = h.BrojCasova
                    });
                }

                // Učitavamo sve stalno zaposlene
                var stalnoZaposleni = s.Query<StalnoZaposlen>().ToList();
                foreach (var sz in stalnoZaposleni)
                {
                    // Koristimo inicijalizator objekta da popunimo SVE propertije
                    rezultat.Add(new NastavnikPregled()
                    {
                        Id = sz.Id,
                        Jmbg = sz.OsnovniPodaci.Jmbg,
                        Ime = sz.OsnovniPodaci.Ime,
                        Prezime = sz.OsnovniPodaci.Prezime,
                        Adresa = sz.OsnovniPodaci.Adresa,     
                        Telefon = sz.OsnovniPodaci.Telefon,   
                        Email = sz.OsnovniPodaci.Email,       
                        StrucnaSprema = sz.OsnovniPodaci.StrucnaSprema,
                        DatumZaposlenja = sz.OsnovniPodaci.DatumZaposlenja,
                        TipZaposlenja = "Stalno zaposlen",
                        RadnoVreme = sz.RadnoVreme
                    });
                }
                s.Close();
            }
            catch (Exception ec)
            {
                string errorMessage = "Došlo je do greške:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }

            return rezultat;
        }


        public static void DodajNastavnika(Osoba osoba, Nastavnik nastavnik)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                // 1. Prvo snimamo OsnovnePodatke (Osoba).
                //    Baza će sama generisati ID za nju.
                s.Save(osoba);

                // 2. Sada kada Osoba ima ID, povezujemo Nastavnika sa njom.
                //    Ovo je ključno za one-to-one vezu.
                nastavnik.OsnovniPodaci = osoba;
                nastavnik.Id = osoba.Id; // Ručno postavljamo isti ID

                // 3. Na kraju, snimamo specifičan tip nastavnika (Honorarac ili StalnoZaposlen).
                //    NHibernate će na osnovu tipa znati u koju tabelu da upiše (HONORARAC ili STALNO_ZAP).
                s.Save(nastavnik);

                s.Transaction.Commit();
            }
            catch (Exception ec)
            {
                // U slučaju greške, poništi sve promene
                s?.Transaction.Rollback();

                // Prikazujemo detaljnu poruku o grešci
                string errorMessage = "Došlo je do greške prilikom snimanja:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
            }
        }

        // U DataProvider.cs

        public static void ObrisiNastavnika(int idNastavnika)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                // KORAK 1: Pokušaj da učitaš i obrišeš kao Honorarac
                Honorarac honoraracZaBrisanje = s.Get<Honorarac>(idNastavnika);
                if (honoraracZaBrisanje != null)
                {
                    // Našli smo ga, brišemo ga
                    s.Delete(honoraracZaBrisanje);
                }
                else
                {
                    // Nije bio Honorarac, mora da je StalnoZaposlen
                    StalnoZaposlen szZaBrisanje = s.Get<StalnoZaposlen>(idNastavnika);
                    if (szZaBrisanje != null)
                    {
                        // Našli smo ga, brišemo ga
                        s.Delete(szZaBrisanje);
                    }
                }

                // KORAK 2: Sada kada je "dete" (uloga) obrisano, brišemo i osnovne podatke.
                // Ovo je neophodno jer Cascade ne radi uvek kako treba u ovom scenariju.
                Osoba osobaZaBrisanje = s.Get<Osoba>(idNastavnika);
                if (osobaZaBrisanje != null)
                {
                    s.Delete(osobaZaBrisanje);
                }

                s.Transaction.Commit();
            }
            catch (Exception ec)
            {
                s?.Transaction.Rollback();

                string errorMessage = "Došlo je do greške prilikom brisanja:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
            }
        }

        public static Nastavnik VratiNastavnika(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Nastavnik n = (Nastavnik)s.Get<Honorarac>(id) ?? s.Get<StalnoZaposlen>(id);

                if (n != null)
                {
                    NHibernateUtil.Initialize(n.OsnovniPodaci);
                }
                return n;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
                return null;
            }
            finally
            {
                if (s != null) s.Close();
            }
        }

        // NOVA, KOMPLETNA METODA ZA IZMENU
        public static void IzmeniNastavnika(Nastavnik nastavnikKojiSeMenja)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                // Pošto je objekat `nastavnikKojiSeMenja` došao iz prethodne sesije,
                // koristimo s.Update() da ga "zakačimo" za novu sesiju i snimimo promene.
                // Moramo da uradimo Update za oba dela objekta.
                s.Update(nastavnikKojiSeMenja.OsnovniPodaci);
                s.Update(nastavnikKojiSeMenja);

                s.Transaction.Commit();
            }
            catch (Exception ec)
            {
                s?.Transaction.Rollback();
                string errorMessage = "Došlo je do greške:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }
            finally
            {
                if (s != null) s.Close();
            }
        }
    }
}