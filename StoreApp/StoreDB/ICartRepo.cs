using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ICartRepo
    {
        void UpdateCartItems(CartItemModel cartItem);
        void AddProductToCart(CartItemModel cartItem);
        List<CartItemModel> GetAllProductsInCartByCartID(int id);
    }
}