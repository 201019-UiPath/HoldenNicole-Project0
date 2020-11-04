
using StoreUI.Entities;
using StoreUI;
using System.Collections.Generic;

namespace OrdersLib
{
    public class OrdersService
    {
        private DBRepo dBRepo;
        public OrdersService(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public void PlaceOrder(Orders order)
        {
            dBRepo.PlaceOrderAsync(order);
        } 
        public List<Orders> GetAllOrdersByCustomerID(int id)
        {
            List<Orders> orders = GetAllOrdersByCustomerID(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDDateAscending(int id)
        {
            List<Orders> orders = dBRepo.GetAllOrdersByCustomerIDDateAscending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDDateDescending(int id)
        {
            List<Orders> orders = dBRepo.GetAllOrdersByCustomerIDDateDescending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceAscending(int id)
        {
            List<Orders> orders = dBRepo.GetAllOrdersByCustomerIDPriceAscending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceDescending(int id)
        {
            List<Orders> orders = dBRepo.GetAllOrdersByCustomerIDPriceDescending(id);
            return orders;
        }
    }
}
