namespace OrderLib
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string LocationID { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingDate { get; set; }
        public string ArrivalDate { get; set; }
    }
}
