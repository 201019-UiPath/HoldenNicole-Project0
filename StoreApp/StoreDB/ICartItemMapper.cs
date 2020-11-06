using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
    /// <summary>
    /// mapps cart items in model and entities
    /// </summary>
    public interface ICartItemMapper
    {
        CartItemModel ParseCartItem(CartItems cartItems);
        CartItems ParseCartItem(CartItemModel cartItems);
        ICollection<CartItems> ParseCartItem(List<CartItemModel> cartItems);
        List<CartItemModel> ParseCartItem(ICollection<CartItems> cartItems);
    }
}
