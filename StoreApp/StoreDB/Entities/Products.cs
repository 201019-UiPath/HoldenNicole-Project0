namespace StoreUI.Entities
{
    public partial class Products
    {
        internal readonly object locationID;
        private string productName;
        private string productType;
        private int quan;
        private string local;

        public Products()
        {
        }

        public Products(int id, string productName, string productType, int quan, string local)
        {
            ID = id;
            this.productName = productName;
            this.productType = productType;
            this.quan = quan;
            this.local = local;
        }

        public object ID { get; internal set; }
        public string Sport { get; set; }
        public string Athlete { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
    }
}
