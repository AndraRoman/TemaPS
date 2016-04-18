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
    public class BileteCRUD
    {
        //lista bilete
        Models.Spectacol spect = new Models.Spectacol();
        public List<Models.Bilet> getBilete()
        {
            List<Models.Bilet> biletList = new List<Models.Bilet>();
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            MySqlDataReader rdr2 = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "select * from bilet";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

               /* string stm2 = "select idSpectacol from spectacol";
                MySqlCommand cmd2 = new MySqlCommand(stm2, conn);
                rdr2 = cmd2.ExecuteReader();*/

               /* while(rdr2.Read())
                {
                    Models.Bilet bilet = new Models.Bilet();
                    bilet.spectacolID = rdr2.GetInt16("idSpectacol");
                }*/
                while (rdr.Read())
                {
                    Models.Bilet bilet = new Models.Bilet();
                    
                   bilet.spectacolID = rdr.GetInt16("spectacolID");
                    bilet.randd = rdr.GetInt16("randd");
                    bilet.numar = rdr.GetInt16("numar");
                    biletList.Add(bilet);
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
            return biletList;
        }

        //add bilet 
        public void addBilet(Bilet bilet)
        {
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO bilet (spectacolID,randd,numar) VALUES (@spectacolID,@randd,@numar)";
                cmd.Parameters.AddWithValue("@spectacolID", spect.idSpectacol);
                cmd.Parameters.AddWithValue("@randd", bilet.randd);
                cmd.Parameters.AddWithValue("@numar", bilet.numar);
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

        //delete bilet
        public void deleteBilet(int id)
        {
            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from bilet WHERE spectacolID=@spectacolID";
                cmd.Parameters.AddWithValue("@spectacolID", id);
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

        //update bilete
        public void updateBilete(int id, Bilet bilet)
        {

            string cs = @"server=127.0.0.1; port=3306; userid=root; password=root; database=spectacole";
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE spectacole.bilet SET spectacolID=@spectacolID, randd=@randd, numar=@numar";
                cmd.Parameters.AddWithValue("@spectacolID", bilet.spectacolID);
                cmd.Parameters.AddWithValue("@randd", bilet.randd);
                cmd.Parameters.AddWithValue("@numar", bilet.numar);
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

