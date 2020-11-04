using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface IOrdersMapper
    {
        Orders ParseOrder(Orders order);
        List<Orders> ParseOrder(ICollection<Orders> order);
        List<Products> ParseOrder(List<Products> lists);

    }
}
