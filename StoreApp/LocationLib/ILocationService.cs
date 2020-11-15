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
        ManagerModel GetManagerByName(string managerUserName);
    }
}