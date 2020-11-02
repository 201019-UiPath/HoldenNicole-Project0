using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? Customerid { get; set; }
        public int? Locationid { get; set; }
        public DateTime? Date { get; set; }
        public long? Price { get; set; }
        public List<Products1> Products {get; set;}

        public virtual Customers Customer { get; set; }
        public virtual Locations Location { get; set; }
    }
}
