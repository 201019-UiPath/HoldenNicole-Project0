using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLib
{
    interface ICustomerOperations
    {
        void PlaceOrder();
        void GetProducts();
        void orderHistory();
        void customerOrderHistory();
    }
}
