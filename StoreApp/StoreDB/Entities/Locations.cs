using System.Collections.Generic;

namespace StoreDB.Entities
{
    public partial class Locations
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int locationID {get; set;}

        public string Address { get; set; }
        public List<int> ProductIDs { get; set; }
        public List<int> OrderHistory { get; set; }
    }
}