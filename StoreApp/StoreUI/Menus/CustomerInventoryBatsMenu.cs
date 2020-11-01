using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StoreUI.Menus
{
    class CustomerInventoryBatsMenu : IMenu
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
            ///retrieve location from previous menus
            Locations location = new Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Bats:");
            Console.WriteLine("[1] By type /n [2] By sport /n [3] By person /n [4] exit store");
            string sorting = System.Console.ReadLine();
            do
            {
                switch (sorting)
                {
                    /// lists products sorted by type
                    case "1":
                        List<Products> allProductsByType = dBRepo.GetAllProductsByType();
                        Console.WriteLine("What type of autographed item are you looking for?");
                        string item = Console.ReadLine();
                        ///want to add function that will only show items type requested
                        foreach (var product in allProductsByType)
                        {
                            Console.WriteLine($"Product {product.Sport} - {product.Athlete} - {product.Quantity} - {product.Price}");
                        }
                        break;
                    ///lists products sorted by sport
                    case "2":
                        List<Products> allProductBySport = dBRepo.GetAllProductsBySport();
                        Console.WriteLine("What sport are you looking for autographs for?");
                        string sport = Console.ReadLine();
                        ///want to add function that will only show items belonging to sport requested
                        foreach (var product in allProductBySport)
                        {
                            Console.WriteLine($"Products {product.Athlete} - {product.Item} - {product.Quantity} - {product.Price}");
                        }
                        break;
                    /// lists products by person
                    case "3":
                        List<Products> allProductsByPerson = dBRepo.GetAllProductsByPerson();
                        Console.WriteLine("What athlete are you looking for?");
                        string athlete = Console.ReadLine();
                        ///want to add function that will only show athlete requested
                        foreach (var product in allProductsByPerson)
                        {
                            Console.WriteLine($"Products {product.Sport} - {product.Item} - {product.Quantity} - {product.Price}");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        break;
                }
            } while (!sorting.Equals(4));
        }
        public Orders GetOrderDetails()
        {
            
            Orders order = new Orders();
            List<Orders> products = new List<Orders>();
            
        }
    }
}