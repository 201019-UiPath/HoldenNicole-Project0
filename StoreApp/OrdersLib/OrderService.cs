
using StoreDB.Entities;
using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace OrdersLib
{
    public class OrdersService
    {
        private readonly DBRepo dBRepo;
        public OrdersService(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public void PlaceOrder(OrderModel order)
        {
            dBRepo.PlaceOrder(order);
        } 
    } 
}
