﻿using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using Serilog;
using CustomerLib;
using LocationLib;
using OrdersLib;

namespace StoreUI.Menus
{
    class CustomerInventoryBatsMenu : IMenu
    {
        private StoreContext storeContext;
        private StoreMapper storeMapper;
        private StoreDB.Entities.Customers customer;
        private CustomerService customerService;
        private CartItemService cartItemService;
        private ProductServices productServices;
        private CustomerMenu customerMenu;
        public CustomerInventoryBatsMenu(StoreDB.Entities.Customers customer,  StoreContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            ///retrieve location from previous menus
            StoreDB.Entities.Locations location = new StoreDB.Entities.Locations();
            Console.WriteLine($"How would you like to see the inventory for World of Bats:");
            Console.WriteLine("[1] By type of item");
            System.Console.WriteLine("[2] By sport");
            System.Console.WriteLine("[3] By person");
            System.Console.WriteLine("[4] exit store");
            string sorting = System.Console.ReadLine();

            switch (sorting)
            {
                /// lists products sorted by type
                case "1":
                    Console.WriteLine("Here are the products available at this location sorted by item:");
                    int id = 1;
                    List<Products> allProductsByType = productServices.ViewAllProductsAtLocationGroupByItem(id);
                    foreach(Products p in allProductsByType)
                    {
                        Products product = cartItemService.GetProductByID(p.ID);
                        System.Console.WriteLine($"[{p.ID}] {p.Item} | {p.Athlete} | {p.Sport} | {p.Quantity} | {p.Price}");
                    }
                    System.Console.WriteLine("Would you like to add to or start new order (yes/no)?");
                    string add = Console.ReadLine();
                    if(add.Equals("yes"))
                    {
                        AddOrder();
                    }
                    else
                    {
                        customerMenu = new CustomerMenu(customer, storeContext, new StoreMapper());
                        customerMenu.Start();
                    }
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
            Log.Information("adding order from bats store");
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