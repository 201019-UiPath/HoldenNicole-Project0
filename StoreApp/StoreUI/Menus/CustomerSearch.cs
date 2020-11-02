using StoreDB.Entities;
using System;

namespace StoreUI.Menus
{
    public class CustomerSearch : IMenu
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
        public void Start()
        {
            Products product = new Products();
            System.Console.WriteLine("What would you like to search by in the entire Sports Authenticated inventory today?");
            System.Console.WriteLine("[1] Search by sport /n [2] Search by type of item /n [3] Search by person /n [4] exit store");
            string searchSelection = Console.ReadLine();
            do
            {
                switch (searchSelection)
                {
                    case "1":
                        Console.WriteLine("Sending you to the search by sport menu");
                        searchBySport.Start();
                        break;
                    case "2":
                        Console.WriteLine("Sending you to the search by type of item menu");
                        searchByType.Start();
                        break;
                    case "3":
                        Console.WriteLine("Sending you to the search by person menu");
                        searchByPerson.Start();
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        // exit store
                        break;
                }
            } while (!searchSelection.Equals(4));
        }
    }
}
