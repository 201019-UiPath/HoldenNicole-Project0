using System;
using System.Collections.Generic;

namespace OrderLib
{
    public class Order
    {
        public Order(int orderID, int customerID, string locationID, string shippingDate, string arrivalDate) 
        {
            this.OrderID = orderID;
                this.CustomerID = customerID;
                this.LocationID = locationID;
                //this.ShippingAddress = shippingAddress;
                this.ShippingDate = shippingDate;
                this.ArrivalDate = arrivalDate;
               
        }
        public int OrderID {get;set;}
        public int CustomerID {get; set;}
        public string LocationID {get; set;}
       // public string ShippingAddress {get; set;}
        public string ShippingDate {get; set;}
        public string ArrivalDate {get; set;}
        public static Dictionary<int, int> orderIDCustomerID = new Dictionary<int, int>();
        public static Dictionary<int, int> orderIDLocationID = new Dictionary<int, int>();
      //  public static Dictionary<int, string> orderIDShippingAddress = new Dictionary<int, string>();
        /// <summary>
        /// may make more sense to connect customerID and shipping address
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> orderIDShippingDate = new Dictionary<int, string>();
        public static Dictionary<int, string> orderIDArrivalDate = new Dictionary<int, string>();
        public static Stack<int> productIDs = new Stack<int>();

        public Order(){
            /// link orderIDs to customerIDs which connects to shipping address
            orderIDCustomerID.Add(1, 1);
            orderIDCustomerID.Add(2, 1);

            /// link orderIDs to location IDs which also connects to location address
            orderIDLocationID.Add(1, 1);
            orderIDLocationID.Add(2, 3);

            /// link orderIDs to shipping dates
            orderIDShippingDate.Add(1, "December 1");
            orderIDShippingDate.Add(2, "January 1");

            /// link orderIDs to arrival dates
            orderIDArrivalDate.Add(1, "January 1");
            orderIDArrivalDate.Add(2, "February 1");

            /// add product IDs to order
            productIDs.Push(123);
            productIDs.Push(124);
        }
        public static IEnumerable<int> GetProductIDs(){
            return productIDs;
        }
        public void RemoveProductID(){
            System.Console.WriteLine("Which product would you like to remove from your cart?");
            /// create loop 
            /// show number beside product ID
            /// show all products with quantity 1 for this
            /// if user selects a number corresponding to product remove that one

        }
       /* public void AddProductID(){
            need to add add to cart functionality but need to be able to do that from multiple
            different inventory lists that user can see
            
            may create inventory lists which can be input to this method to do this
        } */
    }
}
