using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbasadadotNET.Models
{
    public class Podnosilac 
    {
       
        public int id { get; set; }
        public string naziv { get; set; }
        public string email { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string jmbg { get; set; }
        public string dodatneInformacije { get; set; }
        public string mjestoPrebivalista { get; set; }
        public Podnosilac() { }
        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
    }
}
