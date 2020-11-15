using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace CustomerLib
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerModels customer);
        List<CustomerModels> GetAllCustomers();
        List<OrderModel> GetAllOrdersByCustomerID(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDDateDescending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer);
        List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer);
        CustomerModels GetCustomerByID(int id);
        CustomerModels GetCustomerByName(string name);
        List<InventoryModel> ViewAllProductsAtLocationSortByID(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id);
        List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id);
    }
}