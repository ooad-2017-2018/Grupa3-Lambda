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
            Ucitaj();
        }
        void Ucitaj()
        {
            const string GetProductsQuery = "select u.username,u.password,u.id,o.naziv,o.jmbg,o.datum_rodjenja,o.email from uposlenici u, osobe o where u.osoba=o.id ";
            Debug.WriteLine("Ucitavam...");

            var uposlenici = new ObservableCollection<Uposlenik>();
            try
            {
                Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString)) { 
               
                    Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string Username = reader.GetString(0);
                                    string Password = reader.GetString(1);
                                    int id = reader.GetInt32(2);
                                    string naziv = reader.GetString(3);
                                    string jmbg = reader.GetString(4);
                                    DateTime datumRodjenja = reader.GetDateTime(5);
                                    string email = reader.GetString(6);
                                    uposlenici.Add(new Uposlenik(naziv,email,datumRodjenja,jmbg,Username,Password,false,id));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine(eSql);
            }

            ListaUposlenika.ItemsSource = uposlenici;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
