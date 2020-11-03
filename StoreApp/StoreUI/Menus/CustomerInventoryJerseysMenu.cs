using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using Serilog;
using LocationLib;

namespace StoreUI.Menus
{
    public class CustomerInventoryJerseysMenu : IMenu
    {
        private ProductServices productServices;
        private StoreContext storeContext;
        private StoreMapper storeMapper;

        private StoreDB.Entities.Customers customer;

        public CustomerInventoryJerseysMenu(StoreDB.Entities.Customers customer, StoreContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            ///retrieve location from previous menus
            StoreDB.Entities.Locations location = new StoreDB.Entities.Locations();
            Console.WriteLine($"How would you like to see the inventory for World Of Jerseys:");
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
                    List<StoreDB.Entities.Products> allProductsByType = productServices.ViewAllProductsByItem(item);
                    Log.Information("type of item selected");
                    break;
                ///lists products sorted by sport
                case "2":
                    Console.WriteLine("What sport are you looking for autographs for?");
                    string sport = Console.ReadLine();
                    List<StoreDB.Entities.Products> allProductBySport = productServices.ViewAllProductsBySport(sport);
                    Log.Information("sport selected");
                    break;
                /// lists products by person
                case "3":
                    Console.WriteLine("What athlete are you looking for?");
                    string athlete = Console.ReadLine();
                    List<StoreDB.Entities.Products> allProductsByPerson = productServices.ViewAllProductsByAthlete(athlete);
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
            Log.Information("adding order from jerseys store");
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