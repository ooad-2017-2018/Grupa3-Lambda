using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmbasadadotNET.Models
{
    public class Prijava
    {
        [Required]
        public  int id { get; set; }
        [Required]
        public  Podnosilac podnosilacPrijave { get; set; }
        [Required]
        public DateTime vrijemePrijave { get; set; }
        //[Required]
        public bool stanjePrijave { get; set; }

        public Prijava() { }
    }
}
