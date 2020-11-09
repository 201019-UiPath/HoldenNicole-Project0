using LocationLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class LocationOrderHistoryMenu : IMenu
    {
        private ManagerMenu managerMenu;
        private readonly LocationService locationService;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly ManagerModel manager;
        LocationService locationservice = new LocationService();

        public LocationOrderHistoryMenu(ManagerModel manager, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            Locations locationID = new Locations();
            /// <summary>
            /// different ways to sort orders select by location
            /// </summary>
            Console.WriteLine($"How would you like the order history for {locationID.Name} sorted?");
            int id = locationID.Id;
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
                    Console.WriteLine("Here is the location order history sorted by most recent first: ");
                    List<OrderModel> orders = locationservice.GetAllOrdersByLocationIDDateDescending(id);
                    Console.WriteLine("Order Date - Total Price");
                    Console.WriteLine("Athlete - Item - Price");
                    foreach (var o in orders)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} - {o.Price}");
                        foreach (var i in items)
                        {
                            ProductModel pro = new ProductModel();
                            pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} - {pro.Item} - {pro.Price}");
                        }
                    }
                    Log.Information("order history newest first");
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    break;
                case "2":
                    Console.WriteLine("Here is the location order history with oldest orders first: ");
                    List<OrderModel> orders2 = locationService.GetAllOrdersByLocationIDDateAscending(id);
                    Console.WriteLine("Order Date - Total Price");
                    Console.WriteLine("Athlete - Item - Price");
                    foreach (var o in orders2)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} - {o.Price}");
                        foreach (var i in items)
                        {
                            ProductModel pro = new ProductModel();
                            pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} - {pro.Item} - {pro.Price}");
                        }
                    }
                    Log.Information("order history oldest first");
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    break;
                case "3":
                    Console.WriteLine("Here is the location order history sorted by highest price first: ");
                    List<OrderModel> orders3 = locationService.GetAllOrdersByLocationIDPriceDescending(id);
                    Console.WriteLine("Order Date - Total Price");
                    Console.WriteLine("Athlete - Item - Price");
                    foreach (var o in orders3)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} - {o.Price}");
                        foreach (var i in items)
                        {
                            ProductModel pro = new ProductModel();
                            pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} - {pro.Item} - {pro.Price}");
                        }
                    }
                    Log.Information("order history most expensive first");
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    break;
                case "4":
                    Console.WriteLine("Here is the location order history with cheapest items first: ");
                    List<OrderModel> orders4 = locationService.GetAllOrdersByLocationIDPriceDescending(id);
                    Console.WriteLine("Order Date - Total Price");
                    Console.WriteLine("Athlete - Item - Price");
                    foreach (var o in orders4)
                    {
                        DBRepo bRepo = new DBRepo();
                        List<LineItemModel> items = bRepo.GetAllProductsInOrderByID(o.ID);
                        Console.WriteLine($"{o.OrderDate} - {o.Price}");
                        foreach (var i in items)
                        {
                            ProductModel pro = new ProductModel();
                            pro = bRepo.GetProductByID(i.ProductID);
                            Console.WriteLine($"{pro.Athlete} - {pro.Item} - {pro.Price}");
                        }
                    }
                    Log.Information("order history cheapest first");
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    break;
                case "5":
                    Console.WriteLine("Redirecting you back to the order history menu: ");
                    /// <summary>
                    /// return manager to order history menu
                    /// </summary>
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    Log.Information("menu");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
    }
}