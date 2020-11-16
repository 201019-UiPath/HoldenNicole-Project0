using StoreDB.Models;
using System.Collections.Generic;

namespace LocationLib
{
    public interface IProductServices
    {
        List<InventoryModel> ViewAllProductsAtLocationSortByID(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id);
    }
}