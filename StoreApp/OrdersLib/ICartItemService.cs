using StoreDB.Models;
using System.Collections.Generic;

namespace OrdersLib
{
    public interface ICartItemService
    {
        void AddProductToCart(int cartid, int productid, int quantity);
        void DeleteProductInCart(int cartid, int productid, int quantity);
        List<CartItemModel> GetAllProductsInCartByCartID(int id);
        ProductModel GetProductByID(int iD);
        void PlaceOrder(OrderModel order);
        void UpdateCartItems(CartItemModel products);
    }
}