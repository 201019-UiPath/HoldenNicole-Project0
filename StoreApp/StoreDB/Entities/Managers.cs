using System.Collections.Generic;

namespace StoreDB.Entities
{
    public partial class Managers
    {
        public Managers()
        {
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Locations> Locations { get; set; }
    }
}
