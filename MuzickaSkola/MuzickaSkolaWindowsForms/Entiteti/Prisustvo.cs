using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Prisustvo
    {
        public virtual PrisustvoId Id { get; set; }
        //public virtual required string JmbgPolaznika {  get; set; }
        //public virtual int IdCasa {  get; set; }
        public virtual int Ocena {  get; set; }
    }

    public class PrisustvoId
    {
        // Deo ključa koji pokazuje na Polaznika
        public virtual Polaznik PolaznikNaCasu { get; set; }

        // Deo ključa koji pokazuje na Cas
        public virtual Cas CasKomePrisustvuje { get; set; }

        // NHibernate zahteva da se Equals() i GetHashCode() predefinišu
        // za klase koje predstavljaju kompozitni ključ.
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = obj as PrisustvoId;
            if (other == null) return false;

            return PolaznikNaCasu.Id == other.PolaznikNaCasu.Id &&
                   CasKomePrisustvuje.Id == other.CasKomePrisustvuje.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
