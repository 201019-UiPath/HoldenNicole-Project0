using StoreDB.Models;
using System.Collections.Generic;

namespace LocationLib
{
    public interface IInventoryService
    {
        List<InventoryModel> ViewAllProductsAtLocationSortByID(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id);
    }
}