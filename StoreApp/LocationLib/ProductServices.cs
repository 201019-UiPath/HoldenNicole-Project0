using System.Collections.Generic;
using StoreUI;
using StoreDB.Entities;
using StoreDB.Models;

namespace LocationLib
{
    public class ProductServices
    {
        private readonly DBRepo dBRepo;
        public ProductServices()
        {
            this.dBRepo = new DBRepo();
        }
        public List<InventoryModel> ViewAllProductsAtLocation(int id)
        {
            List<InventoryModel> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocation(id);
            return viewAllProductsAtLocation;
        }
    }
}