using StoreDB.Entities;
using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace CustomerLib
{
    public class CustomerService : ICustomerService
    {
        private readonly DBRepo dbRepo;
        public CustomerService()
        {
            this.dbRepo = new DBRepo();
        }

        public CustomerModels GetCustomerByID(int id)
        {
            return dbRepo.GetCustomerByID(id);
        }
        public CustomerModels GetCustomerByName(string name)
        {
            return dbRepo.GetCustomerByName(name);
        }
        public List<CustomerModels> GetAllCustomers()
        {
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            return dbRepo.GetAllCustomersOrderByOrders();
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByID(int id)
        {
            return dbRepo.ViewAllProductsAtLocation(id);
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id)
        {
            return dbRepo.ViewAllProductsAtLocationSortByQuantityAscending(id);
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id)
        {
            return dbRepo.ViewAllProductsAtLocationSortByQuantityDescending(id);
        }
        public List<OrderModel> GetAllOrdersByCustomerIDDateAscending(CustomerModels customer)
        {
            return dbRepo.GetAllOrdersByCustomerIDDateAscending(customer);
        }
        public List<OrderModel> GetAllOrdersByCustomerIDDateDescending(CustomerModels customer)
        {
            return dbRepo.GetAllOrdersByCustomerIDDateDescending(customer);
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer)
        { 
            return dbRepo.GetAllOrdersByCustomerIDPriceAscending(customer);
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer)
        {  
            return dbRepo.GetAllOrdersByCustomerIDPriceDescending(customer);
        } 

        public void AddCustomer(CustomerModels newCustomer)
        {
            List<CustomerModels> getCustomersTask = dbRepo.GetAllCustomersOrderByUsername();
            foreach (var h in getCustomersTask)
            {
                if (newCustomer.Username.Equals(h.Username))
                {
                    throw new System.Exception("Sorry this username is already taken");
                }
                else
                {
                    if (newCustomer.email.Equals(h.email))
                    {
                        throw new System.Exception("Sorry this email is already registered");
                    }
                }
            }
            dbRepo.AddCustomer(newCustomer);
        }
    }
}