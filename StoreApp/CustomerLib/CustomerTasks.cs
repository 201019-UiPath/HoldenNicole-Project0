using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLib
{
    public delegate void CustomerDel();
    public class CustomerTasks : ICustomerOperations
    {
        string path = @"CustomerLib\CustomerCartItems.txt";
        public event CustomerDel placedOrder;
        
        /// <summary>
        /// section used to allow customer to place order
        /// </summary>
        public async void PlaceOrder()
        {
            Console.WriteLine("Opened Cart");
            await Task.Run(new Action(GetProducts));//gets products placed in cart by customer
            Console.WriteLine("Hope you found everything you were looking for today!");
            Console.WriteLine("Come back to Sports Authenticated soon!");
            placedOrder();// call to notify all subscribers
        }
        // make sure events are binded to handlers
        public void OnPlacedOrder()
        {
            if(placedOrder != null)
            {
                placedOrder();// raises event
            }
        }
        /// <summary>
        /// retrieves products in cart
        /// </summary>
        public void GetProducts()
        {
            Console.WriteLine("Getting items in your cart");
            System.Threading.Thread.Sleep(2000);
            string items = System.IO.File.ReadAllText(path);
            Console.WriteLine("Items in cart:");
            Console.WriteLine($"{items}");
        }

        string path2 = @"CustomerLib\CustomerOrderHistory";
        public event CustomerDel OrderHistory;
        /// <summary>
        /// section used to retrieve customer order history
        /// </summary>
        public async void orderHistory()
        {
            Console.WriteLine("Retrieving your order history");
            await Task.Run(new Action(customerOrderHistory));
            Console.WriteLine("Order history acquired hit enter to see it:");
            OrderHistory();
        }
        /// <summary>
        /// checking for bound events
        /// </summary>
        public void OnOrderHistory()
        {
            if(OrderHistory != null)
            {
                OrderHistory();
            }
        }
        /// <summary>
        /// retrieves customer order history
        /// </summary>
        public void customerOrderHistory()
        {
            Console.WriteLine("Getting Order History for you");
            System.Threading.Thread.Sleep(2000);
            string orderHistory = System.IO.File.ReadAllText(path);
            Console.WriteLine($"Order History obtained {orderHistory}");
        }
        
    }
}
