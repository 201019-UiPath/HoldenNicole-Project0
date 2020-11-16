using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace LocationLib
{
    public class ProductServices
    {
        private readonly DBRepo dBRepo;
        public ProductServices(DBRepo repo)
        {
            this.dBRepo = repo;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByID(int id)
        {
            List<InventoryModel> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocationSortByID(id);
            return viewAllProductsAtLocation;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id)
        {
            List<InventoryModel> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocationSortByQuantityAscending(id);
            return viewAllProductsAtLocation;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id)
        {
            List<InventoryModel> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocationSortByQuantityDescending(id);
            return viewAllProductsAtLocation;
        }
    }
}