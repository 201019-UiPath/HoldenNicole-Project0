using System;
using System.Collections.Generic;
using System.Text;
using StoreDB.Entities;

namespace StoreDB
{
    public interface ICustomerMapper
    {
        Customers ParseCustomer(Customers customer);
        List<Customers> ParseCustomer(List<Customers> customer);

    }
}
