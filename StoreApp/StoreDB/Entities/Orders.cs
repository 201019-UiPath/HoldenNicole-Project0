using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Orders
    {
        internal object date;

        public int Id { get; set; }
        public object ID { get; internal set; }
        public int? Customerid { get; set; }
        public object CustomerID { get; internal set; }
        public int? Locationid { get; set; }
        public object LocationID { get; internal set; }
        public DateTime? Date { get; set; }
        public long? Price { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Locations Location { get; set; }
    }
}
