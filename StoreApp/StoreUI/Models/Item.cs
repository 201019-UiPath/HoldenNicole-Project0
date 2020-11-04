using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Item
    {
        public int LocationID { get; set; }
        public int Quantity { get; set; }
        public List<int> ProductIDs { get; set; }
    }
}
