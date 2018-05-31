using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbasadadotNET.Models
{
    public class Podnosilac : Osoba
    {
        string dodatneInformacije;
        string mjestoPrebivalista;
        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
        protected Podnosilac(int idOsobe, string naziv, string email, DateTime datumRodjenja, string jmbg,string dodatneInfo, string mjestoPreb) : base( naziv, email, datumRodjenja, jmbg)
        {
            dodatneInformacije = dodatneInfo;
            mjestoPrebivalista = mjestoPreb;
        }

        public string DodatneInformacije { get => dodatneInformacije; set => dodatneInformacije = value; }
        public string MjestoPrebivalista { get => mjestoPrebivalista; set => mjestoPrebivalista = value; }
    }
}
