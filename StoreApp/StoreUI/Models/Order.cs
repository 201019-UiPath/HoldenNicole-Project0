﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Models
{
    public class Order : Store
    {
        public int CustomerID { get; set; }
        public List<int> ProductIDs { get; set; }
        public List<string> ProductNames { get; set; }
    }
}