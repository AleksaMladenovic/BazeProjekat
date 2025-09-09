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
        public static List<NastavnikPregled> VratiSveNastavnike()
        {


            List<NastavnikPregled> rezultat = new List<NastavnikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();


                IEnumerable<Honorarac> honorarac = s.Query<Honorarac>().ToList();

                foreach (var op in honorarac)
                {
                    rezultat.Add(new NastavnikPregled(op.OsnovniPodaci.Id, op.OsnovniPodaci.Jmbg, op.OsnovniPodaci.Ime, op.OsnovniPodaci.Prezime, "Honorarac")
                    {
                        StrucnaSprema = op.StrucnaSprema
                    });
                }


                IEnumerable<StalnoZaposlen> stalno = s.Query<StalnoZaposlen>().ToList();

                foreach (var dp in stalno)
                {


                    rezultat.Add(new NastavnikPregled(dp.OsnovniPodaci.Id, dp.OsnovniPodaci.Jmbg, dp.OsnovniPodaci.Ime, dp.OsnovniPodaci.Prezime, "Stalno Zaposleni")
                    {
                        RadnoVreme = dp.RadnoVreme

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
    }
}