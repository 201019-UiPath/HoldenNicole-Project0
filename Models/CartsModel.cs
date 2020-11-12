using StoreDB.Entities;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class CartsModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public List<CartItems> cartItems { get; set; }
    }
}
