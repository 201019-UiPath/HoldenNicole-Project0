using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Inventory
    {
        public int Location { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        public virtual Locations LocationNavigation { get; set; }
        public virtual Products ProductNavigation { get; set; }
    }
}
