using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ICustomerRepo
    {
        void PlaceOrder(OrderModel order);
        List<CustomerModels> GetAllCustomersOrderByUsername();
        List<CustomerModels> GetAllCustomersOrderByOrders();
        void AddCustomer(CustomerModels customer);
    }
}
