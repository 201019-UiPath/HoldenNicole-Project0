using System.Collections.Generic;
using StoreDB;
using StoreDB.Entities;

namespace StoreUI
{
    public interface IMapper : ICustomerMapper, IOrdersMapper, IManagerMapper, ILocationMapper, ILineItemsMapper, IProductMapper, IInventoryMapper, ICartMapper, ICartItemMapper
    {
    }
}
