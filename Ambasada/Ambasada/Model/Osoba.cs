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
          //  IdOsobe = idOsobe;
            Naziv = naziv;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Jmbg = jmbg;
        }
        

        public string Naziv { get => naziv; set{
                if (value.Length == 0) throw new Exception("Nevažeći naziv.");                       
                naziv = value; } }
        public string Email { get => email; set {
                if (!value.Contains("@")) throw new Exception("Nevažeći email.");
                email = value; } }
        public DateTime DatumRodjenja { get => datumRodjenja; set {
                if (value.Year < 1900 || value.Year >= System.DateTime.Now.Year - 18)
                    throw new Exception("Nevažeća godina rođenja.");
                datumRodjenja = value; } }
        public string Jmbg { get => jmbg; set{
                if (!App.ValidacijaJMBGa(value, datumRodjenja)) throw new Exception("Nevažeći JMBG");
                jmbg = value; } }

        /* public int IdOsobe { get => idOsobe; set {
if (idOsobe.GetType() != typeof(int) || idOsobe <= 0) throw new Exception("Nevažeći ID osobe."); 
idOsobe = value; } } */
    }
}
