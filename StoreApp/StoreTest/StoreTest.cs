using StoreDB;
using StoreDB.Entities;
using System.Collections.Generic;
using Xunit;

namespace StoreTest
{
    public class StoreTest
    {
        Customers testCustomer = new Customers();
        Locations testLocation = new Locations();
        Managers testManager = new Managers();
        Orders testOrder = new Orders();
        Products testProduct = new Products();

        public void AddCustomerShouldAddCustomer(int customerID, string userName, string userEmail, string userAddress)
        {
            DBRepo dBRepo;
            // do the thing you want to test
            testCustomer.AddCustomerAsync(customerID, userName, userEmail, userAddress);
            List<Customers> allCustomers = dBRepo.GetAllCustomersAsync();


            //asert
            Assert.Equal((customerID, userName, userEmail, userAddress), Customer.Customers.Peek());

        }
    }
}
