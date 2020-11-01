using Microsoft.EntityFrameworkCore;
using StoreDB.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface ICartRepo
    {
        void UpdateCartItems(Products products);
        Products GetProductByID(int id);
        void DeleteProductInCart(Products products);
        void AddProductToCartAsync(Products product);
        Task<List<Products>> GetAllProductsInCartByCartID(int id);
    }
}