using StoreUI;
using StoreUI.Entities;
using System;
using System.Collections.Generic;
using Serilog;
using LocationLib;

namespace StoreUI.Menus
{
    public class CustomerInventoryGamesMenu : IMenu
    {
        private ProductServices productServices;
        private hyfhtbziContext storeContext;
        private StoreMapper storeMapper;
        private StoreUI.Entities.Customers customer;
        public CustomerInventoryGamesMenu(StoreUI.Entities.Customers customer, hyfhtbziContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            ///retrieve location from previous menus
            StoreUI.Entities.Locations location = new StoreUI.Entities.Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Games:");
            Console.WriteLine("[1] By type of item");
            System.Console.WriteLine("[2] By sport");
            System.Console.WriteLine("[3] By person");
            System.Console.WriteLine("[4] exit store");
            string sorting = System.Console.ReadLine();
            switch (sorting)
            {
                /// lists products sorted by type
                case "1":
                    Console.WriteLine("What type of autographed item are you looking for?");
                    string item = Console.ReadLine();
                    List<StoreUI.Entities.Products> allProductsByType = productServices.ViewAllProductsByItem(item);
                    Log.Information("type of item selected");
                    break;
                ///lists products sorted by sport
                case "2":
                    Console.WriteLine("What sport are you looking for autographs for?");
                    string sport = Console.ReadLine();
                    List<StoreUI.Entities.Products> allProductBySport = productServices.ViewAllProductsBySport(sport);
                    Log.Information("sport selected");
                    break;
                /// lists products by person
                case "3":
                    Console.WriteLine("What athlete are you looking for?");
                    string athlete = Console.ReadLine();
                    List<StoreUI.Entities.Products> allProductsByPerson = productServices.ViewAllProductsByAthlete(athlete);
                    Log.Information("athlete selected");
                    break;
                case "4":
                    Console.WriteLine("Bye hope you come again soon");
                    Log.Information("Hsss leaving store");
                    break;
                default:
                    System.Console.WriteLine("Invalid Input");
                    Log.Error("Invalid input");
                    break;
            }
        }
     /*   public StoreUI.Entities.Orders AddOrder()
        {
            StoreUI.Entities.Customers customer = new StoreUI.Entities.Customers();
            StoreUI.Entities.Orders order = new StoreUI.Entities.Orders();
            List<StoreUI.Entities.Products> products = new List<StoreUI.Entities.Products>();
            System.Console.WriteLine("Please enter your username:");
            customer.UserName = Console.ReadLine();
            order.CustomerID = customer.ID;
            order.ID = order.ID;
            order.LocationID = 1;
            order.Price = order.Price;
            order.date = order.date;
            Log.Information("adding order from games store");
            do{
                StoreUI.Entities.Products product = new StoreUI.Entities.Products();
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
        } */
    }
}