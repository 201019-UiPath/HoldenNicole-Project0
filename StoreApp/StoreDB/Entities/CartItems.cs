using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class CartItems
    {
        public int Id { get; set; }
        public int Cart { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        public virtual Carts CartNavigation { get; set; }
        public virtual Products ProductNavigation { get; set; }
    }
}
