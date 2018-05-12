using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.ViewModel
{
    public class uposlenici
    {
        public string id { get; set; }
        // 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        
        public string Naziv { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Jmbg { get; set; }
  
    }
}
