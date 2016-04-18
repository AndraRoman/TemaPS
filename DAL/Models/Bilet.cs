using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bilet
    {
        public int spectacolID
        {
            get;
            set;
        }
        public int randd
        {
            get;
            set;
        }
        public int numar
        {
            get;
            set;
        }
        public Bilet(int spectacolID, int randd, int numar)
        {
            this.spectacolID = spectacolID;
            this.randd = randd;
            this.numar = numar;
        }

        public Bilet()
        {
        }
    }
}
