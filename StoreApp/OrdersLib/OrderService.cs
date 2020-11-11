using StoreDB.Models;
using StoreUI;

namespace OrdersLib
{
    public class OrdersService : IOrdersService
    {
        private readonly DBRepo dBRepo;
        public OrdersService()
        {
            this.dBRepo = new DBRepo();
        }
        public void PlaceOrder(OrderModel order)
        {
            dBRepo.PlaceOrder(order);
        }

    }
}
