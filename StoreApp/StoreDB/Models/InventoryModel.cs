namespace StoreDB.Models
{
    public class InventoryModel
    {
        internal int id;

        public int locationID { get; set; }
        public int productID { get; set; }
        public int Quantity { get; set; }
    }
}
