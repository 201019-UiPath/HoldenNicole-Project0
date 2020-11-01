using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface IOrdersMapper
    {
        Orders ParseOrder(Orders order);
        List<Orders> ParseOrder(ICollection<Orders> order);
        List<Products> ParseOrder(List<Products> lists);

    }
}
