using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada
{
    public abstract class Osoba
    {

        string naziv;
        string email;
        DateTime datumRodjenja;
        string jmbg;

        protected Osoba(string naziv, string email, DateTime datumRodjenja, string jmbg)
        {
            Naziv = naziv;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Jmbg = jmbg;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
    }
}
