namespace StoreDB.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int Location { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        public virtual Locations LocationNavigation { get; set; }
        public virtual Products ProductNavigation { get; set; }
    }
}
