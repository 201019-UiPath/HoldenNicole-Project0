using StoreDB.Models;
using StoreUI;
using System;
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

        public void AddProductToLocation(InventoryModel inventory)
        {
            dBRepo.AddProductToLocation(inventory);
        }

        public void DeleteProductAtLocation(InventoryModel inventory)
        {
            dBRepo.DeleteProductAtLocation(inventory);
        }

        public void DeleteProductAtLocation(InventoryModel items, LocationModel location)
        {
            throw new NotImplementedException();
        }
    }
}