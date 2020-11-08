using StoreDB.Entities;
using System;

namespace StoreDB.Models
{
    public class LocationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }

      /*  public static implicit operator LocationModel(Locations v)
        {
            throw new NotImplementedException();
        } */
    }
}
