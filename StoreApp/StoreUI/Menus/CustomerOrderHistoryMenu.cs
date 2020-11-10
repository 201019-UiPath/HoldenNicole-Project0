using CustomerLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class CustomerOrderHistoryMenu : IMenu
    {
        private CustomerMenu customerMenu;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly CustomerModels customer;
        private readonly CartsModel cart;
        readonly CustomerService customerService = new CustomerService();
        public CustomerOrderHistoryMenu(CustomerModels customer, CartsModel cart, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.cart = cart;
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
            Console.WriteLine("[1] Date most recent-oldest"); //doesnt work
            Console.WriteLine("[2] Date oldest-most recent"); //works
            Console.WriteLine("[3] Price high-low"); // doesnt work
            Console.WriteLine("[4] Price low-high"); // works
            string sortedHistory = Console.ReadLine();

            switch (sortedHistory)
            {
                case "1":
                    Console.WriteLine("Here is your order history sorted by most recent first: ");
                    List<OrderModel> orders = customerService.GetAllOrdersByCustomerIDDateDescending(customer);
                    Console.WriteLine("Order Date \t Total Price");
                    Console.WriteLine("Athlete \t Item \t Price");
                    foreach(var o in orders)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} \t {o.Price}");
                        foreach (var i in items)
                        {
                            //ProductModel pro = new ProductModel();
                            ProductModel pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} \t {pro.Item} \t {pro.Price}");
                        }
                    }
                    Log.Information("order history newest first");
                    customerMenu = new CustomerMenu(customer, cart, storeContext, new StoreMapper());
                    customerMenu.Start();
                    break;
                case "2":
                    Console.WriteLine("Here is your order history with oldest orders first: ");
                    customerService.GetAllOrdersByCustomerIDPriceAscending(customer);
                    List<OrderModel> orders2 = customerService.GetAllOrdersByCustomerIDDateDescending(customer);
                    Console.WriteLine("Order Date \t Total Price");
                    Console.WriteLine("Athlete \t Item \t Price");
                    foreach (var o in orders2)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} \t {o.Price}");
                        foreach (var i in items)
                        {
                            //ProductModel pro = new ProductModel();
                            ProductModel pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} \t {pro.Item} \t {pro.Price}");
                        }
                    }
                    Log.Information("order history oldest first");
                    customerMenu = new CustomerMenu(customer, cart, storeContext, new StoreMapper());
                    customerMenu.Start();
                    break;
                case "3":
                    Console.WriteLine("Here is your order history sorted by highest price first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(customer);
                    List<OrderModel> orders3 = customerService.GetAllOrdersByCustomerIDDateDescending(customer);
                    Console.WriteLine("Order Date \t Total Price");
                    Console.WriteLine("Athlete \t Item \t Price");
                    foreach (var o in orders3)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} \t {o.Price}");
                        foreach (var i in items)
                        {
                            //ProductModel pro = new ProductModel();
                            ProductModel pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} \t {pro.Item} \t {pro.Price}");
                        }
                    }
                    Log.Information("order history most expensive first");
                    customerMenu = new CustomerMenu(customer, cart, storeContext, new StoreMapper());
                    customerMenu.Start();
                    break;
                case "4":
                    Console.WriteLine("Here is your order history with cheapest items first: ");
                    customerService.GetAllOrdersByCustomerIDPriceDescending(customer);
                    List<OrderModel> orders4 = customerService.GetAllOrdersByCustomerIDDateDescending(customer);
                    Console.WriteLine("Order Date \t Total Price");
                    Console.WriteLine("Athlete \t Item \t Price");
                    foreach (var o in orders4)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} \t {o.Price}");
                        foreach (var i in items)
                        {
                            //ProductModel pro = new ProductModel();
                            ProductModel pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} \t {pro.Item} \t {pro.Price}");
                        }
                    }
                    Log.Information("order history cheapest first");
                    customerMenu = new CustomerMenu(customer, cart, storeContext, new StoreMapper());
                    customerMenu.Start();
                    break;
                case "5":
                    Console.WriteLine("Redirecting you back to customer main menu");
                    customerMenu = new CustomerMenu(customer, cart, storeContext, new StoreMapper());
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