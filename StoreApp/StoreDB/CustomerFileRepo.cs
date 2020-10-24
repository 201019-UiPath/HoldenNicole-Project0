using System;
using System.Collections.Generic;
using CustomerLib;
using LocationLib;
using ManagerLib;
using OrderLib;
using ProductLib;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreDB
{
    public class CustomerFileRepo : ICustomerRepository
    {
        //  string customerfilepath = 
        public void AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> ICustomerRepository.GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
