using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ICartRepo
    {
        CartItemModel UpdateCartItems(CartItemModel cartItem);
        CartItemModel AddProductToCart(CartItemModel cartItem);
        List<CartItemModel> GetAllProductsInCartByCartID(int id);
        CartItemModel DeleteProductInCart(int id, int productid, int quantity);
    }
}