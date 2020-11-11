using System.Collections.Generic;

namespace StoreDB.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Athlete { get; set; }
        public string Item { get; set; }
        public string Sport { get; set; }
        public decimal Price { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public List<InventoryModel> inventoryModels { get; set; }
    }
}
