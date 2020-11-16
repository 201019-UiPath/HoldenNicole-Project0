using StoreDB.Entities;
using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace OrdersLib
{
    public class CartItemService : ICartItemService
    {
        private readonly DBRepo dBRepo;
        public CartItemService(DBRepo repo)
        {
            this.dBRepo = repo;
        }
        public CartItemModel AddProductToCart(CartItemModel cartItem)
        {

            CartItemModel cartItems = new CartItemModel()
            {
                CartID = cartItem.CartID,
                productID = cartItem.productID,
                quantity = cartItem.quantity
            };
            dBRepo.AddProductToCart(cartItem);
            return (cartItem);
        }
        public void UpdateCartItems(CartItemModel products)
        {
            dBRepo.UpdateCartItems(products);
        }
        public List<CartItemModel> GetAllProductsInCartByCartID(int id)
        {
            List<CartItemModel> products = dBRepo.GetAllProductsInCartByCartID(id);
            return products;
        }
        public void DeleteProductInCart(CartItemModel cartItem)
        {
            dBRepo.DeleteProductInCart(cartItem);
        }
        public void PlaceOrder(OrderModel order)
        {
            /// <summary>
            /// if order not in orders table
            /// </summary>
            /// <param name="order"></param>
            dBRepo.PlaceOrder(order);
        }

        public ProductModel GetProductByID(int iD)
        {
            ProductModel product = dBRepo.GetProductByID(iD);
            return product;
        }
    }
}