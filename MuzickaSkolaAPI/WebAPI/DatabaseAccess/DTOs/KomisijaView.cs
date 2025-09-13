using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickaSkolaWindowsForms.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KomisijaView
    {
        public int Id { get; set; }
    
        public List<OsobaView> ClanoviKomisijePrikaz { get; set; }
    
        public KomisijaView() 
        {
            ClanoviKomisijePrikaz = new List<OsobaView>();
        }

        internal KomisijaView(Komisija? k)
        {
            if (k != null)
            {
                this.Id = k.Id;

                if (k.ClanoviKomisije != null)
                {
                    this.ClanoviKomisijePrikaz = k.ClanoviKomisije
                                                  .Select(clan => new OsobaView(clan))
                                                  .ToList();
                }
                else
                {
                    this.ClanoviKomisijePrikaz = new List<OsobaView>();
                }

            }
        }
    }
}
