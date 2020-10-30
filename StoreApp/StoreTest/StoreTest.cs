using Xunit;
using StoreDB;
using System.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace StoreTest
{
    public class StoreTest
    {
        Customer testCustomer = new Customer();
        Location testLocation = new Location();
        Manager testManager = new Manager();
        Order testOrder = new Order();
        Product testProduct = new Product();
        
        public void AddCustomerShouldAddCustomer(int customerID, string userName, string userEmail, string userAddress)
        {
            FileRepo storeDB = new FileRepo();
            // do the thing you want to test
            testCustomer.AddCustomer(customerID, userName, userEmail, userAddress);
            List<Customer> allCustomers = storeDB.GetAllCustomersAsync();
            using (FileStream fs = File.OpenRead(customerfilepath))
            {
                allCustomers.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
            return allCustomers;

            //asert
            Assert.Equal((customerID, userName, userEmail, userAddress),Customer.Customers.Peek());

        }
    }
}
