using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class Item
    {
        public int LocationID { get; set; }
        public int Quantity { get; set; }
        public List<int> ProductIDs { get; set; }
    }
}
