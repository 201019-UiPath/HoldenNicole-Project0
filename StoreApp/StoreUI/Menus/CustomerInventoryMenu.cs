
using LocationLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using StoreUI.Menus;
using System;
using System.Collections.Generic;

namespace StoreUI
{
    internal class CustomerInventoryMenu : IMenu
    {
        private readonly CustomerModels customer;
        private readonly ixdssaucContext ixdssaucContext;
        private readonly StoreMapper storeMapper;
        private readonly ProductServices productServices;

        public CustomerInventoryMenu(CustomerModels customer, ixdssaucContext ixdssaucContext, LocationModel location, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.ixdssaucContext = ixdssaucContext;
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
                case "1":
                    List<InventoryModel> allProducts = productServices.ViewAllProductsAtLocationSortByID(id);
                    Log.Information("type of item selected");
                    break;
                ///lists products sorted by sport
                case "2":
                    List<InventoryModel> allProducts2 = productServices.ViewAllProductsAtLocationSortByQuantityAscending(id);
                    Log.Information("sport selected");
                    break;
                /// lists products by person
                case "3":
                    List<InventoryModel> allProducts3 = productServices.ViewAllProductsAtLocationSortByQuantityDescending(id);
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