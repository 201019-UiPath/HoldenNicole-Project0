using StoreUI;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using StoreDB.Models;

namespace OrdersLib
{
    public class CartItemService
    {
        private readonly DBRepo dBRepo;
        public CartItemService(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public void AddProductToCart(CartItemModel cartItem)
        {
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
        public void DeleteProductInCart(CartItemModel product)
        {
            dBRepo.DeleteProductInCart(product);
        } 
        public void PlaceOrder(OrderModel order)
        {
            /// <summary>
            /// if order not in orders table
            /// </summary>
            /// <param name="order"></param>
            dBRepo.PlaceOrder(order);
        }

        public Products GetProductByID(object iD)
        {
            throw new NotImplementedException();
        }
    } 
}