using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Inventory_Service
    {
        Inventory_DAO inventory_db = new Inventory_DAO();

        public List<Inventory> GetInventory()
        {
            try
            {

                List<Inventory> inventory = inventory_db.Db_Get_Inventory();

                return inventory;
            }
            catch (Exception e)
            {
                Console.Write(e);
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Inventory> inventory = new List<Inventory>();
                Inventory a = new Inventory()
                {
                    DrankjeID = 123,
                    Verkocht = 10,
                    Naam = "Sjors",
                    Alcohol = true,
                    Verkoopprijs = 3.50f,
                    Inkoopprijs = 3.00f,
                    BTW = 0.74f,
                    Voorraad = 35
                };
                inventory.Add(a);
                Inventory b = new Inventory()
                {
                    DrankjeID = 234,
                    Verkocht = 22,
                    Naam = "Magic",
                    Alcohol = false,
                    Verkoopprijs = 3.50f,
                    Inkoopprijs = 3.00f,
                    BTW = 0.74f,
                    Voorraad = 5
                };
                inventory.Add(b);
                return inventory;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }

        public void UpdateRow(Inventory updatedItem)
        {
            inventory_db.UpdateRow(updatedItem);
        }
    }
}
