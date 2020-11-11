using StoreDB.Models;

namespace OrdersLib
{
    interface ICartService
    {
        void AddCart(CartsModel carts);
        void DeleteCart(CartsModel carts);
    }
}