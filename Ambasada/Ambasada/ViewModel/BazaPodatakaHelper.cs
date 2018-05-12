using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.ViewModel
{
    public static class BazaPodatakaHelper
    {
        public static async Task<Uposlenik> dajUposlenika(string username, string password)
        {
            var lista = App.MobileService.GetTable<uposlenici>();
            var kor = from x in lista
                      where x.Username == username && x.Password == password
                      select x;
            var listatmp = await kor.ToListAsync();
            if (listatmp.Count == 0) throw new Exception("Nepostojeci korisnik");
            else
            {
                return new Uposlenik(listatmp[0].id,listatmp[0].Naziv, listatmp[0].Email, listatmp[0].DatumRodjenja, listatmp[0].Jmbg, listatmp[0].Username, listatmp[0].Password, listatmp[0].Administrator);
            }
        }
        public static async Task<Uposlenik> dajUposlenika(string id)
        {
            var lista = App.MobileService.GetTable<uposlenici>();
            var kor = from x in lista
                      where x.id == id
                      select x;
            var listatmp = await kor.ToListAsync();
            if (listatmp.Count == 0) throw new Exception("Nepostojeci korisnik");
            else
            {
                return new Uposlenik(listatmp[0].id, listatmp[0].Naziv, listatmp[0].Email, listatmp[0].DatumRodjenja, listatmp[0].Jmbg, listatmp[0].Username, listatmp[0].Password, listatmp[0].Administrator);
            }
        }
        public static async Task< ObservableCollection<Uposlenik>> dajUposlenike()
        {
            ObservableCollection<Uposlenik> tmp = new ObservableCollection<Uposlenik>();
            var lista = App.MobileService.GetTable<uposlenici>();
            var kor = from x in lista
                      select x;
            var listatmp = await kor.ToListAsync();
            foreach (var x in listatmp)
            {
                tmp.Add( new Uposlenik(listatmp[0].id, listatmp[0].Naziv, listatmp[0].Email, listatmp[0].DatumRodjenja, listatmp[0].Jmbg, listatmp[0].Username, listatmp[0].Password, listatmp[0].Administrator));
            }
            return tmp;

        }
        public static async Task obrisiUposlenikaAsync(Uposlenik u)
        {
            ObservableCollection<Uposlenik> tmp = new ObservableCollection<Uposlenik>();
            var lista = App.MobileService.GetTable<uposlenici>();
            var kor = from x in lista
                      where x.id==u.Id
                      select x;
            var listatmp = await kor.ToListAsync();
            await lista.DeleteAsync(listatmp[0]);
        }
    }
    
}
