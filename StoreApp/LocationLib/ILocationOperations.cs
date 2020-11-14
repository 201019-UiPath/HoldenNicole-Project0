using StoreDB.Models;

namespace LocationLib
{
    interface ILocationOperations
    {
        void AddProductToLocation(InventoryModel item, int quantity);
        void GetInventory(int id);
        void GetHistory(int id);
    }
}
