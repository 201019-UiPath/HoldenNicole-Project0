using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace CustomerLib
{
    public interface ICustomerService
    {
        CustomerModels AddCustomer(CustomerModels customer);
        List<CustomerModels> GetAllCustomers();
        List<OrderModel> GetAllOrdersByCustomerID(int id);
        List<OrderModel> GetAllOrdersByCustomerIDDateDescending(int id);
        List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(int id);
        List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(int id);
        List<OrderModel> GetAllOrdersByCustomerIDDateAscending(int id);
        CustomerModels GetCustomerByID(int id);
        CustomerModels GetCustomerByName(string name);
        List<ProductModel> ViewAllProductsAtLocationSortByIDPriceLowToHigh(int id);
        List<ProductModel> ViewAllProductsAtLocationSortByIDPriceHighToLow(int id);
    }
}