//using StoreBL;
namespace StoreUI.Menus
{
    public class CustomerOrderHistoryMenu : IMenu
    {
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
        /// will only have access to customer order history
        //StoreBL storeBL = new StoreBL();
        public void Start(){
            System.Console.WriteLine("How would you like your order history sorted?");
            System.Console.WriteLine("[1] Date most recent-oldest /n [2] Date oldest-most recent /n [3] Price high-low /n [4] Price low-high /n [5] Return to customer menu /n [6] exit");
            string sortedHistory = System.Console.ReadLine();
            do{
                switch (sortedHistory){
                    case "1":
                        System.Console.WriteLine("Here is your order history sorted by most recent first: ");
                        /// output sorted order history most recent first
                        break;
                    case "2":
                        System.Console.WriteLine("Here is your order history with oldest orders first: ");
                        /// output sorted order history oldest first
                        break;
                    case "3":
                        System.Console.WriteLine("Here is your order history sorted by highest price first: ");
                        /// output sorted order history most expensive first
                        break;
                    case "4":
                        System.Console.WriteLine("Here is your order history with cheapest items first: ");
                        /// output sorted order history cheapest items first
                        break;
                    case "5":
                        System.Console.WriteLine("Redirecting you back to customer main menu");
                        /// <summary>
                        /// return customer to main customer menu
                        /// </summary>
                        /// <returns></returns>
                        break;
                }
            } while(!sortedHistory.Equals(6));
        }
    }
}