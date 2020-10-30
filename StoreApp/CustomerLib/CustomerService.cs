using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;
namespace CustomerLib
{
    public class CustomerService
    {
        private ICustomerRepo customerRepo;
        public CustomerService(ICustomerRepo customerRepo){
            this.customerRepo=customerRepo;
        }
        public void AddCustomerAsync(Customer customer){
            /// if customer in customers table give error
            /// otherwise
            customerRepo.AddCustomerAsync(customer);
        }
        public List<Customer> GetAllCustomersAsync(){
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            /// <param name="order"></param>
            Task<List<Customer>> getCustomers = customerRepo.GetAllCustomersAsync();
            return getCustomers.Result;
        }
        public void PlaceOrderAsync(Order order){
            /// <summary>
            /// if order not in orders table
            /// </summary>
            /// <param name="order"></param>
            customerRepo.PlaceOrderAsync(order);
        }
        public List<Customer> GetOrdersByCustomerAsync(){
            Task<List<Customer>> getOrderHistory = customerRepo.GetOrdersByCustomerAsync();
            return getOrderHistory.Result;
        }
        public List<Products> ViewAllProductsAtLocationAsync(){
            Task<List<Products>> viewProductsAtLocation = customerRepo.ViewAllProductsAtLocationAsync();
            return viewProductsAtLocation.Result;
        }
        public void AddProductToCartAsync(){
            ///buisiness logic is somewhere else 1am so forgot
            customerRepo.AddProductToCartAsync();
        }
    }
}