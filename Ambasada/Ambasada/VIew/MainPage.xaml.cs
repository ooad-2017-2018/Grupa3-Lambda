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
        
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            status.Text = "";
            if (pwbox.Password.ToString().Length == 0||UsernameTB.Text.Length==0)
            {
                status.Text = "Nepotpun unos";
                return;
            }
                //var uposlenici = new ObservableCollection<Uposlenik>();
                try
                {
                    if(BazaPodatakaHelper.loginKorisnika(UsernameTB.Text,pwbox.Password)) this.Frame.Navigate(typeof(AdminPanel));
                else this.Frame.Navigate(typeof(UposlenikPage));
                }
                catch (Exception eSql)
                {
                status.Text = eSql.Message;
                }

               /// ListaUposlenika.ItemsSource = uposlenici;

            
           
        }
    }
}
