using System.Collections.Generic;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    /// <summary>
    /// mapping between customer models and entities
    /// </summary>
    public interface ICustomerMapper
    {
        Customer ParseCustomer(CustomerModels customer);
        CustomerModels ParseCustomer(Customer customer);
        ICollection<Customer> ParseCustomer(List<CustomerModels> customer);
        List<CustomerModels> ParseCustomer(ICollection<Customer> customer);

    }
}
