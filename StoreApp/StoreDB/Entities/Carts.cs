using System.Collections.Generic;

namespace StoreDB.Entities
{
    public partial class Carts
    {
        public Carts()
        {
            CartItems = new HashSet<CartItems>();
        }

        public int Id { get; set; }
        public int Customer { get; set; }
        public int Location { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Locations LocationNavigation { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
