using Ambasada.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
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
       public static string apiUrl = "https://ambasadaapinet2018.azurewebsites.net/";
        public static async Task<ObservableCollection<Prijava>> dajPrijave() { //dodati async
            ObservableCollection<Prijava> prijave = new ObservableCollection<Prijava>();
           
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Prijava/");
                    //Provjera da li je rezultat uspješan
                    if (Res.IsSuccessStatusCode)
                    {  
                        var response = Res.Content.ReadAsStringAsync().Result;
                    prijave = JsonConvert.DeserializeObject<ObservableCollection<Prijava>>(response);
                    }

                return prijave;
                }
        }
        public static async Task<ObservableCollection<Prijava>> dajPotvrdjenePrijave() {
            ObservableCollection<Prijava> prijavice = new ObservableCollection<Prijava>();
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Prijava/");

                if (res.IsSuccessStatusCode) {
                    var odgovor = res.Content.ReadAsStringAsync().Result;
                    prijavice = JsonConvert.DeserializeObject<ObservableCollection<Prijava>>(odgovor);
                }
                ObservableCollection<Prijava> vrati = new ObservableCollection<Prijava>();
                foreach (var x in prijavice) {
                    if (x.stanjePrijave)
                        vrati.Add(x);
                }
                return vrati;
            }
        }
        public static async Task<ObservableCollection<Prijava>> dajOdbijenePrijave() {
            ObservableCollection<Prijava> prijavice = new ObservableCollection<Prijava>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Prijava/");

                if (res.IsSuccessStatusCode)
                {
                    var odgovor = res.Content.ReadAsStringAsync().Result;
                    prijavice = JsonConvert.DeserializeObject<ObservableCollection<Prijava>>(odgovor);
                }
                ObservableCollection<Prijava> vrati = new ObservableCollection<Prijava>();
                foreach (var x in prijavice)
                {
                    if (!x.stanjePrijave)
                        vrati.Add(x);
                }
                return vrati;
            }
        }
        public static async void updatePrijavu(Prijava p)
        {
              using(var client =new HttpClient())
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var json = JsonConvert.SerializeObject(p);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, apiUrl+ "api/Prijava/" + p.id);
                request.Content = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                await client.SendAsync(request)
               .ContinueWith(responseTask => {
                   Console.WriteLine("Response: {0}", responseTask.Result);
               });


            }
        }
        public static async Task< ObservableCollection<Uposlenik>> dajUposlenike()
        {
            ObservableCollection<Uposlenik> tmp = new ObservableCollection<Uposlenik>();
            var lista = App.MobileService.GetTable<uposlenici>();
     
            var kor = from x in lista
                      where x.Administrator == false
                      select x;
            var listatmp = await kor.ToListAsync();
            foreach (var x in listatmp)
            {
                tmp.Add( new Uposlenik(x.id, x.Naziv, x.Email, x.DatumRodjenja, x.Jmbg, x.Username, x.Password, x.Administrator));
            }
            return tmp;

        }
        public static async void dodajUposlenika(Uposlenik u) {
            var lista = App.MobileService.GetTable<uposlenici>();
            uposlenici upo = new uposlenici();
            upo.Administrator = false;
            upo.Naziv = u.Naziv;
            upo.Jmbg = u.Jmbg;
            upo.Password = u.Password;
            upo.Username = u.Username;
            upo.Email = u.Email;
            upo.DatumRodjenja = u.DatumRodjenja;
            await lista.InsertAsync(upo);
        }
        public static async void azurirajUposlenika(Uposlenik u) {
            var lista = App.MobileService.GetTable<uposlenici>();
            uposlenici editovani = new uposlenici();
            editovani.id = u.Id;
            editovani.Administrator = false;
            editovani.Naziv = u.Naziv;
            editovani.Jmbg = u.Jmbg;
            editovani.Password = u.Password;
            editovani.Username = u.Username;
            editovani.Email = u.Email;
            editovani.DatumRodjenja = u.DatumRodjenja;
            await lista.UpdateAsync(editovani);
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
