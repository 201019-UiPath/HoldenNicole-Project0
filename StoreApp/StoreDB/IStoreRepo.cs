using StoreUI;

namespace StoreDB
{
    public interface IStoreRepo : ICartRepo, ICustomerRepo, ILocationRepo, IOrderRepo
    {
    }
}
