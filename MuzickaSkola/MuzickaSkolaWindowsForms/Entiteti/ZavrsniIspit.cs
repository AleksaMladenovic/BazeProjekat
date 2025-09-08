using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class ZavrsniIspit
    {
        public virtual ZavrsniIspitId Id { get; set; }
        public virtual int Ocena { get; set; }
        public virtual bool Sertifikat { get; set; }

        public virtual Komisija OcenjujeKomisija { get; set; }
        public virtual Polaznik PolazePolaznik { get; set; }

        public ZavrsniIspit()
        {
            Id = new ZavrsniIspitId();
        }
    }


    public class ZavrsniIspitId 
    {
        public virtual Kurs IspitIzKursa{ get; set; }

        public virtual DateTime Datum { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = obj as ZavrsniIspitId;
            if (other == null) return false;

            // poredimo samo datum, bez vremena
            return IspitIzKursa.Id == other.IspitIzKursa.Id &&
                   Datum.Date == other.Datum.Date;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
