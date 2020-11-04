using System.Collections.Generic;
using System.Threading.Tasks;
using StoreUI.Entities;

namespace StoreUI
{
    public interface ICustomerRepo
    {
        void PlaceOrderAsync(Orders order);
        Task<List<Customer>> GetAllCustomersAsync();
        void AddCustomer(Customer customer);
    }
}
