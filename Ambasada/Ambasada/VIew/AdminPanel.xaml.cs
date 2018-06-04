using Ambasada.VIew;
using Ambasada.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPanel : Page
    {
        private AdminViewModel viewmodel= new AdminViewModel();
        //private UposlenikViewModel uviewmodel = new UposlenikViewModel();
        public AdminPanel()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewmodel = (AdminViewModel)e.Parameter;
            
        }
        private void KreiranjeBrisanjeUposlenika_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UposleniciEdit),viewmodel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UredjivanjeTemplejtaZaEmail),viewmodel);
        }

        private void PokretanjeTombole_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TombolaPanel), viewmodel);
        }
    }
}
