using StoreUI;
using StoreUI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CustomerLib
{
    public class CustomerService
    {
        private DBRepo dbRepo;
        private readonly ixdssaucContext context;
        private readonly IMapper mapper;
        public CustomerService(DBRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }
        public Customer GetCustomerByID(int id)
        {
            Customer customer = dbRepo.GetCustomerByID(id);
            return customer;
        }
        public Customer GetCustomerByName(string name)
        {
            Customer customer = dbRepo.GetCustomerByName(name);
            return customer;
        }
        public void AddCustomer(Customer customer)
        {
            Task<List<Customer>> getCustomersTask = dbRepo.GetAllCustomersAsync();
            foreach(var h in getCustomersTask.Result)
            {
                if(customer.Username.Equals(h.Username))
                {
                    throw new System.Exception("Sorry this username is already taken");
                }
                else 
                {
                    if(customer.Email.Equals(h.Email))
                    {
                        throw new System.Exception("Sorry this email is already registered");
                    }
                }
            }
            dbRepo.AddCustomer(customer);
        }
        public List<Customer> GetAllCustomersAsync()
        {
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            Task<List<Customer>> getCustomers = dbRepo.GetAllCustomersAsync();
            return getCustomers.Result;
        }
        public List<Products> ViewAllProductsAtLocationGroupBySport(int id)
        {
            List<Products> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationGroupBySport(id);
            return viewProductsAtLocation;
        } 
        public List<Products> ViewAllProductsAtLocationGroupByItem(int id)
        {
            List<Products> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationGroupByItem(id);
            return viewProductsAtLocation;
        } 
        public List<Products> ViewAllProductsAtLocationGroupByAthlete(int id)
        {
            List<Products> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationGroupByAthlete(id);
            return viewProductsAtLocation;
        } 
        public List<Orders> GetAllOrdersByCustomerIDDateAscending(int id)
        {
            List<Orders> orders = dbRepo.GetAllOrdersByCustomerIDDateAscending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDDateDescending(int id)
        {
            List<Orders> orders = dbRepo.GetAllOrdersByCustomerIDDateDescending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceAscending(int id)
        {
            List<Orders> orders = dbRepo.GetAllOrdersByCustomerIDPriceAscending(id);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceDescending(int id)
        {
            List<Orders> orders = dbRepo.GetAllOrdersByCustomerIDPriceDescending(id);
            return orders;
        } 
    }
}