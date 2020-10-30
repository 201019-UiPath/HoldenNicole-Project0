using System.Collections.Generic;
using System.Threading.Tasks;
using LocationLib;
using StoreDB.Models;

namespace StoreDB
{
    public interface ILocationRepo
    {
     ///contains all methods to be implemented in location repo
         public void AddProductToLocationAsync(Products product, Location location);
         public Task<List<Order>> GetAllOrdersAsync();
         public Task<List<Manager>> GetAllManagersAsync();
        public Task<List<Products>> ViewAllProductsAtLocationAsync();
        public Task<List<Order>> GetAllOrdersAtLocation();

        /* Want to add section
        Task<List<Order>> GetAllOrdersByType();
        Task<List<Order>> GetAllOrdersBySport();
        Task<List<Order>> GetAllOrdersByPerson();

        Task<List<Order>> GetAllOrdersByTypeAtLocation();
        Task<List<Order>> GetAllOrdersBySportAtLocation();
        Task<List<Order>> GetAllOrdersByPersonAtLocation();
        */
    }
}