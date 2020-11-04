using StoreUI.Entities;

namespace CustomerLib
{
    interface ICustomerOperations
    {
        void PlaceOrder(Orders order);
        void GetProducts(int id);
        void CustomerOrderHistory(int id);
    }
}
