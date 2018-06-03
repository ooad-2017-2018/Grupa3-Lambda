using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.Model
{
    public class Podnosilac 
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Podnosilac()
        {
           
        }

        public int id { get; set; }


        public string naziv { get; set; }

        public string email { get; set; }

        public DateTime datumRodjenja { get; set; }


        public string jmbg { get; set; }

        public string dodatneInformacije { get; set; }


        public string mjestoPrebivalista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Prijava prijavas { get; set; }
    }
}
