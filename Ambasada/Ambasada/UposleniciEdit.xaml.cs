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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ambasada
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UposleniciEdit : Page
    {
        public UposleniciEdit()
        {
            this.InitializeComponent();
            Ucitaj();
        }

        void Ucitaj() {
            const string GetProductsQuery = "select username from uposlenici";
            Debug.WriteLine("Ucitavam...");

            var uposlenici = new ObservableCollection<Uposlenik>();
            try {
                Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString)) {
                    Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open) {
                        using (SqlCommand cmd = conn.CreateCommand()) {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader()) {
                                while (reader.Read()) {
                                    var uposlenik = new Uposlenik();
                                    uposlenik.Username = reader.GetString(0);
                                    uposlenici.Add(uposlenik);
                                }
                            }
                        }
                    }
                }
            } catch (Exception eSql) {
                Debug.WriteLine(eSql);
            }

            ListaUposlenika.ItemsSource = uposlenici;

        }
    }
}
