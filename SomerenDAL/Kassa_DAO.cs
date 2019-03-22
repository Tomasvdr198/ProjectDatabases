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
    public class Kassa_DAO : Base
    {
        public List<Kassa> Db_Get_Kassa()
        {
            string query = "SELECT d.DrankID, d.Naam, d.prijs, s.Voornaam " +
                "FROM Drankje d" +
                "JOIN Student s on drankje d";
               ;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Kassa> ReadTables(DataTable dataTable)
        {
            List<Kassa> kassas = new List<Kassa>();

            foreach (DataRow dr in dataTable.Rows)
            {

                Kassa kassa = new Kassa();
                kassa.DrankjeNaam = (string)dr["Naam"];
                kassa.Naam = (string)dr["Voornaam"];


                kassas.Add(kassa);
            }
            return kassas;
        }
    }
}
