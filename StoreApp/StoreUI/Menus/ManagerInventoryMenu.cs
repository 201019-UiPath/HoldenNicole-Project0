using System.Collections.Generic;
using LocationLib;
using Serilog;
using StoreUI.Entities;
using System;

namespace StoreUI.Menus
{
    public class ManagerInventoryMenu : IMenu
    {
        
        private ProductServices productServices;
        private ixdssaucContext storeContext;
        private StoreMapper storeMapper;
        private Managers manager;
        private ixdssaucContext ixdssaucContext;

        public ManagerInventoryMenu(Managers manager, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            ///retrieve location from previous menus
            StoreUI.Entities.Locations location = new StoreUI.Entities.Locations();
            System.Console.WriteLine($"How would you like to see the inventory for {location.Name} sorted?");
            System.Console.WriteLine("[1] By type of item");
            System.Console.WriteLine("[2] By sport");
            System.Console.WriteLine("[3] By person");
            System.Console.WriteLine("[4] exit store");
            string sorting = System.Console.ReadLine();
            
            switch (sorting)
            {
                /// lists products sorted by type
                case "1":
                    System.Console.WriteLine("What type of autographed item are you looking for?");
                    string item = System.Console.ReadLine();
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