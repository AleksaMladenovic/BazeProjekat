using DatabaseAccess.DTOs;
using MuzickaSkolaWindowsForms;
using ProdavnicaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
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
    }
}
