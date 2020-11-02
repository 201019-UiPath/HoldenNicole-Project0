using System;
using StoreDB.Entities;
using StoreDB.Models;
using StoreDB;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreUI.Menus;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu main = new SignInMenu(new StoreContext(), new StoreMapper());
            main.Start();

            IMenu customerInventoryBatsMenu = new CustomerInventoryBatsMenu(new StoreContext(), new StoreMapper());
            customerInventoryBatsMenu.Start();

            IMenu customerInventoryJerseysMenu = new CustomerInventoryJerseysMenu(new StoreContext(), new StoreMapper());
            customerInventoryJerseysMenu.Start();

            IMenu customerInventorySticksMenu = new CustomerInventorySticks(new StoreContext(), new StoreMapper());
            customerInventorySticksMenu.Start();

            IMenu customerInventoryGamesMenu = new CustomerInventoryGamesMenu(new StoreContext(), new StoreMapper());
            customerInventoryGamesMenu.Start();

            IMenu customerLocationMenu = new CustomerLocationMenu(new StoreContext(), new StoreMapper());
            customerLocationMenu.Start();

            IMenu customerMenu = new CustomerMenu(new StoreContext(), new StoreMapper());
            customerMenu.Start();

            IMenu customerOrderHistoryMenu = new CustomerOrderHistoryMenu(new StoreContext(), new StoreMapper());
            customerOrderHistoryMenu.Start();

          //  IMenu customerSearchMenu = new CustomerSearch(new StoreContext(), new StoreMapper());
           // customerSearchMenu.Start();

            IMenu locationOrderHistoryMenu = new LocationOrderHistoryMenu(new StoreContext(), new StoreMapper());
            locationOrderHistoryMenu.Start();

            IMenu managerMenu = new ManagerMenu(new StoreContext(), new StoreMapper());
            managerMenu.Start();

            IMenu managerWorldOfBatsMenu = new ManagerWorldOfBats(new StoreContext(), new StoreMapper());
            managerWorldOfBatsMenu.Start();

            IMenu managerWorldOfGames = new ManagerWorldOfGames(new StoreContext(), new StoreMapper());
            managerWorldOfGames.Start();

            IMenu managerWorldOfJerseys = new ManagerWorldOfJerseys(new StoreContext(), new StoreMapper());
            managerWorldOfJerseys.Start();

            IMenu managerWorldOfSticks = new ManagerWorldOfSticks(new StoreContext(), new StoreMapper());
            managerWorldOfSticks.Start();
        }
    }
}
