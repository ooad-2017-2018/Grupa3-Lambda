using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ambasada
{
   public class Uposlenik:Osoba
    {
        string username;
        string password;
        bool administrator;
        string id = "";
        
        public Uposlenik(string id,string naziv, string email, DateTime datumRodjenja, string jmbg,string username, string password, bool administrator): base(naziv, email,  datumRodjenja, jmbg)
        {
            Username = username;
            Password = password;
            Administrator = administrator;
            Id = id;
        }

        public string Username { get => username; set{
                if (username.Length == 0) throw new Exception("Nevažeći username.");
                username = value;
            } }
        public string Password { get => password; set {
                if (password.Length == 0) throw new Exception("Nevažeći password.");
                password = value; } }
        public bool Administrator { get => administrator; set => administrator = value;}
        public string Id { get => id; set => id = value; }

        public override string ToString() {
            return Username;
        }
    }
}
