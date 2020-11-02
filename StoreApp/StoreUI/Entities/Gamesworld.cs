using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Gamesworld
    {
        public int? Productid { get; set; }
        public int? Quantity { get; set; }

        public virtual Products1 Product { get; set; }
    }
}
