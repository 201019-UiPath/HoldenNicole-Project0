using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class Products : Store
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int LocationID { get; set; }
        public string Sport { get; set; }
    }
}
