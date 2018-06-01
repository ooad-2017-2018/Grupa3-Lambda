using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmbasadadotNET.Models
{
    public class Podnosilac 
    {
       
        public int id { get; set; }
        [Required]
        public string naziv { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [Range(1900, 2000, ErrorMessage = "Morate biti punoljetni i mlađi od 150 godina.")]
        public DateTime datumRodjenja { get; set; }
        [Required]
        public string jmbg { get; set; }
        public string dodatneInformacije { get; set; }
        [Required]
        public string mjestoPrebivalista { get; set; }
        public Podnosilac() { }
        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
    }
}
