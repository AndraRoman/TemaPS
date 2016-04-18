using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Models;
namespace DAL
{
    public class UserDAO
    {
        public string login(string user, string password)
        {
            string functie = "";
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
           
           
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT tipUser FROM user where username =@user and parola =@password";


                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@password", password);

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    functie = rdr.GetString("tipUser");
                }
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

            return functie;
        }
        //add user
        public void addUser(User user)
        {
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO user (username,parola,tipUser) VALUES (@username,@parola,@tipUser)";
              //  cmd.Parameters.AddWithValue("@idUser", user.idUser);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@parola", user.parola);
                cmd.Parameters.AddWithValue("@tipUser", user.tipUser);
               
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
        }
        //get users
        public List<Models.User> GetUsers()
        {
            List<Models.User> userList = new List<Models.User>();
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "select * from user";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Models.User user = new Models.User();
                    user.idUser = rdr.GetInt16("idUser");
                    user.username = rdr.GetString("username");
                    user.parola = rdr.GetString("parola");
                    user.tipUser=rdr.GetString("tipUser");
                   
                   userList.Add(user);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }
            return userList ;

        }

    }
}
