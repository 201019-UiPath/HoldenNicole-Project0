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
        public void AddCart(CartsModel carts)
        {
            dBRepo.AddCart(carts);
        }

        public void DeleteCart(CartsModel carts)
        {
            dBRepo.DeleteCart(carts);
        }
        public void PlaceOrder(OrderModel order)
        {
            dBRepo.PlaceOrder(order);
        }

        public void AddToOrder(LineItemModel lineItem)
        {
            dBRepo.AddToOrder(lineItem);
        }

        public List<LineItemModel> GetAllProductsInOrderByID(int id)
        {
            List<LineItemModel> lineItems = dBRepo.GetAllProductsInOrderByID(id);
            return lineItems;
        } 
    }
}
