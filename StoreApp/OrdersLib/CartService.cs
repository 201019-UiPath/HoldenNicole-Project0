using StoreDB.Models;
using StoreUI;

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
