using StoreDB.Entities;
using StoreDB;
using StoreUI.Menus;
using Serilog;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("StoreTest/Logger.txt")
                .CreateLogger();
            IMenu main = new SignInMenu(new StoreContext(), new StoreMapper());
            main.Start();

            IMenu customerInventoryBatsMenu = new CustomerInventoryBatsMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerInventoryBatsMenu.Start();

            IMenu customerInventoryJerseysMenu = new CustomerInventoryJerseysMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerInventoryJerseysMenu.Start();

            IMenu customerInventorySticksMenu = new CustomerInventorySticks(new Customers(), new StoreContext(), new StoreMapper());
            customerInventorySticksMenu.Start();

            IMenu customerInventoryGamesMenu = new CustomerInventoryGamesMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerInventoryGamesMenu.Start();

            IMenu customerLocationMenu = new CustomerLocationMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerLocationMenu.Start();

            IMenu customerMenu = new CustomerMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerMenu.Start();

            IMenu customerOrderHistoryMenu = new CustomerOrderHistoryMenu(new Customers(), new StoreContext(), new StoreMapper());
            customerOrderHistoryMenu.Start();

          //  IMenu customerSearchMenu = new CustomerSearch(new StoreContext(), new StoreMapper());
           // customerSearchMenu.Start();

            IMenu locationOrderHistoryMenu = new LocationOrderHistoryMenu(new Managers(), new StoreContext(), new StoreMapper());
            locationOrderHistoryMenu.Start();

            IMenu managerMenu = new ManagerMenu(new Managers(), new StoreContext(), new StoreMapper());
            managerMenu.Start();

            IMenu managerWorldOfBatsMenu = new ManagerWorldOfBats(new Managers(), new StoreContext(), new StoreMapper());
            managerWorldOfBatsMenu.Start();

            IMenu managerWorldOfGames = new ManagerWorldOfGames(new Managers(), new StoreContext(), new StoreMapper());
            managerWorldOfGames.Start();

            IMenu managerWorldOfJerseys = new ManagerWorldOfJerseys(new Managers(), new StoreContext(), new StoreMapper());
            managerWorldOfJerseys.Start();

            IMenu managerWorldOfSticks = new ManagerWorldOfSticks(new Managers(), new StoreContext(), new StoreMapper());
            managerWorldOfSticks.Start();
        }
    }
}
