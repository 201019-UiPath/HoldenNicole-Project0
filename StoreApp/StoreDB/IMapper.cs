using StoreDB;
using StoreDB.Entities;
using StoreDB.Models;
using System.Linq;

namespace StoreUI
{
    public interface IMapper : ICustomerMapper, IOrdersMapper, IManagerMapper, ILocationMapper, ILineItemsMapper, IProductMapper, IInventoryMapper, ICartMapper, ICartItemMapper
    {
    }
}
