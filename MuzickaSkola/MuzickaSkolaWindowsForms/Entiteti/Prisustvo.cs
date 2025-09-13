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
        public virtual int Ocena {  get; set; }

        public Prisustvo() {
            Id = new PrisustvoId();
        }
    }

    public class PrisustvoId
    {
        public virtual int PolaznikId { get; set; }    

        public virtual Cas CasKomePrisustvuje { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = obj as PrisustvoId;
            if (other == null) return false;

            return PolaznikId == other.PolaznikId &&
                   CasKomePrisustvuje.Id == other.CasKomePrisustvuje.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
