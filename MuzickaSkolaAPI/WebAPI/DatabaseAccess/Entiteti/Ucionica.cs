using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Ucionica
    {
        public virtual UcionicaId Id { get; set; }
        public virtual string? Opremljenost {  get; set; }
        public virtual int Kapacitet {  get; set; }

        public virtual IList<Cas> CasoviKojiSeOdrzavaju { get; set; }
        public Ucionica()
        {
            Id = new UcionicaId();
            CasoviKojiSeOdrzavaju = new List<Cas>();
        }
    }

    public class UcionicaId {
        public virtual Lokacija PripadaLokaciji { get; set; }

        public virtual string  Naziv { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = obj as UcionicaId;
            if (other == null) return false;

            return PripadaLokaciji.Adresa == other.PripadaLokaciji.Adresa &&
                   Naziv == other.Naziv;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
