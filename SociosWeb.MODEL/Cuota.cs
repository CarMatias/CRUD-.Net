using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociosWeb.MODEL
{
    public class Cuota
    { 
        public int id { get; set; }
        public string mes { get; set; }
        public double monto { get; set; }
        public int nrosocio { get; set; }
        public bool pago { get; set; }

        
    }
}
