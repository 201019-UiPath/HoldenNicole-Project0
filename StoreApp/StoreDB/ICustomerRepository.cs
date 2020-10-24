using CustomerLib;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationLib;
using ManagerLib;
using OrderLib;
using ProductLib;
namespace StoreDB
{
    public interface IRepository
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