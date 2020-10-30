using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerLib
{
    public class CustomerService
    {
        private ICustomerRepo customerRepo;
        public CustomerService(ICustomerRepo customerRepo){
            this.customerRepo=customerRepo;
        }
        public void AddCustomerAsync(Customer customer);
        public Task<List<Customer>> GetAllCustomersAsync();
        public void PlaceOrderAsync(Order order);
        public void AddOrderAsync (Order order);
        public Task<List<Customer>> GetOrdersByCustomerAsync();
        public Task<List<Products>> ViewAllProductsAtLocationAsync();
        public void AddProductToCartAsync(){
            ///buisiness logic is somewhere else 1am so forgot
        }
    }
}