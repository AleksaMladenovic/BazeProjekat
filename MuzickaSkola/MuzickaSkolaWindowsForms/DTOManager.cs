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

        public static UcionicaBasic vratiUcionicuZaIzmenu(UcionicaPregled ucionicaPregled)
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
    }
}