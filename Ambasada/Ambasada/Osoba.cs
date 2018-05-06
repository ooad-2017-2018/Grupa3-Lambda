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
        int idOsobe;

        protected Osoba(int idOsobe,string naziv, string email, DateTime datumRodjenja, string jmbg)
        {
            IdOsobe = idOsobe;
            Naziv = naziv;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Jmbg = jmbg;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public int IdOsobe { get => idOsobe; set => idOsobe = value; }
    }
}
