using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IOrderRepo
    {
        void PlaceOrder(OrderModel order);
        List<OrderModel> GetAllOrdersByCustomerID(int id);
        List<OrderModel> GetAllOrdersByCustomerIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(int id);
        List<OrderModel> GetAllOrdersByLocationIDDateAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceDescending(int id);
    }
}