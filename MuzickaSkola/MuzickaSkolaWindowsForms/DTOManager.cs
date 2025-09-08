using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MuzickaSkolaWindowsForms.Entiteti;
using FluentNHibernate.Utils;


namespace MuzickaSkolaWindowsForms
{
    public class DTOManager
    {
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

                // --- NOVO: bez obzira da li je PrijavioRoditelj tip Roditelj ili Osoba,
                //           uzmi ID i učitaj OSOBA pa pokupi Ime/Prezime.
                int idRoditelja = dp.PrijavioRoditelj?.Id ?? 0;
                string? punoImeRoditelja = null;
                if (idRoditelja > 0)
                {
                    var osobaRoditelj = s.Get<Osoba>(idRoditelja); // ← direktno iz OSOBA
                    if (osobaRoditelj != null)
                        punoImeRoditelja = $"{osobaRoditelj.Ime} {osobaRoditelj.Prezime}";
                }
                // ---

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
                // Ako imaš FRoditelj flag u OSOBA (kao što prikazuješ u klasi):
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
                    // Obeleži da je roditelj (ako već nije)
                    if (!roditelj.FRoditelj) roditelj.FRoditelj = true;

                    // Po želji osveži osnovne podatke ako su uneti
                    if (!string.IsNullOrWhiteSpace(ime)) roditelj.Ime = ime!;
                    if (!string.IsNullOrWhiteSpace(prezime)) roditelj.Prezime = prezime!;
                    if (!string.IsNullOrWhiteSpace(adresa)) roditelj.Adresa = adresa!;
                    if (!string.IsNullOrWhiteSpace(telefon)) roditelj.Telefon = telefon!;
                    if (!string.IsNullOrWhiteSpace(email)) roditelj.Email = email!;

                    s.Update(roditelj);
                    tx.Commit();
                    return roditelj.Id;
                }

                // 2) Ako ne postoji – kreiraj novog roditelja
                var novaOsoba = new Osoba
                {
                    Jmbg = jmbg,
                    Ime = ime ?? "",
                    Prezime = prezime ?? "",
                    Adresa = adresa,
                    Telefon = telefon,
                    Email = email,
                    FRoditelj = true
                };

                s.Save(novaOsoba);
                tx.Commit();
                return novaOsoba.Id;
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

                // 3) projekcija u DTO
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

        // Izmena roditelja (ažurira OSOBA)
        public static void IzmeniRoditelja(RoditeljListItem dto)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var o = s.Get<Osoba>(dto.IdOsobe) ?? throw new ApplicationException("Roditelj ne postoji.");

                o.Ime = dto.Ime ?? o.Ime;
                o.Prezime = dto.Prezime ?? o.Prezime;
                if (!string.IsNullOrWhiteSpace(dto.Jmbg)) o.Jmbg = dto.Jmbg; // pazi na jedinstvenost JMBG u bazi
                o.Telefon = dto.Telefon;
                o.Email = dto.Email;

                s.Update(o);
                tx.Commit();
            }
        }

        // "Brisanje" roditelja: skini ulogu i odveži svu decu (ID_RODITELJA = NULL)
        public static void ObrisiRoditelja(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            using (var tx = s.BeginTransaction())
            {
                var o = s.Get<Osoba>(idOsobe) ?? throw new ApplicationException("Roditelj ne postoji.");

                // Odveži svu decu koja imaju ovog roditelja
                var deca = s.Query<DetePolaznik>()
                            .Where(d => d.PrijavioRoditelj != null && d.PrijavioRoditelj.Id == idOsobe)
                            .ToList();
                foreach (var d in deca)
                {
                    d.PrijavioRoditelj = null;
                    s.Update(d);
                }

                // Skini ulogu roditelja (OSOBA ostaje)
                o.FRoditelj = false;
                s.Update(o);

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
                    IdKursa = k.Id,
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
        public static List<ZavrsniIspitPregled> VratiPolozeneIspite(int idOsobe)
        {
            using (var s = DataLayer.GetSession())
            {
                return s.Query<ZavrsniIspit>()
                        .Where(z => z.PolazePolaznik.Id == idOsobe)
                        .Select(z => new ZavrsniIspitPregled
                        {
                            IdKursa = z.Id.IspitIzKursa.Id,
                            NazivKursa = z.Id.IspitIzKursa.Naziv,
                            Datum = z.Id.Datum,
                            Ocena = z.Ocena,
                            Sertifikat = z.Sertifikat
                        })
                        .ToList();
            }
        }
    }
}
#endregion