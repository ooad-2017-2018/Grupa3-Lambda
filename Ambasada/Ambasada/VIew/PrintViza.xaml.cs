using Ambasada.Model;
using Ambasada.ViewModel;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
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
    public sealed partial class PrintViza : Page
    {
        public PrintViza()
        {
            this.InitializeComponent();
        }
        private UposlenikViewModel viewmodel = new UposlenikViewModel();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewmodel = (UposlenikViewModel)e.Parameter;
            var lista = viewmodel.dajListuPrijava();
            ListaOdobrenihVizaLB.ItemsSource = lista;
        }
       
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            var clicked = (Prijava)ListaOdobrenihVizaLB.SelectedItem;
            if (clicked != null)
            {
                PdfDocument pd = new PdfDocument();
                PdfPage pdpage = pd.Pages.Add();
                var x = pdpage.CreateTemplate();
                x.Graphics.DrawString("POTVRDA O IZDATOJ VIZI\n\n Poštovani "+clicked.Podnosilac.naziv+" Vaš zahtjev za boravak u državi " +
                    "Elektrotehni podnijet na datum "+clicked.vrijemePrijave.ToString("dd/mm/yyyy/")+" je odobren. Želimo vam ugodan" +
                    "boravak u našoj državi", new PdfStandardFont(PdfFontFamily.Helvetica, 14), new PdfSolidBrush(Color.Black),5,5) ;
                pdpage.Graphics.DrawPdfTemplate(x,PointF.Empty);
                string a = clicked.Podnosilac.naziv + " viza.pdf";
                pd.Save(File.Create(a));
  
            }
      
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void ListaOdobrenihVizaLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
