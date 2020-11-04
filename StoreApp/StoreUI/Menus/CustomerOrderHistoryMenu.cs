using StoreUI.Entities;
using System;
using Serilog;
using CustomerLib;

namespace StoreUI.Menus
{
  /*  public class CustomerOrderHistoryMenu : IMenu
    {
        private CustomerMenu customerMenu;
        private CustomerService customerService;
        private ixdssaucContext storeContext;
        private StoreMapper storeMapper;
        private Customer customer;
        private ixdssaucContext ixdssaucContext;
        public CustomerOrderHistoryMenu(Customer customer, ixdssaucContext storeContext, StoreMapper storeMapper)
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
            System.Console.WriteLine("What is your customer id?");
            string id = System.Console.ReadLine();
            int idd = Convert.ToInt32(id);
            System.Console.WriteLine("How would you like your order history sorted?");
            System.Console.WriteLine("[1] Date most recent-oldest");
            System.Console.WriteLine("[2] Date oldest-most recent");
            System.Console.WriteLine("[3] Price high-low");
            System.Console.WriteLine("[4] Price low-high");
            System.Console.WriteLine("[5] Return to customer menu");
            System.Console.WriteLine("[6] exit");
            string sortedHistory = System.Console.ReadLine();
            
            switch (sortedHistory)
            {
                case "1":
                    System.Console.WriteLine("Here is your order history sorted by most recent first: ");
                    customerService.GetAllOrdersByCustomerIDDateDescending(idd);
                    Log.Information("order history newest first");
                    break;
                case "2":
                    System.Console.WriteLine("Here is your order history with oldest orders first: ");
                    customerService.GetAllOrdersByCustomerIDPriceAscending(idd);
                    Log.Information("order history oldest first");
                    break;
                case "3":
                    System.Console.WriteLine("Here is your order history sorted by highest price first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(idd);
                    Log.Information("order history most expensive first");
                    break;
                case "4":
                    System.Console.WriteLine("Here is your order history with cheapest items first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(idd);
                    Log.Information("order history cheapest first");
                    break;
                case "5":
                    System.Console.WriteLine("Redirecting you back to customer main menu");
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
                    System.Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        } 
    }
    */
}