﻿using CustomerLib;
using StoreDB;
using StoreDB.Entities;
using System;
using Serilog;

namespace StoreUI.Menus
{
    public class CustomerMenu : IMenu
    {
        private CustomerOrderHistoryMenu customerOrderHistoryMenu;
        private CustomerLocationMenu customerLocationMenu;
        private StoreContext storeContext;
        private StoreMapper storeMapper;
        private Customers customer;

        public CustomerMenu(Customers customer, StoreContext storeContext, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }

        public void Start()
        {
            Console.WriteLine("Howdy! What would you like to do today at Sports Authenticated?");
            Console.WriteLine("[1] View your order history");
            Console.WriteLine("[2] Shop at a specific store");
            Console.WriteLine("[3] Search entire inventory");
            Console.WriteLine("[4] exit store");
            string customerInput = Console.ReadLine();
            do
            {
                switch (customerInput)
                {
                    case "1":
                        //redirect to customer order history
                        Console.WriteLine("Redirecting you to your order history");
                        customerOrderHistoryMenu = new CustomerOrderHistoryMenu(customer, storeContext, new StoreMapper());
                        customerOrderHistoryMenu.Start();
                        Log.Information("order history");
                        break;
                    case "2":
                        //redirect to location menu
                        Console.WriteLine("Redirecting you to the location menu. Hope you find something you like.");
                        customerLocationMenu = new CustomerLocationMenu(customer, storeContext, new StoreMapper());
                        customerLocationMenu.Start();
                        Log.Information("location menu selected");
                        break;
                    case "3":
                        //redirect to customer search menu
                       /* Console.WriteLine("Redirecting you to the search menu");
                        customerSearch.Start(); */
                        break;
                    case "4":
                        //exit store
                        Console.WriteLine("Come back again soon");
                        Environment.Exit(0);
                        Log.Information("stop leaving and buy something");
                        break;
                    default:
                        System.Console.WriteLine("Invalid Input");
                        Log.Error("Invalid input");
                        break;
                }
            } while (!customerInput.Equals(4));
        }
    }
}