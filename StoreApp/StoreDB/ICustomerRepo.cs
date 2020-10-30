using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerLib;
using StoreDB.Models;

namespace StoreDB
{
    public interface ICustomerRepo
    {
         /// contains all customer methods to be implemented
         public void AddCustomerAsync(Customer customer);
         public List<Customer> GetAllCustomersAsync();
         public void PlaceOrderAsync(Order order);
         public void AddProductToCartAsync (Products product, Order order);
        public List<Customer> GetOrdersByCustomerAsync();
        public List<Products> ViewAllProductsAtLocationAsync();

        /* would like to add section
        Task<List<Products>> ViewAllProductsOfType(); 
        Task<List<Products>> ViewAllProductsOfSport();
        Task<List<Products>> ViewAllProductsByPerson();
        
        Task<List<Products>> ViewProductsOfTypeAtLocation();
        Task<List<Products>> ViewProductsOfSportAtLocation();
        Task<List<Products>> ViewProductsOfPersonAtLocation();
        */
    }
}