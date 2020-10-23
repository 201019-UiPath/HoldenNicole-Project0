using System.Collections.Generic;
using OrderLib;
using OrderDB;
using System.Threading.Tasks;

namespace OrderBL
{
    public class OrderBL
    {
        IRepository repo = new FileRepo();
        public void AddOrder(OrderBL newOrder){
            repo.AddOrderAsync(newOrder);
        }
        public List<Order> GetAllOrders(){
            Task<List<Order>> getOrders = repo.GetAllOrdersAsync();
            return getOrders.Result;
        }
    }
}
