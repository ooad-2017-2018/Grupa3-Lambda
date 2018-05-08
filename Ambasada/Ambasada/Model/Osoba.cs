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
        

        public string Naziv { get => naziv; set{
                if (naziv.Length == 0 || !naziv.Contains(" ")) throw new Exception("Nevažeći naziv.");                       
                naziv = value; } }
        public string Email { get => email; set {
                if (!email.Contains("@")) throw new Exception("Nevažeći email.");
                email = value; } }
        public DateTime DatumRodjenja { get => datumRodjenja; set {
                if (datumRodjenja.Year < 1900 || datumRodjenja.Year >= System.DateTime.Now.Year - 18)
                    throw new Exception("Nevažeća godina rođenja.");
                datumRodjenja = value; } }
        public string Jmbg { get => jmbg; set{
                var a = (jmbg[4].ToString() + jmbg[5].ToString() + jmbg[6].ToString());
                var b =//1997 => 997
                    (datumRodjenja.Year / 100 % 10).ToString() //9
                    + (datumRodjenja.Year / 10 % 10).ToString() //9
                    + (datumRodjenja.Year % 10).ToString(); //7
                if (jmbg.Length < 13 || jmbg[0] != (int)datumRodjenja.Day / 10 || jmbg[1] != datumRodjenja.Day % 10
                   || jmbg[2] != (int)datumRodjenja.Month / 10 || jmbg[3] != datumRodjenja.Month % 10 ||
                    a != b) throw new Exception("Nevažeći JMBG.");
                jmbg = value; } }
        public int IdOsobe { get => idOsobe; set {
                if (idOsobe.GetType() != typeof(int) || idOsobe <= 0) throw new Exception("Nevažeći ID osobe."); 
                idOsobe = value; } }
    }
}
