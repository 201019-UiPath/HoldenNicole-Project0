using LocationLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI.Menus
{
    public class ManagerMenu : IMenu
    {
        private SignInMenu signInMenu;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private ManagerMenu managerMenu;
        private readonly ManagerModel manager;
        private ManagerInventoryMenu managerInventoryMenu;
        private LocationService locationService;
        public ManagerMenu(ManagerModel manager, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            System.Console.WriteLine("Which store are you the manager of?");
            System.Console.WriteLine("[1] World of Bats");
            System.Console.WriteLine("[2] World of Sticks");
            System.Console.WriteLine("[3] World of Jerseys");
            System.Console.WriteLine("[4] World of Games");
            System.Console.WriteLine("[5] Back to Sign in menu");
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Sending you to the World of Bats store");
                    ///replace
                    int id = 1;
                    locationService = new LocationService();
                    LocationModel location = locationService.GetLocationByID(id);
                    /// change info here
                    managerInventoryMenu = new ManagerInventoryMenu(manager, storeContext, location, new StoreMapper());
                    managerInventoryMenu.Start();
                    Log.Information("Cob");
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    /// replace
                    int id2 = 2;
                    locationService = new LocationService();
                    LocationModel location2 = locationService.GetLocationByID(id2);
                    /// change info here
                    managerInventoryMenu = new ManagerInventoryMenu(manager, storeContext, location2, new StoreMapper());
                    managerInventoryMenu.Start();
                    Log.Information("Great One");
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    /// replace
                    int id3 = 3;
                    locationService = new LocationService();
                    LocationModel location3 = locationService.GetLocationByID(id3);
                    /// change info here
                    managerInventoryMenu = new ManagerInventoryMenu(manager, storeContext, location3, new StoreMapper());
                    managerInventoryMenu.Start();
                    Log.Information("Miracle Team");
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    /// replace
                    int id4 = 4;
                    locationService = new LocationService();
                    LocationModel location4 = locationService.GetLocationByID(id4);
                    /// change info here
                    managerInventoryMenu = new ManagerInventoryMenu(manager, storeContext, location4, new StoreMapper());
                    managerInventoryMenu.Start();
                    Log.Information("Heisman");
                    break;
                case "5":
                    signInMenu = new SignInMenu(storeContext, storeMapper);
                    signInMenu.Start();
                    Log.Information("wrong choice?");
                    break;
                default:
                    managerMenu.Start();
                    Log.Information("invalid option try again");
                    break;
            }
        }
    }
}