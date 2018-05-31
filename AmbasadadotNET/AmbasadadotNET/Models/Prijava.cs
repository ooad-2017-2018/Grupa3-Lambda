using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbasadadotNET.Models
{
    class Prijava
    {
        Podnosilac podnosilacPrijave;
        DateTime vrijemePrijave;
        bool stanjePrijave;

        public Prijava(Podnosilac podnosilacPrijave, DateTime vrijemePrijave, bool stanjePrijave)
        {
            this.podnosilacPrijave = podnosilacPrijave;
            this.vrijemePrijave = vrijemePrijave;
            this.stanjePrijave = stanjePrijave;
        }

        public Podnosilac PodnosilacPrijave { get => podnosilacPrijave; set => podnosilacPrijave = value; }
        public DateTime VrijemePrijave { get => vrijemePrijave; set => vrijemePrijave = value; }
        public bool StanjePrijave { get => stanjePrijave; set => stanjePrijave = value; }
        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
    }
}
