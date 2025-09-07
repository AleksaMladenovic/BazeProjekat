using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class Nastava
    {
        public virtual int Id { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }
        //public virtual int IdKursa {  get; set; }
        //public virtual int FIndividualna {  get; set; }
        //public virtual int FGrupna {  get; set; }

    }
}
