using Ambasada.Model;
using Ambasada.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada.VIew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TombolaPanel : Page
    {
        AdminViewModel viewmodel = new AdminViewModel();
        public TombolaPanel()
        {
            this.InitializeComponent();
        }
        ObservableCollection<Prijava> proslePrijave = new ObservableCollection<Prijava>();
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            PosaljiEmailPobjednicimaButton.Visibility = (Visibility)(1); //collapsed 1, visible 0
            base.OnNavigatedTo(e);
            viewmodel = (AdminViewModel)e.Parameter;
            ObavjestenjeLabela.Text = "";
            proslePrijave =await BazaPodatakaHelper.dajPotvrdjenePrijave();
            ListaOdobrenihPrijavaLB.ItemsSource = proslePrijave;
            ObavjestenjeLabela.Text = "Učitane su odobrene prijave.";
        }
        public async void PokreniTomboluButton_Click(object sender, RoutedEventArgs e)
        {

            ObservableCollection<Prijava> pobjednici = new ObservableCollection<Prijava>();
                pobjednici = await viewmodel.Tombola.uradiTombolu();
            ListaOdobrenihVizaLB.ItemsSource = pobjednici;
            ObavjestenjeLabela.Text = "Izvršen je proces tombole. Sretni dobitnici su prikazani desno.";
            PosaljiEmailPobjednicimaButton.Visibility = (Visibility)(0);
            foreach (var x in pobjednici)
            {
                proslePrijave.Remove(x); // šutanje uspjelih iz prijava.
                x.izdataPrijava = true; // 
                BazaPodatakaHelper.updatePrijavu(x);
            }
        }

        private void PosaljiEmailPobjednicimaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPanel), viewmodel);
        }
    }
}
