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
                    NHibernateUtil.Initialize(n.VodiKurseve);
                    NHibernateUtil.Initialize(n.DrziCasove);
                    NHibernateUtil.Initialize(n.KomisijeCijiJeClan);
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

        public static List<KursPregled> VratiSveKurseveNastavnika(int nastavnikId)
        {
            List<KursPregled> rezultat = new List<KursPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                // 1. Učitavamo kompletan objekat nastavnika iz baze
                Nastavnik n = (Nastavnik)s.Get<Honorarac>(nastavnikId) ?? s.Get<StalnoZaposlen>(nastavnikId);

                if (n != null)
                {
                    // 2. KLJUČAN KORAK: "Budimo" kolekciju kurseva PRE zatvaranja sesije
                    //    da bismo izbegli LazyInitializationException.
                    NHibernateUtil.Initialize(n.VodiKurseve);

                    // 3. Sada kada je kolekcija učitana, prolazimo kroz nju
                    foreach (Kurs k in n.VodiKurseve)
                    {
                        string tipKursa = "Nepoznat";
                        if (k is MuzickaTeorijaKurs) tipKursa = "Muzička teorija";
                        else if (k is InstrumentKurs) tipKursa = "Instrument";
                        else if (k is GrupaInstrumenataKurs) tipKursa = "Grupa instrumenata";
                        else if (k is IndividualnoPevanje) tipKursa = "Individualno pevanje";
                        else if (k is HorskoPevanjeKurs) tipKursa = "Horsko pevanje";

                        rezultat.Add(new KursPregled(k.Id, k.Naziv, k.Nivo,tipKursa));
                    }
                }
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
            finally
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
            }
            return rezultat;
        }

        public static List<MentorPregled> VratiSveMoguceMentore()
        {
            List<MentorPregled> rezultat = new List<MentorPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                // Povlačimo sve stalno zaposlene, jer samo oni mogu biti mentori
                IEnumerable<StalnoZaposlen> mentori = s.Query<StalnoZaposlen>().ToList();

                foreach (var sz in mentori)
                {
                    rezultat.Add(new MentorPregled(sz.Id, $"{sz.OsnovniPodaci.Ime} {sz.OsnovniPodaci.Prezime}"));
                }
            }
            catch (Exception ec) {
                string errorMessage = "Došlo je do greške:" + Environment.NewLine + ec.Message;
                if (ec.InnerException != null)
                {
                    errorMessage += Environment.NewLine + "Unutrašnja greška:" + Environment.NewLine + ec.InnerException.Message;
                }
                MessageBox.Show(errorMessage);
            }
            finally { if (s != null) s.Close(); }

            return rezultat;
        }

        public static void DodeliMentora(int nastavnikId, int mentorId)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                // 1. Učitamo nastavnika kojem dodeljujemo mentora
                Osoba ucenik = s.Load<Osoba>(nastavnikId);

                // 2. Učitamo nastavnika koji postaje mentor
                StalnoZaposlen mentor = s.Load<StalnoZaposlen>(mentorId);

                // 3. Povežemo ih
                ucenik.Mentor = mentor;

                // 4. s.Update() nije potreban, Commit će snimiti promenu
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

        public static List<CasPregled> VratiSveCasoveNastavnika(int nastavnikId)
        {
            List<CasPregled> rezultat = new List<CasPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Nastavnik n = (Nastavnik)s.Get<Honorarac>(nastavnikId) ?? s.Get<StalnoZaposlen>(nastavnikId);

                if (n != null)
                {
                    // "Budimo" kolekciju časova pre zatvaranja sesije
                    NHibernateUtil.Initialize(n.DrziCasove);

                    foreach (Cas c in n.DrziCasove)
                    {
                        // Formiramo string za prikaz učionice
                        string ucionicaInfo = "N/A";
                        if (c.UcionicaOdrzavnja != null && c.UcionicaOdrzavnja.Id != null)
                        {
                            ucionicaInfo = $"{c.UcionicaOdrzavnja.Id.Naziv}, {c.UcionicaOdrzavnja.Id.PripadaLokaciji.Adresa}";
                        }

                        rezultat.Add(new CasPregled(c.Id, c.Termin, c.Tema, ucionicaInfo));
                    }
                }
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
            finally
            {
                if (s != null) s.Close();
            }
            return rezultat;
        }

        public static List<KomisijaPregled> VratiSveKomisije()
        {
            List<KomisijaPregled> rezultat = new List<KomisijaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Komisija> komisije = s.Query<Komisija>().ToList();
                foreach (var k in komisije)
                {
                    rezultat.Add(new KomisijaPregled(k.Id));
                }
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
            finally { if (s != null) s.Close(); }
            return rezultat;
        }

        // Metoda koja snima izmene u članstvu
        public static void SacuvajIzmeneZaKomisije(int nastavnikId, List<int> noveKomisijeIds)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                s.BeginTransaction();

                Nastavnik n = (Nastavnik)s.Get<Honorarac>(nastavnikId) ?? s.Get<StalnoZaposlen>(nastavnikId);

                if (n != null)
                {

                    // 1. Prvo brišemo sve postojeće veze
                    n.KomisijeCijiJeClan.Clear();

                    // 2. Zatim dodajemo nove veze
                    foreach (int komisijaId in noveKomisijeIds)
                    {
                        Komisija k = s.Load<Komisija>(komisijaId);
                        n.KomisijeCijiJeClan.Add(k);
                    }

                    // s.Update(n) nije neophodan, Commit će snimiti promene u kolekciji
                    s.Transaction.Commit();
                }
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


        // Metoda koja vraća sve ispite za jednu odabranu komisiju
        public static List<ZavrsniIspitPregled> VratiIspiteZaKomisiju(int komisijaId)
        {
            List<ZavrsniIspitPregled> rezultat = new List<ZavrsniIspitPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Komisija k = s.Get<Komisija>(komisijaId);

                if (k != null)
                {
                    // "Budimo" sve potrebne objekte pre zatvaranja sesije da izbegnemo greške
                    NHibernateUtil.Initialize(k.IspitiKojeOcenjuje);
                    foreach (var ispit in k.IspitiKojeOcenjuje)
                    {
                        NHibernateUtil.Initialize(ispit.Id.IspitIzKursa);
                        NHibernateUtil.Initialize(ispit.PolazePolaznik);
                        NHibernateUtil.Initialize(ispit.PolazePolaznik.OsnovniPodaci);
                    }

                    // Sada kada je sve učitano, pravimo DTO-e
                    foreach (var ispit in k.IspitiKojeOcenjuje)
                    {
                        rezultat.Add(new ZavrsniIspitPregled(ispit));
                    }
                }
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
            finally
            {
                if (s != null) s.Close();
            }
            return rezultat;
        }
    }
}