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
            Locations location = new Locations();
            int id = location.Id;
            Console.WriteLine($"How would you like to see the inventory for {location.Name} sorted?");
            Console.WriteLine("[1] By item ID");
            Console.WriteLine("[2] By quantity of item ascending");
            Console.WriteLine("[3] By quantity of item descending");
            Console.WriteLine("[4] exit store");
            string sorting = Console.ReadLine();

            switch (sorting)
            {
                /// want to be able to sort but may go away
                /// lists products sorted by type
                case "1":
                    List<InventoryModel> allProducts = productServices.ViewAllProductsAtLocationSortByID(id);
                    Log.Information("type of item selected");
                    break;
                case "2":
                    List<InventoryModel> allProductBySport = productServices.ViewAllProductsAtLocationSortByQuantityAscending(id);
                    Log.Information("sport selected");
                    break;
                case "3":
                    List<InventoryModel> allProductsByPerson = productServices.ViewAllProductsAtLocationSortByQuantityDescending(id);
                    Log.Information("athlete selected");
                    break;
                case "4":
                    Console.WriteLine("Bye hope you come again soon");
                    Log.Information("Hsss leaving store");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }

    }
}