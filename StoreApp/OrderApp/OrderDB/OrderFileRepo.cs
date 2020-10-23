using System.Collections.Generic;
using HeroesLib;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace OrderDB
{
    public class OrderFileRepo : IOrderRepository
    {
        string filepath = "StoreApp/OrderApp/OrderDB/OrderDataLocation/Orders.txt";
        /// <summary>
        /// adds order to file
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async void AddOrderAsync(Order order){
            using(FileStream fs = File.Create(filepath)){
                await JsonSerializer.SerializeAsync(fs, order);
            }
        }
        /// <summary>
        /// gets all orders from file
        /// </summary>
        public async Task<List<Order>> GetAllOrdersAsync(){
            List<Order> allOrders = new List<Hero>();
            using(FileStream fs = File.OpenRead(filepath)){
                allOrders.Add(await JsonSerializer.DeserializeAsync<Order>(fs));
            }
            return allOrders;
        }
    }
}