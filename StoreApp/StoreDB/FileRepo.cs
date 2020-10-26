using System.Collections.Generic;
using CustomerLib;
using LocationLib;
using ManagerLib;
using OrderLib;
using ProductLib;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreDB
{
    public class FileRepo : IRepository
    {
        /// <summary>
        /// adds customer too customer file
        /// </summary>
        string customerfilepath = "StoreDB/StoreDataHoldingCell/CustomerCell/CustomerData.txt";
        public async void AddCustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(customerfilepath))
            {
                await JsonSerializer.SerializeAsync(fs, customer);
            }
        }
        /// <summary>
        /// adds order to order file
        /// </summary>
        string orderfilepath = "StoreDB/StoreDataHoldingCell/OrderCell/OrderData.txt";
        public async void AddOrderAsync(Order order)
        {
            using (FileStream fs = File.Create(orderfilepath))
            {
                await JsonSerializer.SerializeAsync(fs, order);
            }
        }
        /// <summary>
        /// adds product to cart file
        /// </summary>
        string productcartfilepath = "StoreDB/StoreDataHoldingCell/CartCell/CartData.txt";
        public async void AddProductToCartAsync(Product product, Order order)
        {
            using (FileStream fs = File.Create(productcartfilepath))
            {
                await JsonSerializer.SerializeAsync(fs, product);
            }
        }
        /// <summary>
        /// add product to location file
        /// </summary>
        string productlocationfilepath = "StoreDB/StoreDataHoldingCell/ProductCell/ProductLocationData.txt";
        public async void AddProductToLocationAsync(Product product, Location location)
        {
            using (FileStream fs = File.Create(productlocationfilepath))
            {
                await JsonSerializer.SerializeAsync(fs, product);
            }
        }
        /// <summary>
        /// returns all orders from order file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            List<Order> allOrders = new List<Order>();
            using(FileStream fs = File.OpenRead(orderfilepath))
            {
                allOrders.Add(await JsonSerializer.DeserializeAsync<Order>(fs));
            }
            return allOrders;
        }
        /// <summary>
        /// returns list of all customers
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> allCustomers = new List<Customer>();
            using(FileStream fs = File.OpenRead(customerfilepath))
            {
                allCustomers.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
            return allCustomers;
        }
        /// <summary>
        /// returns list of all managers
        /// </summary>
        string managerfilepath = "StoreDB/StoreDataHoldingCell/ManagerCell/ManagerData.txt";
        public async Task<List<Manager>> GetAllManagersAsync()
        {
            List<Manager> allManagers = new List<Manager>();
            using (FileStream fs = File.OpenRead(managerfilepath))
            {
                allManagers.Add(await JsonSerializer.DeserializeAsync<Manager>(fs));
            }
            return allManagers;
        }

    }
}
