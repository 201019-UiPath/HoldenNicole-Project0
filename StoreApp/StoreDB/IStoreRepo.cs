using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace StoreDB
{
    public interface IStoreRepo : ICartRepo, ICustomerRepo, ILocationRepo, IOrderRepo
    {
        List<InventoryModel> ViewAllProductsAtLocation(int id);
    }
}
