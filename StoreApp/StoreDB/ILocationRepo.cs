using StoreDB.Entities;
using System.Collections.Generic;

namespace StoreDB
{
    public interface ILocationRepo
    {
        ///contains all methods to be implemented in location repo
        void AddProductToLocationAsync(Products product);
        void UpdateProducts(Products product);
        void DeleteProduct(Products product);
        List<Products> ViewAllProductsAtLocation(int id);
        Locations GetLocationByID(int id);
        Locations GetLocationByName(string name);
        List<Locations> GetAllLocations();

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