using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface ICustomerMapper
    {
        Customer ParseCustomer(Customer customer);
        List<Customer> ParseCustomer(List<Customer> customer);

    }
}
