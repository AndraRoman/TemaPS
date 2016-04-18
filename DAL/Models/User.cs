using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int idUser
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public string parola
        {
            get;
            set;
        }
        public string tipUser
        {
            get;
            set;
        }

        public User()
        {

        }

        public User(/*int idUser*/string username,string parola, string tipUser)
        {

           // this.idUser = idUser;
            this.username = username;
            this.parola = parola;
            this.tipUser = tipUser;
        }
    }   
}
