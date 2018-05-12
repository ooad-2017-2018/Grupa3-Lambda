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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrisanjeAzuriranjeRacuna : Page
    {
        public BrisanjeAzuriranjeRacuna()
        {
            this.InitializeComponent();
         //   ListaUposlenika.ItemsSource = BazaPodatakaHelper.Ucitaj();  //
        }
       

         //   ListaUposlenika.ItemsSource = uposlenici;

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if (!(kliknuti is null))
            {
             //    BazaPodatakaHelper.ObrisiUposlenika(kliknuti);
                ListaUposlenika.Items.RemoveAt(ListaUposlenika.SelectedIndex);
                EmailTB.Text = ""; JMBGTB.Text = ""; UsernameTB.Text = "";
                PasswordTB.Password = ""; ImePrezimeTB.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if (!(kliknuti is null))
            {
               // BazaPodatakaHelper.AzurirajUposlenika(kliknuti);
            }
        }
              
    }
}
