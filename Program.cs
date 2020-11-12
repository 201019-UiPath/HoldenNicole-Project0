using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Runtime.CompilerServices;

namespace ConsumeStoreApp { 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }

        public static void GetAllOrders()
        {
            string url = "https://localhost:44319/customer/get/history";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync("order");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderModel>();
                    readTask.Wait();

                    var orders = readTask.Result;
                    Console.WriteLine($"Here is the list of items you bought from Sports Authenticated store number {orders.LocationID} \n" +
                        $" on {orders.OrderDate} for ${orders.Price}");
                    List<OrderModel> order = new List<OrderModel>();
                    foreach (order in orders)
                        Console.WriteLine($"{order.LocationID} - {order.Price} - {order.items}");
                }
            }
        }
    }
}
