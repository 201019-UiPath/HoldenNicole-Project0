using CustomerLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using System;

namespace StoreUI.Menus
{
    public class CustomerOrderHistoryMenu : IMenu
    {
        private CustomerMenu customerMenu;
        private CustomerService customerService;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly CustomerModels customer;
        public CustomerOrderHistoryMenu(CustomerModels customer, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            /// <summary>
            /// need to figure out how to send customer data here
            /// </summary>
            /// <returns></returns>
            int id = customer.ID;
            Console.WriteLine("How would you like your order history sorted?");
            Console.WriteLine("[1] Date most recent-oldest");
            Console.WriteLine("[2] Date oldest-most recent");
            Console.WriteLine("[3] Price high-low");
            Console.WriteLine("[4] Price low-high");
            Console.WriteLine("[5] Return to customer menu");
            Console.WriteLine("[6] exit");
            string sortedHistory = Console.ReadLine();

            switch (sortedHistory)
            {
                case "1":
                    Console.WriteLine("Here is your order history sorted by most recent first: ");
                    customerService.GetAllOrdersByCustomerIDDateDescending(customer);
                    Log.Information("order history newest first");
                    break;
                case "2":
                    Console.WriteLine("Here is your order history with oldest orders first: ");
                    customerService.GetAllOrdersByCustomerIDPriceAscending(customer);
                    Log.Information("order history oldest first");
                    break;
                case "3":
                    Console.WriteLine("Here is your order history sorted by highest price first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(customer);
                    Log.Information("order history most expensive first");
                    break;
                case "4":
                    Console.WriteLine("Here is your order history with cheapest items first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(customer);
                    Log.Information("order history cheapest first");
                    break;
                case "5":
                    Console.WriteLine("Redirecting you back to customer main menu");
                    customerMenu = new CustomerMenu(customer, storeContext, new StoreMapper());
                    customerMenu.Start();
                    Log.Information("back to customer menu");
                    /// <summary>
                    /// return customer to main customer menu
                    /// </summary>
                    /// <returns></returns>
                    break;
                case "6":
                    Environment.Exit(0);
                    Log.Information("buy something already");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
    }
}