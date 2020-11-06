using System.Collections.Generic;
using LocationLib;
using Serilog;
using StoreDB.Entities;
using System;

namespace StoreUI.Menus
{
    public class ManagerInventoryMenu : IMenu
    {
        
        private readonly ProductServices productServices;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly Managers manager;
        private readonly Locations locations;

        public ManagerInventoryMenu(Managers manager, ixdssaucContext storeContext, Locations location, StoreMapper storeMapper)
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
            Console.WriteLine($"How would you like to see the inventory for {location.Name} sorted?");
            Console.WriteLine("[1] By type of item");
            Console.WriteLine("[2] By sport");
            Console.WriteLine("[3] By person");
            Console.WriteLine("[4] exit store");
            string sorting = Console.ReadLine();
            
            switch (sorting)
            {
                /// want to be able to sort but may go away
                /// lists products sorted by type
                case "1":
                    Console.WriteLine("What type of autographed item are you looking for?");
                    string item = Console.ReadLine();
                    List<Products> allProductsByType = productServices.ViewAllProductsByItem(item);
                    Log.Information("type of item selected");
                    break;
                ///lists products sorted by sport
                case "2":
                    Console.WriteLine("What sport are you looking for autographs for?");
                    string sport = Console.ReadLine();
                    List<Products> allProductBySport = productServices.ViewAllProductsBySport(sport);
                    Log.Information("sport selected");
                    break;
                /// lists products by person
                case "3":
                    Console.WriteLine("What athlete are you looking for?");
                    string athlete = Console.ReadLine();
                    List<Products> allProductsByPerson = productServices.ViewAllProductsByAthlete(athlete);
                    Log.Information("athlete selected");
                    break;
                case "4":
                    Console.WriteLine("Bye hope you come again soon");
                    Log.Information("Hsss leaving store");
                    break;
                default:
                    System.Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
        
    } 
}