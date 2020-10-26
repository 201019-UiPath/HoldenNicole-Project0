﻿using System;
using System.Collections.Generic;
using LocationLib;
using ProductLib;
using StoreBL;

namespace StoreUI.Menus
{
    class LocationInventoryMenu : IMenu
    {
        StoreBLL storeBL = new StoreBLL();
        public void Start()
        {
            ///retrieve location from previous menus
            Location location = new Location();
            Console.WriteLine($"How would you like to see the inventory for {location.LocationName} :");
            Console.WriteLine("[1] By type /n [2] By sport /n [3] By person /n [4] exit store");
            string sorting = System.Console.ReadLine();
            do
            {
                switch (sorting)
                {
                    /// lists products sorted by type
                    case "1":
                        List<Product> allProductsByType = storeBL.GetAllProductsByType();
                        foreach (var product in allProductsByType)
                        {
                            Console.WriteLine($"Product {product.ProductName} - {product.Quantity}");
                        }
                        break;
                    ///lists products sorted by sport
                    case "2":
                        List<Product> allProductBySport = storeBL.GetAllProductsBySport();
                        foreach (var product in allProductBySport)
                        {
                            Console.WriteLine($"Products {product.ProductName} - {product.Quantity}");
                        }
                        break;
                    /// lists products by person
                    case "3":
                        List<Product> allProductsByPerson = storeBL.GetAllProductsByPerson();
                        Console.WriteLine("Product name - Quantity");
                        foreach (var product in allProductsByPerson)
                        {
                            Console.WriteLine($"Products {product.ProductName} - {product.Quantity}");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        break;
                }
            } while (!sorting.Equals(4));
        }
    }
}
