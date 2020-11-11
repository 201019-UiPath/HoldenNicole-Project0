using StoreDB.Models;
using StoreUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersLib
{
    public class CartService : ICartService
    {
        private readonly DBRepo dBRepo;
        public CartService()
        {
            this.dBRepo = new DBRepo();
        }

        public void AddCart(CartsModel carts)
        {
            dBRepo.AddCart(carts);
        }

        public void DeleteCart(CartsModel carts)
        {
            dBRepo.DeleteCart(carts);
        }

    }
}
