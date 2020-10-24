using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerLib;
using OrderLib;
using ProductLib;

namespace StoreDB
{
    public interface ICustomerRepository
    {
         /// <summary>
         /// 
         /// <summary>
         void AddCustomerAsync(Customer customer);
         void AddOrder (Order order);
         void AddProduct (Product product);
         Task<List<Order>> GetAllOrdersAsync();
    }
}