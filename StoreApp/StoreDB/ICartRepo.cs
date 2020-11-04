using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ICartRepo
    {
        void UpdateCartItems(Products products);
        Products GetProductByID(int id);
        void DeleteProductInCart(Products products);
        void AddProductToCartAsync(Products product);
        List<Products> GetAllProductsInCartByCartID(int id);
    }
}