using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Mapiranja
{
    class NastavnikMapiranja : SubclassMap<Nastavnik>
    {
        public NastavnikMapiranja(){
            DiscriminatorValue(1);

            Map(p => p.DatumZaposlenja, "DATUM_ZAPOSLENJA");
            Map(p => p.StrucnaSprema, "STRUCNA_SPREMA");

        }
    }
}
