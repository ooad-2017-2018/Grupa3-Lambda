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
            const string GetProductsQuery = "select u.username,u.password,u.id,o.naziv,o.jmbg,o.datum_rodjenja,o.email,o.id from uposlenici u, osobe o where u.osoba=o.id ";
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
                                    int idOsobe = reader.GetInt32(7);
                                    uposlenici.Add(new Uposlenik(naziv,email,datumRodjenja,jmbg,Username,Password,false,id,idOsobe));
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
            if (!(kliknuti is null)) {

                string GetProductsQuery = "delete from uposlenici u where u.id=@id";
                string drugiUpit = "delete from osobe o where o.id =@idosobe";
                Debug.WriteLine("Ucitavam...");

                var uposlenici = new ObservableCollection<Uposlenik>();
                try
                {
                    Debug.WriteLine("Spajam sam na bazu");
                    using (SqlConnection conn = new SqlConnection(App.connectionString))
                    {

                        Debug.WriteLine("Spojen sam na bazu");
                        conn.Open();
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                                cmd.Parameters.Add("@idosobe", System.Data.SqlDbType.Int);
                                cmd.Parameters["@id"].Value = kliknuti.Id;
                                cmd.Parameters["@idosobe"].Value = kliknuti.IdOsobe;
                                cmd.CommandText = GetProductsQuery;
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = drugiUpit;
                                cmd.ExecuteNonQuery();
                         
                            }
                        }
                    }
                }
                catch (Exception eSql)
                {
                    Debug.WriteLine(eSql);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var kliknuti = (Uposlenik)ListaUposlenika.SelectedItem;
            if (!(kliknuti is null))
            {

                string GetProductsQuery = "update uposlenici u set u.username=@user"; //nije dovršeno
                Debug.WriteLine("Ucitavam...");

                var uposlenici = new ObservableCollection<Uposlenik>();
                try
                {
                    Debug.WriteLine("Spajam sam na bazu");
                    using (SqlConnection conn = new SqlConnection(App.connectionString))
                    {

                        Debug.WriteLine("Spojen sam na bazu");
                        conn.Open();
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = GetProductsQuery;
                            }
                        }
                    }
                }
                catch (Exception eSql)
                {
                    Debug.WriteLine(eSql);
                }
            }

        }
    }
}
