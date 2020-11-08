using StoreUI;
using StoreDB.Entities;
using System;
using Xunit;
using StoreDB;
using StoreDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StoreTest
{
    public class StoreTest
    {
        private readonly IMapper mapper = new StoreMapper();
        private DBRepo dBrepo;

        private readonly CustomerModels testcustomer = new CustomerModels()
        {
            ID = 1,
            Username = "Bob",
            email = "Bob@gmail.com"
        };

        private readonly Customer testCustomer2 = new Customer()
        {
            Id = 1,
            Username = "Danny",
            Email = "Danny1@gmail.com"
        };

        private readonly CartItems testCartItems = new CartItems()
        {
            Id = 1,
            Cart = 1,
            Product = 3,
            Quantity = 5
        };

        private readonly CartItemModel cartItemModel = new CartItemModel()
        {
            CartID = 1,

        };
        public void AddCustomerShouldAddCustomer(int customerID, string userName, string userEmail, string userAddress)
        {
            //Arange
            //   var options = new 
        }
    }
}
