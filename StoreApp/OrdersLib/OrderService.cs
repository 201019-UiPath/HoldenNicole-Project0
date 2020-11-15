using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace OrdersLib
{
    public class OrdersService : IOrdersService
    {
        private readonly DBRepo dBRepo;
        public OrdersService()
        {
            this.dBRepo = new DBRepo();
        }

        public void AddCart(CartsModel cart)
        {
            dBRepo.AddCart(cart);
        }

        public void AddToOrder(LineItemModel lineItem)
        {
            dBRepo.AddToOrder(lineItem);
        }

        public void DeleteCart(CartsModel cart)
        {
            dBRepo.DeleteCart(cart);
        }

        public List<LineItemModel> GetAllProductsInOrderByID(int id)
        {
            List<LineItemModel> items = dBRepo.GetAllProductsInOrderByID(id);
            List<LineItemModel> item = items;
            return items;
        }

        public void PlaceOrder(OrderModel order)
        {
            dBRepo.PlaceOrder(order);
        }
        
    }
}
