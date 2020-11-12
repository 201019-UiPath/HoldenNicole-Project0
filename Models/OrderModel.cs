using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public List<LineItemModel> items { get; set; }
    }
}
