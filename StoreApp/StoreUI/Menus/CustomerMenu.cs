using StoreDB.Entities;
using System;

namespace StoreUI.Menus
{
    public class CustomerMenu : IMenu
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
        private CustomerInventorySticks customerInventorySticksMenu;
        private CustomerInventoryJerseysMenu customerInventoryJerseysMenu;
        private CustomerInventoryGamesMenu customerInventoryGamesMenu;
        private CustomerLocationMenu customerLocationMenu;

        public void Start()
        {
            Customers customer = new Customers();
            //retrieve customer info from sign in menu
            Console.WriteLine($"Howdy {customer.UserName}! What would you like to do today at Sports Authenticated?");
            Console.WriteLine("[1] View your order history /n [2] Shop at a specific store /n [3] Search entire inventory /n [4] exit store");
            string customerInput = Console.ReadLine();
            do
            {
                switch (customerInput)
                {
                    case "1":
                        //redirect to customer order history
                        Console.WriteLine("Redirecting you to your order history");
                        customerOrderHistoryMenu.Start();
                        break;
                    case "2":
                        //redirect to location menu
                        Console.WriteLine("Redirecting you to the location menu. Hope you find something you like.");
                        customerLocationMenu.Start();
                        break;
                    case "3":
                        //redirect to customer search menu
                        Console.WriteLine("Redirecting you to the search menu");
                        customerSearch.Start();
                        break;
                    case "4":
                        //exit store
                        Console.WriteLine("Come back again soon");
                        break;
                }
            } while (!customerInput.Equals(4));
        }
    }
}