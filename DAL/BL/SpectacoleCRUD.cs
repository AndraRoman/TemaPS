using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace BL
{
    public class SpectacoleCRUD
    {
        //View spectacole

        public List<Models.Spectacol> Spectacole()
        {
            DAL.SpectacoleCRUD spect = new DAL.SpectacoleCRUD();
            return spect.GetSpectacole();

        }

        //Add Spectacol
        public void addSpectacol(Spectacol spectacol)
        {
            DAL.SpectacoleCRUD spectacole = new DAL.SpectacoleCRUD();
            spectacole.addSpectacol(spectacol);

        }

        //Delete Spectacol
        public void deleteSpectacol(int id)
        {
            DAL.SpectacoleCRUD delete = new DAL.SpectacoleCRUD();
            delete.deleteSpectacol(id);
        }

        //Update Spectacole
        public void updateSpectacol(int id, Spectacol spectacol)
        {
            DAL.SpectacoleCRUD spectacole = new DAL.SpectacoleCRUD();
            spectacole.updateSpectacole(id, spectacol);

        }

       
    }
}
