using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface ICustomerMapper
    {
        Customers ParseCustomer(Customers customer);
        List<Customers> ParseCustomer(List<Customers> customer);

    }
}
