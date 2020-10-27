using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class Manager : User
    {
        public string LocationName { get; set; }
        public int LocationID { get; set; }
    }
}
