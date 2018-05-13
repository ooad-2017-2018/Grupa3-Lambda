using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.SqlClient;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Ambasada.ViewModel;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrisanjeAzuriranjeRacuna : Page
    {
        private AdminViewModel viewmodel = new AdminViewModel();
        public BrisanjeAzuriranjeRacuna()
        {

           
            this.InitializeComponent();
            status.Text = "";
      //    ImePrezimeTB.Text = ListaUposlenika.Items.Count.ToString();
            
        }
      

         //   ListaUposlenika.ItemsSource = uposlenici;

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewmodel = (AdminViewModel)e.Parameter;
            ListaUposlenika.ItemsSource = viewmodel.Lista; // krah zbog nullptr

        }
        private void ListaUposlenika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if(!(kliknuti is null))
            {
                JMBGTB.Text = kliknuti.Jmbg;
                ImePrezimeTB.Text = kliknuti.Naziv;
                UsernameTB.Text = kliknuti.Username;
                PasswordTB.Password = kliknuti.Password;
                DatumRodjenjaDP.Date = kliknuti.DatumRodjenja;
                EmailTB.Text = kliknuti.Email;
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if (!(kliknuti is null))
            {
                await BazaPodatakaHelper.obrisiUposlenikaAsync(kliknuti);
                ListaUposlenika.Items.RemoveAt(ListaUposlenika.SelectedIndex);
                EmailTB.Text = ""; JMBGTB.Text = ""; UsernameTB.Text = "";
                PasswordTB.Password = ""; ImePrezimeTB.Text = "";
                var dialog = new MessageDialog("Uspješno obrisan uposlenik");
                dialog.Title = "Uspješno obavljena radnja";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();
                if ((int)res.Id == 0) {
                    //kliknuto je OK!
                    return;
                }
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if (!(kliknuti is null))
            {
                try
                {
                    Uposlenik u = new Uposlenik(kliknuti.Id,ImePrezimeTB.Text,EmailTB.Text,DatumRodjenjaDP.Date.Date,JMBGTB.Text,UsernameTB.Text,PasswordTB.Password,kliknuti.Administrator);

                    viewmodel.Lista[ListaUposlenika.SelectedIndex] = u;
                    BazaPodatakaHelper.azurirajUposlenika(kliknuti);



                    var dialog1 = new MessageDialog("Uspješno ažuriran uposlenik");
                    dialog1.Title = "Uspješno obavljena radnja";
                    dialog1.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                    var res = await dialog1.ShowAsync();
                    if ((int)res.Id == 0)
                    {
                        //kliknuto je OK!
                        return;
                    }

                }
                catch (Exception ex) {
                    status.Text = ex.ToString();
                }

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UposleniciEdit));
        }
    }
}
