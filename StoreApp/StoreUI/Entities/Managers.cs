namespace StoreUI.Entities
{
    public partial class Managers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Location { get; set; }

        public virtual Locations LocationNavigation { get; set; }
    }
}
