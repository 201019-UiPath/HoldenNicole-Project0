using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public class StoreMapper : IMapper
    {
        public Customers ParseCustomer(Customers customer)
        {
            return new Customers()
            {
                ID = customer.ID,
                UserName = customer.UserName,
                Address = customer.Address,
                Email = customer.Email,
            };
        }

        public List<Customers> ParseCustomer(List<Customers> customer)
        {
            List<Customers> allCustomers = new List<Customers>();
            foreach(var c in customer)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }

        public Locations ParseLocation(Locations location)
        {
            return new Locations()
            {
                ID = location.ID,
                Name = location.Name,
                Address = location.Address,
            };
        }

        public List<Locations> ParseLocation(List<Locations> location)
        {
            List<Locations> allLocations = new List<Locations>();
            foreach(var l in location)
            {
                allLocations.Add(ParseLocation(l));
            }
            return allLocations;
        }

        public Managers ParseManager(Managers manager)
        {
            return new Managers()
            {
                ID = manager.ID,
                Name = manager.Name,
                LocationID = manager.LocationID,
            };
        }

        public List<Managers> ParseManager(List<Managers> manager)
        {
            List<Managers> allManagers = new List<Managers>();
            foreach(var m in manager)
            {
                allManagers.Add(m);
            }
            return allManagers;
        }

        public Orders ParseOrder(Orders order)
        {
            return new Orders()
            {
                ID = order.ID,
                CustomerID = order.CustomerID,
                LocationID = order.LocationID,
                date = order.date,
                Price = order.Price,
                /* not in order table need to add this functionality see superpowers to do it
                 * ProductIDs = order.ProductIDs,
                    ProductNames = order.ProductNames,
                */
            };
        }

        public List<Orders> ParseOrder(ICollection<Orders> order)
        {
            List<Orders> allOrders = new List<Orders>();
            foreach(var o in order)
            {
                allOrders.Add(o);
            }
            return allOrders;
        }

        public List<Products> ParseOrder(List<Products> products)
        {
            List<Products> allProducts = new List<Products>();
            foreach (var p in products)
            {
                allProducts.Add(p);
            }
            return allProducts;
        }

        public Products ParseProducts(Products product)
        {
            return new Products()
            {
                ID = product.ID,
                Sport = product.Sport,
                Athlete = product.Athlete,
                Item = product.Item,
                Quantity = product.Quantity,
                Price = product.Price,
            };
        }
        public List<Products> ParseProducts(List<Products> products)
        {
            List<Products> allProducts = new List<Products>();
            foreach(var p in products)
            {
                allProducts.Add(p);
            }
            return allProducts;
        }

        public List<Products> ParseProducts(ICollection<Products> products)
        {
            List<Products> allProducts = new List<Products>();
            foreach(var o in products)
            {
                allProducts.Add(o);
            }
            return allProducts;
        }

        ICollection<Products> IMapper.ParseProducts(List<Products> products)
        {
            ICollection<Products> allProducts = new List<Products>();
            foreach(var p in products)
            {
                allProducts.Add(ParseProducts(p));
            }
            return allProducts;
        }
    }
}