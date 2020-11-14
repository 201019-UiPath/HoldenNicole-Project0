using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ICustomerRepo
    {
        CustomerModels AddCustomer(CustomerModels customer);
        CustomerModels GetCustomerByName(string username);
    }
}
