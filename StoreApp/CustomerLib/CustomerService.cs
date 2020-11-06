using StoreUI;
using StoreDB.Entities;
using System.Collections.Generic;
using StoreDB.Models;

namespace CustomerLib
{
    public class CustomerService
    {
        private readonly DBRepo dbRepo;
        public CustomerService(DBRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }
        public CustomerModels GetCustomerByID(int id)
        {
            CustomerModels customer = dbRepo.GetCustomerByID(id);
            return customer;
        }
        public CustomerModels GetCustomerByName(string name)
        {
            CustomerModels customer = dbRepo.GetCustomerByName(name);
            return customer;
        }
        public void AddCustomer(CustomerModels customer)
        {
            List<CustomerModels> getCustomersTask = dbRepo.GetAllCustomersOrderByUsername();
            foreach(var h in getCustomersTask)
            {
                if(customer.Username.Equals(h.Username))
                {
                    throw new System.Exception("Sorry this username is already taken");
                }
                else 
                {
                    if(customer.email.Equals(h.email))
                    {
                        throw new System.Exception("Sorry this email is already registered");
                    }
                }
            }
            dbRepo.AddCustomer(customer);
        }
        public List<CustomerModels> GetAllCustomers()
        {
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            List<CustomerModels> getCustomers = dbRepo.GetAllCustomersOrderByOrders();
            return getCustomers;
        }
        public List<InventoryModel> ViewAllProductsAtLocation(int id)
        {
            List<InventoryModel> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocation(id);
            return viewProductsAtLocation;
        } 
        public List<OrderModel> GetAllOrdersByCustomerIDDateAscending(CustomerModels customer)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDDateAscending(customer);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDDateDescending(CustomerModels customer)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDDateDescending(customer);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDPriceAscending(customer);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDPriceDescending(customer);
            return orders;
        } 
    }
}