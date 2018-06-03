using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.Model
{
    public class Prijava
    {
        public int id { get; set; }

        public DateTime vrijemePrijave { get; set; }

        public bool stanjePrijave { get; set; }

        public int podnosilacPrijave_id { get; set; }
        public bool izdataPrijava { get; set; }
        public virtual Podnosilac Podnosilac { get; set; }

        public override string ToString() {
            return Podnosilac.naziv;
        }
    }
}
