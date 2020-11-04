using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class LineItems
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        public virtual Orders OrderNavigation { get; set; }
    }
}
