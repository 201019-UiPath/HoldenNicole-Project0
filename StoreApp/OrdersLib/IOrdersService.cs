using StoreDB.Models;

namespace OrdersLib
{
    public interface IOrdersService
    {
        void PlaceOrder(OrderModel order);
    }
}