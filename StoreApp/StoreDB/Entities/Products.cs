namespace StoreDB.Entities
{
    public partial class Products
    {
        private string productName;
        private string productType;
        private int quan;
        public string location;
        public int locationID;

        public Products()
        {
        }

        public Products(int id, string productName, string productType, int quan, string location)
        {
            ID = id;
            this.productName = productName;
            this.productType = productType;
            this.quan = quan;
            this.location = location;
        }

        public int ID { get; set; }
        public string Sport { get; set; }
        public string Athlete { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}