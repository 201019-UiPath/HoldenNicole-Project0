using StoreUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface IStoreRepo : ICartRepo, ICustomerRepo, ILocationRepo, IOrderRepo
    {
    }
}
