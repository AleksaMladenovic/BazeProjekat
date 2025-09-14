using DatabaseAccess.DTOs;
using FluentNHibernate.Conventions;
using MuzickaSkolaLibrary;
using MuzickaSkolaWindowsForms.Entiteti;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DatabaseAccess.DTOs.PolaznikView;

namespace DatabaseAccess.DataProvider
{
    public static class DataProvider
    {
        #region Lokacija
        public static Result<List<LokacijaView>, ErrorMessage> VratiSveLokacije()
        {
            List<LokacijaView> lokacijePregled = new List<LokacijaView>();
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();

                IEnumerable<Lokacija> sveLokacije = s.Query<Lokacija>().ToList();

                foreach (var lok in sveLokacije)
                {
                    lokacijePregled.Add(new LokacijaView()
                    {
                        Adresa = lok.Adresa,
                        Kapacitet = lok.Ucionice.Sum(u => u.Kapacitet),
                        RadnoVreme = lok.RadnoVreme
                    });
                }

                return lokacijePregled;
            }
            catch (Exception ex)
            {
                var error = new ErrorMessage(ex.Message, 500);
                return error;
            }
            finally
            {
                s?.Close();
            }
        }
        public static Result<LokacijaView, ErrorMessage> DodajLokaciju(LokacijaView lokacijaView)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var postojecaLokacija = s.Get<Lokacija>(lokacijaView.Adresa);
                if (postojecaLokacija != null)
                {
                    return new ErrorMessage($"Lokacija sa adresom '{lokacijaView.Adresa}' već postoji.", 409);
                }

                Lokacija novaLokacija = new Lokacija
                {
                    Adresa = lokacijaView.Adresa,
                    RadnoVreme = lokacijaView.RadnoVreme
                };

                if (lokacijaView.Ucionice != null)
                {
                    foreach (var ucionicaView in lokacijaView.Ucionice)
                    {
                        var novaUcionica = new Ucionica
                        {
                            Kapacitet = ucionicaView.Kapacitet,
                            Opremljenost = ucionicaView.Opremljenost,
                            Id = new UcionicaId { Naziv = ucionicaView.Naziv, PripadaLokaciji = novaLokacija }
                        };
                        novaLokacija.Ucionice.Add(novaUcionica);
                    }
                }

                s.Save(novaLokacija);
                s.Flush();
                return new LokacijaView(novaLokacija);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        public static Result<LokacijaView, ErrorMessage> IzmeniLokaciju(LokacijaView lokacijaView)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Lokacija lokacijaIzBaze = s.Get<Lokacija>(lokacijaView.Adresa);

                if (lokacijaIzBaze == null)
                {
                    return new ErrorMessage($"Lokacija sa adresom '{lokacijaView.Adresa}' nije pronađena.", 404);
                }

                lokacijaIzBaze.RadnoVreme = lokacijaView.RadnoVreme;

