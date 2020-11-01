using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface IOrdersMapper
    {
        Orders ParseOrder(Orders order);
        ICollection<Orders> ParseOrders(List<Orders> order);
        List<Orders> ParseOrder(ICollection<Orders> order);
    }
}
