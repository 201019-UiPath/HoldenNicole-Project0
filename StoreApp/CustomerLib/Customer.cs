using System;
using System.Collections.Generic;

namespace CustomerLib
{
    public class Customer
    {
        /// <summary>
        /// want to autogenerate customer ID number upon sign up
        /// autogenerate order IDs when placing order
        /// also want to take in shipping address first time customer places order
        /// </summary>
        /// <value></value>
        public int CustomerID {get; set;}
        public string UserName {get; set;}
        public string Email {get; set; }
        public int OrderID {get; set;}
        public string ShippingAddress {get; set;}

        public static Dictionary<int, int> customerIDOrderID = new Dictionary<int, int>();
        public static Dictionary<int, string> customerIDUserName = new Dictionary<int, string>();
        public static Dictionary<int, string> customerIDShippingAddress = new Dictionary<int, string>();
        public static Dictionary<int, string> customerIDEmail = new Dictionary<int, string>();
        public Customer(){
            customerIDOrderID.Add(1, 2);
            customerIDOrderID.Add(2, 3);

            customerIDUserName.Add(1 , "Bob");
            customerIDUserName.Add(2, "Barry");

            customerIDShippingAddress.Add(1, "123 Test Street");
            customerIDShippingAddress.Add(2, "456 Test street");

            customerIDEmail.Add(1, "nfh.32@gmail.com");
            customerIDEmail.Add(2, "ghw.43@gmail.com");

            /// <summary>
            /// creates 2 different customers and links customer ID 
            /// directly to order ID, customer name, shipping address, and email
            /// </summary>
        }
        public Customer GetCustomerDetails(){
            Customer newCustomer = new Customer();
            //use while loops to check first 2 to give customer chance to continue on
            System.Console.WriteLine("Enter email: ");
            newCustomer.Email = System.Console.ReadLine();
            /// <summary>
            /// validate email regular expression
            /// then check if email already exists
            /// </summary>
            
            System.Console.WriteLine("Enter user name you would like to use: ");
            newCustomer.UserName = System.Console.ReadLine();
            /// <summary>
            /// check if user name already exists
            /// if passes
            /// </summary>

            return newCustomer;
        }
        
        public void AddCustomer(){
            /// send 
            
            /// <summary>
            /// validate email by regular expression 
            /// if fails regular expression test send error message in use
            /// if passes check if email already used 
            /// if email is already used send error message already in use
            /// </summary>
            
            System.Console.WriteLine("What user name would you like to create?");
            string userName = System.Console.ReadLine();
            /// <summary>
            /// need input validation to check if customer shares user name
            /// if share both send error message
            /// </summary>
            
        }
        public void CheckCustomer(){
            System.Console.WriteLine();
            /// need to add validation check for customer
            /// if passes send customerID to customer menu
        }
    }
}
