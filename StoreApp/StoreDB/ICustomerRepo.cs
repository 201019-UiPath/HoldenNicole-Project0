using StoreUI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreUI
{
    public interface ICustomerRepo
    {
        void PlaceOrderAsync(Orders order);
        Task<List<Customers>> GetAllCustomersAsync();
        void AddCustomer(Customers customer);
    }
}
