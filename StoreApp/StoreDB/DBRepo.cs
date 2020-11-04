using Microsoft.EntityFrameworkCore;
using StoreUI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI
{
    public class DBRepo : ICustomerRepo, ILocationRepo, ICartRepo, IOrderRepo
    {
        private readonly hyfhtbziContext context;
        private readonly IMapper mapper;

        public DBRepo(hyfhtbziContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        /// <summary>
        /// customer section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customers GetCustomerByID(int id)
        {
            return mapper.ParseCustomer(context.Customers
            .Include("UserName")
            .Include("Email")
                .First(x => x.ID.Equals(id)));
        }
        public Customers GetCustomerByName(string name)
        {
            return mapper.ParseCustomer(context.Customers
            .Include("UserName")
            .Include("Email")
                .First(x => x.UserName.Equals("name")));
        }
        public void AddCustomer(Customers customer)
        {
            context.Customers.Add(mapper.ParseCustomer(customer));
            context.SaveChanges();
        }
        public Task<List<Customers>> GetAllCustomersAsync()
        {
            return Task.Run<List<Customers>>(
                () => mapper.ParseCustomer(
                    context.Customers
                    .Include("Name")
                    .Include("Email")
                    .ToList()));
        }
        /// <summary>
        /// managers section
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Managers GetManagerByName(string name)
        {
            return mapper.ParseManager(context.Managers.Include("location")
                .First(x => x.Name.Equals(name)));
        }
        public Managers GetManagerByID(int id)
        {
            return mapper.ParseManager(context.Managers
                .Include("UserName, Location")
                .First(x => x.ID.Equals(id)));
        }
        public List<Managers> GetAllManagers()
        {
            return mapper.ParseManager(
                context.Managers
                .Include("Name")
                .Include("location")
                .ToList());
        }
        /// <summary>
        /// current order section
        /// </summary>
        /// <param name="product"></param>
        public void AddProductToCartAsync(Products product)
        {
            context.Products.AddAsync(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public List<Products> GetAllProductsInCartByCartID(int id)
        {
            return mapper.ParseOrder(
                context.Products
                .Where(x => x.ID == context.Orders.Single(y => y.ID.Equals(id)).ID)
                .Include("Products")
                .Include("Quantity")
                .Include("Price")
                .ToList());
        }
        public void UpdateCartItems(Products product)
        {
            context.Products.Update(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public void DeleteProductInCart(Products product)
        {
            context.Products.Remove(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public void PlaceOrderAsync(Orders order)
        {
            context.Orders.AddAsync(mapper.ParseOrder(order));
            context.SaveChangesAsync();
        }
        /// <summary>
        /// customer and manager search section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Products GetProductByID(int id)
        {
            return mapper.ParseProducts(context.Products.Include("Products").First(x => x.ID.Equals(id)));
        }
        public List<Products> ViewAllProductsAtLocationGroupByItem(int id)
        {
            return (List<Products>)mapper.ParseProducts(
                (ICollection<Products>)context.Products
                .Include("Athlete").Include("Item").Include("Price").Include("Quantity")
                .Where(x => x.locationID.Equals(id))
                .GroupBy(p => p.Item)
                .ToList());
        }
        public List<Products> ViewAllProductsAtLocationGroupBySport(int id)
        {
            return (List<Products>)mapper.ParseProducts(
                (ICollection<Products>)context.Products
                .Include("Name")
                .Include("Quantity")
                .Include("Item")
                .Include("Price")
                .Where(x => x.locationID == context.Locations.Single(y => y.locationID.Equals(id)).locationID)
                .GroupBy(p => p.Sport)
                .ToList());
        }
        public List<Products> ViewAllProductsAtLocationGroupByAthlete(int id)
        {
            return (List<Products>)mapper.ParseProducts(
                (ICollection<Products>)context.Products
                .Include("Name")
                .Include("Quantity")
                .Include("Item")
                .Include("Price")
                .Where(x => x.locationID == context.Locations.Single(y => y.locationID.Equals(id)).locationID)
                .GroupBy(p => p.Athlete)
                .ToList());
        }
        public List<Products> ViewAllProductsBySport(string sport)
        {
            return (List<Products>)mapper.ParseProducts(
                context.Products
                .Include("Name")
                .Include("Quantity")
                .Include("Item")
                .Include("Price")
                .Where(x => x.Sport.Equals(sport))
                .ToList());
        }
        public List<Products> ViewAllProductsByAthlete(string athlete)
        {
            return (List<Products>)mapper.ParseProducts(
                context.Products
                .Include("Name")
                .Include("Quantity")
                .Include("Item")
                .Include("Price")
                .Where(x => x.Sport.Equals(athlete))
                .ToList());
        }
        public List<Products> ViewAllProductsByItem(string item)
        {
            return (List<Products>)mapper.ParseProducts(
                context.Products
                .Include("Name")
                .Include("Quantity")
                .Include("Item")
                .Include("Price")
                .Where(x => x.Sport.Equals(item))
                .ToList());
        }
        /// <summary>
        /// location section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Locations GetLocationByID(int id)
        {
            return mapper.ParseLocation(context.Locations.Include("Name").First(x => x.ID.Equals(id)));
        }
        public Locations GetLocationByName(string name)
        {
            return mapper.ParseLocation(context.Locations.Include("LocationID").First(x => x.Name.Equals(name)));
        }
        public List<Locations> GetAllLocations()
        {
            return mapper.ParseLocation(
                context.Locations
                .Include("Name")
                .Include("IDs")
                .Include("Location")
                .ToList());
        }
        /// <summary>
        /// Manager inventory section
        /// </summary>
        /// <param name="product"></param>
        public void AddProductToLocationAsync(Products product)
        {
            context.Products.AddAsync(mapper.ParseProducts(product));
            context.SaveChangesAsync();
        }
        public void UpdateProducts(Products product)
        {
            context.Products.Update(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        public void DeleteProduct(Products product)
        {
            context.Products.Remove(mapper.ParseProducts(product));
            context.SaveChanges();
        }
        /// <summary>
        /// Order histories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Orders> GetAllOrdersByCustomerIDDateAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.CustomerID == context.Customers.SingleOrDefault(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderBy(s => s.date);
        }
        public List<Orders> GetAllOrdersByCustomerIDDateDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.CustomerID == context.Customers.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderByDescending(s => s.date);
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.CustomerID == context.Customers.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderBy(s => s.Price);
        }
        public List<Orders> GetAllOrdersByCustomerIDPriceDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.CustomerID == context.Customers.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderByDescending(s => s.Price);
        }
        public List<Orders> GetAllOrdersByLocationIDDateAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.LocationID == context.Locations.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderBy(s => s.date);
        }
        public List<Orders> GetAllOrdersByLocationIDDateDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.LocationID == context.Locations.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderByDescending(s => s.date);
        }
        public List<Orders> GetAllOrdersByLocationIDPriceAscending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.LocationID == context.Locations.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderBy(s => s.Price);
        }
        public List<Orders> GetAllOrdersByLocationIDPriceDescending(int id)
        {
            return (List<Orders>)mapper.ParseOrder(
                context.Orders
                .Where(x => x.LocationID == context.Locations.Single(y => y.ID.Equals(id)).ID)
                .Include("OrderID")
                .Include("ProductID")
                .Include("Quantity")
                .Include("Date")
                .Include("Price")
                .ToList())
                .OrderByDescending(s => s.Price);
        }
    }
}