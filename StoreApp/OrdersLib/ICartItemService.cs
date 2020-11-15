using StoreDB.Models;
using System.Collections.Generic;

namespace OrdersLib
{
    public interface ICartItemService
    {
        CartItemModel AddProductToCart(CartItemModel cartItem);
        void DeleteProductInCart(CartItemModel cartItem);
        List<CartItemModel> GetAllProductsInCartByCartID(int id);
        ProductModel GetProductByID(int iD);
        void PlaceOrder(OrderModel order);
        void UpdateCartItems(CartItemModel products);
    }
}