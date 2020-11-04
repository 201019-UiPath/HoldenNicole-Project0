using StoreUI.Entities;
using System;
using System.Collections.Generic;
using Serilog;
using LocationLib;

namespace StoreUI.Menus
{
    public class CustomerInventoryMenu : IMenu
    {
        private ProductServices productServices;
        private ixdssaucContext storeContext;
        private StoreMapper storeMapper;
        private Customer customer;
        private ixdssaucContext ixdssaucContext;

        public CustomerInventoryMenu(Customer customer, ixdssaucContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            ///retrieve location from previous menus
            StoreUI.Entities.Locations location = new StoreUI.Entities.Locations();
            Console.WriteLine($"How would you like to see the inventory for World Of Sticks:");
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
                    List<Products> allProductsByType = productServices.ViewAllProductsByItem(item);
                    Log.Information("type of item selected");
                    break;
                ///lists products sorted by sport
                case "2":
                    Console.WriteLine("What sport are you looking for autographs for?");
                    string sport = Console.ReadLine();
                    List<Products> allProductBySport = productServices.ViewAllProductsBySport(sport);
                    Log.Information("sport selected");
                    break;
                /// lists products by person
                case "3":
                    Console.WriteLine("What athlete are you looking for?");
                    string athlete = Console.ReadLine();
                    List<Products> allProductsByPerson = productServices.ViewAllProductsByAthlete(athlete);
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
        public Orders AddOrder()
        {
            Customer customer = new Customer();
            Orders order = new Orders();
            List<Products> products = new List<Products>();
            System.Console.WriteLine("Please enter your username:");
            customer.Username = Console.ReadLine();
            object iD = customer.ID;
            order.Customer = (int)iD;
            order.ID = order.ID;
            order.Location = 1;
            order.Price = order.Price;
            order.OrderDate = order.OrderDate;
            Log.Information("adding order from sticks store");
            do{
                Products product = new Products();
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