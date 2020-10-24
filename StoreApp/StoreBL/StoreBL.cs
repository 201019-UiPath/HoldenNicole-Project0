using CustomerLib;
using LocationLib;
using ManagerLib;
using StoreDB;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace StoreBL
{
    public class StoreBL
    {
        ICustomerRepository repo = new CustomerFileRepo();
        public void AddCustomer(Customer newCustomer){
            ///add BL check if name unique (SQL it)
            repo.AddCustomerAsync(newCustomer);
            // in customer file repo
        }
        public void CheckCustomer(Customer newCustomer){
            /// check if customer exists in database
            /// reach this when they hit sign in
        }
        public void CheckManager(Manager newManager){
            ///check if manager exists
            //need to add implementation
        }
    }
}
