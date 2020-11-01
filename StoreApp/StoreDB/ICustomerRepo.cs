using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface ICustomerRepo
    {
        void PlaceOrderAsync(Orders order);
        Task<List<Customers>> GetAllCustomersAsync();
        void AddCustomerAsync(Customers customer);
    }
}
