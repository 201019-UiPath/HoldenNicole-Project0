using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ILocationRepo
    {
        ///contains all methods to be implemented in location repo
        void AddProductToLocation(InventoryModel inventory);
        void DeleteProductAtLocation(InventoryModel inventory);
        LocationModel GetLocationByID(int id);
        LocationModel GetLocationByName(string name);
        List<LocationModel> GetAllLocations();
    }
}