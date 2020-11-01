namespace StoreUI.Menus
{
    public class CustomerLocationMenu : IMenu
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
            System.Console.WriteLine("Which store would you like to shop at?");
            System.Console.WriteLine("[1] World of Bats /n [2] World of Sticks /n [3] World of Jerseys /n [4] World of Games /n [5] Back to Sign in menu");
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Sending you to the World of Bats store");
                    System.Console.WriteLine("Hope you find something you like");
                    customerInventoryBatsMenu.Start();
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    System.Console.WriteLine("Hope you find something you like");
                    customerInventorySticksMenu.Start();
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    System.Console.WriteLine("Hope you find something you like");
                    customerInventoryJerseysMenu.Start();
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    System.Console.WriteLine("Hope you find somthing you like");
                    customerInventoryGamesMenu.Start();
                    break;
                case "5":
                    signInMenu.Start();
                    break;
                default:
                    customerLocationMenu.Start();
                    break;
            }
        }

    }
}
