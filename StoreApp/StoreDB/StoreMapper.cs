using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public class StoreMapper : IMapper
    {
        public Customer ParseCustomer(Customer customer)
        {
            return new Customer()
            {
                ID = customer.ID,
                Username = customer.Username,
                Email = customer.Email,
            };
        }

        public List<Customer> ParseCustomer(List<Customer> customer)
        {
            List<Customer> allCustomers = new List<Customer>();
            foreach(var c in customer)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
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

        public Locations ParseLocation(Locations location)
        {
            throw new System.NotImplementedException();
        }

        public Managers ParseManager(Managers manager)
        {
            return new Managers()
            {
                ID = manager.ID,
                Username = manager.Username,
                Location = manager.Location,
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
                Customer = order.Customer,
                Location = order.Location,
                OrderDate = order.OrderDate,
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

        public object ParseOrder(List<Orders> lists)
        {
            throw new System.NotImplementedException();
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
    }
}