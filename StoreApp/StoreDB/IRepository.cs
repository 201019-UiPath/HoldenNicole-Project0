using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerLib;
using LocationLib;
using StoreDB.Models;

namespace StoreDB
{
    public interface IRepository
    {
         /// <summary>
         /// contains all methods to be implemented in file repo
         /// <summary>
         public void AddCustomerAsync(Customer customer);
         public Task<List<Customer>> GetAllCustomersAsync();
         public void PlaceOrderAsync(Order order);
         public void AddOrderAsync (Order order);
         public void AddProductToCartAsync (Products product, Order order);
         public void AddProductToLocationAsync(Products product, Location location);
         public Task<List<Order>> GetAllOrdersAsync();
         public Task<List<Manager>> GetAllManagersAsync();
         public Task<List<Customer>> GetOrdersByCustomerAsync();
         public Task<List<Products>> ViewAllProductsAtLocationAsync();
        public Task<List<Order>> GetAllOrdersAtLocation();

        /* Want to add section would allow searching objects in whole store inventory and at location
        Task<List<Products>> ViewAllProductsOfType(); 
        Task<List<Products>> ViewAllProductsOfSport();
        Task<List<Products>> ViewAllProductsByPerson();
        
        Task<List<Products>> ViewProductsOfTypeAtLocation();
        Task<List<Products>> ViewProductsOfSportAtLocation();
        Task<List<Products>> ViewProductsOfPersonAtLocation();
        
        Task<List<Order>> GetAllOrdersByType();
        Task<List<Order>> GetAllOrdersBySport();
        Task<List<Order>> GetAllOrdersByPerson();

        Task<List<Order>> GetAllOrdersByTypeAtLocation();
        Task<List<Order>> GetAllOrdersBySportAtLocation();
        Task<List<Order>> GetAllOrdersByPersonAtLocation();
        */
    }
}