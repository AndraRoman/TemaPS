using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Spectacol
    {
        public int idSpectacol
        {
            get;
            set;

        }
        public string titlul
        {
            get;
            set;

        }
        public string regia
        {
            get;
            set;

        }
        public string distributia
        {
            get;
            set;
        }
        public DateTime dataPremierei
        {
            get;
            set;

        }
        public int nrBilete
        {
            get;
            set;

        }
        public Spectacol()
        {

        }
        public Spectacol(int idSpectacol,string titlul, string regia, string distributia, DateTime dataPremierei, int nrBilete)
        {
            this.idSpectacol = idSpectacol;
            this.titlul = titlul;
            this.regia = regia;
            this.distributia = distributia;
            this.dataPremierei = dataPremierei;
            this.nrBilete = nrBilete;
        }
    }
}
