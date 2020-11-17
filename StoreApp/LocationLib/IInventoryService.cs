using StoreDB.Models;
using System.Collections.Generic;

namespace LocationLib
{
    public interface IInventoryService
    {
        void AddProductToLocation(InventoryModel inventory);
        void DeleteProductAtLocation(InventoryModel inventory);
    }
}