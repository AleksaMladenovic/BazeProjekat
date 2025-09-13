using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class PrisustvoView
    {
        public int PolaznikId { get; set; }
        public int CasId { get; set; }

        // Podaci za prikaz
        public string PolaznikPunoIme { get; set; }
        public string CasTema { get; set; }
        public DateTime CasTermin { get; set; }
        public int? Ocena { get; set; }

        public PrisustvoView() { }

    }
}
