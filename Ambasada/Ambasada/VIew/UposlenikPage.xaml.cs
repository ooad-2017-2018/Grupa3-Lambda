using System;
using System.Collections.Generic;
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
using Ambasada.VIew;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada.VIew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UposlenikPage : Page
    {
        public UposlenikPage()
        {
            this.InitializeComponent();
        }

        private void PrintVizeButton_Click(object sender, RoutedEventArgs e)
        {
            //uradi nešto što će se povezati sa printerom i isprintati
        }

        private void PotvrdiPrijavuButton_Click(object sender, RoutedEventArgs e)
        {
            //odobri selektovanu prijavu za tombolu//
        }

        private void OdbijPrijavuButton_Click(object sender, RoutedEventArgs e)
        {
            //odbij selektovanu prijavu za tombolu
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            //logout korisnika, vraća na login page
        }

        private void PosaljiEmailButton_Click(object sender, RoutedEventArgs e)
        {
            //šalje sve na formu za popunjavanje emaila
            this.Frame.Navigate(typeof(SlanjeEmail)); //fali helper kao drugi arg
        }

        private void DownloadPDFPrijaveButton_Click(object sender, RoutedEventArgs e)
        {
            //servis da se učita PDF fajl trenutačne prijave
        }
    }
}
