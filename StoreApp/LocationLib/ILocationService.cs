using StoreDB.Models;
using System.Collections.Generic;

namespace LocationLib
{
    public interface ILocationService
    {
        List<LocationModel> GetAllLocations();
        List<OrderModel> GetAllOrdersByLocationID(int id);
        List<OrderModel> GetAllOrdersByLocationIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceDescending(int id);
        LocationModel GetLocationByID(int id);
        LocationModel GetLocationByName(string name);
        void AddProductToLocation(InventoryModel item);
        void DeleteProductAtLocation(InventoryModel item);
        void GetManagerByName(string managerUserName);
        List<InventoryModel> GetLocationInventory(int id);
    }
}