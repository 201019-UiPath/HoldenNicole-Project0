namespace ProductLib
{
    public class Product
    {
        public int ProductID {get; set;}
        public int Quantity {get; set;}
        public string ProductType {get; set;}
        public string ProductName {get; set;}
        public string Location {get; set;}
        public string Sport { get; set; }

        public Product(int id, string productName, string productType, int quantity, string location, string sport)
        {
            ProductID= id;
            ProductName = productName;
            ProductType = productType;
            Quantity = quantity;
            Location = location;
            Sport = sport;
        } 
        public Product()
        {
            this.ProductID = 0;
            this.Quantity = 0;
            this.ProductType = "";
            this.ProductName = "";
            this.Location = "";
            this.Sport = "";
        }
    }
}
