using DatabaseAccess.DTOs;
using FluentNHibernate.Conventions;
using MuzickaSkolaWindowsForms;
using MuzickaSkolaWindowsForms.Entiteti;
using NHibernate.Linq;
using ProdavnicaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseAccess.DataProvider
{
    public static class DataProviderAleksa
    {
        #region Lokacija
        public static Result<List<LokacijaView>,ErrorMessage> VratiSveLokacije()
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
                var error = new ErrorMessage(ex.Message,500);
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

        // Unutar DataProviderAleksa.cs

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
            ISession s=null;
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
                if(kurs==null)
                    return new ErrorMessage($"Kurs sa id'{kursId}' ne postoji.", 404);

                string tipNastave = VratiTipNastave(VratiTipKursa(kurs));
                foreach (var n in nastave)
                {
                    nastavePregled.Add(new NastavaView()
                    {
                        Id = n.Id,
                        DatumOd = n.DatumOd,
                        DatumDo = n.DatumDo,
                        FIndividualna = tipNastave=="Individualna",
                        FGrupna = tipNastave=="Grupna",
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
            if (tipKursa == TipKursaEnum.Instrument || tipKursa == TipKursaEnum.GrupaInstrumenata|| tipKursa == TipKursaEnum.IndividualnoPevanje)
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
                if (nastava == null )
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
        public static Result<List<CasView>,ErrorMessage> VratiSveCasoveZaNastavu(int nastavaId)
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
                if(nastavnik == null)
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

        public static Result<List<PrisustvoView>,ErrorMessage> VratiPrisustvaZaCas(int casId)
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
                        PolaznikPunoIme = polaznikOsoba.Ime + " " +polaznikOsoba.Prezime,
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
                    return new ErrorMessage("Nije moguce evidentirati polaznika za dati čas!",400);
                }
                Cas c = s.Load<Cas>(prisustvoDto.IdCasa);
                if(c==null)
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
    }
}
