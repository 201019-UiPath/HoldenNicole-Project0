using System;
using System.Collections.Generic;
namespace LocationLib
{
    public class Location
    {
        public int LocationID {get; set;}
        public string LocationAddress {get; set;}
        public int ProductIDs {get; set;}
        public static Dictionary<int, string> locationIDAddress = new Dictionary<int, string>();
        public static Stack<int> productIDs = new Stack<int>();

        public Location(){
            productIDs.Push(1);
            productIDs.Push(2);

            locationIDAddress.Add(1, "123 random street");
            locationIDAddress.Add(2, "456 randome street");
        }
        public static IEnumerable<int> GetProductIDs(){
            /// <summary>
            /// list all product IDs
            /// </summary>
            return productIDs;
        }
    }
}
