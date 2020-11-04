using StoreUI.Entities;
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
            IMenu main = new SignInMenu(new ixdssaucContext(), new StoreMapper());
            main.Start();

            IMenu customerInventoryMenu = new CustomerInventoryMenu(new Customer(), new ixdssaucContext(), new StoreMapper());
            customerInventoryMenu.Start();

            IMenu customerLocationMenu = new CustomerLocationMenu(new Customer(), new ixdssaucContext(), new StoreMapper());
            customerLocationMenu.Start();

            IMenu customerMenu = new CustomerMenu(new Customer(), new ixdssaucContext(), new StoreMapper());
            customerMenu.Start();

         /*   IMenu customerOrderHistoryMenu = new CustomerOrderHistoryMenu(new Customer(), new ixdssaucContext(), new StoreMapper());
            customerOrderHistoryMenu.Start();

            IMenu locationOrderHistoryMenu = new LocationOrderHistoryMenu(new Managers(), new ixdssaucContext(), new StoreMapper());
            locationOrderHistoryMenu.Start(); */

            IMenu managerMenu = new ManagerMenu(new Managers(), new ixdssaucContext(), new StoreMapper());
            managerMenu.Start();

        }
    }
}
