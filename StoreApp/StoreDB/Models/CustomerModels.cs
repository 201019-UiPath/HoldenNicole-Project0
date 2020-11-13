using System.Collections.Generic;

namespace StoreDB.Models
{
    public class CustomerModels
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string email { get; set; }

        public List<CartsModel> carts { get; set; }
        public List<OrderModel> orders { get; set; }
    }
}
