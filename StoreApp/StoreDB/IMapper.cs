using StoreDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface IMapper : ICustomerMapper, IOrdersMapper, IManagerMapper, ILocationMapper
    {
        Products ParseProducts(Products products);
        ICollection<Products> ParseProducts(List<Products> products);
        List<Products> ParseProducts(ICollection<Products> products);
    }
}
