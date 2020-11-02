using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class ManagerWorldOfGames
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
        private DBRepo dBRepo;
        public void Start()
        {
            ///retrieve location from previous menu
            Locations location = new Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Games :");
            Console.WriteLine("[1] By type /n [2] By sport /n [3] By person /n [4] exit store");
            string sorting = System.Console.ReadLine();
            do
            {
                switch (sorting)
                {
                    /// lists products sorted by type
                    case "1":
                        Console.WriteLine("What type of autographed item are you looking for?");
                        string item = Console.ReadLine();
                        List<Products> allProductsByType = dBRepo.ViewAllProductsByItem(item);
                        break;
                    ///lists products of sport
                    case "2":
                        Console.WriteLine("What sport are you looking for autographs for?");
                        string sport = Console.ReadLine();
                        List<Products> allProductBySport = dBRepo.ViewAllProductsBySport(sport);
                        break;
                    /// lists products of person
                    case "3":
                        Console.WriteLine("What athlete are you looking for?");
                        string athlete = Console.ReadLine();
                        List<Products> allProductsByPerson = dBRepo.ViewAllProductsByAthlete(athlete);
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        break;
                }
            } while (!sorting.Equals(4));

            // allowing manager to replenish inventory after seeing remaining inventory at this store
            Console.WriteLine("Would you like to replenish the inventory at your location? (yes/no)");
            string response = System.Console.ReadLine();
            if (response == "yes")
            {
                string local = location.ToString();
                Console.WriteLine("How many products would you like to add?");
                string newProducts = Console.ReadLine();
                int newP = (int)Convert.ToInt64(newProducts);
                int i = 1;
                do
                {
                    Console.WriteLine("Please enter the productID you wish to add: ");
                    string productID = Console.ReadLine();
                    int id = (int)Convert.ToInt64(productID);
                    Console.WriteLine("Please enter the product name you would like to add: ");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please enter the product type you would like to add: ");
                    string productType = Console.ReadLine();
                    Console.WriteLine("Please enter the product quantity you would like to add: ");
                    string quantity = Console.ReadLine();
                    int quan = (int)Convert.ToInt64(quantity);
                    Products addProduct = new Products(id, productName, productType, quan, local);
                    i += 1;
                }
                while (i <= newP); 
            }
            else
            {
                Console.WriteLine("Would you like to do anything else (yes/no)?");
                string a = System.Console.ReadLine();
                if (a == "no")
                {
                    Console.WriteLine("Goodbye, Hope you come back soon!");
                    // exit store
                }
                else
                {
                    Console.WriteLine("Redirecting you back to the first menu");
                    signInMenu.Start();
                }
            } 
        } 
    }
}
