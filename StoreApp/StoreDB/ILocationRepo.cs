using System.Collections.Generic;
using StoreUI.Entities;

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
    }
}