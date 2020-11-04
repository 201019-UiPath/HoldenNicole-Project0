using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Locations
    {
        internal object locationID;

        public Locations()
        {
            Managers = new HashSet<Managers>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public object ID { get; internal set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Managers> Managers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        public static implicit operator int(Locations v)
        {
            throw new NotImplementedException();
        }
    }
}
