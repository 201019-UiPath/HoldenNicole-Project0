using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class Customer : User
    {
        public List<int> OrderIDs { get; set; }
    }
}
