using System.Collections.Generic;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    public interface IOrdersMapper
    {
        Orders ParseOrder(OrderModel order);
        ICollection<Orders> ParseOrder(List<OrderModel> order);
        OrderModel ParseOrder(Orders order);
        List<OrderModel> ParseOrder(ICollection<Orders> order);

    }
}
