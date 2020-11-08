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
            locations = location;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            ///retrieve location from previous menus
            ///LocationModel location = new LocationModel();
            int id = locations.ID;
            string name = locations.Name;
            Console.WriteLine($"How would you like to see the inventory for {name} sorted?");
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
                    Console.WriteLine("ID \t Athlete \t Item \t Sport \t Price \t Quantity");
                    foreach (var p in allProducts)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("type of item selected");
                    AddToInventory(locations);
                    break;
                case "2":
                    List<InventoryModel> allProductBySport = productServices.ViewAllProductsAtLocationSortByQuantityAscending(id);
                    Console.WriteLine("ID \t Athlete \t Item \t Sport \t Price \t Quantity");
                    foreach (var p in allProductBySport)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("sport selected");
                    AddToInventory(locations);
                    break;
                case "3":
                    List<InventoryModel> allProductsByPerson = productServices.ViewAllProductsAtLocationSortByQuantityDescending(id);
                    Console.WriteLine("ID \t Athlete \t Item \t Sport \t Price \t Quantity");
                    foreach (var p in allProductsByPerson)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("athlete selected");
                    AddToInventory(locations);
                    break;
                case "4":
                    Console.WriteLine("Returning to sign in menu");
                    signInMenu = new SignInMenu(new ixdssaucContext(), new StoreMapper());
                    Log.Information("no idea what youre doing");
                    signInMenu.Start();
                    break;
                case "5":
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
            string UserInput = "";
            do {
                Inventory inventory = new Inventory();
                inventory.Location = location.ID;
                Console.WriteLine("What would you like to do to the inventory?");
                Console.WriteLine("[1] Add product to inventory");
                Console.WriteLine("[2] Remove product from inventory");
                Console.WriteLine("[3] Return to location inventory selection menu");
                Console.WriteLine("[4] Return to manager menu");
                Console.WriteLine("[5] Return to sign in menu");
                Console.WriteLine("[6] Exit store");
                UserInput = Console.ReadLine();
                switch (UserInput)
                {
                case "1":
                    Console.WriteLine("Enter the product ID you would like to add to the location inventory");
                    Inventory item = new Inventory();
                    item.Product = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many would you like to add?");
                    item.Quantity = Convert.ToInt32(Console.ReadLine());
                    DBRepo dBRepo = new DBRepo();
                    dBRepo.AddProductToLocation(location.ID, item.Product, item.Quantity);
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
                    ritem.Quantity = Convert.ToInt32(Console.ReadLine());
                    DBRepo bRepo = new DBRepo();
                    
                    Inventory products = bRepo.DeleteProductAtLocation(location.ID, ritem.Product, ritem.Quantity);
                    Console.WriteLine("Would you like to modify the inventory more (Y/N)?");
                    string possibly = Console.ReadLine();
                    // if(possibly == "N")
                    // {
                        
                    // }
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
            while(UserInput != "6");
        }

    }
}