using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IOrderRepo
    {
        void PlaceOrder(OrderModel order);
        List<OrderModel> GetAllOrdersByCustomerIDDateAscending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDDateDescending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByLocationIDDateAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceDescending(int id);
    }
}