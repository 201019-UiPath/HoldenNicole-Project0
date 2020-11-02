using System;
using System.Collections.Generic;


namespace StoreDB.Entities
{
    public partial class Orders
    {
        public DateTime date = new DateTime();
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public int Price {get; set;}
        public List<Products> Products {get; set;}
        public List<int> ProductIDs { get; set; }
        public List<string> ProductNames { get; set; }
    }
}