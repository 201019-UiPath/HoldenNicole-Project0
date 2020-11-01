using StoreDB.Entities;

namespace LocationLib
{
    interface ILocationOperations
    {
        void AddInventory(Products product);
        void GetInventory(int id);
        void GetHistory(int id);
    }
}
