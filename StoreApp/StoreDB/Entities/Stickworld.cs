namespace StoreUI.Entities
{
    public partial class Stickworld
    {
        public int? Productid { get; set; }
        public int? Quantity { get; set; }

        public object ID { get; internal set; }
        public object Product { get; internal set; }
    }
}
