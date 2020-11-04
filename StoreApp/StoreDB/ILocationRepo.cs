using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ILocationRepo
    {
        ///contains all methods to be implemented in location repo
        void AddProductToLocationAsync(Products product);
        void UpdateProducts(Products product);
        void DeleteProduct(Products product);
        List<Products> ViewAllProductsAtLocationGroupByItem(int id);
        List<Products> ViewAllProductsAtLocationGroupBySport(int id);
        List<Products> ViewAllProductsAtLocationGroupByAthlete(int id);
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