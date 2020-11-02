using StoreDB;
using StoreDB.Entities;
using StoreUI.Entities;
using System;
using System.Collections.Generic;

namespace StoreUI.Menus
{
    public class CustomerInventoryGamesMenu : IMenu
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
        private StoreContext storeContext;
        private StoreMapper storeMapper;

        public CustomerInventoryGamesMenu(StoreContext storeContext, StoreMapper storeMapper)
        {
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            ///retrieve location from previous menus
            StoreDB.Entities.Locations location = new StoreDB.Entities.Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Games:");
            Console.WriteLine("[1] By type of item");
            System.Console.WriteLine("[2] By sport");
            System.Console.WriteLine("[3] By person");
            System.Console.WriteLine("[4] exit store");
            string sorting = System.Console.ReadLine();
            do
            {
                switch (sorting)
                {
                    /// lists products sorted by type
                    case "1":
                        Console.WriteLine("What type of autographed item are you looking for?");
                        string item = Console.ReadLine();
                        List<StoreDB.Entities.Products> allProductsByType = dBRepo.ViewAllProductsByItem(item);
                        break;
                    ///lists products sorted by sport
                    case "2":
                        Console.WriteLine("What sport are you looking for autographs for?");
                        string sport = Console.ReadLine();
                        List<StoreDB.Entities.Products> allProductBySport = dBRepo.ViewAllProductsBySport(sport);
                        break;
                    /// lists products by person
                    case "3":
                        Console.WriteLine("What athlete are you looking for?");
                        string athlete = Console.ReadLine();
                        List<StoreDB.Entities.Products> allProductsByPerson = dBRepo.ViewAllProductsByAthlete(athlete);
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        break;
                }
            } while (!sorting.Equals(4)); 
        }
        public StoreDB.Entities.Orders AddOrder()
        {
            StoreDB.Entities.Customers customer = new StoreDB.Entities.Customers();
            StoreDB.Entities.Orders order = new StoreDB.Entities.Orders();
            List<StoreDB.Entities.Products> products = new List<StoreDB.Entities.Products>();
            System.Console.WriteLine("Please enter your username:");
            customer.UserName = Console.ReadLine();
            order.CustomerID = customer.ID;
            order.ID = order.ID;
            order.LocationID = 1;
            order.Price = order.Price;
            order.date = order.date;
            do{
                StoreDB.Entities.Products product = new StoreDB.Entities.Products();
                System.Console.WriteLine("Enter product you would like to add to your order: ");
                string id = Console.ReadLine();
                product.ID = Convert.ToInt32(id);
                product.Sport = product.Sport;
                product.Price = product.Price;
                product.Item = product.Item;
                product.Athlete = product.Athlete;
                if(product.ID.Equals("end")) break;
                System.Console.WriteLine("How many would you like to order");
                string quantity = Console.ReadLine();
                product.Quantity = Convert.ToInt32(quantity);
                products.Add(product);
            } while(true);
            order.Products = products;
            return order;
        } 
    }
}