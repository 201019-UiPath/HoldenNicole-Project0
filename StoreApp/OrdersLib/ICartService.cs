using StoreDB.Models;

namespace OrdersLib
{
    public interface ICartService
    {
        void AddCart(CartsModel carts);
        void DeleteCart(CartsModel carts);
    }
}