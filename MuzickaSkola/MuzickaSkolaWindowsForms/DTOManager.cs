using MuzickaSkolaWindowsForms.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
    public class DTOManager
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

        public static List<Nastavnik> VratiSveNastavnike()
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var osobeNastavnici =( from o in s.Query<Osoba>()
                                       where o.FNastavnik==true
                                       select o).ToList();

                List<Nastavnik> listaNastavnika = new List<Nastavnik>();
                foreach(var o in osobeNastavnici)
                {
                    var st = s.Get<StalnoZaposlen>(o.Id);
                    if (st != null)
                    {
                        listaNastavnika.Add(st);
                        continue;
                    }
                    var hn = s.Get<Honorarac>(o.Id);
                    listaNastavnika.Add(hn);
                }
                s.Close();
                return listaNastavnika;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return new List<Nastavnik>();
            }
        }

        public static Nastavnik VratiNastavnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                
                Nastavnik nastavnik = s.Get<StalnoZaposlen>(id);
                if (nastavnik != null)
                    return nastavnik;
                nastavnik = s.Get<Honorarac>(id);
                return nastavnik;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
                return null;
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
                return nastavePregled;
                s.Close();
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
            return true;
        }


        #endregion
    }
}