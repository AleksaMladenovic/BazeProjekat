using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MuzickaSkolaWindowsForms.Entiteti;
using FluentNHibernate.Utils;
using FluentNHibernate.Conventions;
using NHibernate.Linq;
using Antlr.Runtime.Tree;


namespace MuzickaSkolaWindowsForms
{
    public static class DTOManager
    {
        
        #region Lokacija
        public static List<LokacijaPregled> VratiSveLokacije()
        {
            List<LokacijaPregled> lokacijePregled = new List<LokacijaPregled>();
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();

                IEnumerable<MuzickaSkolaWindowsForms.Entiteti.Lokacija> sveLokacije = s.Query<Lokacija>().ToList();

                foreach (var lok in sveLokacije)
                {
                    int sumaKapaciteta = lok.Ucionice.Sum(u => u.Kapacitet);

                    lokacijePregled.Add(new LokacijaPregled(lok.Adresa, sumaKapaciteta, lok.RadnoVreme));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                s?.Close();
            }
            return lokacijePregled;
        }

        public static List<LokacijaPregled> VratiSveLokacijeZaKurs(int kursId)
        {
            List<LokacijaPregled> lokacijePregled = new List<LokacijaPregled>();
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                Kurs kurs = s.Get<Kurs>(kursId);
                IList<Lokacija> sveLokacijeZaKurs = kurs.LokacijeOdrzavanja;

                foreach (var lok in sveLokacijeZaKurs)
                {
                    int sumaKapaciteta = lok.Ucionice.Sum(u => u.Kapacitet);

                    lokacijePregled.Add(new LokacijaPregled(lok.Adresa, sumaKapaciteta, lok.RadnoVreme));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                s?.Close();
            }
            return lokacijePregled;
        }

