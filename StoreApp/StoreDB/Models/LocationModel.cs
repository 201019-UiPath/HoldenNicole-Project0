using StoreDB.Entities;
using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class LocationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }

        public List<CartsModel> carts { get; set; }
        public List<InventoryModel> inventory { get; set; }
        public List<OrderModel> orders { get; set; }
    }
}
