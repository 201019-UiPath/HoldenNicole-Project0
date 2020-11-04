namespace StoreUI.Entities
{
    public partial class Gamesworld
    {
        public int? Productid { get; set; }
        public int? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public object ID { get; internal set; }
    }
}
