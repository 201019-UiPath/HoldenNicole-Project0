using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerLib;
using OrderLib;
using ProductLib;
using LocationLib;
using ManagerLib;

namespace StoreDB
{
    public interface IRepository
    {
         /// <summary>
         /// contains all methods to be implemented in file repo
         /// <summary>
         void AddCustomerAsync(Customer customer);
         void AddOrderAsync (Order order);
         void AddProductToCartAsync (Product product, Order order);
         void AddProductToLocationAsync(Product product, Location location);
         Task<List<Order>> GetAllOrdersAsync();
         Task<List<Customer>> GetAllCustomersAsync();
         Task<List<Manager>> GetAllManagersAsync();
    }
}