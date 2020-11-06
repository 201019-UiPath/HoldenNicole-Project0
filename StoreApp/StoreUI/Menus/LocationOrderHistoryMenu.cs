using LocationLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI.Menus
{
    public class LocationOrderHistoryMenu : IMenu
    {
        private ManagerMenu managerMenu;
        private readonly LocationService locationService;
        private readonly ixdssaucContext storeContext;
        private readonly StoreMapper storeMapper;
        private readonly ManagerModel manager;

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
            System.Console.WriteLine($"How would you like the order history for {locationID.Name} sorted?");
            int id = locationID.Id;
            System.Console.WriteLine("[1] Date most recent-oldest");
            System.Console.WriteLine("[2] Date oldest-most recent");
            System.Console.WriteLine("[3] Price high-low");
            System.Console.WriteLine("[4] Price low-high");
            System.Console.WriteLine("[5] Return to customer menu");
            System.Console.WriteLine("[6] exit");
            string sortedHistory = System.Console.ReadLine();

            switch (sortedHistory)
            {
                case "1":
                    System.Console.WriteLine("Here is the location order history sorted by most recent first: ");
                    locationService.GetAllOrdersByLocationIDDateDescending(id);
                    Log.Information("order history newest first");
                    break;
                case "2":
                    System.Console.WriteLine("Here is the location order history with oldest orders first: ");
                    locationService.GetAllOrdersByLocationIDDateAscending(id);
                    Log.Information("order history oldest first");
                    break;
                case "3":
                    System.Console.WriteLine("Here is the location order history sorted by highest price first: ");
                    locationService.GetAllOrdersByLocationIDPriceDescending(id);
                    Log.Information("order history most expensive first");
                    break;
                case "4":
                    System.Console.WriteLine("Here is the location order history with cheapest items first: ");
                    locationService.GetAllOrdersByLocationIDPriceDescending(id);
                    Log.Information("order history cheapest first");
                    break;
                case "5":
                    System.Console.WriteLine("Redirecting you back to the order history menu: ");
                    /// <summary>
                    /// return manager to order history menu
                    /// </summary>
                    managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                    managerMenu.Start();
                    Log.Information("menu");
                    break;
                default:
                    System.Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
    }
}