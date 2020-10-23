using System.Collections.Generic;
using CustomerLib;
using CustomerDB;
using System.Threading.Tasks;

namespace CustomerBL
{
    public class CustomerBL
    {
        IRepository repo = new FileRepo();
        public void AddCustomer(CustomerBL newCustomer){
            //add business logic
            //check for unique name
            //throw exception if 2
            repo.AddCustomerAsync(newCustomer);
        }
        public List<CustomerBL> GetAllCustomers(){
            Task<List<Hero>> getCustomers = repo.GetAllCustomersAsync();
            return getCustomers.Result;
        }
    }
}
