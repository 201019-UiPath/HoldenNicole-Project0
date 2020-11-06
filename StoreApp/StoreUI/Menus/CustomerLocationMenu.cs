using StoreDB.Entities;
using Serilog;
using LocationLib;
using System;
using StoreDB.Models;

namespace StoreUI.Menus
{
    public class CustomerLocationMenu : IMenu
    {
        private readonly SignInMenu signInMenu;
        private CustomerLocationMenu customerLocationMenu;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private CustomerInventoryMenu customerInventoryMenu;
        private readonly LocationService locationService;

        private readonly CustomerModels customer;

        public CustomerLocationMenu(CustomerModels customer, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
            this.locationService = new LocationService();
        }
        public void Start()
        {
            System.Console.WriteLine("Which store would you like to shop at?");
            System.Console.WriteLine("[1] World of Bats");
            System.Console.WriteLine("[2] World of Sticks");
            System.Console.WriteLine("[3] World of Jerseys");
            System.Console.WriteLine("[4] World of Games");
            System.Console.WriteLine("[5] Back to Sign in menu");
            System.Console.WriteLine("[6] Exit store");
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Sending you to the World of Bats store");
                    System.Console.WriteLine("Hope you find something you like");
                    int id = 1;
                    Log.Information("Please work");
                    LocationModel location = locationService.GetLocationByID(id);
                    /// change info here
                    customerInventoryMenu = new CustomerInventoryMenu(customer, storeContext, location, new StoreMapper());
                    customerInventoryMenu.Start();
                    Log.Information("bats store selected");
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    System.Console.WriteLine("Hope you find something you like");
                    int id2 = 2;
                    LocationModel location2 = locationService.GetLocationByID(id2);
                    /// change info here
                    customerInventoryMenu = new CustomerInventoryMenu(customer, storeContext, location2, new StoreMapper());
                    customerInventoryMenu.Start();
                    Log.Information("sticks store selected");
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    System.Console.WriteLine("Hope you find something you like");
                    int id3 = 3;
                    LocationModel location3 = locationService.GetLocationByID(id3);
                    /// change info here
                    customerInventoryMenu = new CustomerInventoryMenu(customer, storeContext, location3, new StoreMapper());
                    customerInventoryMenu.Start();
                    Log.Information("jersey store selected");
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    System.Console.WriteLine("Hope you find somthing you like");
                    int id4 = 4;
                    LocationModel location4 = locationService.GetLocationByID(id4);
                    /// change info here
                    customerInventoryMenu = new CustomerInventoryMenu(customer, storeContext, location4, new StoreMapper());
                    customerInventoryMenu.Start();
                    Log.Information("games store selected");
                    break;
                case "5":
                    signInMenu.Start();
                    Log.Information("backwards");
                    break;
                case "6":
                    System.Console.WriteLine("Come back again soon!");
                    Log.Information("seriously buy something");
                    break;
                default:
                    customerLocationMenu = new CustomerLocationMenu(customer, storeContext, new StoreMapper());
                    customerLocationMenu.Start();
                    Log.Information("Invalid try again");
                    break;
            }
        }

    } 
}
