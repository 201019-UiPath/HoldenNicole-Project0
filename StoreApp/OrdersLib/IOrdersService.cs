using StoreDB.Models;
using System.Collections.Generic;

namespace OrdersLib
{
    public interface IOrdersService
    {
        void PlaceOrder(OrderModel order);
        void AddToOrder(LineItemModel lineItem);
        void AddCart(CartsModel cart);
        void DeleteCart(CartsModel cart);
        List<LineItemModel> GetAllProductsInOrderByID(int id);
    }
}