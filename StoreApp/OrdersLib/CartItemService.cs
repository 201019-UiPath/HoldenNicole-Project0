using StoreDB.Entities;
using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace OrdersLib
{
    public class CartItemService : ICartItemService
    {
        private readonly DBRepo dBRepo;
        public CartItemService()
        {
            this.dBRepo = new DBRepo();
        }
        public void AddProductToCart(int cartid, int productid, int quantity)
        {
            CartItemModel cartItem = new CartItemModel()
            {
                CartID = cartid,
                productID = productid,
                quantity = quantity
            };
            dBRepo.AddProductToCart(cartItem);
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
        public void DeleteProductInCart(int cartid, int productid)
        {
            dBRepo.DeleteProductInCart(cartid, productid);
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