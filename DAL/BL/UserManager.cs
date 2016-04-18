using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BL
{
    public class UserManager
    {
        public string log(string user, string password)
        {

            DAL.UserDAO dal = new DAL.UserDAO();
           MD5 md5Hash = MD5.Create();
          string pass = GetMd5Hash(md5Hash, password);
            return dal.login(user, password);
        }
      

       public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

       
        public void addUser(User user)
        {
            DAL.UserDAO users = new DAL.UserDAO();
            users.addUser(user);

        }

        public List<Models.User> Users()
        {
            DAL.UserDAO us = new DAL.UserDAO();
            return us.GetUsers();

        }

    }
}
