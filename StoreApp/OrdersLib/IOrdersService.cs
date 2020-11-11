using StoreDB.Models;
using System.Collections.Generic;

namespace OrdersLib
{
    public interface IOrdersService
    {
        void PlaceOrder(OrderModel order);
        void AddToOrder(LineItemModel lineItem);
        List<LineItemModel> GetAllProductsInOrderByID(int id);
    }
}