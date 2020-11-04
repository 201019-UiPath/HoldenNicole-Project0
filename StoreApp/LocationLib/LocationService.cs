using StoreUI;
using StoreUI.Entities;
using System.Collections.Generic;

namespace LocationLib
{
    public class LocationService
    {
        private DBRepo dbRepo;
        public LocationService (DBRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }
        public Locations GetLocationByID(int id)
        {
            Locations location = dbRepo.GetLocationByID(id);
            return location;
        }
        public Locations GetLocationByName(string name)
        {
            Locations location = dbRepo.GetLocationByName(name);
            return location;
        }
        public List<Locations> GetAllLocations()
        {
            List<Locations> locations = dbRepo.GetAllLocations();
            return locations;
        }
        public void AddProductToLocationAsync(Products product)
        {
            dbRepo.AddProductToLocationAsync(product);
        }
        public void UpdateProduct(Products product)
        {
            dbRepo.UpdateProducts(product);
        }
        public void DeleteProduct(Products product)
        {
            dbRepo.DeleteProduct(product);
        }
        public Managers GetManagerByName(string name)
        {
            Managers manager = dbRepo.GetManagerByName(name);
            return manager;
        }
        public Managers GetManagerByID(int id)
        {
            Managers manager = dbRepo.GetManagerByID(id);
            return manager;
        }
        public List<Managers> GetAllManagers()
        {
            List<Managers> getAllManagers = dbRepo.GetAllManagers();
            return getAllManagers;
        }
        public List<Orders> GetAllOrdersByLocationIDPriceDescending(int id)
        {
            List<Orders> getOrdersByLocation = dbRepo.GetAllOrdersByCustomerIDPriceDescending(id);
            return getOrdersByLocation;
        }
        public List<Orders> GetAllOrdersByLocationIDPriceAscending(int id)
        {
            List<Orders> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDPriceAscending(id);
            return getOrdersByLocation;
        }
        public List<Orders> GetAllOrdersByLocationIDDateDescending(int id)
        {
            List<Orders> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDDateDescending(id);
            return getOrdersByLocation;
        }
        public List<Orders> GetAllOrdersByLocationIDDateAscending(int id)
        {
            List<Orders> getOrdersByLocation = dbRepo.GetAllOrdersByLocationIDDateAscending(id);
            return getOrdersByLocation;
        }
    }
}
