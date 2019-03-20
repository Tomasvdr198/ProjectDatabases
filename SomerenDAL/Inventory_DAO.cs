using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Inventory_DAO : Base
    {
        public List<Inventory> Db_Get_Inventory()
        {
            string query = "SELECT Drankje.DrankID, verkochtSom.Verkocht, Naam, Alcohol, Verkoopprijs, prijs, BTW, Voorraad FROM ( " +
                                "SELECT DrankID, SUM(Verkoop) as Verkocht FROM Drankje " +
                                "JOIN Verkoop on Drankje.DrankID = Verkoop.DrankjeID " +
                                "WHERE DrankID<> 1 AND DrankID<> 2 AND DrankID<> 3 AND Voorraad > 1 " +
                                "GROUP BY DrankID" +
                            ") as verkochtSom " +
                            "JOIN Drankje On Drankje.DrankID = verkochtSom.DrankID " +
                            "ORDER BY Voorraad ASC, verkoopprijs ASC, Verkocht ASC";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Inventory> ReadTables(DataTable dataTable)
        {
            List<Inventory> inventories = new List<Inventory>();

            foreach (DataRow dr in dataTable.Rows)
            {
                /*Inventory inventory = new Inventory()
                {
                    DrankjeID = (int)dr["DrankID"],
                    Verkocht = (int)dr["Verkocht"],
                    Naam = (string)dr["Naam"],
                    Alcohol = (int)dr["Alcohol"] == 1,
                    Verkoopprijs = (float)dr["Verkoopprijs"],
                    Inkoopprijs = (float)dr["Prijs"],
                    BTW = (float)dr["BTW"],
                    Voorraad = (int)dr["Voorraad"]
                };*/

                Inventory inventory = new Inventory();
                inventory.DrankjeID = (int)dr["DrankID"];
                inventory.Verkocht = (int)dr["Verkocht"];
                inventory.Naam = (string)dr["Naam"];
                inventory.Alcohol = (int)dr["Alcohol"] == 0;
                inventory.Verkoopprijs = decimal.ToDouble((decimal)dr["Verkoopprijs"]);
                inventory.Inkoopprijs = decimal.ToDouble((decimal)dr["Prijs"]);
                inventory.BTW = decimal.ToDouble((decimal)dr["BTW"]);
                inventory.Voorraad = (int)dr["Voorraad"];
                
                inventories.Add(inventory);
            }
            return inventories;
        }

        public void UpdateRow(Inventory updatedItem)
        {
            string query = "UPDATE Drankje " + 
                            "set naam = @naam, verkoopprijs = @verkoop, Voorraad = @voorraad, BTW = @btw " +
                            "Where DrankID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("naam", updatedItem.Naam),
                new SqlParameter("verkoop", updatedItem.Verkoopprijs),
                new SqlParameter("voorraad", updatedItem.Voorraad),
                new SqlParameter("id", updatedItem.DrankjeID),
                new SqlParameter("btw", Math.Round(updatedItem.BTW, 2))
                };
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
