using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class User : Store
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
