using StoreUI;
using StoreUI.Entities;
using System;
using System.Collections.Generic;

namespace OrdersLib
{
    public class CartItemService
    {
        private DBRepo dBRepo;
        public CartItemService(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public void AddProductToCartAsync(Products product)
        {
            dBRepo.AddProductToCartAsync(product);
        }
        public void UpdateCartItems(Products products)
        {
            dBRepo.UpdateCartItems(products);
        }
        public Products GetProductByID(int id)
        {
            Products item = dBRepo.GetProductByID(id);
            return item;
        }
        public List<Products> GetAllProductsInCartByCartID(int id)
        {
            List<Products> products = dBRepo.GetAllProductsInCartByCartID(id);
            return products;
        }
        public void DeleteProductInCart(Products product)
        {
            dBRepo.DeleteProductInCart(product);
        } 
        public void PlaceOrderAsync(Orders order)
        {
            /// <summary>
            /// if order not in orders table
            /// </summary>
            /// <param name="order"></param>
            dBRepo.PlaceOrderAsync(order);
        }

        public Products GetProductByID(object iD)
        {
            throw new NotImplementedException();
        }
    }
}