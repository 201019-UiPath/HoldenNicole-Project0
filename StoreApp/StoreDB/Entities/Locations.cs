using System.Collections.Generic;

namespace StoreDB.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Manager { get; set; }

        public virtual Managers ManagerNavigation { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
