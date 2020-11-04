using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface IMapper : ICustomerMapper, IOrdersMapper, IManagerMapper, ILocationMapper
    {
        Products ParseProducts(Products products);
        List<Products> ParseProducts(ICollection<Products> products);
        Customer ParseCustomer(Customer customer);
        List<Customer> ParseCustomer(List<Customer> lists);
        Managers ParseManager(Managers managers);
        List<Managers> ParseManager(List<Managers> lists);
        Orders ParseOrder(Orders order);
        Locations ParseLocation(Locations locations);
        List<Locations> ParseLocation(List<Locations> lists);
        object ParseOrder(List<Orders> lists); 
    }
}
