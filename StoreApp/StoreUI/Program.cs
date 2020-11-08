using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using StoreUI.Menus;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.File("StoreTest/LogPleaseReally.txt")
                 .CreateLogger(); 
            IMenu main = new SignInMenu(new ixdssaucContext(), new StoreMapper());
            main.Start();

            IMenu customerInventoryMenu = new CustomerInventoryMenu(new CustomerModels(), new ixdssaucContext(), new LocationModel(), new StoreMapper());
            customerInventoryMenu.Start();

            IMenu customerLocationMenu = new CustomerLocationMenu(new CustomerModels(), new ixdssaucContext(), new StoreMapper());
            customerLocationMenu.Start();

            IMenu customerMenu = new CustomerMenu(new CustomerModels(), new ixdssaucContext(), new StoreMapper());
            customerMenu.Start();

            IMenu customerOrderHistoryMenu = new CustomerOrderHistoryMenu(new CustomerModels(), new ixdssaucContext(), new StoreMapper());
            customerOrderHistoryMenu.Start();

            IMenu locationOrderHistoryMenu = new LocationOrderHistoryMenu(new ManagerModel(), new ixdssaucContext(), new StoreMapper());
            locationOrderHistoryMenu.Start();

            IMenu managerMenu = new ManagerMenu(new ManagerModel(), new ixdssaucContext(), new StoreMapper());
            managerMenu.Start();

            IMenu managerInventoryMenu = new ManagerInventoryMenu(new ManagerModel(), new ixdssaucContext(), new LocationModel(), new StoreMapper());
            managerInventoryMenu.Start();
        }
    }
}
