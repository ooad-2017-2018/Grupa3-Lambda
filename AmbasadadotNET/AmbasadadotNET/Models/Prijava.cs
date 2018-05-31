using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbasadadotNET.Models
{
    public class Prijava
    {
       public  int id { get; set; }
       public  Podnosilac podnosilacPrijave { get; set; }
        public DateTime vrijemePrijave { get; set; }
        public bool stanjePrijave { get; set; }
        public Prijava() { }
    }
}
