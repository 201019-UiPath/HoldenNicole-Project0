using StoreDB.Entities;

namespace StoreDB
{
    public class StoreMapper : IMapper
    {
        public Customers ParseCustomer(Customers customer)
        {
            return new Customers()
            {
                ID = customer.ID,
                UserName = customer.UserName,
                Address = customer.Address,
                Email = customer.Email,
            };
        }
    }
}