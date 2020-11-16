using StoreDB.Models;
using StoreUI;
using System.Collections.Generic;

namespace CustomerLib
{
    public class CustomerService : ICustomerService
    {
        private readonly DBRepo dbRepo;
        public CustomerService(DBRepo repo)
        {
            this.dbRepo = repo;
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
        public CustomerModels AddCustomer(CustomerModels customer)
        {
            List<CustomerModels> getCustomersTask = dbRepo.GetAllCustomersOrderByUsername();
            foreach (var h in getCustomersTask)
            {
                if (customer.Username.Equals(h.Username))
                {
                    throw new System.Exception("Sorry this username is already taken");
                }
                else
                {
                    if (customer.email.Equals(h.email))
                    {
                        throw new System.Exception("Sorry this email is already registered");
                    }
                }
            }
            dbRepo.AddCustomer(customer);
            return (customer);
        }
        public List<CustomerModels> GetAllCustomers()
        {
            /// <summary>
            /// retrieve list of customers from customer table
            /// </summary>
            List<CustomerModels> getCustomers = dbRepo.GetAllCustomersOrderByOrders();
            return getCustomers;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByID(int id)
        {
            List<InventoryModel> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationSortByID(id);
            return viewProductsAtLocation;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityAscending(int id)
        {
            List<InventoryModel> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationSortByQuantityAscending(id);
            return viewProductsAtLocation;
        }
        public List<InventoryModel> ViewAllProductsAtLocationSortByQuantityDescending(int id)
        {
            List<InventoryModel> viewProductsAtLocation = dbRepo.ViewAllProductsAtLocationSortByQuantityDescending(id);
            return viewProductsAtLocation;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDDateAscending(int id)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDDateAscending(id);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDDateDescending(int id)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDDateDescending(id);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceAscending(int id)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDPriceAscending(id);
            return orders;
        }
        public List<OrderModel> GetAllOrdersByCustomerIDPriceDescending(int id)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDPriceDescending(id);
            return orders;
        }

        public List<OrderModel> GetAllOrdersByCustomerID(int id)
        {
            List<OrderModel> orders = dbRepo.GetAllOrdersByCustomerIDDateAscending(id);
            return orders;
        }
    }
}