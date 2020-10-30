using CustomerLib;
using StoreDB.Models;
using System;
using StoreBL;
namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        private string userInput;

        private CustomerMenu customerMenu;
        private CustomerOrderHistoryMenu customerOrderHistoryMenu;
        private CustomerSearch customerSearch;
        private LocationInventoryMenu locationInventoryMenu;
        private LocationOrderHistoryMenu locationOrderHistoryMenu;
        private ManagerLocationInventory managerLocationInventory;
        private SearchBySport searchBySport;
        private SearchByType searchByType;
        private SignInMenu signInMenu;
        private SportOrderHistoryMenu sportOrderHistoryMenu;
        private TypeOrderHistoryMenu typeOrderHistoryMenu;
        private AthleteOrderHistoryMenu athleteOrderHistoryMenu;
        private ManagerWorldOfBats managerWorldOfBats;
        private ManagerWorldOfGames managerWorldOfGames;
        private ManagerWorldOfJerseys managerWorldOfJerseys;
        private ManagerWorldOfSticks managerWorldOfSticks;
        private CustomerInventoryBatsMenu customerInventoryBatsMenu;
        private CustomerInventorySticksMenu customerInventorySticksMenu;
        private CustomerInventoryJerseysMenu customerInventoryJerseysMenu;
        private CustomerInventoryGamesMenu customerInventoryGamesMenu;

        public SignInMenu(UserContext context, IMapper mapper);
        public StoreBLL storeBL = new StoreBLL();
        public void Start(){
            Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            Console.WriteLine("Please select the option matching you below:");
            Console.WriteLine("[1] Sign in as a manager /n [2] Sign in as a returning customer /n [3] Sign up as a new customer /n [4] exit");
            userInput = Console.ReadLine();
            do{
                switch (userInput){
                    case "1":
                        Manager manager = new Manager();
                        Console.WriteLine("Please enter your username:");
                        string managerUserName = Console.ReadLine();
                        storeBL.CheckManager(manager);
                        // manager name should be linked to location
                        /// <summary>
                        /// send to location corresponding to manager's location
                        /// </summary>
                        break;
                    case "2":
                        Customer customer = new Customer();
                        System.Console.WriteLine("Please enter your username:");
                        string returningCustomerUserName = System.Console.ReadLine();
                        storeBL.CheckCustomer(customer);
                        System.Console.WriteLine($"Welcome back {customer.UserName}");
                        Console.WriteLine("Hope you find something you like!");
                        /// <summary>
                        /// send to customer menu
                        /// </summary>
                        break;
                    case "3":
                        Customer newCustomer = new Customer();
                        storeBL.AddCustomer(newCustomer);
                        /// <summary>
                        /// if pass add to customer list then
                        /// send to customer menu otherwise give message try again
                        /// </summary>
                        break;
                    case "4":
                        System.Console.WriteLine("Bye come again some other time.");
                        break;
                }
            } while(!userInput.Equals("4")); 
        }
        
    }
}