using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Inventory
    {
        public int DrankjeID { get; set; }
        public int Verkocht { get; set; }
        public string Naam { get; set; }
        public bool Alcohol { get; set; }
        public double Verkoopprijs { get; set; }
        public double Inkoopprijs { get; set; }
        public double BTW { get; set; }
        public int Voorraad { get; set; }
    }
}