        public static void DodajLokaciju(LokacijaBasic lokacijaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija l = new Lokacija();

                l.Adresa = lokacijaDto.Adresa;
                l.RadnoVreme = lokacijaDto.RadnoVreme;

                s.Save(l);
                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static void DodajLokacijuKursu(string lokacija, int idKursa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static bool DaLiPostojeCasoviZaKursNaLokaciji(int kursId,string adresa)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var casovi = from c in s.Query<Cas>()
                             where c.UcionicaOdrzavnja.Id.PripadaLokaciji.Adresa == adresa && c.PripadaNastavi.PripadaKursu.Id == kursId
                             select c;

                return casovi.Any();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return true;
            }
            finally
            {
                s?.Close();
            }
        }
        public static bool DaLiLokacijaPostoji(string adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija? l = s.Load<Lokacija>(adresa);

                s.Close();

                return l != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return true;
            }
        }
        public static void IzmeniLokaciju(LokacijaBasic lokacijaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija l = s.Load<Lokacija>(lokacijaDto.Adresa);
                l.RadnoVreme = lokacijaDto.RadnoVreme;

                s.Update(l);
                s.Flush();
                s.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }

        }

        public static void AzurirajLokacijeZaKurs(int kursId, List<string> adreseNovihLokacija)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Kurs kurs = s.Get<Kurs>(kursId);

                if (kurs == null)
                {
                    throw new ArgumentException($"Kurs sa ID-jem {kursId} ne postoji.");
                }

                kurs.LokacijeOdrzavanja.Clear();
                
                foreach (string adresa in adreseNovihLokacija)
                {
                    Lokacija lokacija = s.Load<Lokacija>(adresa);

                    kurs.LokacijeOdrzavanja.Add(lokacija);
                }

                s.Update(kurs);
                s.Flush();
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                s?.Close();
            }
        }
        public static LokacijaBasic VratiLokacijuZaIzmenu(string adresa)
        {
            LokacijaBasic novaLokacija = new LokacijaBasic() { Adresa = adresa};
            return novaLokacija;
        }

        public static bool ObrisiLokaciju(string adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija l = s.Load<Lokacija>(adresa);
                s.Delete(l);
                s.Flush();

                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }
        #endregion

        #region Ucionica

        public static List<UcionicaPregled> VratiSveUcioniceZaLokaciju(string adresaLokacije)
        {
            List<UcionicaPregled> ucionicePregled = new List<UcionicaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ucionica> ucionice = from u in s.Query<Ucionica>()
                                                 where u.Id.PripadaLokaciji.Adresa == adresaLokacije
                                                 select u;

                foreach (Ucionica u in ucionice)
                {
                    ucionicePregled.Add(new UcionicaPregled()
                    {
                        Naziv = u.Id.Naziv,
                        Kapacitet = u.Kapacitet,
                        Opremljenost = u.Opremljenost,
                        AdresaLokacije = u.Id.PripadaLokaciji.Adresa,
                    });

                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return ucionicePregled;
        }

        public static List<UcionicaPregled> VratiSveUcioniceNastavu(int nastavaId)
        {
            List<UcionicaPregled> ucionicePregled = new List<UcionicaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                Nastava nastava = s.Get<Nastava>(nastavaId);
                if (nastava == null)
                {
                    return ucionicePregled;
                }
                int kursId = nastava.PripadaKursu.Id;

                Kurs kurs = s.Get<Kurs>(kursId);
                IList<Lokacija> dostupneLokacije = kurs.LokacijeOdrzavanja;

                if (dostupneLokacije.Count == 0)
                {
                    return ucionicePregled;
                }

                List<string> adreseLokacija = dostupneLokacije.Select(l => l.Adresa).ToList();

                IEnumerable<Ucionica> ucionice = s.Query<Ucionica>()
                    .Where(u => adreseLokacija.Contains(u.Id.PripadaLokaciji.Adresa))
                    .ToList();

                foreach (Ucionica u in ucionice)
                {
                    ucionicePregled.Add(new UcionicaPregled()
                    {
                        Naziv = u.Id.Naziv,
                        Kapacitet = u.Kapacitet,
                        Opremljenost = u.Opremljenost,
                        AdresaLokacije = u.Id.PripadaLokaciji.Adresa,
                        PunoImeUcionice = $"{u.Id.Naziv} ({u.Id.PripadaLokaciji.Adresa})"
                    });
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return ucionicePregled;
        }
        public static bool DaLiUcionicaPostoji(string adresaLokacije, string nazivUcionice)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var uc = (from u in s.Query<Ucionica>()
                         where u.Id.PripadaLokaciji.Adresa == adresaLokacije && u.Id.Naziv == nazivUcionice
                         select u).FirstOrDefault();
                s.Close();
                return uc != null;
            }
            catch (Exception)
            {
                // U slučaju greške, bolje je pretpostaviti da postoji da se ne bi desio duplikat
                return true;
            }
        }
        public static void DodajUcionicu(UcionicaBasic ucionicaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija lokacijaEntitet = s.Load<Lokacija>(ucionicaDto.AdresaLokacije);

                var novaUcionica = new Ucionica()
                {
                    Kapacitet = ucionicaDto.Kapacitet,
                    Opremljenost = ucionicaDto.Opremljenost
                };

                novaUcionica.Id.Naziv = ucionicaDto.Naziv;
                novaUcionica.Id.PripadaLokaciji = lokacijaEntitet;

                s.Save(novaUcionica);
                s.Flush();
                s.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static bool ObrisiUcionicu(string adresaLokacije, string nazivUcionice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var idZaBrisanje = new UcionicaId 
                { 
                    Naziv = nazivUcionice , 
                    PripadaLokaciji = s.Load<Lokacija>(adresaLokacije)
                };

                Ucionica ucionicaZaBrisanje = s.Load<Ucionica>(idZaBrisanje);
                s.Delete(ucionicaZaBrisanje);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }

        public static void IzmeniUcionicu(UcionicaBasic ucionicaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var idZaIzmenu = new UcionicaId
                {
                    Naziv = ucionicaDto.Naziv,
                    PripadaLokaciji = s.Load<Lokacija>(ucionicaDto.AdresaLokacije)
                };

                Ucionica ucionicaZaIzmenu = s.Load<Ucionica>(idZaIzmenu);
                ucionicaZaIzmenu.Opremljenost = ucionicaDto.Opremljenost;
                ucionicaZaIzmenu.Kapacitet = ucionicaDto.Kapacitet;

                s.Update(ucionicaZaIzmenu);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static UcionicaBasic VratiUcionicuZaIzmenu(UcionicaPregled ucionicaPregled)
        {
            return new UcionicaBasic()
            {
                Naziv = ucionicaPregled.Naziv,
                Kapacitet = ucionicaPregled.Kapacitet,
                Opremljenost = ucionicaPregled.Opremljenost,
                AdresaLokacije = ucionicaPregled.AdresaLokacije
            };
        }

        public static bool DaLiPostojeUcioniceZaKurs(int kursId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //fetch osigurava da se sve ucita u jednom upitu
                Kurs kurs = s.Query<Kurs>()
                            .Fetch(k => k.LokacijeOdrzavanja)
                            .Where(k => k.Id == kursId)
                            .SingleOrDefault();

                if (kurs == null)
                {
                    return false;
                }

                if (kurs.LokacijeOdrzavanja.Count == 0)
                {
                    return false;
                }


                List<string> adreseLokacija = kurs.LokacijeOdrzavanja.Select(l => l.Adresa).ToList();

                bool imaUcionica = s.Query<Ucionica>()
                                    .Any(u => adreseLokacija.Contains(u.Id.PripadaLokaciji.Adresa));

                return imaUcionica;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }
        #endregion

        #region Kurs

        public static List<KursPregled> VratiSveKurseve()
        {
            List<KursPregled> kurseviPregled = new List<KursPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Kurs> kursevi = s.Query<Kurs>().ToList();

                foreach (var k in kursevi)
                {
                    var Nastavnik = s.Get<Osoba>(k.VodiNastavnik.Id);
                    var noviKurs = new KursPregled()
                    {
                        Id = k.Id,
                        Naziv = k.Naziv,
                        Nivo = k.Nivo,
                        ImeNastavnika = k.VodiNastavnik != null ? $"{Nastavnik.Ime} {Nastavnik.Prezime}" : "Nije dodeljen",
                        NastavnikId = k.Id,
                    };

                    noviKurs.TipKursa = VratiTipKursa(k);
                    kurseviPregled.Add(noviKurs);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return kurseviPregled;
        }

        public static string VratiTipKursa(Kurs kurs)
        {
            if (kurs is InstrumentKurs)
            {
                return "INSTRUMENT";
            }
            else if (kurs is GrupaInstrumenataKurs)
            {
                return "GRUPA_INSTRUMENATA";
            }
            else if (kurs is IndividualnoPevanjeKurs)
            {
                return "INDIVIDUALNO_PEVANJE";
            }
            else if (kurs is HorskoPevanjeKurs)
            {
                return "HORSKO_PEVANJE";
            }
            else if (kurs is MuzickaTeorijaKurs)
            {
                return "MUZICKA_TEORIJA";
            }
            else
            {
                return "NEPOZNAT_TIP";
            }
        }

        public static KursBasic? VratiKursBasic(int kursId)
        {
            KursBasic ?kursBasic = null;
            try
            {
                ISession s = DataLayer.GetSession();

                var kurs = s.Get<Kurs>(kursId);
                if (kurs == null)
                {
                    MessageBox.Show($"Kurs sa id'{kursId}' ne postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var nastavnik = VratiNastavnika(kurs.VodiNastavnik.Id);
                kursBasic = new KursBasic()
                {
                    Id = kurs.Id,
                    Naziv = kurs.Naziv,
                    Nivo = kurs.Nivo,
                    ImeNastavnika = nastavnik.OsnovniPodaci.Ime + " " + nastavnik.OsnovniPodaci.Prezime,
                    NastavnikId = nastavnik.Id,
                    TipKursa = VratiTipKursa(kurs),
                };
                PostaviSpecijalanPropertyKursuBasic(kursBasic,kurs);

                    s.Close();
                return kursBasic;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return kursBasic;
        }


        private static void PostaviSpecijalanPropertyKursuBasic(KursBasic kursBasic, Kurs kurs)
        {
            if (kursBasic.TipKursa == "INSTRUMENT")
                kursBasic.Instrument = ((InstrumentKurs)kurs).Instrument;
            else if (kursBasic.TipKursa == "GRUPA_INSTRUMENATA")
                kursBasic.GrupaInstrumenata = ((GrupaInstrumenataKurs)kurs).GrupaInstrumenata;
            else if (kursBasic.TipKursa == "MUZICKA_TEORIJA")
                kursBasic.NazivPredmeta = ((MuzickaTeorijaKurs)kurs).NazivPredmeta;
        }
        private static void PostaviSpecijalanProperyKursu(KursBasic kursBasic, Kurs kurs)
        {
            if (kursBasic.TipKursa == "INSTRUMENT")
                ((InstrumentKurs)kurs).Instrument = kursBasic.Instrument;
            else if (kursBasic.TipKursa == "GRUPA_INSTRUMENATA")
                ((GrupaInstrumenataKurs)kurs).GrupaInstrumenata = kursBasic.GrupaInstrumenata;
            else if (kursBasic.TipKursa == "MUZICKA_TEORIJA")
                ((MuzickaTeorijaKurs)kurs).NazivPredmeta = kursBasic.NazivPredmeta;
        }


        public static void DodajKurs(KursBasic kursDto, string tipKursa)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Kurs? noviKursEntitet = null;
                switch (tipKursa)
                {
                    case "INSTRUMENT":
                        noviKursEntitet = new InstrumentKurs
                        {
                            // Popunjavamo specifični properti
                            Instrument = kursDto.Instrument
                        };
                        break;

                    case "GRUPA_INSTRUMENATA":
                        noviKursEntitet = new GrupaInstrumenataKurs
                        {
                            GrupaInstrumenata = kursDto.GrupaInstrumenata
                        };
                        break;

                    case "INDIVIDUALNO_PEVANJE":
                        noviKursEntitet = new IndividualnoPevanjeKurs();
                        break;

                    case "HORSKO_PEVANJE":
                        noviKursEntitet = new HorskoPevanjeKurs();
                        break;

                    case "MUZICKA_TEORIJA":
                        noviKursEntitet = new MuzickaTeorijaKurs
                        {
                            NazivPredmeta = kursDto.NazivPredmeta
                        };
                        break;

                    default:
                        throw new ArgumentException($"Tip kursa '{tipKursa}' nije prepoznat.");
                }
                if (noviKursEntitet != null)
                {
                    noviKursEntitet.Naziv = kursDto.Naziv;
                    noviKursEntitet.Nivo = kursDto.Nivo;
                    noviKursEntitet.VodiNastavnik = DTOManager.VratiNastavnika(kursDto.NastavnikId);

                    s.Save(noviKursEntitet);

                }
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static void IzmeniKurs(KursBasic kursDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kurs? kursZaIzmenu = s.Get<Kurs>(kursDto.Id);
                if (kursZaIzmenu == null)
                {
                    MessageBox.Show($"Kurs sa id'{kursDto.Id}' ne postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                kursZaIzmenu.Naziv = kursDto.Naziv;
                kursZaIzmenu.Nivo = kursDto.Nivo;
                PostaviSpecijalanProperyKursu(kursDto, kursZaIzmenu);
                kursZaIzmenu.VodiNastavnik = DTOManager.VratiNastavnika(kursDto.NastavnikId);
                s.Update(kursZaIzmenu);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static bool ObrisiKurs(int KursId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kurs? kursZaBrisanje = s.Get<Kurs>(KursId);
                if (kursZaBrisanje == null)
                { 
                    MessageBox.Show($"Kurs sa id'{KursId}' ne postoji.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                s.Delete(kursZaBrisanje);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }
        #endregion

        #region Nastava

        public static List<NastavaPregled> VratiSvuNastavuZaKurs(int kursId, string tipKursa)
        {
            List<NastavaPregled> nastavePregled = new List<NastavaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                var nastave = from n in s.Query<Nastava>()
                              where n.PripadaKursu.Id == kursId
                              select n;

                string tipNastave = VratiTipNastave(tipKursa);
                foreach (var n in nastave)
                {
                    nastavePregled.Add(new NastavaPregled()
                    {
                        Id = n.Id,
                        DatumOd = n.DatumOd,
                        DatumDo = n.DatumDo,
                        TipNastave = tipNastave,
                    });
                }
                s.Close();
                return nastavePregled;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return nastavePregled;
        }

        public static string VratiTipNastave(string tipKursa)
        {
            if (tipKursa == "INSTRUMENT" || tipKursa == "GRUPA_INSTRUMENATA" || tipKursa == "INDIVIDUALNO_PEVANJE")
            {
                return "Individualna";
            }
            else
            {
                return "Grupna";
            }
        }

        public static bool DodajNastavu(NastavaBasic nastavaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Kurs kursEntitet = s.Get<Kurs>(nastavaDto.IdKursa);

                Nastava nastava = new Nastava()
                {
                    DatumOd = nastavaDto.DatumOd,
                    DatumDo = nastavaDto.DatumDo,
                    FIndividualna = nastavaDto.FIndividualna,
                    FGrupna = nastavaDto.FGrupna,
                    PripadaKursu = kursEntitet,
                };

                
                s.Save(nastava);
                s.Flush();
                s.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }

        }

        public static bool IzmeniNastavu(NastavaBasic nastavaDto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nastava nastava = s.Get<Nastava>(nastavaDto.Id);
                bool postojeCasoviIzvanOpsega = false;
                foreach(var cas in nastava.Casovi)
                {
                    if (cas.Termin < nastavaDto.DatumOd || (nastavaDto.DatumDo.HasValue&&cas.Termin > nastavaDto.DatumDo))
                    {
                        postojeCasoviIzvanOpsega = true;
                    }
                }
                if (postojeCasoviIzvanOpsega)
                {
                    s.Close();
                    MessageBox.Show($"Postoje časovi koji su izvan opsega datuma!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                nastava.DatumDo = nastavaDto.DatumDo;
                nastava.DatumOd = nastavaDto.DatumOd;



                s.Update(nastava);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }

        public static bool ObrisiNastavu(int NastavaId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nastava? nastava = s.Get<Nastava>(NastavaId);
                s.Delete(nastava);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }

        public static List<CasPregled> VratiSveCasoveZaNastavu(int nastavaId)
        {
            List<CasPregled> casoviPregled = new List<CasPregled>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Cas> sviCasovi = from c in s.Query<Cas>()
                                             where c.PripadaNastavi.Id == nastavaId
                                             select c;

                foreach(Cas c in sviCasovi)
                {
                    Nastavnik nastavnik = DTOManager.VratiNastavnika(c.DrziNastavnik.Id);

                    casoviPregled.Add(new CasPregled
                    {
                        Id = c.Id,
                        Termin = c.Termin,
                        Tema = c.Tema,
                        ImeNastavnika = nastavnik != null ? $"{nastavnik.OsnovniPodaci.Ime} {nastavnik.OsnovniPodaci.Prezime}" : "N/A",
                        Ucionica = c.UcionicaOdrzavnja.Id.Naziv,
                        IdNastavnika = nastavnik.Id,
                        Lokacija = c.UcionicaOdrzavnja.Id.PripadaLokaciji.Adresa
                    });
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            return casoviPregled;

        }

        public static bool TerminObuhvataNastava(DateTime termin, int idNastave)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var nastava = s.Get<Nastava>(idNastave);
                bool poslePocetka = termin.Date >= nastava.DatumOd.Date;
                bool preKraja = !nastava.DatumDo.HasValue || termin.Date <= nastava.DatumDo.Value.Date;
                return poslePocetka && preKraja;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }

        public static void DodajCas(CasBasic cas)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                UcionicaId idUcionice = new UcionicaId() { Naziv = cas.Ucionica, PripadaLokaciji = s.Get<Lokacija>(cas.Lokacija) };
                Cas? noviCas = new Cas()
                {
                    Termin = cas.Termin,
                    Tema = cas.Tema,
                    DrziNastavnik = VratiNastavnika(cas.NastavnikId),
                    PripadaNastavi = s.Get<Nastava>(cas.NastavaId),
                    UcionicaOdrzavnja = s.Get<Ucionica>(idUcionice)
                };

                s.Save(noviCas);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static void IzmeniCas(CasBasic cas)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                UcionicaId idUcionice = new UcionicaId() { Naziv = cas.Ucionica, PripadaLokaciji = s.Get<Lokacija>(cas.Lokacija) };
                var casZaMenjanje = s.Get<Cas>(cas.Id);
                casZaMenjanje.Tema = cas.Tema;
                casZaMenjanje.Termin = cas.Termin;
                casZaMenjanje.DrziNastavnik = VratiNastavnika(cas.NastavnikId);
                casZaMenjanje.PripadaNastavi = s.Get<Nastava>(cas.NastavaId);
                casZaMenjanje.UcionicaOdrzavnja = s.Get<Ucionica>(idUcionice);


                s.Update(casZaMenjanje);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
        }

        public static bool ObrisiCas(int casId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var cas = s.Get<Cas>(casId);


                s.Delete(cas);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return false;
            }
        }
        #endregion

        #region Nastavnik
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
                        else if (k is IndividualnoPevanjeKurs) tipKursa = "Individualno pevanje";
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
        public static List<NastavnikPregled> VratiClanoveKomisije(int komisijaId)
        {
            List<NastavnikPregled> rezultat = new List<NastavnikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Komisija k = s.Get<Komisija>(komisijaId);

                if (k != null)
                {
                    // "Budimo" kolekciju članova pre zatvaranja sesije
                    NHibernateUtil.Initialize(k.ClanoviKomisije);

                    // Sada prolazimo kroz listu članova (koji su tipa Osoba)
                    foreach (Osoba clan in k.ClanoviKomisije)
                    {
                        // Za svakog člana, moramo da saznamo da li je Honorarac ili StalnoZaposlen
                        // da bismo ga mogli prikazati u našem DTO-u.
                        Nastavnik detaljiNastavnika = (Nastavnik)s.Get<Honorarac>(clan.Id) ?? s.Get<StalnoZaposlen>(clan.Id);

                        if (detaljiNastavnika != null)
                        {
                            string tip = detaljiNastavnika is StalnoZaposlen ? "Stalno zaposlen" : "Honorarac";
                            // Kreiramo DTO sa svim podacima
                            rezultat.Add(new NastavnikPregled(clan.Id, clan.Jmbg, clan.Ime, clan.Prezime, clan.StrucnaSprema, tip)); // Detalje ostavljamo prazne za sada
                        }
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
            finally { if (s != null) s.Close(); }
            return rezultat;
        }
        #endregion Nastavnik
        #region Polaznik

        public static List<PolaznikPregled> VratiSvePolaznike()
        {
            List<PolaznikPregled> rezultat = new List<PolaznikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();


                IEnumerable<OdrasliPolaznik> odrasli = s.Query<OdrasliPolaznik>().ToList();

                foreach (var op in odrasli)
                {
                    rezultat.Add(new PolaznikPregled(op.OsnovniPodaci.Id, op.OsnovniPodaci.Jmbg, op.OsnovniPodaci.Ime, op.OsnovniPodaci.Prezime, "Odrasli")
                    {
                        Zanimanje = op.Zanimanje
                    });
                }


                IEnumerable<DetePolaznik> deca = s.Query<DetePolaznik>().ToList();

                foreach (var dp in deca)
                {
                    // Proveravamo da li roditelj postoji da izbegnemo grešku
                    string imeRoditelja = (dp.PrijavioRoditelj != null && dp.PrijavioRoditelj.OsnovniPodaci != null)
                                          ? $"{dp.PrijavioRoditelj.OsnovniPodaci.Ime} {dp.PrijavioRoditelj.OsnovniPodaci.Prezime}"
                                          : "N/A";

                    rezultat.Add(new PolaznikPregled(dp.OsnovniPodaci.Id, dp.OsnovniPodaci.Jmbg, dp.OsnovniPodaci.Ime, dp.OsnovniPodaci.Prezime, "Dete")
                    {
                        Jbd = dp.Jbd,
                        ImeRoditelja = imeRoditelja
                    });
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rezultat;

        }
        private static Polaznik DohvatiPolaznika(ISession s, int idOsobe)
        {
            var odr = s.Get<OdrasliPolaznik>(idOsobe);
            if (odr != null) return odr;
            var det = s.Get<DetePolaznik>(idOsobe);
            if (det != null) return det;
            throw new ApplicationException($"Polaznik (ID_OSOBE={idOsobe}) ne postoji.");
        }
        public static void DodajOdraslogPolaznika(OdrasliPolaznikBasic dto)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                
                if (string.IsNullOrWhiteSpace(dto.Ime) || string.IsNullOrWhiteSpace(dto.Prezime) || string.IsNullOrWhiteSpace(dto.Jmbg))
                    throw new ApplicationException("Ime, Prezime i JMBG su obavezni.");

                var o = new Osoba
                {
                    Ime = dto.Ime!,
                    Prezime = dto.Prezime!,
                    Jmbg = dto.Jmbg!,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    Email = dto.Email,
                    FPolaznik = true
                };

                var op = new OdrasliPolaznik
                {
                    OsnovniPodaci = o,
                    Zanimanje = dto.Zanimanje
                };

                
                o.UlogaPolaznik = op;

           
                s.Save(op);

                tx.Commit();
            }
        }
        public static void DodajDetePolaznika(DetePolaznikBasic dto)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var o = new Osoba
                {
                    Ime = dto.Ime!,
                    Prezime = dto.Prezime!,
                    Jmbg = dto.Jmbg!,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    Email = dto.Email,
                    FPolaznik = true
                };

                Roditelj roditelj = null;
                if (dto.IdRoditelja > 0)
                {
                    roditelj = s.Get<Roditelj>(dto.IdRoditelja);
                    if (roditelj == null)
                        throw new ApplicationException($"Roditelj sa ID={dto.IdRoditelja} ne postoji.");
                }

                var dp = new DetePolaznik
                {
                    OsnovniPodaci = o,
                    Jbd = dto.Jbd,
                    PrijavioRoditelj = roditelj 
                };

                s.Save(dp);
                tx.Commit();
            }
        }
        public static void ObrisiPolaznika(int idOsobe, bool obrisiISamuOsobu = false)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                
                var odrasli = s.Get<OdrasliPolaznik>(idOsobe);
               
                var dete = odrasli == null ? s.Get<DetePolaznik>(idOsobe) : null;

                if (odrasli == null && dete == null)
                    throw new ApplicationException($"Polaznik sa ID={idOsobe} ne postoji.");

                
                var osoba = odrasli != null ? odrasli.OsnovniPodaci : dete!.OsnovniPodaci;

                
                if (odrasli != null && odrasli.PrijavljeniKursevi != null)
                    odrasli.PrijavljeniKursevi.Clear();
                if (dete != null && dete.PrijavljeniKursevi != null)
                    dete.PrijavljeniKursevi.Clear();

               
                if (odrasli != null) s.Delete(odrasli); else s.Delete(dete);

                
                if (!obrisiISamuOsobu)
                {
                    
                    var o = s.Get<Osoba>(idOsobe);
                    if (o != null)
                    {
                        o.FPolaznik = false;   
                        s.Update(o);
                    }
                }
                else
                {
                  
                    var o = s.Get<Osoba>(idOsobe);
                    if (o != null)
                    {
                        if (!o.FNastavnik && !o.FRoditelj)   
                            s.Delete(o);
                        else
                        {
                            
                            o.FPolaznik = false;
                            s.Update(o);
                        }
                    }
                }

                tx.Commit();
            }
        }
        public static OdrasliPolaznikBasic VratiOdraslogPolaznika(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                var op = s.Get<OdrasliPolaznik>(idOsobe) ?? throw new ApplicationException("Odrasli polaznik ne postoji.");
                return new OdrasliPolaznikBasic
                {
                    IdOsobe = op.OsnovniPodaci.Id,
                    Ime = op.OsnovniPodaci.Ime,
                    Prezime = op.OsnovniPodaci.Prezime,
                    Jmbg = op.OsnovniPodaci.Jmbg,
                    Adresa = op.OsnovniPodaci.Adresa,
                    Telefon = op.OsnovniPodaci.Telefon,
                    Email = op.OsnovniPodaci.Email,
                    Zanimanje = op.Zanimanje
                };
            }
        }

        public static DetePolaznikBasic VratiDetePolaznika(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                var dp = s.Get<DetePolaznik>(idOsobe)
                         ?? throw new ApplicationException("Dete polaznik ne postoji.");

               
                int idRoditelja = dp.PrijavioRoditelj?.Id ?? 0;
                string? punoImeRoditelja = null;
                if (idRoditelja > 0)
                {
                    var osobaRoditelj = s.Get<Osoba>(idRoditelja); 
                    if (osobaRoditelj != null)
                        punoImeRoditelja = $"{osobaRoditelj.Ime} {osobaRoditelj.Prezime}";
                }
               

                return new DetePolaznikBasic
                {
                    IdOsobe = dp.OsnovniPodaci.Id,
                    Ime = dp.OsnovniPodaci.Ime,
                    Prezime = dp.OsnovniPodaci.Prezime,
                    Jmbg = dp.OsnovniPodaci.Jmbg,
                    Adresa = dp.OsnovniPodaci.Adresa,
                    Telefon = dp.OsnovniPodaci.Telefon,
                    Email = dp.OsnovniPodaci.Email,
                    Jbd = dp.Jbd,
                    IdRoditelja = idRoditelja,
                    PunoImeRoditelja = punoImeRoditelja
                };
            }
        }
        public static void IzmeniOdraslogPolaznika(OdrasliPolaznikBasic dto)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var op = s.Get<OdrasliPolaznik>(dto.IdOsobe) ?? throw new ApplicationException("Odrasli polaznik ne postoji.");
                var o = op.OsnovniPodaci;

                o.Ime = dto.Ime ?? o.Ime;
                o.Prezime = dto.Prezime ?? o.Prezime;
                o.Jmbg = dto.Jmbg ?? o.Jmbg;
                o.Adresa = dto.Adresa;
                o.Telefon = dto.Telefon;
                o.Email = dto.Email;

                op.Zanimanje = dto.Zanimanje;

                s.Update(op);
                s.Update(o);
                tx.Commit();
            }
        }

        public static void IzmeniDetePolaznika(DetePolaznikBasic dto, string? roditeljJmbg = null, string? roditeljIme = null, string? roditeljPrezime = null)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var dp = s.Get<DetePolaznik>(dto.IdOsobe)
                         ?? throw new ApplicationException("Dete polaznik ne postoji.");
                var o = dp.OsnovniPodaci;

               
                o.Ime = dto.Ime ?? o.Ime;
                o.Prezime = dto.Prezime ?? o.Prezime;
                o.Jmbg = dto.Jmbg ?? o.Jmbg;
                o.Adresa = dto.Adresa;
                o.Telefon = dto.Telefon;
                o.Email = dto.Email;

                dp.Jbd = dto.Jbd;

                
                int roditeljId = dto.IdRoditelja > 0
                                 ? dto.IdRoditelja
                                 : (dp.PrijavioRoditelj?.Id ?? 0);

                bool imaUnosaZaRoditelja =
                    !string.IsNullOrWhiteSpace(roditeljJmbg) ||
                    !string.IsNullOrWhiteSpace(roditeljIme) ||
                    !string.IsNullOrWhiteSpace(roditeljPrezime);

                if (!string.IsNullOrWhiteSpace(roditeljJmbg))
                {
                    
                    roditeljId = NadjiIliKreirajRoditeljaId(roditeljJmbg!, roditeljIme, roditeljPrezime);
                }
                else if (roditeljId > 0 && imaUnosaZaRoditelja)
                {
                  
                    var osobaRoditelj = s.Get<Osoba>(roditeljId);
                    if (osobaRoditelj != null)
                    {
                        if (!string.IsNullOrWhiteSpace(roditeljIme))
                            osobaRoditelj.Ime = roditeljIme!;
                        if (!string.IsNullOrWhiteSpace(roditeljPrezime))
                            osobaRoditelj.Prezime = roditeljPrezime!;
                        if(!string.IsNullOrEmpty(roditeljJmbg))
                            osobaRoditelj.Jmbg= roditeljJmbg!;
                       
                        s.Update(osobaRoditelj);
                    }
                }
             

              
                if (roditeljId > 0)
                {
                    
                    dp.PrijavioRoditelj = s.Get<Roditelj>(roditeljId);
                }
                else
                {
                    dp.PrijavioRoditelj = null;
                }

                s.Update(dp);
                s.Update(o);
                tx.Commit();
            }
        }
        public static List<RoditeljPregled> VratiSveRoditelje()
        {
            using (var s = DataLayer.GetSession())
            {
             
                var q = s.Query<Osoba>()
                         .Where(x => x.FRoditelj == true)
                         .Select(x => new RoditeljPregled
                         {
                             IdOsobe = x.Id,
                             PunoIme = x.Ime + " " + x.Prezime
                         })
                         .ToList();

                return q;
            }
        }

        public static int NadjiIliKreirajRoditeljaId(string jmbg, string? ime = null, string? prezime = null,
                                           string? adresa = null, string? telefon = null, string? email = null)
        {
            if (string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13 || !jmbg.All(char.IsDigit))
                throw new ApplicationException("JMBG roditelja je obavezan i mora imati 13 cifara.");

            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                // 1) Nađi po JMBG
                var roditelj = s.Query<Osoba>()
                                .FirstOrDefault(x => x.Jmbg == jmbg);

                if (roditelj != null)
                {

                    if (!roditelj.FRoditelj) roditelj.FRoditelj = true;


                    if (!string.IsNullOrWhiteSpace(ime)) roditelj.Ime = ime!;
                    if (!string.IsNullOrWhiteSpace(prezime)) roditelj.Prezime = prezime!;
                    if (!string.IsNullOrWhiteSpace(adresa)) roditelj.Adresa = adresa!;
                    if (!string.IsNullOrWhiteSpace(telefon)) roditelj.Telefon = telefon!;
                    if (!string.IsNullOrWhiteSpace(email)) roditelj.Email = email!;

                    s.Update(roditelj);
                    tx.Commit();
                    return roditelj.Id;
                }
                else
                {
                    if (roditelj == null)
                        throw new ApplicationException("Roditelj sa ovim JMBG-om ne postoji. Molimo Vas dodajte ga.");
                    return 0;
                }

            }
        }
        public static List<RoditeljListItem> VratiSveRoditeljeDetalji()
        {
            var rezultat = new List<RoditeljListItem>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

               
                var roditelji = s.Query<Osoba>()
                                 .Where(o => o.FRoditelj == true)
                                 .ToList();

               
                var decaPoRoditelju = s.Query<DetePolaznik>()
                                       .Where(d => d.PrijavioRoditelj != null)
                                       .GroupBy(d => d.PrijavioRoditelj.Id)   
                                       .Select(g => new { IdRod = g.Key, Broj = g.Count() })
                                       .ToDictionary(x => x.IdRod, x => x.Broj);

               
                foreach (var o in roditelji)
                {
                    rezultat.Add(new RoditeljListItem
                    {
                        IdOsobe = o.Id,
                        Jmbg = o.Jmbg,
                        Ime = o.Ime,
                        Prezime = o.Prezime,
                        Telefon = o.Telefon,
                        Email = o.Email,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { s?.Close(); }

            return rezultat;
        }

        // Detalji jednog roditelja
        public static RoditeljListItem VratiRoditeljaDetalji(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                var o = s.Get<Osoba>(idOsobe) ?? throw new ApplicationException("Roditelj ne postoji.");
                if (!o.FRoditelj) throw new ApplicationException("Izabrana osoba nije roditelj.");

                return new RoditeljListItem
                {
                    IdOsobe = o.Id,
                    Jmbg = o.Jmbg,
                    Ime = o.Ime,
                    Prezime = o.Prezime,
                    Telefon = o.Telefon,
                    Email = o.Email
                };
            }
        }

        
        public static void IzmeniRoditelja(RoditeljListItem dto)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var o = s.Get<Osoba>(dto.IdOsobe) ?? throw new ApplicationException("Roditelj ne postoji.");

                o.Ime = dto.Ime ?? o.Ime;
                o.Prezime = dto.Prezime ?? o.Prezime;
                if (!string.IsNullOrWhiteSpace(dto.Jmbg)) o.Jmbg = dto.Jmbg; 
                o.Telefon = dto.Telefon;
                o.Email = dto.Email;

                s.Update(o);
                tx.Commit();
            }
        }


        public static void ObrisiRoditelja(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var o = s.Get<Osoba>(idOsobe);
                if (o == null)
                    throw new ApplicationException($"Osoba sa ID={idOsobe} ne postoji.");


                var deca = s.Query<DetePolaznik>()
                            .Where(d => d.PrijavioRoditelj != null && d.PrijavioRoditelj.Id == idOsobe)
                            .ToList();

                foreach (var d in deca)
                {
                    d.PrijavioRoditelj = null;
                    s.Update(d);
                }


                s.Delete(o);

                tx.Commit();
            }
        }
        public static void DodajPolaznikaNaKurs(int idPolaznika, int idKursa)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var polaznik = s.Get<Polaznik>(idPolaznika);
                var kurs = s.Get<Kurs>(idKursa);

                if (polaznik == null || kurs == null)
                    throw new Exception("Polaznik ili kurs ne postoji.");

                polaznik.PrijavljeniKursevi.Add(kurs);

                s.SaveOrUpdate(polaznik);
                tx.Commit();
            }
        }
        public static List<KursPregled> VratiPrijavljeneKurseve(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                var p = DohvatiPolaznika(s, idOsobe);

                
                return p.PrijavljeniKursevi?.Select(k => new KursPregled
                {
                    Id = k.Id,
                    Naziv = k.Naziv,
                    Nivo = k.Nivo,
                }).ToList() ?? new List<KursPregled>();
            }
        }
        public static List<PrisustvoPregled> VratiPrisustva(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                return s.Query<Prisustvo>()
                        .Where(pr => pr.Id.PolaznikId == idOsobe)
                        .Select(pr => new PrisustvoPregled
                        {
                            IdPolaznika = pr.Id.PolaznikId,
                            IdCasa = pr.Id.CasKomePrisustvuje.Id,
                            Termin = pr.Id.CasKomePrisustvuje.Termin,
                            Tema = pr.Id.CasKomePrisustvuje.Tema,
                            Ocena = pr.Ocena
                        })
                        .ToList();
            }
        }

        public static List<PrisustvoPregled> VratiPrisustvaZaCas(int casId)
        {
            List<PrisustvoPregled> prisustvaPregled = new List<PrisustvoPregled>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                IEnumerable<Prisustvo> svaPrisustva = s.Query<Prisustvo>()
                    .Where(p => p.Id.CasKomePrisustvuje.Id == casId);

                foreach (var p in svaPrisustva)
                {
                    var polaznikOsoba = s.Get<Osoba>(p.Id.PolaznikId);
                    prisustvaPregled.Add(new PrisustvoPregled
                    {
                        IdPolaznika = p.Id.PolaznikId,
                        ImePolaznika =  polaznikOsoba.Ime,
                        PrezimePolaznika = polaznikOsoba.Prezime,
                        IdCasa = casId,
                        Ocena = p.Ocena,
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                s?.Close();
            }

            return prisustvaPregled;
        }

        public static void DodajPrisustvo(PrisustvoPregled prisustvoDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Polaznik p = s.Load<Polaznik>(prisustvoDto.IdPolaznika);
                Cas c = s.Load<Cas>(prisustvoDto.IdCasa);

                var novoPrisustvo = new Prisustvo
                {
                    Ocena = prisustvoDto.Ocena
                };
                novoPrisustvo.Id.PolaznikId = prisustvoDto.IdPolaznika;
                novoPrisustvo.Id.CasKomePrisustvuje = c;

                s.Save(novoPrisustvo);
                s.Flush();
            }
            catch (Exception) { throw; }
            finally { s?.Close(); }
        }

        public static void IzmeniPrisustvo(PrisustvoPregled prisustvoDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Cas c = s.Load<Cas>(prisustvoDto.IdCasa);

                var idZaPretragu = new PrisustvoId() {
                    CasKomePrisustvuje = c,
                    PolaznikId = prisustvoDto.IdPolaznika,
                };
                Prisustvo p = s.Get<Prisustvo>(idZaPretragu);
                p.Ocena = prisustvoDto.Ocena;
                

                s.Update(p);
                s.Flush();
            }
            catch (Exception) { throw; }
            finally { s?.Close(); }
        }

        public static void ObrisiPrisustvo(PrisustvoPregled prisustvo)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var idZaBrisanje = new PrisustvoId
                {
                    PolaznikId = prisustvo.IdPolaznika,
                    CasKomePrisustvuje = s.Load<Cas>(prisustvo.IdCasa)
                };

                Prisustvo prisustvoZaBrisanje = s.Get<Prisustvo>(idZaBrisanje);

                if (prisustvoZaBrisanje != null)
                {
                    s.Delete(prisustvoZaBrisanje);
                }
                s.Flush();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                s?.Close();
            }
        }

        public static List<PolaznikPregled> VratiPolaznikeZaEvidenciju(int casId)
        {
            List<PolaznikPregled> polazniciZaEvidenciju = new List<PolaznikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Cas cas = s.Get<Cas>(casId);
                if (cas == null) return polazniciZaEvidenciju;
                Kurs kurs = cas.PripadaNastavi.PripadaKursu;

                IList<DetePolaznik> decaPolaznici = s.Query<DetePolaznik>()
                                    .Where(dp => dp.PrijavljeniKursevi.Contains(kurs))
                                    .ToList();

                IList<OdrasliPolaznik> odrasliPolaznici = s.Query<OdrasliPolaznik>()
                                                           .Where(op => op.PrijavljeniKursevi.Contains(kurs))
                                                           .ToList();

                IList<Polaznik> prijavljeniPolaznici = new List<Polaznik>();
                foreach (var dete in decaPolaznici) { prijavljeniPolaznici.Add(dete); }
                foreach (var odrasli in odrasliPolaznici) { prijavljeniPolaznici.Add(odrasli); }

                if (!prijavljeniPolaznici.Any()) return polazniciZaEvidenciju;

                HashSet<int> idjeviPrisutnihPolaznika = s.Query<Prisustvo>()
                                                       .Where(p => p.Id.CasKomePrisustvuje.Id == casId)
                                                       .Select(p => p.Id.PolaznikId)
                                                       .ToHashSet();

                var neevidentiraniPolaznici = prijavljeniPolaznici
                                              .Where(p => !idjeviPrisutnihPolaznika.Contains(p.Id));

                // 4. Prevedi u DTO
                foreach (var p in neevidentiraniPolaznici)
                {
                    polazniciZaEvidenciju.Add(new PolaznikPregled
                    {
                        IdOsobe = p.Id,
                        Ime = p.OsnovniPodaci.Ime,
                        Prezime =p.OsnovniPodaci.Prezime
                    });
                }
            }
            catch (Exception ex) { throw; }
            finally { s?.Close(); }

            return polazniciZaEvidenciju;
        }


        public static List<ZavrsniIspitPregled> VratiPolozeneIspite(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                return s.Query<ZavrsniIspit>()
                        .Where(z => z.PolazePolaznik.Id == idOsobe)
                        .Select(z => new ZavrsniIspitPregled
                        {
                            IdKursa = z.KursKojiSePolaze.Id,
                            NazivKursa = z.KursKojiSePolaze.Naziv,
                            Datum = z.Datum,
                            Ocena = z.Ocena,
                            Sertifikat = z.Sertifikat
                        })
                        .ToList();
            }
        }
      
        #endregion
    }
}