using StoreUI;
using StoreUI.Entities;
using System;
using System.Collections.Generic;
using Serilog;
using System.Linq;
using LocationLib;

namespace StoreUI.Menus
{
    public class ManagerWorldOfSticks : IMenu
    {
        private SignInMenu signInMenu;
        private Managers manager;
        private ProductServices productServices;

        public ManagerWorldOfSticks(Managers manager, hyfhtbziContext storeContext, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public ManagerWorldOfSticks(hyfhtbziContext storeContext, StoreMapper storeMapper)
        {
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;

        }
        public hyfhtbziContext storeContext { get; }
        public StoreMapper storeMapper { get; }

        /*   public string ViewAllProductsAtLocation(int id)
           {
                return storeMapper.ParseProducts(
                    storeContext.Product
                    .Include("Name - Quantity - Item - Price")
                    .Where(x => x.locationID == storeContext.Location.Single(y => y.locationID == id).locationID)
                    .GroupBy(p => p.Item)
                    .ToList()); 
           } */
      /*  public List<Products> ViewAllProductsBySport(string sport)
        {
            string u = "hi";
            List<Products> products = (List<Products>)storeContext.Product.GroupBy(p => p.Sport);
            foreach(var t in products)
            {
                System.Console.WriteLine($"{t.Athlete}, {t.Item}");
            }
            return u;
        } */
        public void Start()
        {
            ///retrieve location from previous menu
            Locations location = new Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Sticks :");
            Console.WriteLine("[1] By type");
            System.Console.WriteLine("[2] By sport");
            System.Console.WriteLine("[3] By person");
            System.Console.WriteLine("[4] exit store");
            string sorting = System.Console.ReadLine();
            
            switch (sorting)
            {
                /// lists products sorted by type
                case "1":
                    Console.WriteLine("What type of autographed item are you looking for?");
                    string sport = Console.ReadLine();
                    int id = 2;

                    foreach(Products t in productServices.ViewAllProductsAtLocationGroupByItem(id))
                    {
                        System.Console.WriteLine($"Products available: Athlete: {t.Athlete} | Item: {t.Item} | Price: {t.Price} | Available Quantity: {t.Quantity}");
                    }
                    Log.Information("Item type selected");
                    break;
                    ///lists products of sport
                case "2":
                    Console.WriteLine("What sport are you looking for autographs for?");
                   // string sport = Console.ReadLine();
                   // List<Products> allProductBySport = dBRepo.ViewAllProductsBySport(sport);
                    Log.Information("Sport selected");
                    break;
                /// lists products of person
                case "3":
                    Console.WriteLine("What athlete are you looking for?");
                    string athlete = Console.ReadLine();
                    List<Products> allProductsByPerson = productServices.ViewAllProductsByAthlete(athlete);
                    Log.Information("Athlete selected");
                    break;
                case "4":
                    Console.WriteLine("Bye hope you come again soon");
                    Log.Information("Replenish?");
                    break;
                default:
                    System.Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }

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
                Log.Information("In replenish inventory loop");
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

