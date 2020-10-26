namespace CustomerLib
{
    public class Customer
    {
        /// <summary>
        /// want to autogenerate customer ID number upon sign up
        /// </summary>
        /// <value></value>
        public int CustomerID {get; set;}
        public string UserName {get; set;}
        public string Email {get; set; }
        public string ShippingAddress {get; set;}
    }
}
