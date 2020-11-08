using LocationLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class ManagerInventoryMenu : IMenu
    {

        private readonly ProductServices productServices;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly ManagerModel manager;
        private readonly LocationModel locations;
        private SignInMenu signInMenu;
        private ManagerInventoryMenu managerInventoryMenu;
        private ManagerMenu managerMenu;

        public ManagerInventoryMenu(ManagerModel manager, ixdssaucContext storeContext, LocationModel location, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.locations = location;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            ///retrieve location from previous menus
            LocationModel location = new LocationModel();
            int id = location.ID;
            Console.WriteLine($"How would you like to see the inventory for {location.Name} sorted?");
            Console.WriteLine("[1] By item ID");
            Console.WriteLine("[2] By quantity of item ascending");
            Console.WriteLine("[3] By quantity of item descending");
            Console.WriteLine("[4] Return to the sign in menu");
            Console.WriteLine("[5] exit store");
            
            string sorting = Console.ReadLine();
            ProductServices productServices = new ProductServices();

            switch (sorting)
            {
                /// want to be able to sort but may go away
                /// lists products sorted by type
                case "1":
                    List<InventoryModel> allProducts = productServices.ViewAllProductsAtLocationSortByID(id);
                    foreach (var p in allProducts)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.Athlete} {product.Item} {product.Sport} {product.Price} {p.Quantity}");
                    }
                    AddToInventory(location);
                    Log.Information("type of item selected");
                    break;
                case "2":
                    List<InventoryModel> allProductBySport = productServices.ViewAllProductsAtLocationSortByQuantityAscending(id);
                    foreach (var p in allProductBySport)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.Athlete} {product.Item} {product.Sport} {product.Price} {p.Quantity}");
                    }
                    AddToInventory(location);
                    Log.Information("sport selected");
                    break;
                case "3":
                    List<InventoryModel> allProductsByPerson = productServices.ViewAllProductsAtLocationSortByQuantityDescending(id);
                    foreach (var p in allProductsByPerson)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.Athlete} {product.Item} {product.Sport} {product.Price} {p.Quantity}");
                    }
                    AddToInventory(location);
                    Log.Information("athlete selected");
                    break;
                case "4":
                    Console.WriteLine("Returning to sign in menu");
                    signInMenu = new SignInMenu(new ixdssaucContext(), new StoreMapper());
                    signInMenu.Start();
                    Log.Information("no idea what youre doing");
                    break;
                case "5":
                    Console.WriteLine("Exiting store");
                    Console.WriteLine("Leaving store");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
        public void AddToInventory(LocationModel location)
        {
            Inventory inventory = new Inventory();
            inventory.Location = location.ID;
            Console.WriteLine("What would you like to do to the inventory?");
            Console.WriteLine("[1] Add product to inventory");
            Console.WriteLine("[2] Remove product from inventory");
            Console.WriteLine("[3] Return to location inventory selection menu");
            Console.WriteLine("[4] Return to manager menu");
            Console.WriteLine("[5] Return to sign in menu");
            Console.WriteLine("[6] Exit store");
            string UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "1":
                    Console.WriteLine("Enter the product ID you would like to add to the location inventory");
                    Inventory item = new Inventory();
                    item.Product = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many would you like to add?");
                    DBRepo dBRepo = new DBRepo();
                    Inventory product = dBRepo.AddProductToLocation(location.ID, item.Product, item.Quantity);
                    Console.WriteLine("Would you like to modify the inventory more (Y/N)?");
                    string maybe = Console.ReadLine();
                    if(maybe == "Y")
                    {
                        AddToInventory(location);
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter the product ID you would like to remove from the location inventory");
                    Inventory ritem = new Inventory();
                    ritem.Product = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many would you like to remove?");
                    DBRepo bRepo = new DBRepo();
                    Inventory products = bRepo.DeleteProductAtLocation(location.ID, ritem.Product, ritem.Quantity);
                    Console.WriteLine("Would you like to modify the inventory more (Y/N)?");
                    string possibly = Console.ReadLine();
                    if(possibly == "Y")
                    {
                        AddToInventory(location);
                    }
                    break;
                case "3":
                    managerInventoryMenu = new ManagerInventoryMenu(manager, new ixdssaucContext(), location, new StoreMapper());
                    managerInventoryMenu.Start();
                    break;
                case "4":
                    Console.WriteLine("Returning you to manager menu");
                    managerMenu = new ManagerMenu(manager, new ixdssaucContext(), new StoreMapper());
                    managerMenu.Start();
                    break;
                case "5":
                    Console.WriteLine("Returning you to sign in menu");
                    signInMenu = new SignInMenu(new ixdssaucContext(), new StoreMapper());
                    signInMenu.Start();
                    break;
                case "6":
                    Console.WriteLine("Exiting store");
                    Environment.Exit(0);
                    break;
            }
        }

    }
}