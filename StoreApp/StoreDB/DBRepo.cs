using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;
using StoreDB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreDB
{
    public class DBRepo : ICustomerRepo, ILocationRepo
    {
        private readonly StoreContext context;
        private readonly IMapper mapper;

        public DBRepo(StoreContext context, IMapper mapper){
            this.context = context;
            this.mapper = mapper;
        }
        /// <summary>
        /// customer section
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomerAsync(Customer customer){
            context.User.AddCustomerAsync(mapper.ParseCustomer(customer));
            context.SaveChangesAsync;
        }
        public void PlaceOrderAsync(Order order){
            context.Order.PlaceOrderAsync(mapper.ParseOrder(order));
            context.SaveChangesAsync;
        }
        public void AddProductToCartAsync(Products products){
            context.Products.AddProductToCartAsync(mapper.ParseProducts(products));
        }
   /*    public Task<List<Customer>> GetAllCustomersAsync(){
            return Task.Run<List<Customer>>(
                () => mapper.ParseCustomer(
                    context.User
                    .Include("UserName")
                )   
            )
        } */



        /// <summary>
        /// location section
        /// </summary>
        /// <param name="location"></param>        
        public void AddProductToLocationAsync(LocationLib location){
            context.Products.AddProductToLocationAsync(mapper.ParseProducts(location));
            ///idk if this can work or not may try double mapping to the product and location
        }
    }
}