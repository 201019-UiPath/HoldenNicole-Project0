using CustomerLib;
using StoreDB;
using StoreDB.Entities;
using System;
using LocationLib;
using System.Configuration;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class ManagerMenu
    {
        private string userInput;
        private CustomerMenu customerMenu;
        private CustomerOrderHistoryMenu customerOrderHistoryMenu;
        private CustomerSearch customerSearch;
        private LocationOrderHistoryMenu locationOrderHistoryMenu;
        private SearchBySport searchBySport;
        private SearchByType searchByType;
        private SearchByPerson searchByPerson;
        private SignInMenu signInMenu;
        private SportOrderHistoryMenu sportOrderHistoryMenu;
        private TypeOrderHistoryMenu typeOrderHistoryMenu;
        private ManagerWorldOfBats managerWorldOfBats;
        private ManagerWorldOfGames managerWorldOfGames;
        private ManagerWorldOfJerseys managerWorldOfJerseys;
        private ManagerWorldOfSticks managerWorldOfSticks;
        private CustomerInventoryBatsMenu customerInventoryBatsMenu;
        private CustomerInventoryJerseysMenu customerInventoryJerseysMenu;
        private CustomerInventoryGamesMenu customerInventoryGamesMenu;
        private ManagerMenu managerMenu;

        private Customers customer;
        private StoreContext storeContext;
        private ICustomerRepo customerRepo;
        private CustomerService customerService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private DBRepo dBRepo;
        private StoreMapper storeMapper;

        public ManagerMenu(StoreContext storeContext, StoreMapper storeMapper)
        {
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
                    managerWorldOfBats.Start();
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    managerWorldOfSticks.Start();
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    managerWorldOfJerseys.Start();
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    managerWorldOfGames.Start();
                    break;
                case "5":
                    signInMenu.Start();
                    break;
                default:
                    managerMenu.Start();
                    break;
            }
        }
    }
}