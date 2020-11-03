namespace StoreUI.Entities
{
    public partial class Batworld
    {
        public int? Productid { get; set; }
        public int? Quantity { get; set; }

        public virtual Products1 Product { get; set; }
    }
}
