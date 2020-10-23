using System.Collections.Generic;
using System.Collections.Generic;
using CustomerLib;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerDB
{
    /// <summary>
    /// file repository with customer data
    /// </summary>
    public class FileRepo
    {
        string filepath = "StoreApp/CustomerDB/CustomerDataLocation/Customers.txt";
        /// <summary>
        /// Adds customer to file
        /// </summary>
        ///<param name="customer"></param>
        public async void AddCustomerAsync(Customer customer){
            using(FileStream fs = File.Create(filepath)){
                await JsonSerializer.SerializeAsync(fs, customer);
            }
        }
        /// <summary>
        /// gets all customers data from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync(){
            List<CustomerBL> allCustomers = new List<Hero>();
            using(FileStream fs = File.OpenRead(filepath)){
                allCustomers.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
            return allCustomers;
        }
    }
}
