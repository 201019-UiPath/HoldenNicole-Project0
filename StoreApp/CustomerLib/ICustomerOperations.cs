using StoreDB.Entities;
using StoreDB.Models;

namespace CustomerLib
{
    interface ICustomerOperations
    {
        void PlaceOrder(OrderModel order);
        void GetProducts(int id);
        void CustomerOrderHistory(CustomerModels customer);
    }
}
