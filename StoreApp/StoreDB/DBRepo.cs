using Microsoft.EntityFrameworkCore;
using StoreDB.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreDB;

namespace StoreDB
{
    public class DBRepo : ICustomerRepo, ILocationRepo, ICartRepo, IOrderRepo
    {
        private readonly StoreContext context;
        private readonly IMapper mapper;

        public DBRepo(StoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// customer cart section
        /// </summary>

        public Customers GetCustomerByID(int id)
        {
            return mapper.ParseCustomer(context.Customer.Include("UserName, Email").First(x => x.ID == id));
        }
        public Customers GetCustomerByName(string name)
        {
            return mapper.ParseCustomer(context.Customer.Include("UserName, Email").First(x => x.UserName == "name"));
        }
        public void AddProductToCartAsync(Products product)
        {
            context.Product.AddAsync(mapper.ParseProducts(product));
            context.SaveChangesAsync();
        }
        public void PlaceOrderAsync(Orders order)
        {
            context.Order.PlaceOrderAsync(mapper.ParseOrder(order));
            context.SaveChangesAsync();
        }
        public Task<List<Products>> GetAllProductsInCartByCartID(int id)
        {
            return (Task<List<Products>>)mapper.ParseOrders(
                context.Order
                .Where(x => x.ID == context.Order.Single(y => y.ID == id).ID)
                .Include("Products - Quantity - Price")
                .ToList()
            );
        }
        public void UpdateCartItems(Products product)
        {
            context.Product.Update(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public Products GetProductByID(int id)
        {
            return mapper.ParseProducts(context.Product.Include("Products").First(x => x.ID == id));
        }
        public void DeleteProductInCart(Products product)
        {
            context.Product.Delete(mapper.ParseProducts(product));
            context.SaveChanges();
        }

        /// <summary>
        /// customer section
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomerAsync(Customers customer)
        {
            context.Customer.AddAsync(mapper.ParseCustomer(customer));
            context.SaveChangesAsync();
        }
        public Task<List<Customers>> GetAllCustomersAsync()
        {
            return Task.Run<List<Customers>>(
                () => mapper.ParseCustomer(
                    context.Customer
                    .Include("UserName - Email - Address")
                    .ToList()
                )
            );
        }

        /// <summary>
        /// Order histories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Orders> GetAllOrdersByCustomerIDDateAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Order
                .Where(x => x.CustomerID == context.Customer.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderBy(s => s.date);
        }
        public List<Orders> GetAllOrdersByCustomerIDDateDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.CustomerID == context.Customer.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderByDescending(s => s.date);
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.CustomerID == context.Customer.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderBy(s => s.Price);
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.CustomerID == context.Customer.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderByDescending(s => s.Price);
        }
        public List<Orders> GetAllOrdersByLocationIDDateAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.LocationID == context.Location.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderBy(s => s.date);
        }

        public List<Orders> GetAllOrdersByLocationIDDateDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.LocationID == context.Location.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderByDescending(s => s.date);
        }
        public List<Orders> GetAllOrdersByLocationIDPriceAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.LocationID == context.Location.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderBy(s => s.Price);
        }
        public List<Orders> GetAllOrdersByLocationIDPriceDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrders(
                context.Order
                .Where(x => x.LocationID == context.Location.Single(y => y.ID == id).ID)
                .Include("OrderID - ProductID - Quantity - Date - Price")
                .ToList())
                .OrderByDescending(s => s.Price);
        }
        /// <summary>
        /// location and manager section
        /// </summary>
        /// <returns></returns>

        public List<Products> ViewAllProductsAtLocation(int id)
        {
            return (List<Products>)mapper.ParseProducts(
                    context.Product
                    .Include("Name Quantity Item Price")
                    .Where(x => x.locationID == context.Location.Single(y => y.locationID == id).locationID)
                    .ToList()
                );
            }
        /// <summary>
        /// manager/location section
        /// </summary>     
        
        public Locations GetLocationByID(int id)
        {
            return mapper.ParseLocation(context.Location.Include("Name").First(x => x.ID == id));
        }
        public Locations GetLocationByName(string name)
        {
            return mapper.ParseLocation(context.Location.Include("LocationID").First(x => x.Name == name));
        }
        public List<Locations> GetAllLocations()
        {
            return mapper.ParseLocation(
                context.Location
                .Include("Name")
                .Include("Location names ids")
                .ToList()
            );
        }
        public void AddProductToLocationAsync(Products product)
        {
            context.Product.AddAsync(mapper.ParseProducts(product));
            context.SaveChangesAsync();
        }
        public void UpdateProducts(Products product)
        {
            context.Product.Update(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public void DeleteProduct(Products product)
        {
            context.Product.Delete(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public List<Managers> GetAllManagers()
        {
            return mapper.ParseManager(
                    context.Managers
                    .Include("Name")
                    .Include("location")
                    .ToList()
            );
        }
    }
}