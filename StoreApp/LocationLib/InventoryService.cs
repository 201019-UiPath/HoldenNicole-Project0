using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace LocationLib
{
    public class InventoryService: IInventoryService
    {
        private readonly DBRepo dBRepo;
        public InventoryService(DBRepo repo)
        {
            this.dBRepo = repo;
        }

        public void AddProductToLocation(InventoryModel item)
        {
            dBRepo.AddProductToLocation(item);
        }

        public void DeleteProductAtLocation(InventoryModel item)
        {
            dBRepo.DeleteProductAtLocation(item);
        }

        public List<InventoryModel> ViewAllProductsAtLocation(int id)
        {
            List<InventoryModel> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocation(id);
            return viewAllProductsAtLocation;
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