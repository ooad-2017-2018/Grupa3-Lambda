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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            status.Text = "";
            if (pwbox.Password.ToString().Length == 0||UsernameTB.Text.Length==0)
            {
                status.Text = "Nepotpun unos";
                return;
            }
            
            const string GetProductsQuery = "select password,administrator from uposlenici where username=@user;";
                Debug.WriteLine("Ucitavam...");

                //var uposlenici = new ObservableCollection<Uposlenik>();
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
                            cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar);
                            
                         
                            cmd.Parameters["@user"].Value = UsernameTB.Text;
                                cmd.CommandText = GetProductsQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                if (reader.Read())
                                {
                                    if (pwbox.Password.ToString().Equals(reader.GetString(0)))
                                    {
                                        if (reader.GetBoolean(1))
                                        {
                                            this.Frame.Navigate(typeof(AdminPanel));
                                        }
                                        else
                                        {
                                            this.Frame.Navigate(typeof(UposlenikPage));  // UPOSLENIK PANEL
                                        }
                                    }
                                    else
                                    {
                                        status.Text = "Pogresan password";
                                    }
                                }
                                else
                                {
                                    status.Text = "Korisnik ne postoji";
                                }
                                }
                            
                            }
                        }
                    }
                }
                catch (Exception eSql)
                {
                status.Text = "Problemi sa citanjem baze podataka";
                }

               /// ListaUposlenika.ItemsSource = uposlenici;

            
           
        }
    }
}
