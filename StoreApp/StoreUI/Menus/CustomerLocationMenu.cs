using StoreDB;
using StoreDB.Entities;
using Serilog;

namespace StoreUI.Menus
{
    public class CustomerLocationMenu : IMenu
    {
        private SignInMenu signInMenu;
        private CustomerInventoryBatsMenu customerInventoryBatsMenu;
        private CustomerInventorySticks customerInventorySticksMenu;
        private CustomerInventoryJerseysMenu customerInventoryJerseysMenu;
        private CustomerInventoryGamesMenu customerInventoryGamesMenu;
        private CustomerLocationMenu customerLocationMenu;
        private StoreContext storeContext;
        private StoreMapper storeMapper;

        private Customers customer;

        public CustomerLocationMenu(Customers customer, StoreContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
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
                    customerInventoryBatsMenu = new CustomerInventoryBatsMenu(customer, storeContext, new StoreMapper());
                    customerInventoryBatsMenu.Start();
                    Log.Information("bats store selected");
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    System.Console.WriteLine("Hope you find something you like");
                    customerInventorySticksMenu = new CustomerInventorySticks(customer, storeContext, new StoreMapper());
                    customerInventorySticksMenu.Start();
                    Log.Information("sticks store selected");
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    System.Console.WriteLine("Hope you find something you like");
                    customerInventoryJerseysMenu = new CustomerInventoryJerseysMenu(customer, storeContext, new StoreMapper());
                    customerInventoryJerseysMenu.Start();
                    Log.Information("jersey store selected");
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    System.Console.WriteLine("Hope you find somthing you like");
                    customerInventoryGamesMenu = new CustomerInventoryGamesMenu(customer, storeContext, new StoreMapper());
                    customerInventoryGamesMenu.Start();
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
