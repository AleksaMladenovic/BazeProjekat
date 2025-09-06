using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace MuzickaSkolaWindowsForms.Entiteti
{
    public class VokalniKurs
    {
        public virtual int IdKursa { get; set; }
        public virtual int FIndividualnoPevanje {  get; set; }
        public virtual int FHorskoPevanje { get; set; }
    }
}
