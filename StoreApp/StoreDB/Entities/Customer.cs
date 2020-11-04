using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public object ID { get; internal set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
