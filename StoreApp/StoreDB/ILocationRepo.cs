using System.Collections.Generic;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    public interface ILocationRepo
    {
        ///contains all methods to be implemented in location repo
        void AddProductToLocation(int locationid, int productid, int quantity);
        void DeleteProductAtLocation(int locationid, int productid, int quantity);
        LocationModel GetLocationByID(int id);
        LocationModel GetLocationByName(string name);
        List<LocationModel> GetAllLocations(); 
    }
}