using System;

namespace StoreDB.Models
{
    public class CustomerModels
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string email { get; set; }

       /* public static implicit operator int(CustomerModels v)
        {
            throw new NotImplementedException();
        } */
    }
}
