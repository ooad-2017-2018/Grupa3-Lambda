using Ambasada.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinUX;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private async System.Threading.Tasks.Task LoginButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            status.Text = "";
            if (pwbox.Password.ToString().Length == 0||UsernameTB.Text.Length==0)
            {
                status.Text = "Nepotpun unos";
                return;
            }
            //var uposlenici = new ObservableCollection<Uposlenik>();
             var lista = App.MobileService.GetTable<uposlenici>();
            var kor = from x in lista
                      where x.Username == UsernameTB.Text && x.Password == pwbox.Password
                      select x;
            var listatmp = await kor.ToListAsync();
            if (listatmp.Count ==0)
            {
                status.Text = "Nepostojeci korisnik";
            }
            else
            {
                var k = listatmp[0];
                if(k.Administrator) this.Frame.Navigate(typeof(AdminPanel));
                else this.Frame.Navigate(typeof(UposlenikPage));
            }
               /// ListaUposlenika.ItemsSource = uposlenici;

            
           
        }
    }
}
