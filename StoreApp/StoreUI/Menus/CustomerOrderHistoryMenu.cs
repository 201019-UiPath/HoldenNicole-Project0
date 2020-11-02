//using StoreBL;
using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreUI.Menus
{
    public class CustomerOrderHistoryMenu : IMenu
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
        DBRepo dBRepo;

        public void Start()
        {
            /// <summary>
            /// need to figure out how to send customer data here
            /// </summary>
            /// <returns></returns>
            System.Console.WriteLine("What is your customer id?");
            string id = System.Console.ReadLine();
            int idd = Convert.ToInt32(id);
            System.Console.WriteLine("How would you like your order history sorted?");
            System.Console.WriteLine("[1] Date most recent-oldest /n [2] Date oldest-most recent /n [3] Price high-low /n [4] Price low-high /n [5] Return to customer menu /n [6] exit");
            string sortedHistory = System.Console.ReadLine();
            do
            {
                switch (sortedHistory)
                {
                    case "1":
                        System.Console.WriteLine("Here is your order history sorted by most recent first: ");
                        dBRepo.GetAllOrdersByCustomerIDDateDescending(idd);
                        
                        break;
                    case "2":
                        System.Console.WriteLine("Here is your order history with oldest orders first: ");
                        dBRepo.GetAllOrdersByCustomerIDPriceAscending(idd);
                        break;
                    case "3":
                        System.Console.WriteLine("Here is your order history sorted by highest price first: ");
                        dBRepo.GetAllOrdersByCustomerIDPriceDescending(idd);
                        break;
                    case "4":
                        System.Console.WriteLine("Here is your order history with cheapest items first: ");
                        dBRepo.GetAllOrdersByCustomerIDPriceDescending(idd);
                        break;
                    case "5":
                        System.Console.WriteLine("Redirecting you back to customer main menu");
                        customerMenu.Start();
                        /// <summary>
                        /// return customer to main customer menu
                        /// </summary>
                        /// <returns></returns>
                        break;
                }
            } while (!sortedHistory.Equals(6)); 
        } 
    }
}