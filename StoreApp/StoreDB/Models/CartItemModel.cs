namespace StoreDB.Models
{
    public class CartItemModel
    {
        public int orderID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public int CartID { get; set; }
    }
}