                s.Update(lokacijaIzBaze);
                s.Flush();
                return new LokacijaView(lokacijaIzBaze);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }


        public static Result<bool, ErrorMessage> ObrisiLokaciju(string adresa)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Lokacija lokacijaZaBrisanje = s.Get<Lokacija>(adresa);

                if (lokacijaZaBrisanje == null)
                {
                    return new ErrorMessage($"Lokacija sa adresom '{adresa}' nije pronađena.", 404);
                }

                if (lokacijaZaBrisanje.Ucionice.Count > 0)
                {
                    return new ErrorMessage("Nije moguće obrisati lokaciju jer sadrži jednu ili više učionica. Molimo vas, prvo obrišite učionice.", 409);
                }

                if (lokacijaZaBrisanje.KurseviKojiSeOdrzavaju.Count > 0)
                {
                    return new ErrorMessage("Nije moguće obrisati lokaciju jer se na njoj održavaju kursevi. Molimo vas, prvo uklonite kurseve sa ove lokacije.", 409);
                }

                s.Delete(lokacijaZaBrisanje);
                s.Flush();

                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }
        #endregion

        #region Ucionica
        public static Result<List<UcionicaView>, ErrorMessage> VratiSveUcioniceZaLokaciju(string adresaLokacije)
        {
            List<UcionicaView> ucionice = new List<UcionicaView>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                Lokacija lokacija = s.Get<Lokacija>(adresaLokacije);
                if (lokacija == null)
                {
                    return new ErrorMessage($"Lokacija sa adresom '{adresaLokacije}' nije pronađena.", 404);
                }

                IEnumerable<Ucionica> sveUcionice = s.Query<Ucionica>()
                                                     .Where(u => u.Id.PripadaLokaciji.Adresa == adresaLokacije)
                                                     .ToList();
                foreach (var u in sveUcionice)
                {
                    ucionice.Add(new UcionicaView(u));
                }

                return ucionice;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }
        public static Result<UcionicaView, ErrorMessage> DodajUcionicu(string adresaLokacije, UcionicaView ucionicaView)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Lokacija lokacijaEntitet = s.Get<Lokacija>(adresaLokacije);
                if (lokacijaEntitet == null)
                {
                    return new ErrorMessage($"Lokacija sa adresom '{adresaLokacije}' nije pronađena.", 404);
                }

                var idZaProveru = new UcionicaId { PripadaLokaciji = lokacijaEntitet, Naziv = ucionicaView.Naziv };
                Ucionica postojecaUcionica = s.Get<Ucionica>(idZaProveru);
                if (postojecaUcionica != null)
                {
                    return new ErrorMessage($"Učionica sa nazivom '{ucionicaView.Naziv}' već postoji na lokaciji '{adresaLokacije}'.", 409); // Conflict
                }

                Ucionica novaUcionica = new Ucionica
                {
                    Kapacitet = ucionicaView.Kapacitet,
                    Opremljenost = ucionicaView.Opremljenost
                };

                novaUcionica.Id.Naziv = ucionicaView.Naziv;
                novaUcionica.Id.PripadaLokaciji = lokacijaEntitet;

                lokacijaEntitet.Ucionice.Add(novaUcionica);

                s.Save(novaUcionica);
                s.Flush();
                return new UcionicaView(novaUcionica);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        public static Result<UcionicaView, ErrorMessage> IzmeniUcionicu(UcionicaView ucionicaView)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var idZaPretragu = new UcionicaId
                {
                    PripadaLokaciji = s.Load<Lokacija>(ucionicaView.AdresaLokacije),
                    Naziv = ucionicaView.Naziv
                };

                Ucionica ucionicaIzBaze = s.Get<Ucionica>(idZaPretragu);

                if (ucionicaIzBaze == null)
                {
                    return new ErrorMessage($"Učionica sa nazivom '{ucionicaView.Naziv}' na lokaciji '{ucionicaView.AdresaLokacije}' nije pronađena.", 404);
                }

                ucionicaIzBaze.Kapacitet = ucionicaView.Kapacitet;
                ucionicaIzBaze.Opremljenost = ucionicaView.Opremljenost;


                s.Update(ucionicaIzBaze);
                s.Flush();

                return new UcionicaView(ucionicaIzBaze);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        public static Result<bool, ErrorMessage> ObrisiUcionicu(string adresaLokacije, string nazivUcionice)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var idZaPretragu = new UcionicaId
                {
                    PripadaLokaciji = s.Load<Lokacija>(adresaLokacije),
                    Naziv = nazivUcionice
                };

                Ucionica ucionicaZaBrisanje = s.Get<Ucionica>(idZaPretragu);

                if (ucionicaZaBrisanje == null)
                {
                    return new ErrorMessage($"Učionica sa nazivom '{nazivUcionice}' na lokaciji '{adresaLokacije}' nije pronađena.", 404);
                }

                if (ucionicaZaBrisanje.CasoviKojiSeOdrzavaju.Count > 0)
                {
                    return new ErrorMessage("Nije moguće obrisati učionicu jer u njoj postoje zakazani časovi. Molimo vas, prvo obrišite ili premestite te časove.", 409); // Conflict
                }

                s.Delete(ucionicaZaBrisanje);
                s.Flush();

                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region Kurs
        public static Result<List<DatabaseAccess.DTOs.KursView>, ErrorMessage> VratiSveKursevePregled()
        {
            List<DatabaseAccess.DTOs.KursView> kurseviPregled = new List<DatabaseAccess.DTOs.KursView>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                IList<Kurs> kursevi = s.Query<Kurs>().ToList();
                foreach (var k in kursevi)
                {
                    var nastavnikDto = NastavnikView.VratiNastavnika(k.VodiNastavnik.Id);
                    var dto = new DatabaseAccess.DTOs.KursView()
                    {
                        Id = k.Id,
                        Naziv = k.Naziv,
                        Nivo = k.Nivo,
                        VodiNastavnik = nastavnikDto
                    };
                    if (k is InstrumentKurs) dto.TipKursa = TipKursaEnum.Instrument;
                    else if (k is GrupaInstrumenataKurs) dto.TipKursa = TipKursaEnum.GrupaInstrumenata;
                    else if (k is IndividualnoPevanjeKurs) dto.TipKursa = TipKursaEnum.IndividualnoPevanje;
                    else if (k is HorskoPevanjeKurs) dto.TipKursa = TipKursaEnum.HorskoPevanje;
                    else if (k is MuzickaTeorijaKurs) dto.TipKursa = TipKursaEnum.MuzickaTeorija;

                    kurseviPregled.Add(dto);
                }

                return kurseviPregled;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }


        public static Result<DatabaseAccess.DTOs.KursView, ErrorMessage> IzmeniKurs(KursBasic kursDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Kurs? kursZaIzmenu = s.Get<Kurs>(kursDto.Id);
                if (kursZaIzmenu == null)
                {
                    return new ErrorMessage($"Kurs sa id'{kursDto.Id}' ne postoji.", 404);
                }

                kursZaIzmenu.Naziv = kursDto.Naziv;
                kursZaIzmenu.Nivo = kursDto.Nivo;
                PostaviSpecijalanProperyKursu(kursDto, kursZaIzmenu);
                kursZaIzmenu.VodiNastavnik = VratiNastavnika(kursDto.NastavnikId);
                s.Update(kursZaIzmenu);
                s.Flush();
                return new DatabaseAccess.DTOs.KursView(kursZaIzmenu);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }
        private static void PostaviSpecijalanProperyKursu(KursBasic kursBasic, Kurs kurs)
        {
            if (kursBasic.TipKursa == TipKursaEnum.Instrument)
                ((InstrumentKurs)kurs).Instrument = kursBasic.Instrument;
            else if (kursBasic.TipKursa == TipKursaEnum.GrupaInstrumenata)
                ((GrupaInstrumenataKurs)kurs).GrupaInstrumenata = kursBasic.GrupaInstrumenata;
            else if (kursBasic.TipKursa == TipKursaEnum.MuzickaTeorija)
                ((MuzickaTeorijaKurs)kurs).NazivPredmeta = kursBasic.NazivPredmeta;
        }
        public static Result<DatabaseAccess.DTOs.KursView, ErrorMessage> DodajKurs(KursBasic kursDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Kurs? noviKursEntitet = null;
                switch (kursDto.TipKursa)
                {
                    case TipKursaEnum.Instrument:
                        noviKursEntitet = new InstrumentKurs
                        {
                            // Popunjavamo specifični properti
                            Instrument = kursDto.Instrument
                        };
                        break;

                    case TipKursaEnum.GrupaInstrumenata:
                        noviKursEntitet = new GrupaInstrumenataKurs
                        {
                            GrupaInstrumenata = kursDto.GrupaInstrumenata
                        };
                        break;

                    case TipKursaEnum.IndividualnoPevanje:
                        noviKursEntitet = new IndividualnoPevanjeKurs();
                        break;

                    case TipKursaEnum.HorskoPevanje:
                        noviKursEntitet = new HorskoPevanjeKurs();
                        break;

                    case TipKursaEnum.MuzickaTeorija:
                        noviKursEntitet = new MuzickaTeorijaKurs
                        {
                            NazivPredmeta = kursDto.NazivPredmeta
                        };
                        break;

                    default:
                        return new ErrorMessage($"Prosleđeni DTO ne odgovara tipu kursa '{kursDto.TipKursa}'.", 400);
                }
                if (noviKursEntitet != null)
                {
                    noviKursEntitet.Naziv = kursDto.Naziv;
                    noviKursEntitet.Nivo = kursDto.Nivo;
                    noviKursEntitet.VodiNastavnik = VratiNastavnika(kursDto.NastavnikId);

                    s.Save(noviKursEntitet);
                    s.Flush();
                }
                return new DatabaseAccess.DTOs.KursView(noviKursEntitet);

            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        public static Result<bool, ErrorMessage> ObrisiKurs(int KursId)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Kurs? kursZaBrisanje = s.Get<Kurs>(KursId);
                if (kursZaBrisanje == null)
                {
                    return new ErrorMessage($"Kurs sa id'{KursId}' ne postoji.", 404);

                }
                s.Delete(kursZaBrisanje);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
        }
        public static string VratiTipKursa(Kurs kurs)
        {
            if (kurs is InstrumentKurs)
            {
                return TipKursaEnum.Instrument;
            }
            else if (kurs is GrupaInstrumenataKurs)
            {
                return TipKursaEnum.GrupaInstrumenata;
            }
            else if (kurs is IndividualnoPevanjeKurs)
            {
                return TipKursaEnum.IndividualnoPevanje;
            }
            else if (kurs is HorskoPevanjeKurs)
            {
                return TipKursaEnum.HorskoPevanje;
            }
            else if (kurs is MuzickaTeorijaKurs)
            {
                return TipKursaEnum.MuzickaTeorija;
            }
            else
            {
                return "NEPOZNAT_TIP";
            }
        }
        #endregion

        #region Nastavnik 

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
                throw;
            }
            finally
            {
                if (s != null) s.Close();
            }
        }
        #endregion

        #region Nastava
        public static Result<List<NastavaView>, ErrorMessage> VratiSvuNastavuZaKurs(int kursId)
        {
            List<NastavaView> nastavePregled = new List<NastavaView>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();
                var nastave = from n in s.Query<Nastava>()
                              where n.PripadaKursu.Id == kursId
                              select n;
                var kurs = s.Get<Kurs>(kursId);
                if (kurs == null)
                    return new ErrorMessage($"Kurs sa id'{kursId}' ne postoji.", 404);

                string tipNastave = VratiTipNastave(VratiTipKursa(kurs));
                foreach (var n in nastave)
                {
                    nastavePregled.Add(new NastavaView()
                    {
                        Id = n.Id,
                        DatumOd = n.DatumOd,
                        DatumDo = n.DatumDo,
                        FIndividualna = tipNastave == "Individualna",
                        FGrupna = tipNastave == "Grupna",
                    });
                }
                return nastavePregled;

            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        public static string VratiTipNastave(string tipKursa)
        {
            if (tipKursa == TipKursaEnum.Instrument || tipKursa == TipKursaEnum.GrupaInstrumenata || tipKursa == TipKursaEnum.IndividualnoPevanje)
            {
                return "Individualna";
            }
            else
            {
                return "Grupna";
            }
        }
        public static Result<bool, ErrorMessage> DodajNastavu(NastavaBasic nastavaDto)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();
                Kurs kursEntitet = s.Get<Kurs>(nastavaDto.IdKursa);
                if (kursEntitet == null)
                    return new ErrorMessage($"Kurs sa id'{nastavaDto.IdKursa}' ne postoji.", 404);

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
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        public static Result<NastavaView, ErrorMessage> IzmeniNastavu(NastavaBasic nastavaDto)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();
                Nastava nastava = s.Get<Nastava>(nastavaDto.Id);
                bool postojeCasoviIzvanOpsega = false;
                foreach (var cas in nastava.Casovi)
                {
                    if (cas.Termin < nastavaDto.DatumOd || (nastavaDto.DatumDo.HasValue && cas.Termin > nastavaDto.DatumDo))
                    {
                        postojeCasoviIzvanOpsega = true;
                    }
                }
                if (postojeCasoviIzvanOpsega)
                {
                    return new ErrorMessage($"Postoje časovi za nastavu koji su van opsega!", 400);
                }
                nastava.DatumDo = nastavaDto.DatumDo;
                nastava.DatumOd = nastavaDto.DatumOd;



                s.Update(nastava);
                s.Flush();
                return new NastavaView(nastava);
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        public static Result<bool, ErrorMessage> ObrisiNastavu(int NastavaId)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Nastava? nastava = s.Get<Nastava>(NastavaId);
                if (nastava == null)
                    return new ErrorMessage("Nije pronadjena nastava!", 404);
                if (nastava.Casovi.Count > 0)
                    return new ErrorMessage("Za nastavu su evidentirani casovi!", 400);
                s.Delete(nastava);
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        #endregion

        #region Casovi
        public static Result<List<CasView>, ErrorMessage> VratiSveCasoveZaNastavu(int nastavaId)
        {
            List<CasView> casoviPregled = new List<CasView>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Cas> sviCasovi = from c in s.Query<Cas>()
                                             where c.PripadaNastavi.Id == nastavaId
                                             select c;

                foreach (Cas c in sviCasovi)
                {

                    casoviPregled.Add(new CasView
                    {
                        Id = c.Id,
                        Termin = c.Termin,
                        Tema = c.Tema,
                        DrziNastavnik = NastavnikView.VratiNastavnika(c.DrziNastavnik.Id),
                        UcionicaOdrzavanja = new UcionicaView(c.UcionicaOdrzavnja),
                    });
                }
                return casoviPregled;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }

        }

        public static Result<CasView, ErrorMessage> DodajCas(CasBasic cas)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();
                var nastavnik = VratiNastavnika(cas.NastavnikId);
                if (nastavnik == null)
                    return new ErrorMessage("Ne postoji nastavnik sa datim ID-em!", 400);
                var nastava = s.Get<Nastava>(cas.NastavaId);
                if (nastavnik == null)
                    return new ErrorMessage("Ne postoji nastava sa datim ID-em!", 400);
                UcionicaId idUcionice = new UcionicaId() { Naziv = cas.Ucionica, PripadaLokaciji = s.Get<Lokacija>(cas.Lokacija) };
                var ucionica = s.Get<Ucionica>(idUcionice);
                if (ucionica == null)
                    return new ErrorMessage("Ne postoji ucionica sa datim parametrima!", 400);
                Cas? noviCas = new Cas()
                {
                    Termin = cas.Termin,
                    Tema = cas.Tema,
                    DrziNastavnik = nastavnik,
                    PripadaNastavi = nastava,
                    UcionicaOdrzavnja = ucionica,
                };

                s.Save(noviCas);

                s.Flush();
                return new CasView()
                {
                    Id = noviCas.Id,
                    Tema = cas.Tema,
                    Termin = cas.Termin,
                    DrziNastavnik = NastavnikView.KreirajNastavnikView(nastavnik),
                    UcionicaOdrzavanja = new UcionicaView(ucionica),
                };
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        public static Result<CasView, ErrorMessage> IzmeniCas(CasBasic cas)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var casZaMenjanje = s.Get<Cas>(cas.Id);
                if (casZaMenjanje == null)
                    return new ErrorMessage("Cas sa datim id-em ne postoji", 400);

                var nastavnik = VratiNastavnika(cas.NastavnikId);
                if (nastavnik == null)
                    return new ErrorMessage("Ne postoji nastavnik sa datim ID-em!", 400);

                var nastava = s.Get<Nastava>(cas.NastavaId);
                if (nastavnik == null)
                    return new ErrorMessage("Ne postoji nastava sa datim ID-em!", 400);

                UcionicaId idUcionice = new UcionicaId() { Naziv = cas.Ucionica, PripadaLokaciji = s.Get<Lokacija>(cas.Lokacija) };
                var ucionica = s.Get<Ucionica>(idUcionice);
                if (ucionica == null)
                    return new ErrorMessage("Ne postoji ucionica sa datim parametrima!", 400);

                casZaMenjanje.Tema = cas.Tema;
                casZaMenjanje.Termin = cas.Termin;
                casZaMenjanje.DrziNastavnik = nastavnik;
                casZaMenjanje.PripadaNastavi = nastava;
                casZaMenjanje.UcionicaOdrzavnja = ucionica;


                s.Update(casZaMenjanje);

                s.Flush();
                return new CasView()
                {
                    Id = casZaMenjanje.Id,
                    Tema = casZaMenjanje.Tema,
                    Termin = casZaMenjanje.Termin,
                    DrziNastavnik = NastavnikView.KreirajNastavnikView(nastavnik),
                    UcionicaOdrzavanja = new UcionicaView(ucionica),
                };
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }

        public static Result<bool, ErrorMessage> ObrisiCas(int casId)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var cas = s.Get<Cas>(casId);
                if (cas == null)
                    return new ErrorMessage("Cas sa id-em nije pronadjen!", 404);

                s.Delete(cas);
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s.Close();
            }
        }
        #endregion

        #region PrisustvaCasovi

        public static Result<List<PrisustvoView>, ErrorMessage> VratiPrisustvaZaCas(int casId)
        {
            List<PrisustvoView> prisustvaView = new List<PrisustvoView>();
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                IEnumerable<Prisustvo> svaPrisustva = s.Query<Prisustvo>()
                    .Where(p => p.Id.CasKomePrisustvuje.Id == casId);

                foreach (var p in svaPrisustva)
                {
                    var polaznikOsoba = s.Get<Osoba>(p.Id.PolaznikId);
                    prisustvaView.Add(new PrisustvoView
                    {
                        PolaznikId = p.Id.PolaznikId,
                        PolaznikPunoIme = polaznikOsoba.Ime + " " + polaznikOsoba.Prezime,
                        CasId = casId,
                        Ocena = p.Ocena,
                    });
                }
                return prisustvaView;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }

        }

        public static Result<PrisustvoView, ErrorMessage> DodajPrisustvo(PrisustvoPregled prisustvoDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var moguciPolaznici = VratiPolaznikeZaEvidenciju(prisustvoDto.IdCasa);
                if (moguciPolaznici.IsEmpty())
                {
                    return new ErrorMessage("Svi polaznici za ovaj kurs su vec evidentirani u času!", 400);
                }
                Polaznik p = s.Load<Polaznik>(prisustvoDto.IdPolaznika);
                if (p == null)
                    return new ErrorMessage("Polaznik sa Id-em ne postoji!", 400);

                if (!moguciPolaznici.Select(p => p.IdOsobe).Contains(prisustvoDto.IdPolaznika))
                {
                    return new ErrorMessage("Nije moguce evidentirati polaznika za dati čas!", 400);
                }
                Cas c = s.Load<Cas>(prisustvoDto.IdCasa);
                if (c == null)
                    return new ErrorMessage("Cas sa Id-em ne postoji!", 400);

                var novoPrisustvo = new Prisustvo
                {
                    Ocena = prisustvoDto.Ocena
                };
                novoPrisustvo.Id.PolaznikId = prisustvoDto.IdPolaznika;
                novoPrisustvo.Id.CasKomePrisustvuje = c;

                s.Save(novoPrisustvo);
                s.Flush();
                return new PrisustvoView
                {
                    PolaznikId = p.Id,
                    PolaznikPunoIme = p.OsnovniPodaci.Ime + " " + p.OsnovniPodaci.Prezime,
                    CasId = c.Id,
                    Ocena = novoPrisustvo.Ocena,
                };
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally { s?.Close(); }
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

                foreach (var p in neevidentiraniPolaznici)
                {
                    polazniciZaEvidenciju.Add(new PolaznikPregled
                    {
                        IdOsobe = p.Id,
                        Ime = p.OsnovniPodaci.Ime,
                        Prezime = p.OsnovniPodaci.Prezime
                    });
                }
            }
            catch (Exception ex) { throw; }
            finally { s?.Close(); }

            return polazniciZaEvidenciju;
        }
        public static Result<bool, ErrorMessage> IzmeniPrisustvo(PrisustvoPregled prisustvoDto)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Cas c = s.Load<Cas>(prisustvoDto.IdCasa);
                if (c == null)
                    return new ErrorMessage("Cas sa Id-em ne postoji!", 400);
                var idZaPretragu = new PrisustvoId()
                {
                    CasKomePrisustvuje = c,
                    PolaznikId = prisustvoDto.IdPolaznika,
                };
                if (c == null)
                    return new ErrorMessage("Prisustvo za promenu ne postoji!", 400);
                Prisustvo p = s.Get<Prisustvo>(idZaPretragu);
                p.Ocena = prisustvoDto.Ocena;

                s.Update(p);
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally { s?.Close(); }
        }

        public static Result<bool, ErrorMessage> ObrisiPrisustvo(int idPolaznika, int idCasa)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                var idZaBrisanje = new PrisustvoId
                {
                    PolaznikId = idPolaznika,
                    CasKomePrisustvuje = s.Load<Cas>(idCasa)
                };

                Prisustvo prisustvoZaBrisanje = s.Get<Prisustvo>(idZaBrisanje);

                if (prisustvoZaBrisanje != null)
                {
                    s.Delete(prisustvoZaBrisanje);
                }
                else
                {
                    return new ErrorMessage("Prisustvo za brisanje ne postoji!", 404);
                }
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region KurseviLokacije

        public static Result<List<LokacijaPregled>, ErrorMessage> VratiSveLokacijeZaKurs(int kursId)
        {
            List<LokacijaPregled> lokacijePregled = new();
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();

                Kurs? kurs = s.Get<Kurs>(kursId);

                if (kurs == null)
                    return new ErrorMessage("Kurs sa tim ID-jem ne postoji!", 404);

                foreach (var lok in kurs.LokacijeOdrzavanja)
                {
                    int sumaKapaciteta = lok.Ucionice.Sum(u => u.Kapacitet);
                    lokacijePregled.Add(new LokacijaPregled(lok.Adresa, sumaKapaciteta, lok.RadnoVreme));
                }
                return lokacijePregled;
            }
            catch (Exception ex) { return new ErrorMessage(ex.Message, 500); }
            finally { s?.Close(); }
        }
        public static Result<bool, ErrorMessage> DodajLokacijuKursu(string adresaLokacije, int idKursa)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();

                Kurs kurs = s.Get<Kurs>(idKursa);
                if (kurs == null)
                    return new ErrorMessage("Kurs ne postoji.", 404);

                Lokacija lok = s.Get<Lokacija>(adresaLokacije);
                if (lok == null)
                    return new ErrorMessage("Lokacija ne postoji.", 404);

                if (kurs.LokacijeOdrzavanja.Any(l => l.Adresa == adresaLokacije))
                {
                    return new ErrorMessage("Kurs je već dodeljen ovoj lokaciji!", 409);
                }

                kurs.LokacijeOdrzavanja.Add(lok);

                s.Update(kurs);
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }



        public static Result<bool, ErrorMessage> UkloniLokacijuIzKursa(int kursId, string adresa)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();


                bool postojeCasovi = s.Query<Cas>()
                                       .Any(c => c.PripadaNastavi.PripadaKursu.Id == kursId &&
                                                 c.UcionicaOdrzavnja.Id.PripadaLokaciji.Adresa == adresa);
                if (postojeCasovi)
                    return new ErrorMessage("Postoje časovi za ovaj kurs na lokaciji, uklanjanje nije dozvoljeno!", 409);

                Kurs kurs = s.Query<Kurs>().Fetch(k => k.LokacijeOdrzavanja).Where(k => k.Id == kursId).SingleOrDefault();
                if (kurs == null)
                    return new ErrorMessage("Kurs ne postoji.", 404);

                Lokacija? lokZaBrisanje = kurs.LokacijeOdrzavanja.FirstOrDefault(l => l.Adresa == adresa);
                if (lokZaBrisanje == null)
                    return new ErrorMessage("Kurs nije bio dodeljen toj lokaciji.", 404);

                kurs.LokacijeOdrzavanja.Remove(lokZaBrisanje);

                s.Update(kurs);
                s.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                s?.Close();
            }
        }
        #endregion

        #region Polaznik

        public static Result<List<PolaznikView>, ErrorMessage> VratiSvePolaznike()
        {
            ISession? s = null;
            List<PolaznikView> rezultat = new List<PolaznikView>();
            try
            {
                using (s = DataLayer.GetSession())
                {
                    if (!(s?.IsConnected ?? false))
                    {
                        return "Nemoguće otvoriti sesiju.".ToError(403);
                    }
                    var odrasli = s.Query<OdrasliPolaznik>().ToList();
                    rezultat.AddRange(odrasli.Select(op => new OdrasliPolaznikView(op)));

                    var deca = s.Query<DetePolaznik>().ToList();
                    rezultat.AddRange(deca.Select(dp => new DetePolaznikView(dp)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška prilikom preuzimanja polaznika.", ex);
            }

            return rezultat;
        }

        public static Result<PolaznikView, ErrorMessage> VratiPolaznika(int id)
        {
            ISession? s = null;
            try
            {
                using (s = DataLayer.GetSession())
                {
                    if (!(s?.IsConnected ?? false))
                    {
                        return "Nemoguće otvoriti sesiju.".ToError(403);
                    }
                    var odrasli = s.Get<OdrasliPolaznik>(id);
                    if (odrasli != null)
                    {
                        return new OdrasliPolaznikView(odrasli);
                    }


                    var dete = s.Get<DetePolaznik>(id);
                    if (dete != null)
                    {
                        return new DetePolaznikView(dete);
                    }


                    throw new Exception($"Polaznik sa ID={id} nije pronađen.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<OdrasliPolaznikView, string>> DodajOdraslogPolaznikaAsync(OdrasliPolaznikCreateView dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Ime) || string.IsNullOrWhiteSpace(dto.Prezime) || string.IsNullOrWhiteSpace(dto.Jmbg))
            {
                return "Ime, Prezime i JMBG su obavezna polja.";
            }

            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var postojeci = await s.Query<Osoba>().FirstOrDefaultAsync(x => x.Jmbg == dto.Jmbg);
                    if (postojeci != null)
                    {
                        return $"Osoba sa JMBG '{dto.Jmbg}' već postoji u sistemu.";
                    }

                    var osobaEntitet = new Osoba
                    {
                        Ime = dto.Ime,
                        Prezime = dto.Prezime,
                        Jmbg = dto.Jmbg,
                        Adresa = dto.Adresa,
                        Telefon = dto.Telefon,
                        Email = dto.Email,
                        FPolaznik = true
                    };

                    var polaznikEntitet = new OdrasliPolaznik
                    {
                        Zanimanje = dto.Zanimanje,
                        OsnovniPodaci = osobaEntitet
                    };

                    await s.SaveAsync(polaznikEntitet);
                    await tx.CommitAsync();

                    return new OdrasliPolaznikView(polaznikEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do neočekivane greške: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<DetePolaznikView, string>> DodajDetePolaznikaAsync(DetePolaznikCreateView dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Ime) || string.IsNullOrWhiteSpace(dto.Prezime) || string.IsNullOrWhiteSpace(dto.Jmbg))
            {
                return "Ime, Prezime i JMBG su obavezna polja.";
            }

            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var postojeci = await s.Query<Osoba>().FirstOrDefaultAsync(x => x.Jmbg == dto.Jmbg);
                    if (postojeci != null)
                    {
                        return $"Osoba sa JMBG '{dto.Jmbg}' već postoji u sistemu.";
                    }

                    var osobaEntitet = new Osoba
                    {
                        Ime = dto.Ime,
                        Prezime = dto.Prezime,
                        Jmbg = dto.Jmbg,
                        Adresa = dto.Adresa,
                        Telefon = dto.Telefon,
                        Email = dto.Email,
                        FPolaznik = true
                    };

                    Roditelj roditeljEntitet = null;
                    if (dto.IdRoditelja > 0)
                    {
                        roditeljEntitet = await s.GetAsync<Roditelj>(dto.IdRoditelja);
                        if (roditeljEntitet == null)
                        {
                            return $"Roditelj sa ID={dto.IdRoditelja} ne postoji. Molimo prvo dodajte roditelja.";
                        }
                    }

                    var polaznikEntitet = new DetePolaznik
                    {
                        Jbd = dto.Jbd,
                        PrijavioRoditelj = roditeljEntitet,
                        OsnovniPodaci = osobaEntitet
                    };

                    await s.SaveAsync(polaznikEntitet);
                    await tx.CommitAsync();

                    return new DetePolaznikView(polaznikEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do neočekivane greške: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<bool, string>> ObrisiPolaznikaAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var odrasli = await s.GetAsync<OdrasliPolaznik>(idOsobe);
                    var dete = odrasli == null ? await s.GetAsync<DetePolaznik>(idOsobe) : null;

                    if (odrasli == null && dete == null)
                    {
                        return $"Polaznik sa ID={idOsobe} ne postoji.";
                    }

                    if (odrasli?.PrijavljeniKursevi != null)
                        odrasli.PrijavljeniKursevi.Clear();
                    if (dete?.PrijavljeniKursevi != null)
                        dete.PrijavljeniKursevi.Clear();


                    if (odrasli != null) await s.DeleteAsync(odrasli); else await s.DeleteAsync(dete);



                    var o = await s.GetAsync<Osoba>(idOsobe);
                    if (o != null)
                    {
                        if (!o.FNastavnik && !o.FRoditelj)
                            await s.DeleteAsync(o);
                        else
                        {
                            o.FPolaznik = false;
                            await s.UpdateAsync(o);
                        }
                    }


                    await tx.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće obrisati polaznika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public static async Task<Result<OdrasliPolaznikView, string>> AzurirajOdraslogPolaznikaAsync(OdrasliPolaznikUpdateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var polaznikEntitet = await s.GetAsync<OdrasliPolaznik>(dto.IdOsobe);
                    if (polaznikEntitet == null)
                    {
                        return $"Odrasli polaznik sa ID={dto.IdOsobe} ne postoji.";
                    }

                    var osobaEntitet = polaznikEntitet.OsnovniPodaci;

                    osobaEntitet.Ime = dto.Ime;
                    osobaEntitet.Prezime = dto.Prezime;
                    osobaEntitet.Jmbg = dto.Jmbg;
                    osobaEntitet.Adresa = dto.Adresa;
                    osobaEntitet.Telefon = dto.Telefon;
                    osobaEntitet.Email = dto.Email;
                    polaznikEntitet.Zanimanje = dto.Zanimanje;

                    await s.UpdateAsync(osobaEntitet);
                    await s.UpdateAsync(polaznikEntitet);
                    await tx.CommitAsync();

                    return new OdrasliPolaznikView(polaznikEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće ažurirati polaznika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

        }
        public static async Task<Result<PolaznikView, string>> AzurirajPolaznikaAsync(PolaznikUpdateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var odrasli = await s.GetAsync<OdrasliPolaznik>(dto.IdOsobe);

                    if (odrasli != null)
                    {
                        var osoba = odrasli.OsnovniPodaci;
                        osoba.Ime = dto.Ime;
                        osoba.Prezime = dto.Prezime;
                        osoba.Jmbg = dto.Jmbg;
                        osoba.Adresa = dto.Adresa;
                        osoba.Telefon = dto.Telefon;
                        osoba.Email = dto.Email;
                        odrasli.Zanimanje = dto.Zanimanje;

                        await s.UpdateAsync(osoba);
                        await s.UpdateAsync(odrasli);
                        await tx.CommitAsync();

                        return new OdrasliPolaznikView(odrasli);
                    }
                    else
                    {
                        var dete = await s.GetAsync<DetePolaznik>(dto.IdOsobe);
                        if (dete != null)
                        {
                            var osoba = dete.OsnovniPodaci;
                            osoba.Ime = dto.Ime;
                            osoba.Prezime = dto.Prezime;
                            osoba.Jmbg = dto.Jmbg;
                            osoba.Adresa = dto.Adresa;
                            osoba.Telefon = dto.Telefon;
                            osoba.Email = dto.Email;
                            dete.Jbd = dto.Jbd;

                            if (dto.IdRoditelja.HasValue)
                            {
                                if (dto.IdRoditelja > 0)
                                {
                                    var noviRoditelj = await s.GetAsync<Roditelj>(dto.IdRoditelja.Value);
                                    if (noviRoditelj == null) return $"Roditelj sa ID={dto.IdRoditelja.Value} ne postoji.";
                                    dete.PrijavioRoditelj = noviRoditelj;
                                }
                                else
                                {
                                    dete.PrijavioRoditelj = null;
                                }
                            }

                            await s.UpdateAsync(osoba);
                            await s.UpdateAsync(dete);
                            await tx.CommitAsync();

                            return new DetePolaznikView(dete);
                        }
                        else
                        {
                            return $"Polaznik sa ID={dto.IdOsobe} ne postoji.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće ažurirati polaznika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        public static async Task<Result<DetePolaznikView, string>> AzurirajDetePolaznikaAsync(DetePolaznikUpdateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var polaznikEntitet = await s.GetAsync<DetePolaznik>(dto.IdOsobe);
                    if (polaznikEntitet == null)
                    {
                        return $"Dete polaznik sa ID={dto.IdOsobe} ne postoji.";
                    }

                    var osobaEntitet = polaznikEntitet.OsnovniPodaci;

                    osobaEntitet.Ime = dto.Ime;
                    osobaEntitet.Prezime = dto.Prezime;
                    osobaEntitet.Jmbg = dto.Jmbg;
                    osobaEntitet.Adresa = dto.Adresa;
                    osobaEntitet.Telefon = dto.Telefon;
                    osobaEntitet.Email = dto.Email;
                    polaznikEntitet.Jbd = dto.Jbd;

                    if (dto.IdRoditelja > 0)
                    {
                        var noviRoditelj = await s.GetAsync<Roditelj>(dto.IdRoditelja);
                        if (noviRoditelj == null)
                        {
                            return $"Roditelj sa ID={dto.IdRoditelja} na koga želite da promenite ne postoji.";
                        }
                        polaznikEntitet.PrijavioRoditelj = noviRoditelj;
                    }
                    else
                    {
                        polaznikEntitet.PrijavioRoditelj = null;
                    }

                    await s.UpdateAsync(osobaEntitet);
                    await s.UpdateAsync(polaznikEntitet);
                    await tx.CommitAsync();

                    return new DetePolaznikView(polaznikEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće ažurirati polaznika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static Result<List<RoditeljView>, string> VratiSveRoditelje()
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var osobeRoditelja = s.Query<Osoba>().Where(o => o.FRoditelj == true).ToList();

                var decaPoRoditeljuId = s.Query<DetePolaznik>()
                                         .Where(d => d.PrijavioRoditelj != null)
                                         .Select(d => new
                                         {
                                             RoditeljId = d.PrijavioRoditelj.Id,
                                             DeteDto = new DetePolaznikView(d)
                                         })
                                         .ToList()
                                         .GroupBy(x => x.RoditeljId)
                                         .ToDictionary(g => g.Key, g => g.Select(x => x.DeteDto).ToList());

                var rezultat = new List<RoditeljView>();


                foreach (var osoba in osobeRoditelja)
                {
                    var roditeljView = new RoditeljView();


                    roditeljView.OsnovniPodaci = new OsobaView(osoba);


                    if (decaPoRoditeljuId.ContainsKey(osoba.Id))
                    {
                        roditeljView.Deca = decaPoRoditeljuId[osoba.Id];
                    }

                    roditeljView.BrojDece = roditeljView.Deca.Count;

                    rezultat.Add(roditeljView);
                }

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti roditelje. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<RoditeljView, string>> VratiRoditeljaAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }
                var osoba = await s.GetAsync<Osoba>(idOsobe);

                if (osoba == null || !osoba.FRoditelj)
                {
                    return $"Roditelj sa ID={idOsobe} ne postoji.";
                }

                var decaEntiteti = await s.Query<DetePolaznik>()
                                          .Where(d => d.PrijavioRoditelj.Id == idOsobe)
                                          .ToListAsync();

                var roditeljView = new RoditeljView
                {
                    OsnovniPodaci = new OsobaView(osoba),

                    Deca = decaEntiteti.Select(dete => new DetePolaznikView(dete)).ToList()
                };

                roditeljView.BrojDece = roditeljView.Deca.Count;

                return roditeljView;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti roditelja. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<RoditeljView, string>> DodajRoditeljaAsync(RoditeljCreateView dto)
        {
            ISession? s = null;
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Jmbg) || dto.Jmbg.Length != 13) return "JMBG je obavezan i mora imati 13 cifara.";
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false)) return "Nemoguće uspostaviti vezu sa bazom.";
                using (var tx = s.BeginTransaction())
                {
                    var postojeci = await s.Query<Osoba>().FirstOrDefaultAsync(o => o.Jmbg == dto.Jmbg);
                    if (postojeci != null) return $"Osoba sa JMBG {dto.Jmbg} već postoji.";

                    var osoba = new Osoba
                    {
                        Jmbg = dto.Jmbg,
                        Ime = dto.Ime,
                        Prezime = dto.Prezime,
                        Adresa = dto.Adresa,
                        Telefon = dto.Telefon,
                        Email = dto.Email,
                        FRoditelj = true
                    };
                    await s.SaveAsync(osoba);
                    var roditeljEntitet = await s.GetAsync<Roditelj>(osoba.Id);
                    await tx.CommitAsync();
                    return new RoditeljView(roditeljEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće dodati roditelja. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<RoditeljView, string>> AzurirajRoditeljaAsync(int idOsobe, RoditeljUpdateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {

                    var osobaEntitet = await s.GetAsync<Osoba>(idOsobe);


                    if (osobaEntitet == null || !osobaEntitet.FRoditelj)
                    {
                        return $"Roditelj sa ID={idOsobe} ne postoji.";
                    }


                    osobaEntitet.Ime = dto.Ime;
                    osobaEntitet.Adresa = dto.Adresa;
                    osobaEntitet.Prezime = dto.Prezime;
                    osobaEntitet.Jmbg = dto.Jmbg;
                    osobaEntitet.Telefon = dto.Telefon;
                    osobaEntitet.Email = dto.Email;

                    await s.UpdateAsync(osobaEntitet);
                    await tx.CommitAsync();

                    var roditeljEntitet = await s.GetAsync<Roditelj>(idOsobe);
                    NHibernateUtil.Initialize(roditeljEntitet.Deca);

                    return new RoditeljView(roditeljEntitet);
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće ažurirati roditelja. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, string>> ObrisiRoditeljaAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false)) return "Nemoguće uspostaviti vezu sa bazom.";
                using (var tx = s.BeginTransaction())
                {
                    var o = await s.GetAsync<Osoba>(idOsobe);
                    if (o == null || !o.FRoditelj) return $"Roditelj sa ID={idOsobe} ne postoji.";

                    var deca = await s.Query<DetePolaznik>().Where(d => d.PrijavioRoditelj != null && d.PrijavioRoditelj.Id == idOsobe).ToListAsync();
                    foreach (var d in deca)
                    {
                        d.PrijavioRoditelj = null;
                        await s.UpdateAsync(d);
                    }

                    if (o.FPolaznik || o.FNastavnik)
                    {
                        o.FRoditelj = false;
                        await s.UpdateAsync(o);
                    }
                    else { await s.DeleteAsync(o); }

                    await tx.CommitAsync();
                    return true;
                }
            }
            catch (Exception ex) { return $"Nemoguće obrisati roditelja. Greška: {ex.Message}"; }
            finally { s?.Close(); s?.Dispose(); }
        }

        public static async Task<Result<List<KursView>, string>> VratiPrijavljeneKurseveAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }


                Polaznik polaznik = await s.GetAsync<OdrasliPolaznik>(idOsobe);
                if (polaznik == null)
                {
                    polaznik = await s.GetAsync<DetePolaznik>(idOsobe);
                }

                if (polaznik == null)
                {
                    return $"Polaznik sa ID={idOsobe} ne postoji.";
                }


                await NHibernateUtil.InitializeAsync(polaznik.PrijavljeniKursevi);


                var rezultat = polaznik.PrijavljeniKursevi
                                       .Select(k => new KursView(k))
                                       .ToList();

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti prijavljene kurseve. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<bool, string>> DodajPolaznikaNaKursAsync(int idPolaznika, int idKursa)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    Polaznik polaznik = await s.GetAsync<OdrasliPolaznik>(idPolaznika);
                    if (polaznik == null)
                    {
                        polaznik = await s.GetAsync<DetePolaznik>(idPolaznika);
                    }

                    if (polaznik == null)
                    {
                        return $"Polaznik sa ID={idPolaznika} ne postoji.";
                    }

                    var kurs = await s.GetAsync<Kurs>(idKursa);
                    if (kurs == null)
                    {
                        return $"Kurs sa ID={idKursa} ne postoji.";
                    }

                    await NHibernateUtil.InitializeAsync(polaznik.PrijavljeniKursevi);
                    if (polaznik.PrijavljeniKursevi.Any(k => k.Id == idKursa))
                    {
                        return $"Polaznik je već prijavljen na kurs '{kurs.Naziv}'.";
                    }
                    polaznik.PrijavljeniKursevi.Add(kurs);

                    await s.UpdateAsync(polaznik);
                    await tx.CommitAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom dodavanja polaznika na kurs. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<List<PrisustvoView>, string>> VratiPrisustvaAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var polaznik = await s.GetAsync<Polaznik>(idOsobe);
                if (polaznik == null)
                {
                    return $"Polaznik sa ID={idOsobe} ne postoji.";
                }

                var prisustva = await s.Query<Prisustvo>()
                                       .Where(pr => pr.Id.PolaznikId == idOsobe)
                                       .Select(pr => new PrisustvoView
                                       {
                                           PolaznikId = pr.Id.PolaznikId,
                                           PolaznikPunoIme = polaznik.OsnovniPodaci.Ime + " " + polaznik.OsnovniPodaci.Prezime,
                                           CasId = pr.Id.CasKomePrisustvuje.Id,
                                           CasTermin = pr.Id.CasKomePrisustvuje.Termin,
                                           CasTema = pr.Id.CasKomePrisustvuje.Tema,
                                           Ocena = pr.Ocena
                                       })
                                       .ToListAsync();

                return prisustva;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti prisustva. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        public static async Task<Result<List<ZavrsniIspitView>, string>> VratiPolozeneIspiteAsync(int idOsobe)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var polaznik = await s.GetAsync<Polaznik>(idOsobe);
                if (polaznik == null)
                {
                    return $"Polaznik sa ID={idOsobe} ne postoji.";
                }
                var ispiti = await s.Query<ZavrsniIspit>()
                                    .Where(z => z.PolazePolaznik.Id == idOsobe)
                                    .Select(z => new ZavrsniIspitView
                                    {
                                        Id = z.Id,
                                        Ocena = z.Ocena,
                                        Sertifikat = z.Sertifikat,
                                        Datum = z.Datum,
                                        NazivKursa = z.KursKojiSePolaze.Naziv,
                                        PolaznikPunoIme = z.PolazePolaznik.OsnovniPodaci.Ime + " " + z.PolazePolaznik.OsnovniPodaci.Prezime,
                                        IdKomisije = (z.OcenjujeKomisija != null) ? z.OcenjujeKomisija.Id : 0
                                    })
                                    .ToListAsync();

                return ispiti;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti položene ispite. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<ZavrsniIspitView, string>> DodajPolozeniIspitAsync(int idPolaznika, ZavrsniIspitCreateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    Polaznik polaznik = await s.GetAsync<OdrasliPolaznik>(idPolaznika);
                    if (polaznik == null) { polaznik = await s.GetAsync<DetePolaznik>(idPolaznika); }
                    if (polaznik == null) return $"Polaznik sa ID={idPolaznika} ne postoji.";

                    var kurs = await s.GetAsync<Kurs>(dto.IdKursa);
                    if (kurs == null) return $"Kurs sa ID={dto.IdKursa} ne postoji.";

                    var komisija = await s.GetAsync<Komisija>(dto.IdKomisije);
                    if (komisija == null) return $"Komisija sa ID={dto.IdKomisije} ne postoji.";

                    await NHibernateUtil.InitializeAsync(polaznik.PrijavljeniKursevi);

                    bool jePrijavljen = polaznik.PrijavljeniKursevi.Any(prijavljeniKurs => prijavljeniKurs.Id == dto.IdKursa);

                    if (!jePrijavljen)
                    {
                        return $"Polaznik sa ID={idPolaznika} nije prijavljen na kurs '{kurs.Naziv}' i ne može polagati ispit.";
                    }

                    var noviIspit = new ZavrsniIspit
                    {
                        PolazePolaznik = polaznik,
                        KursKojiSePolaze = kurs,
                        OcenjujeKomisija = komisija,
                        Datum = dto.Datum,
                        Ocena = dto.Ocena,
                        Sertifikat = dto.Sertifikat
                    };

                    await s.SaveAsync(noviIspit);
                    await tx.CommitAsync();

                    return new ZavrsniIspitView(noviIspit);
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom dodavanja ispita: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        #endregion

        #region Nastavnik

        public static async Task<Result<List<NastavnikView>, string>> VratiSveNastavnikeAsync()
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var rezultat = new List<NastavnikView>();

                var honorarci = await s.Query<Honorarac>()
                                       .Fetch(h => h.OsnovniPodaci)
                                       .ToListAsync();

                foreach (var h in honorarci)
                {
                    await NHibernateUtil.InitializeAsync(h.DrziCasove);
                    await NHibernateUtil.InitializeAsync(h.VodiKurseve);
                    rezultat.Add(new HonoraracView(h));
                }

                var stalnoZaposleni = await s.Query<StalnoZaposlen>()
                                             .Fetch(sz => sz.OsnovniPodaci)
                                             .ToListAsync();

                foreach (var sz in stalnoZaposleni)
                {

                    await NHibernateUtil.InitializeAsync(sz.DrziCasove);
                    await NHibernateUtil.InitializeAsync(sz.VodiKurseve);
                    if (sz.OsnovniPodaci?.Mentor != null)
                    {
                        await NHibernateUtil.InitializeAsync(sz.OsnovniPodaci.Mentor.OsnovniPodaci);
                    }
                    rezultat.Add(new StalnoZaposlenView(sz));
                }

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti nastavnike. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NastavnikView, string>> VratiNastavnikaAsync(int id)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var honorarac = await s.GetAsync<Honorarac>(id);
                if (honorarac != null)
                {
                    await NHibernateUtil.InitializeAsync(honorarac.OsnovniPodaci);
                    await NHibernateUtil.InitializeAsync(honorarac.VodiKurseve);
                    await NHibernateUtil.InitializeAsync(honorarac.DrziCasove);
                    await NHibernateUtil.InitializeAsync(honorarac.KomisijeCijiJeClan);

                    if (honorarac.OsnovniPodaci?.Mentor != null)
                    {
                        await NHibernateUtil.InitializeAsync(honorarac.OsnovniPodaci.Mentor.OsnovniPodaci);
                    }

                    return new HonoraracView(honorarac);
                }

                var stalnoZaposlen = await s.GetAsync<StalnoZaposlen>(id);
                if (stalnoZaposlen != null)
                {
                    await NHibernateUtil.InitializeAsync(stalnoZaposlen.OsnovniPodaci);
                    await NHibernateUtil.InitializeAsync(stalnoZaposlen.VodiKurseve);
                    await NHibernateUtil.InitializeAsync(stalnoZaposlen.DrziCasove);
                    await NHibernateUtil.InitializeAsync(stalnoZaposlen.KomisijeCijiJeClan);

                    if (stalnoZaposlen.OsnovniPodaci?.Mentor != null)
                    {
                        await NHibernateUtil.InitializeAsync(stalnoZaposlen.OsnovniPodaci.Mentor.OsnovniPodaci);
                    }

                    return new StalnoZaposlenView(stalnoZaposlen);
                }

                return $"Nastavnik sa ID={id} ne postoji.";
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti nastavnika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        public static async Task<Result<NastavnikView, string>> DodajNastavnikaAsync(NastavnikCreateView dto)
        {
            ISession? s = null;
            try
            {
                // Validacija
                if (string.IsNullOrWhiteSpace(dto.Jmbg) || string.IsNullOrWhiteSpace(dto.Ime) || string.IsNullOrWhiteSpace(dto.Prezime))
                    return "JMBG, Ime i Prezime su obavezna polja.";
                if (string.IsNullOrEmpty(dto.TipZaposlenja))
                    return "TipZaposlenja je obavezno polje ('Honorarac' ili 'StalnoZaposlen').";

                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false)) return "Nemoguće uspostaviti vezu sa bazom.";

                using (var tx = s.BeginTransaction())
                {
                    var postojeci = await s.Query<Osoba>().FirstOrDefaultAsync(o => o.Jmbg == dto.Jmbg);
                    if (postojeci != null) return $"Osoba sa JMBG '{dto.Jmbg}' već postoji.";

                    StalnoZaposlen mentor = null;
                    if (dto.IdMentora.HasValue)
                    {
                        mentor = await s.GetAsync<StalnoZaposlen>(dto.IdMentora.Value);
                        if (mentor == null) return $"Mentor sa ID={dto.IdMentora.Value} ne postoji ili nije stalno zaposlen.";
                    }

                    var osoba = new Osoba
                    {
                        Jmbg = dto.Jmbg,
                        Ime = dto.Ime,
                        Prezime = dto.Prezime,
                        Adresa = dto.Adresa,
                        Telefon = dto.Telefon,
                        Email = dto.Email,
                        DatumZaposlenja = dto.DatumZaposlenja,
                        StrucnaSprema = dto.StrucnaSprema,
                        Mentor = mentor,
                        FNastavnik = true
                    };

                    Nastavnik nastavnik;
                    if (dto.TipZaposlenja.Equals("Honorarac", StringComparison.OrdinalIgnoreCase))
                    {
                        nastavnik = new Honorarac
                        {
                            BrojUgovora = dto.BrojUgovora,
                            TrajanjeUgovora = dto.TrajanjeUgovora,
                            BrojCasova = dto.BrojCasova
                        };
                    }
                    else if (dto.TipZaposlenja.Equals("StalnoZaposlen", StringComparison.OrdinalIgnoreCase))
                    {
                        nastavnik = new StalnoZaposlen { RadnoVreme = dto.RadnoVreme };
                    }
                    else
                    {
                        return "Nepodržan TipZaposlenja. Mora biti 'Honorarac' ili 'StalnoZaposlen'.";
                    }

                    nastavnik.OsnovniPodaci = osoba;

                    await s.SaveAsync(osoba);

                    nastavnik.Id = osoba.Id;

                    await s.SaveAsync(nastavnik);

                    await tx.CommitAsync();

                    if (nastavnik is Honorarac h) return new HonoraracView(h);
                    if (nastavnik is StalnoZaposlen sz) return new StalnoZaposlenView(sz);

                    return "Došlo je do greške prilikom vraćanja kreiranog nastavnika.";
                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće dodati nastavnika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, string>> ObrisiNastavnikaAsync(int idNastavnika)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }


                var osoba = await s.GetAsync<Osoba>(idNastavnika);

                if (osoba == null || !osoba.FNastavnik)
                {
                    return $"Nastavnik sa ID={idNastavnika} ne postoji.";
                }


                using (var tx = s.BeginTransaction())
                {


                    string updateMentorSql = "UPDATE OSOBA SET ID_MENTORA = NULL WHERE ID_MENTORA = :id";
                    await s.CreateSQLQuery(updateMentorSql).SetParameter("id", idNastavnika).ExecuteUpdateAsync();

                    string deleteKomisijeSql = "DELETE FROM SE_SASTOJI WHERE ID_NASTAVNIKA = :id";
                    await s.CreateSQLQuery(deleteKomisijeSql).SetParameter("id", idNastavnika).ExecuteUpdateAsync();

                    string deleteStalnoZapSql = "DELETE FROM STALNO_ZAP WHERE ID_OSOBE = :id";
                    await s.CreateSQLQuery(deleteStalnoZapSql).SetParameter("id", idNastavnika).ExecuteUpdateAsync();

                    string deleteHonoraracSql = "DELETE FROM HONORARAC WHERE ID_OSOBE = :id";
                    await s.CreateSQLQuery(deleteHonoraracSql).SetParameter("id", idNastavnika).ExecuteUpdateAsync();

                    string deleteOsobaSql = "DELETE FROM OSOBA WHERE ID_OSOBE = :id";
                    await s.CreateSQLQuery(deleteOsobaSql).SetParameter("id", idNastavnika).ExecuteUpdateAsync();

                    await tx.CommitAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom brisanja nastavnika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<NastavnikView, string>> AzurirajNastavnikaAsync(int idNastavnika, NastavnikCreateView dto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false)) return "Nemoguće uspostaviti vezu sa bazom.";

                using (var tx = s.BeginTransaction())
                {
                    Nastavnik nastavnikIzBaze = (Nastavnik)await s.GetAsync<Honorarac>(idNastavnika) ?? await s.GetAsync<StalnoZaposlen>(idNastavnika);
                    if (nastavnikIzBaze == null)
                    {
                        return $"Nastavnik sa ID={idNastavnika} ne postoji.";
                    }

                    string updateOsobaSql = @"UPDATE OSOBA SET 
                                        JMBG = :jmbg, IME = :ime, PREZIME = :prezime, ADRESA = :adresa, 
                                        TELEFON = :telefon, EMAIL = :email, STRUCNA_SPREMA = :sprema, 
                                        DATUM_ZAPOSLENJA = :datum, ID_MENTORA = :mentorId 
                                      WHERE ID_OSOBE = :id";

                    var query = s.CreateSQLQuery(updateOsobaSql);

                    query.SetParameter("jmbg", dto.Jmbg);
                    query.SetParameter("ime", dto.Ime);
                    query.SetParameter("prezime", dto.Prezime);
                    query.SetParameter("adresa", dto.Adresa);
                    query.SetParameter("telefon", dto.Telefon);
                    query.SetParameter("email", dto.Email);
                    query.SetParameter("sprema", dto.StrucnaSprema);
                    query.SetParameter("id", idNastavnika);

                    if (dto.DatumZaposlenja.HasValue)
                    {
                        query.SetParameter("datum", dto.DatumZaposlenja.Value, NHibernateUtil.DateTime);
                    }
                    else
                    {
                        query.SetParameter("datum", null, NHibernateUtil.DateTime);
                    }

                    if (dto.IdMentora.HasValue)
                    {
                        query.SetParameter("mentorId", dto.IdMentora.Value, NHibernateUtil.Int32);
                    }
                    else
                    {
                        query.SetParameter("mentorId", null, NHibernateUtil.Int32);
                    }

                    await query.ExecuteUpdateAsync();

                    Type noviTip = (dto.TipZaposlenja.Equals("Honorarac", StringComparison.OrdinalIgnoreCase))
                        ? typeof(Honorarac)
                        : typeof(StalnoZaposlen);
                    bool tipSePromenio = nastavnikIzBaze.GetType() != noviTip;

                    if (tipSePromenio)
                    {
                        if (nastavnikIzBaze is StalnoZaposlen)
                        {

                            await s.CreateSQLQuery("DELETE FROM STALNO_ZAP WHERE ID_OSOBE = :id")
                                   .SetParameter("id", idNastavnika)
                                   .ExecuteUpdateAsync();

                            string insertHonoraracSql = "INSERT INTO HONORARAC (ID_OSOBE, BROJ_UGOVORA, TRAJANJE_UGOVORA, BROJ_CASOVA) VALUES (:id, :broj, :trajanje, :casovi)";
                            await s.CreateSQLQuery(insertHonoraracSql)
                                   .SetParameter("id", idNastavnika)
                                   .SetParameter("broj", dto.BrojUgovora)
                                   .SetParameter("trajanje", dto.TrajanjeUgovora)
                                   .SetParameter("casovi", dto.BrojCasova)
                                   .ExecuteUpdateAsync();
                        }
                        else
                        {
                            await s.CreateSQLQuery("DELETE FROM HONORARAC WHERE ID_OSOBE = :id")
                                   .SetParameter("id", idNastavnika)
                                   .ExecuteUpdateAsync();

                            string insertStalnoZapSql = "INSERT INTO STALNO_ZAP (ID_OSOBE, RADNO_VREME) VALUES (:id, :vreme)";
                            await s.CreateSQLQuery(insertStalnoZapSql)
                                   .SetParameter("id", idNastavnika)
                                   .SetParameter("vreme", dto.RadnoVreme)
                                   .ExecuteUpdateAsync();
                        }
                    }
                    else
                    {
                        if (nastavnikIzBaze is StalnoZaposlen)
                        {
                            await s.CreateSQLQuery("UPDATE STALNO_ZAP SET RADNO_VREME = :vreme WHERE ID_OSOBE = :id")
                                   .SetParameter("vreme", dto.RadnoVreme)
                                   .SetParameter("id", idNastavnika)
                                   .ExecuteUpdateAsync();
                        }
                        else if (nastavnikIzBaze is Honorarac)
                        {
                            await s.CreateSQLQuery("UPDATE HONORARAC SET BROJ_UGOVORA = :broj, TRAJANJE_UGOVORA = :trajanje, BROJ_CASOVA = :casovi WHERE ID_OSOBE = :id")
                                   .SetParameter("broj", dto.BrojUgovora)
                                   .SetParameter("trajanje", dto.TrajanjeUgovora)
                                   .SetParameter("casovi", dto.BrojCasova)
                                   .SetParameter("id", idNastavnika)
                                   .ExecuteUpdateAsync();
                        }
                    }

                    await tx.CommitAsync();

                    var finalniNastavnik = (Nastavnik)await s.GetAsync<Honorarac>(idNastavnika) ?? await s.GetAsync<StalnoZaposlen>(idNastavnika);
                    if (finalniNastavnik is Honorarac h) return new HonoraracView(h);
                    if (finalniNastavnik is StalnoZaposlen sz) return new StalnoZaposlenView(sz);
                    return "Došlo je do greške pri vraćanju ažuriranih podataka.";

                }
            }
            catch (Exception ex)
            {
                return $"Nemoguće ažurirati nastavnika. Greška: {ex.InnerException?.Message ?? ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<KursView>, string>> VratiSveKurseveNastavnikaAsync(int nastavnikId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                Nastavnik nastavnik = (Nastavnik)await s.GetAsync<Honorarac>(nastavnikId) ?? await s.GetAsync<StalnoZaposlen>(nastavnikId);

                if (nastavnik == null)
                {
                    return $"Nastavnik sa ID={nastavnikId} ne postoji.";
                }

                await NHibernateUtil.InitializeAsync(nastavnik.VodiKurseve);

                var rezultat = nastavnik.VodiKurseve
                                        .Select(k => new KursView(k))
                                        .ToList();

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti kurseve nastavnika. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<CasViewPomocni>, string>> VratiSveCasoveNastavnikaAsync(int nastavnikId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                Nastavnik nastavnik = (Nastavnik)await s.GetAsync<Honorarac>(nastavnikId) ?? await s.GetAsync<StalnoZaposlen>(nastavnikId);

                if (nastavnik == null)
                {
                    return $"Nastavnik sa ID={nastavnikId} ne postoji.";
                }

                await NHibernateUtil.InitializeAsync(nastavnik.DrziCasove);

                foreach (var cas in nastavnik.DrziCasove)
                {
                    if (cas.UcionicaOdrzavnja != null)
                    {
                        await NHibernateUtil.InitializeAsync(cas.UcionicaOdrzavnja.Id);
                        if (cas.UcionicaOdrzavnja.Id != null)
                        {
                            await NHibernateUtil.InitializeAsync(cas.UcionicaOdrzavnja.Id.PripadaLokaciji);
                        }
                    }
                    if (cas.DrziNastavnik != null)
                    {
                        await NHibernateUtil.InitializeAsync(cas.DrziNastavnik.OsnovniPodaci);
                    }
                    await NHibernateUtil.InitializeAsync(cas.PrisutniPolaznici);
                }

                var rezultat = nastavnik.DrziCasove
                                        .Select(c => new CasViewPomocni(c))
                                        .ToList();

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti časove nastavnika. Greška: {ex.InnerException?.Message ?? ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, string>> DodeliMentoraAsync(int nastavnikId, int mentorId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    if (nastavnikId == mentorId)
                    {
                        return "Nastavnik ne može sam sebi biti mentor.";
                    }

                    var ucenikOsoba = await s.GetAsync<Osoba>(nastavnikId);
                    if (ucenikOsoba == null || !ucenikOsoba.FNastavnik)
                    {
                        return $"Nastavnik (učenik) sa ID={nastavnikId} ne postoji.";
                    }

                    var mentor = await s.GetAsync<StalnoZaposlen>(mentorId);
                    if (mentor == null)
                    {
                        return $"Mentor sa ID={mentorId} ne postoji ili nije stalno zaposlen.";
                    }

                    ucenikOsoba.Mentor = mentor;

                    await s.UpdateAsync(ucenikOsoba);
                    await tx.CommitAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom dodele mentora. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<KomisijaView>, string>> VratiSveKomisijeAsync()
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var komisijeEntiteti = await s.Query<Komisija>().ToListAsync();

                foreach (var komisija in komisijeEntiteti)
                {
                    await NHibernateUtil.InitializeAsync(komisija.ClanoviKomisije);

                    foreach (var clan in komisija.ClanoviKomisije)
                    {
                        await NHibernateUtil.InitializeAsync(clan);
                    }
                }

                var rezultat = komisijeEntiteti.Select(k => new KomisijaView(k)).ToList();

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti komisije. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }


        public static async Task<Result<List<NastavnikView>, string>> VratiClanoveKomisijeAsync(int komisijaId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                var komisija = await s.GetAsync<Komisija>(komisijaId);
                if (komisija == null)
                {
                    return $"Komisija sa ID={komisijaId} ne postoji.";
                }

                await NHibernateUtil.InitializeAsync(komisija.ClanoviKomisije);

                var rezultat = new List<NastavnikView>();

                foreach (var clanOsoba in komisija.ClanoviKomisije)
                {
                    Nastavnik detaljiNastavnika = (Nastavnik)await s.GetAsync<Honorarac>(clanOsoba.Id) ?? await s.GetAsync<StalnoZaposlen>(clanOsoba.Id);

                    if (detaljiNastavnika != null)
                    {
                        await NHibernateUtil.InitializeAsync(detaljiNastavnika.OsnovniPodaci);
                        await NHibernateUtil.InitializeAsync(detaljiNastavnika.DrziCasove);
                        await NHibernateUtil.InitializeAsync(detaljiNastavnika.VodiKurseve);
                        if (detaljiNastavnika.OsnovniPodaci?.Mentor != null)
                        {
                            await NHibernateUtil.InitializeAsync(detaljiNastavnika.OsnovniPodaci.Mentor.OsnovniPodaci);
                        }

                        if (detaljiNastavnika is Honorarac h)
                        {
                            rezultat.Add(new HonoraracView(h));
                        }
                        else if (detaljiNastavnika is StalnoZaposlen sz)
                        {
                            rezultat.Add(new StalnoZaposlenView(sz));
                        }
                    }
                }

                return rezultat;
            }
            catch (Exception ex)
            {
                return $"Nemoguće preuzeti članove komisije. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<KomisijaView, string>> DodajNovuKomisijuAsync()
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var novaKomisija = new Komisija();

                    await s.SaveAsync(novaKomisija);
                    await tx.CommitAsync();

                    return new KomisijaView(novaKomisija);
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom dodavanja komisije: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<List<KomisijaView>, string>> SacuvajIzmeneZaKomisijeAsync(int nastavnikId, List<int> noveKomisijeIds)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    Nastavnik nastavnik = (Nastavnik)await s.GetAsync<Honorarac>(nastavnikId) ?? await s.GetAsync<StalnoZaposlen>(nastavnikId);
                    if (nastavnik == null)
                    {
                        return $"Nastavnik sa ID={nastavnikId} ne postoji.";
                    }

                    await NHibernateUtil.InitializeAsync(nastavnik.KomisijeCijiJeClan);
                    nastavnik.KomisijeCijiJeClan.Clear();

                    foreach (int komisijaId in noveKomisijeIds)
                    {
                        var komisija = await s.LoadAsync<Komisija>(komisijaId);
                        nastavnik.KomisijeCijiJeClan.Add(komisija);
                    }

                    await s.UpdateAsync(nastavnik);
                    await tx.CommitAsync();

                    await NHibernateUtil.InitializeAsync(nastavnik.KomisijeCijiJeClan);
                    var rezultat = nastavnik.KomisijeCijiJeClan.Select(k => new KomisijaView(k)).ToList();

                    return rezultat;
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom čuvanja izmena. Proverite da li sve komisije sa datim ID-jevima postoje. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }

        public static async Task<Result<bool, string>> ObrisiKomisijuAsync(int komisijaId)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće uspostaviti vezu sa bazom.";
                }

                using (var tx = s.BeginTransaction())
                {
                    var komisijaZaBrisanje = await s.GetAsync<Komisija>(komisijaId);
                    if (komisijaZaBrisanje == null)
                    {
                        return $"Komisija sa ID={komisijaId} ne postoji.";
                    }

                    await NHibernateUtil.InitializeAsync(komisijaZaBrisanje.IspitiKojeOcenjuje);
                    foreach (var ispit in komisijaZaBrisanje.IspitiKojeOcenjuje)
                    {
                        ispit.OcenjujeKomisija = null;
                        await s.UpdateAsync(ispit);
                    }

                    await NHibernateUtil.InitializeAsync(komisijaZaBrisanje.ClanoviKomisije);
                    komisijaZaBrisanje.ClanoviKomisije.Clear();


                    await s.DeleteAsync(komisijaZaBrisanje);

                    await tx.CommitAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return $"Došlo je do greške prilikom brisanja komisije. Greška: {ex.Message}";
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
        }
        #endregion

    }
}
