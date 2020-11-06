using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Entities;
using StoreDB.Models;

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
