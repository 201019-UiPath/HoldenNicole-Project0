using StoreDB;

namespace StoreUI
{
    public interface IMapper : ICustomerMapper, IOrdersMapper, IManagerMapper, ILocationMapper, ILineItemsMapper, IProductMapper, IInventoryMapper, ICartMapper, ICartItemMapper
    {
    }
}
