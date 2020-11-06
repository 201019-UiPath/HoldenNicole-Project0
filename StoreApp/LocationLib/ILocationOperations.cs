using StoreDB.Entities;

namespace LocationLib
{
    interface ILocationOperations
    {
        void AddProductToLocation(int locationid, int productid, int quantity);
        void GetInventory(int id);
        void GetHistory(int id);
    }
}
