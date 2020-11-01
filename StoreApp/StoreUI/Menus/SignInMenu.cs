using CustomerLib;
using StoreDB;
using StoreDB.Entities;
using System;
using LocationLib;
using System.Configuration;

namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
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

        private Customers customer;
        private StoreContext storeContext;
        private ICustomerRepo customerRepo;
        private CustomerService customerService;
        private ILocationRepo locationRepo;
        private LocationService locationService;

        private DBRepo dBRepo;

        public WelcomeMenu(StoreContext storeContext, ICustomerRepo customerRepo, ILocationRepo locationRepo)
        {
            this.storeContext = storeContext;
            this.customerRepo = customerRepo;
            this.locationRepo = locationRepo;
        }

        public void Start()
        {
            Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            Console.WriteLine("Please select the option matching you below:");
            Console.WriteLine("[1] Sign in as a manager /n [2] Sign in as a returning customer /n [3] Sign up as a new customer /n [4] exit");
            userInput = Console.ReadLine();
            do
            {
                switch (userInput)
                {
                    case "1":
                        Managers manager = new Managers();
                        Console.WriteLine("Please enter your username:");
                        string managerUserName = Console.ReadLine();
                        dBRepo.GetAllManagersAsync();
                        ///if output from dBRepo contains user input redirect to location corresponding to manager
                        break;
                    case "2":
                        Customers customer = new Customers();
                        System.Console.WriteLine("Please enter your username:");
                        string returningCustomerUserName = System.Console.ReadLine();
                        dBRepo.GetAllCustomersAsync();
                        ///compare output with returning user input
                        ///if passes
                        System.Console.WriteLine($"Welcome back {customer.UserName}");
                        Console.WriteLine("Hope you find something you like!");
                        /// <summary>
                        /// send to customer menu
                        /// </summary>
                        customerMenu.Start();
                        break;
                    case "3":
                        Customers newCustomer = new Customers();
                        dBRepo.AddCustomerAsync(newCustomer);
                        /// <summary>
                        /// if pass add to customer list then
                        /// send to customer menu otherwise give message try again
                        /// </summary>
                        customerMenu.Start();
                        break;
                    case "4":
                        System.Console.WriteLine("Bye come again some other time.");
                        break;
                }
            } while (!userInput.Equals("4"));
        }

    }
}