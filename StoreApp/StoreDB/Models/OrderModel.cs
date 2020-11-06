using System;

namespace StoreDB.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
