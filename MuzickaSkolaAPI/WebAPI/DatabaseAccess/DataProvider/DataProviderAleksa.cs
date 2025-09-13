using DatabaseAccess.DTOs;
using MuzickaSkolaWindowsForms;
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
    }
}
