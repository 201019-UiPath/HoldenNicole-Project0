using System;
using System.Collections.Generic;
namespace ProductLib
{
    public class Product
    {
        public int ProductID {get; set;}
        public int Quantity {get; set;}
        public string ProductType {get; set;}
        public string ProductName {get; set;}
        public string LocationID {get; set;}
        public static Dictionary<int, int> productIDQuantity = new Dictionary<int, int>();
        /// need to implement this dictionary for by location and order

        public static Dictionary<int, string> productIDProductType = new Dictionary<int, string>();
        public static Dictionary<int, string> productIDProductName = new Dictionary<int, string>();
        public static Dictionary<int, int> productIDProductLocation = new Dictionary<int, int>();

        public Product(){
            ///this needs to be able to be implemented for location and order
            productIDQuantity.Add(1, 2);
            productIDQuantity.Add(3, 15);

            /// links product ID to product name
            productIDProductName.Add(1, "Crosby stick");
            productIDProductName.Add(3, "Derian Hatcher pics");

            /// links productID to type of item signed
            productIDProductType.Add(1, "hockey stick");
            productIDProductType.Add(3, "pictures");

            /// links product ID to location ID
            productIDProductLocation.Add(1, 1);
            productIDProductLocation.Add(3, 2);
        }
    }
}
