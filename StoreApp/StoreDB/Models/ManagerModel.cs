using System.Collections.Generic;

namespace StoreDB.Models
{
    public class ManagerModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<LocationModel> locations { get; set; }
    }
}
