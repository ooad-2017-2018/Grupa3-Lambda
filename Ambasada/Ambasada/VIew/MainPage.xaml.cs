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
using Ambasada.Model;
using Ambasada.VIew;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AdminViewModel viewmodel = new AdminViewModel();

        private UposlenikViewModel uviewmodel = new UposlenikViewModel();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            status.Text = "";
            try
            {
                var k = await BazaPodatakaHelper.DajUposlenika(UsernameTB.Text, pwbox.Password);
                if (k.Administrator) this.Frame.Navigate(typeof(AdminPanel),viewmodel);
                else this.Frame.Navigate(typeof(UposlenikPage),uviewmodel);
            }
            catch (Exception ex)
            {// me valja username ili password
                status.Text = ex.Message;
                status.Text = "Pogrešno ste unijeli username/password ili je došlo do greške na serveru.";
                //status.Text = ex.ToString();
            }
 
           

        }
    }
}
