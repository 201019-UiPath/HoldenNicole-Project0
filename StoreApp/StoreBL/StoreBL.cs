using System;
using CustomerLib;
using ManagerLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBL
{
    public class StoreBL
    {
        IRepository repo = new FileRepo();
        public void AddCustomer(Customer newCustomer){
            ///add BL check if name unique (SQL it)
            repo.AddCustomerAsync(newCustomer);
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
