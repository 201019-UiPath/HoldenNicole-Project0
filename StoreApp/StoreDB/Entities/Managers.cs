using System;
using System.Collections.Generic;

namespace StoreUI.Entities
{
    public partial class Managers
    {
        public int Id { get; set; }
        public object ID { get; internal set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public object Location { get; internal set; }
    }
}
