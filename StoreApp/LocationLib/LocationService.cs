using StoreDB;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
