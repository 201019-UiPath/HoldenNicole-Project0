using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ILocationRepo
    {
        ///contains all methods to be implemented in location repo
        Inventory AddProductToLocation(int locationid, int productid, int quantity);
        Inventory DeleteProductAtLocation(int locationid, int productid, int quantity);
        LocationModel GetLocationByID(int id);
        LocationModel GetLocationByName(string name);
        List<LocationModel> GetAllLocations();
    }
}