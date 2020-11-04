using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IOrderRepo
    {
         void PlaceOrderAsync(Orders order);
         List<Orders> GetAllOrdersByCustomerIDDateAscending(int id);
         List<Orders> GetAllOrdersByCustomerIDDateDescending(int id);
         List<Orders> GetAllOrdersByCustomerIDPriceAscending(int id);
         List<Orders> GetAllOrdersByCustomerIDPriceDescending(int id);
         List<Orders> GetAllOrdersByLocationIDDateAscending(int id);
         List<Orders> GetAllOrdersByLocationIDDateDescending(int id);
         List<Orders> GetAllOrdersByLocationIDPriceAscending(int id);
         List<Orders> GetAllOrdersByLocationIDPriceDescending(int id);
    }
}