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
    public sealed partial class KreiranjeRacuna : Page
    {
        public KreiranjeRacuna()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void RregistrujUposlenikaB_Click(object sender, RoutedEventArgs e)
        {
            status.Text = "";
            try
            {
                BazaPodatakaHelper.dodajUposlenika(new Uposlenik("-1", ImePrezimeTB.Text, EmailTB.Text, DatumRodjenjaDP.Date.Date, JMBGTB.Text, UsernameTB.Text, PasswordTB.Password, false));
            }
            catch (Exception ex) {
                status.Text = ex.ToString();
            }
        }
    }
}
