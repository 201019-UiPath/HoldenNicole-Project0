using StoreDB;
using StoreDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CustomerLib
{
    public class CustomerService
    {/// <summary>
     /// need to replace this with DBRepo
     /// </summary>
        private DBRepo dbRepo;
        public CustomerService(DBRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }
        public Customers GetCustomerByID(int id)
        {
            Customers customer = dbRepo.GetCustomerByID(id);
            return customer;
        }
        public Customers GetCustomerByName(string name)
        {
            Customers customer = dbRepo.GetCustomerByName(name);
            return customer;
        }
        public void AddCustomerAsync(Customers customer)
        {
            if (!GetAllCustomersAsync().Contains(customer))
            {
                dbRepo.AddCustomerAsync(customer);
            }
            else
            {
                System.Console.WriteLine("Sorry could not register you at this time.");
                System.Console.WriteLine("Please try again.");
            }
        }
        public List<Customers> GetAllCustomersAsync()
        {
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            Task<List<Customers>> getCustomers = dbRepo.GetAllCustomersAsync();
            return getCustomers.Result;
        }
        public void PlaceOrderAsync(Orders order)
        {
            /// <summary>
            /// if order not in orders table
            /// </summary>
            /// <param name="order"></param>
            dbRepo.PlaceOrderAsync(order);
        }
        
        public List<Products> ViewAllProductsAtLocationAsync(int id)
        {
            List<Products> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocation(id);
            return viewProductsAtLocation;
        }
        public void AddProductToCartAsync(Products product)
        {
            ///buisiness logic is somewhere else 1am so forgot
            dbRepo.AddProductToCartAsync(product);
        }
    }
}