using StoreDB;
using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersLib
{
    public class CartService
    {
        private DBRepo dbRepo;
        public CartService(DBRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }
        public void UpdateCart(Cart cart)
        {
            dbRepo.UpdateCart(cart);
        }
        public Cart GetCartByCustomerID(int id)
        {
            Cart cart = dbRepo.GetCartByCustomerID(id);
            return cart;
        }
        public void DeleteCart(Cart cart)
        {
            dbRepo.DeleteCart(cart);
        }
    }
}