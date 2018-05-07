using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.ViewModel
{
    public static class BazaPodatakaHelper
    {
        public static bool loginKorisnika(string user, string password)
        {
            const string GetProductsQuery = "select password,administrator from uposlenici where username=@user;";
            using (SqlConnection conn = new SqlConnection(App.connectionString))
            {
                // Debug.WriteLine("Spojen sam na bazu");
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar);


                        cmd.Parameters["@user"].Value = user;
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (password.Equals(reader.GetString(0)))
                                {
                                    if (reader.GetBoolean(1))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;  // UPOSLENIK PANEL
                                    }
                                }
                                else
                                {
                                    throw new Exception("Pogresan password");
                                }
                            }
                            else
                            {
                                throw new Exception("Korisnik ne postoji");
                            }
                        }

                    }
                }
                throw new Exception("Problemi sa bazom");

            }
        }

        public static ObservableCollection<Uposlenik> Ucitaj()
        {
            const string GetProductsQuery = "select u.username,u.password,u.id,o.naziv,o.jmbg,o.datum_rodjenja,o.email,o.id from uposlenici u, osobe o where u.osoba=o.id ";
            //   Debug.WriteLine("Ucitavam...");

            var uposlenici = new ObservableCollection<Uposlenik>();
            try
            {
               // Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString))
                {

                   // Debug.WriteLine("Spojen sam na bazu");
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
                                    uposlenici.Add(new Uposlenik(naziv, email, datumRodjenja, jmbg, Username, Password, false, id, idOsobe));
                                }
                            }
                        }
                    }
                }
                return uposlenici;
            }
            catch (Exception eSql)
            {
            //    Debug.WriteLine(eSql);
                return null;
            }
            return uposlenici;

        }

        public static void ObrisiUposlenika(Uposlenik kliknuti)
        {
            string GetProductsQuery = "delete from uposlenici u where u.id=@id";
            string drugiUpit = "delete from osobe o where o.id =@idosobe";
          //  Debug.WriteLine("Ucitavam...");


            try
            {
              //  Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString))
                {

              //      Debug.WriteLine("Spojen sam na bazu");
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
               // Debug.WriteLine(eSql);
            }
        }
        
        public static void AzurirajUposlenika(Uposlenik kliknuti)
        {
            string GetProductsQuery = "update uposlenici u set u.username=@user, u.password=@pass where u.id = @id";
            string drugiUpit = "update osobe o set o.naziv=@naziv,o.jmbg=@jmbg, o.datum_rodjenja=@datum, o.email=@email where o.id=@idosobe";
          //  Debug.WriteLine("Ucitavam...");

           // var uposlenici = new ObservableCollection<Uposlenik>();
            try
            {
               // Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString))
                {

                 //   Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                            cmd.Parameters.Add("@idosobe", System.Data.SqlDbType.Int);
                            cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@naziv", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@jmbg", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@datum", System.Data.SqlDbType.Date);
                            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters["@id"].Value = kliknuti.Id;
                            cmd.Parameters["@user"].Value = kliknuti.Username;
                            cmd.Parameters["@pass"].Value = kliknuti.Password;
                            cmd.Parameters["@naziv"].Value = kliknuti.Naziv;
                            cmd.Parameters["@jmbg"].Value = kliknuti.Jmbg;
                            cmd.Parameters["@idosobe"].Value = kliknuti.IdOsobe;
                            cmd.Parameters["@datum"].Value = kliknuti.DatumRodjenja;
                            cmd.Parameters["@email"].Value = kliknuti.Email;
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
           //     Debug.WriteLine(eSql);
            }
        

    
        }

        public static void RegistrujUposlenika(Uposlenik k)
        {
            string GetProductsQuery = "Insert into osobe (naziv,jmbg,datum_rodjenja,email) OUTPUT Inserted.id values (@naziv,@jmbg,@datum_rodjenja,@email)";
            string drugiUpit = "Insert into uposlenici (username,password,administrator,osoba) values (@username,@password,0,@osoba)";

            //  Debug.WriteLine("Ucitavam...");


            try
            {
                //  Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.connectionString))
                {

                    //      Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            
                            cmd.Parameters.Add("@osoba", System.Data.SqlDbType.Int);
                            cmd.Parameters.Add("@naziv", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@jmbg", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar);
                            cmd.Parameters.Add("@datum_rodjenja", System.Data.SqlDbType.Date);
                      //      cmd.Parameters.Add("@administrator", System.Data.SqlDbType.n);
                            cmd.Parameters["@naziv"].Value = k.Naziv;
                            cmd.Parameters["@jmbg"].Value = k.Jmbg;
                            cmd.Parameters["@email"].Value = k.Email;
                            cmd.Parameters["@datum_rodjenja"].Value = k.DatumRodjenja;
                            cmd.Parameters["@username"].Value = k.Username;
                            cmd.Parameters["@password"].Value = k.Password;
                            // cmd.Parameters["@administrator"] = false;
                            cmd.CommandText = GetProductsQuery;
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read()) cmd.Parameters["osoba"].Value = reader.GetInt32(0);
                            cmd.CommandText = drugiUpit;
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            }
            catch (Exception eSql)
            {
                // Debug.WriteLine(eSql);
            }
        }
    }
    
}
