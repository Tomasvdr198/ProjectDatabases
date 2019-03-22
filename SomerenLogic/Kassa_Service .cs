using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Kassa_Service
    {
        Kassa_DAO Kassa_db = new Kassa_DAO();

        public List<Kassa> GetKassa()
        {
            try
            {

                List<Kassa> kassa = Kassa_db.Db_Get_Kassa();

                return kassa;
            }
            catch (Exception e)
            {
                List<Kassa> kassas = new List<Kassa>();
                Kassa kassa = new Kassa();
                kassa.DrankjeNaam = "bier";
                kassa.Naam = "Tomas";
                kassas.Add(kassa);
                Console.Write(e);
                return kassas;
            }

        }
    }
}
