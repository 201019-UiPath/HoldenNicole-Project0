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
         public List<Order> GetAllOrdersAsync();
         public List<Manager> GetAllManagersAsync();
        public List<Products> ViewAllProductsAtLocationAsync();
        public List<Order> GetAllOrdersAtLocation();

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