using System;
using System.Collections.Generic;

namespace StoreDB.Entities
{
    public partial class Customers
    {
        public int ID {get; set;}
        public string UserName {get; set;}
        public string Address {get; set;}
        public string Email {get; set;}
    }
}