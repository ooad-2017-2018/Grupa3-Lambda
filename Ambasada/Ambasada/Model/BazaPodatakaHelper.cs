using Ambasada.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace Ambasada.Model
{
    public static class BazaPodatakaHelper
    {
        public static async Task<Uposlenik> DajUposlenika(string username, string password)
        {
            var lista = App.MobileService.GetTable<Uposlenici>();
            var kor = from x in lista
                      where x.Username == username && x.Password == password 
                      select x;
            var listatmp = await kor.ToListAsync();
            if (listatmp.Count == 0) throw new Exception("Nepostojeci korisnik");
            else
            {
                return new Uposlenik(listatmp[0].Id,listatmp[0].Naziv, listatmp[0].Email, listatmp[0].DatumRodjenja, listatmp[0].Jmbg, listatmp[0].Username, listatmp[0].Password, listatmp[0].Administrator);
            }
        }
        public static async Task<Uposlenik> DajUposlenika(string id)
        {
            var lista = App.MobileService.GetTable<Uposlenici>();
            var kor = from x in lista
                      where x.Id == id 
                      select x;
            var listatmp = await kor.ToListAsync();
            if (listatmp.Count == 0) throw new Exception("Nepostojeci korisnik");
            else
            {
                return new Uposlenik(listatmp[0].Id, listatmp[0].Naziv, listatmp[0].Email, listatmp[0].DatumRodjenja, listatmp[0].Jmbg, listatmp[0].Username, listatmp[0].Password, listatmp[0].Administrator);
            }
        }
       public static string apiUrl = "https://ambasadaapinet2018.azurewebsites.net/";
        public static async Task<ObservableCollection<Prijava>> DajPrijave() { //dodati async
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
        public static async Task<ObservableCollection<Prijava>> DajPotvrdjenePrijave() {
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
                    if (x.stanjePrijave && !x.izdataPrijava)
                        vrati.Add(x);
                }
                return vrati;
            }
        }
        public static async Task<ObservableCollection<Prijava>> DajOdbijenePrijave() {
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
        public static async void UpdatePrijavu(Prijava p)
        {
              using(var client =new HttpClient())
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var json = JsonConvert.SerializeObject(p);

#pragma warning disable IDE0017 // Simplify object initialization
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put , apiUrl+ "api/Prijava/" + p.id);
#pragma warning restore IDE0017 // Simplify object initialization
                request.Content = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                await client.SendAsync(request)
               .ContinueWith(responseTask => {
                   Console.WriteLine("Response: {0}", responseTask.Result);
               });


            }
        }
        public static async void posaljiEmail(Email a)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var json = JsonConvert.SerializeObject(a);

#pragma warning disable IDE0017 // Simplify object initialization
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl + "api/Email" );
#pragma warning restore IDE0017 // Simplify object initialization
                request.Content = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                await client.SendAsync(request)
               .ContinueWith(responseTask => {
                   Console.WriteLine("Response: {0}", responseTask.Result);
               });


            }
        }
        public static async Task< ObservableCollection<Uposlenik>> DajUposlenike()
        {
            ObservableCollection<Uposlenik> tmp = new ObservableCollection<Uposlenik>();
            var lista = App.MobileService.GetTable<Uposlenici>();
     
            var kor = from x in lista
                      where x.Administrator == false
                      select x;
            var listatmp = await kor.ToListAsync();
            foreach (var x in listatmp)
            {
                tmp.Add( new Uposlenik(x.Id, x.Naziv, x.Email, x.DatumRodjenja, x.Jmbg, x.Username, x.Password, x.Administrator));
            }
            return tmp;

        }
        public static async void DodajUposlenika(Uposlenik u) {
            var lista = App.MobileService.GetTable<Uposlenici>();
#pragma warning disable IDE0017 // Simplify object initialization
            Uposlenici upo = new Uposlenici();
#pragma warning restore IDE0017 // Simplify object initialization
            upo.Administrator = false;
            upo.Naziv = u.Naziv;
            upo.Jmbg = u.Jmbg;
            upo.Password = u.Password;
            upo.Username = u.Username;
            upo.Email = u.Email;
            upo.DatumRodjenja = u.DatumRodjenja;
            await lista.InsertAsync(upo);
        }
        public static async void AzurirajUposlenika(Uposlenik u) {
            var lista = App.MobileService.GetTable<Uposlenici>();
#pragma warning disable IDE0017 // Simplify object initialization
            Uposlenici editovani = new Uposlenici();
#pragma warning restore IDE0017 // Simplify object initialization
            editovani.Id = u.Id;
            editovani.Administrator = false;
            editovani.Naziv = u.Naziv;
            editovani.Jmbg = u.Jmbg;
            editovani.Password = u.Password;
            editovani.Username = u.Username;
            editovani.Email = u.Email;
            editovani.DatumRodjenja = u.DatumRodjenja;
            await lista.UpdateAsync(editovani);
        }
        public static async Task ObrisiUposlenikaAsync(Uposlenik u)
        {
            ObservableCollection<Uposlenik> tmp = new ObservableCollection<Uposlenik>();
            var lista = App.MobileService.GetTable<Uposlenici>();
            var kor = from x in lista
                      where x.Id==u.Id
                      select x;
            var listatmp = await kor.ToListAsync();
            await lista.DeleteAsync(listatmp[0]);
        }
    }
    
}
