using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Cas
    {
        public virtual int Id { get; set; }
        public virtual DateTime Termin{ get; set;}
        public virtual string? Tema { get; set; }
        //public  virtual required int  JmbgNastavnika { get; set; }
        //public virtual string? NazivUcionice { get; set; }
        
        //public virtual required string AdresaLokacije { get; set; }
        //public virtual int IdNastave { get; set; }

    }
}
