using System.Collections.Generic;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    public interface ICartRepo
    {
        void UpdateCartItems(CartItemModel cartItem);
        void AddProductToCart(CartItemModel cartItem);
        List<CartItemModel> GetAllProductsInCartByCartID(int id);
    }
}