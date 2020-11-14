using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IOrderRepo
    {
        OrderModel PlaceOrder(OrderModel order); //void in a working version
        LineItemModel AddToOrder(LineItemModel lineItem); //doesnt exits in working version
        List<LineItemModel> GetAllProductsInOrderByID(int id);
        List<OrderModel> GetAllOrdersByCustomerIDDateAscending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDDateDescending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByLocationID(int id);
        List<OrderModel> GetAllOrdersByLocationIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByLocationIDPriceDescending(int id);
    }
}