using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class SpectacoleCRUD
    {
        //lista Spectacole
        public List<Models.Spectacol> GetSpectacole()
        {
            List<Models.Spectacol> spectacolList = new List<Models.Spectacol>();
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "select * from spectacol";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Models.Spectacol spectacol = new Models.Spectacol();
                    spectacol.idSpectacol = rdr.GetInt16("idSpectacol");
                    spectacol.titlul = rdr.GetString("titlul");
                    spectacol.regia= rdr.GetString("regia");
                    spectacol.distributia = rdr.GetString("distributia");
                    spectacol.dataPremierei = rdr.GetDateTime("dataPremierei");
                    spectacol.nrBilete = rdr.GetInt16("nrBilete");
                    spectacolList.Add(spectacol);
                    
                
                }
               
                }
            
            catch(MySqlException ex)
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
            return spectacolList;

        }
        //add spectacol
        public void addSpectacol(Spectacol spectacol)
        {
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO spectacol (idSpectacol,titlul,regia,distributia,dataPremierei,nrBilete) VALUES (@idSpectacol,@titlul,@regia,@distributia,@dataPremierei,@nrBilete)";
                cmd.Parameters.AddWithValue("@idSpectacol", spectacol.idSpectacol);
                cmd.Parameters.AddWithValue("@titlul", spectacol.titlul);
                cmd.Parameters.AddWithValue("@regia", spectacol.regia);
                cmd.Parameters.AddWithValue("@distributia", spectacol.distributia);
                cmd.Parameters.AddWithValue("@dataPremierei", spectacol.dataPremierei);
                cmd.Parameters.AddWithValue("@nrBilete", spectacol.nrBilete);
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
        //delete spectacol
        public void deleteSpectacol(int id)
        {
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from spectacol WHERE idSpectacol=@idSpectacol";
                cmd.Parameters.AddWithValue("@idSpectacol", id);
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
        //update Spectacole
        public void updateSpectacole(int id, Spectacol spectacol)
        {

            string cs = @"server=127.0.0.1; port=3306; userid=root; password=; database=spectacole";
            MySqlConnection conn = null;
         
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE spectacole.spectacol SET idSpectacol=@idSpectacol, titlul=@titlul, regia=@regia, distributia=@distributia, dataPremierei=@dataPremierei, nrBilete=@nrBilete WHERE idSpectacol=@idSpectacol";
                cmd.Parameters.AddWithValue("@idSpectacol", spectacol.idSpectacol);
                cmd.Parameters.AddWithValue("@titlul", spectacol.titlul);
                cmd.Parameters.AddWithValue("@regia", spectacol.regia);
                cmd.Parameters.AddWithValue("@distributia", spectacol.distributia);
                cmd.Parameters.AddWithValue("@dataPremierei", spectacol.dataPremierei);
                cmd.Parameters.AddWithValue("@nrBilete", spectacol.nrBilete);
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

    }
}
