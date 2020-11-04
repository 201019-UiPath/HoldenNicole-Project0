using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int locationID {get; set; }
        public List<int> ProductIDs { get; set; }
        public List<int> OrderHistory { get; set; }
    }
}
