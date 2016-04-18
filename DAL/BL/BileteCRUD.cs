using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BL
{
    public class BileteCRUD
    {

        //View bilete

        public List<Models.Bilet> Bilete()
        {
            DAL.BileteCRUD bil = new DAL.BileteCRUD();
            return bil.getBilete();

        }

        //Add bilet
        public void addBilete(Bilet bilet)
        {
            DAL.BileteCRUD bilete = new DAL.BileteCRUD();
            bilete.addBilet(bilet);

        }

        //Delete bilete
        public void deleteBilet(int id)
        {
            DAL.BileteCRUD delete = new DAL.BileteCRUD();
            delete.deleteBilet(id);
        }

        //Update bilete
        public void updateBilet(int id, Bilet bilet)
        {
            DAL.BileteCRUD bilete = new DAL.BileteCRUD();
            bilete.updateBilete(id, bilet);

        }
    }
}
