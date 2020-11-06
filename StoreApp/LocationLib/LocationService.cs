using StoreUI;
using StoreDB.Entities;
using System.Collections.Generic;
using StoreDB.Models;

namespace LocationLib
{
    public class LocationService
    {
        private readonly DBRepo dbRepo;
        public LocationService ()
        {
            this.dbRepo = new DBRepo();

        }

       // public LocationService()
        //{
        //}

        public LocationModel GetLocationByID(int id)
        {
            LocationModel location = dbRepo.GetLocationByID(id);
            return location;
        }
        public LocationModel GetLocationByName(string name)
        {
            LocationModel location = dbRepo.GetLocationByName(name);
            return location;
        }
        public List<LocationModel> GetAllLocations()
        {
            List<LocationModel> locations = dbRepo.GetAllLocations();
            return locations;
        }
        public List<OrderModel> GetAllOrdersByLocationIDPriceAscending(int id)
        {
            List<OrderModel> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDPriceAscending(id);
            return getOrdersByLocation;
        }
        public List<OrderModel> GetAllOrdersByLocationIDDateDescending(int id)
        {
            List<OrderModel> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDDateDescending(id);
            return getOrdersByLocation;
        }
        public List<OrderModel> GetAllOrdersByLocationIDDateAscending(int id)
        {
            List<OrderModel> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDDateAscending(id);
            return getOrdersByLocation;
        } 
        public List<OrderModel> GetAllOrdersByLocationIDPriceDescending(int id)
        {
            List<OrderModel> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDPriceDescending(id);
            return getOrdersByLocation;
        } 
    }
}
