using Microsoft.EntityFrameworkCore;
using StoreDB;
using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreUI
{
    /// <summary>
    /// implements all the mappings
    /// </summary>
    public class StoreMapper : IMapper
    {
        public StoreMapper()
        {
        }
        /// <summary>
        /// cart items section
        /// </summary>
        public CartItemModel ParseCartItem(CartItems cartItems)
        {
            return new CartItemModel()
            {
                CartID = cartItems.Id,
                productID = cartItems.Product,
                quantity = cartItems.Quantity
            };
        }

        public CartItems ParseCartItem(CartItemModel cartItems)
        {
            return new CartItems()
            {
                Product = cartItems.productID,
                Quantity = cartItems.quantity
            };
        }

        public ICollection<CartItems> ParseCartItem(List<CartItemModel> cartItems)
        {
            ICollection<CartItems> cartItem = new List<CartItems>();
            foreach (var c in cartItems)
            {
                cartItem.Add(ParseCartItem(c));
            }
            return cartItem;
        }

        public List<CartItemModel> ParseCartItem(ICollection<CartItems> cartItems)
        {
            List<CartItemModel> cartItemModels = new List<CartItemModel>();
            foreach (var c in cartItems)
            {
                cartItemModels.Add(ParseCartItem(c));
            }
            return cartItemModels;
        }
        /// <summary>
        /// cart section
        /// </summary>
        public CartsModel ParseCarts(Carts carts)
        {
            return new CartsModel()
            {
                ID = carts.Id,
                CustomerID = carts.Customer,
                LocationID = carts.Location
            };
        }

        public Carts ParseCarts(CartsModel carts)
        {
            return new Carts()
            {
                Customer = carts.CustomerID,
                Location = carts.LocationID
            };
        }

        public ICollection<Carts> ParseCarts(List<CartsModel> carts)
        {
            ICollection<Carts> cart = new List<Carts>();
            foreach (var c in carts)
            {
                cart.Add(ParseCarts(c));
            }
            return cart;
        }

        public List<CartsModel> ParseCarts(ICollection<Carts> carts)
        {
            List<CartsModel> cartsModels = new List<CartsModel>();
            foreach (var c in carts)
            {
                cartsModels.Add(ParseCarts(c));
            }
            return cartsModels;
        }

        /// <summary>
        /// customer section
        /// </summary>
        public Customer ParseCustomer(CustomerModels customer)
        {
            return new Customer()
            {
                Username = customer.Username,
                Email = customer.email
            };
        }

        public CustomerModels ParseCustomer(Customer customer)
        {
            return new CustomerModels()
            {
                ID = customer.Id,
                Username = customer.Username,
                email = customer.Email
            };
        }
        public ICollection<Customer> ParseCustomer(List<CustomerModels> customer)
        {
            ICollection<Customer> customers = new List<Customer>();
            foreach (var c in customer)
            {
                customers.Add(ParseCustomer(c));
            }
            return customers;
        }

        public List<CustomerModels> ParseCustomer(ICollection<Customer> customer)
        {
            List<CustomerModels> customers = new List<CustomerModels>();
            foreach (var c in customer)
            {
                customers.Add(ParseCustomer(c));
            }
            return customers;
        }
        /// <summary>
        /// inventory section
        /// </summary>
        public Inventory ParseInventory(InventoryModel inventory)
        {
            return new Inventory()
            {
                Location = inventory.locationID,
                Product = inventory.productID,
                Quantity = inventory.Quantity
            };
        }

        public ICollection<Inventory> ParseInventory(List<InventoryModel> inventory)
        {
            ICollection<Inventory> inventories = new List<Inventory>();
            foreach (var i in inventory)
            {
                inventories.Add(ParseInventory(i));
            }
            return inventories;
        }

        public InventoryModel ParseInventory(Inventory inventory)
        {
            return new InventoryModel()
            {
                id = inventory.Id,
                locationID = inventory.Location,
                productID = inventory.Product,
                Quantity = inventory.Quantity
            };
        }

        public List<InventoryModel> ParseInventory(ICollection<Inventory> inventory)
        {
            List<InventoryModel> inventories = new List<InventoryModel>();
            foreach (var i in inventory)
            {
                inventories.Add(ParseInventory(i));
            }
            return inventories;
        }
        /// <summary>
        /// line item section
        /// </summary>
        public LineItems ParseLineItem(LineItemModel lineItem)
        {
            return new LineItems()
            {
                Order = lineItem.OrderID,
                Product = lineItem.ProductID,
                Quantity = lineItem.Quantity
            };
        }

        public ICollection<LineItems> ParseLineItem(List<LineItemModel> lineItem)
        {
            List<LineItems> lineItems = new List<LineItems>();
            foreach (var l in lineItem)
            {
                lineItems.Add(ParseLineItem(l));
            }
            return lineItems;
        }

        public LineItemModel ParseLineItem(LineItems lineItem)
        {
            return new LineItemModel()
            {
                ID = lineItem.Id,
                OrderID = lineItem.Order,
                ProductID = lineItem.Product,
                Quantity = lineItem.Quantity
            };
        }

        public List<LineItemModel> ParseLineItem(ICollection<LineItems> lineItem)
        {
            List<LineItemModel> lineItemModels = new List<LineItemModel>();
            foreach (var l in lineItem)
            {
                lineItemModels.Add(ParseLineItem(l));
            }
            return lineItemModels;
        }

        /// <summary>
        ///  location section
        /// </summary>
        public Locations ParseLocation(LocationModel location)
        {
            return new Locations()
            {
                Name = location.Name,
                Manager = location.ManagerID
            };
        }

        public ICollection<Locations> ParseLocation(List<LocationModel> location)
        {
            ICollection<Locations> locations = new List<Locations>();
            foreach (var l in location)
            {
                locations.Add(ParseLocation(l));
            }
            return locations;
        }

        public List<LocationModel> ParseLocation(ICollection<Locations> location)
        {
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var l in location)
            {
                locations.Add(ParseLocation(l));
            }
            return locations;
        }

        public LocationModel ParseLocation(Locations location)
        {
            return new LocationModel()
            {
                ID = location.Id,
                Name = location.Name,
                ManagerID = location.Manager
            };
        }
        /// <summary>
        /// managers section
        /// </summary>
        public ManagerModel ParseManager(Managers manager)
        {
            return new ManagerModel()
            {
                ID = manager.Id,
                Username = manager.Username,
                Email = manager.Email
            };
        }
        public Managers ParseManager(ManagerModel manager)
        {
            return new Managers()
            {
                Id = manager.ID,
                Username = manager.Username,
                Email = manager.Email
            };
        }
        public ICollection<Managers> ParseManager(List<ManagerModel> manager)
        {
            ICollection<Managers> managers = new List<Managers>();
            foreach (var m in manager)
            {
                managers.Add(ParseManager(m));
            }
            return managers;
        }

        public List<ManagerModel> ParseManager(ICollection<Managers> manager)
        {
            List<ManagerModel> managers = new List<ManagerModel>();
            foreach (var m in manager)
            {
                managers.Add(ParseManager(m));
            }
            return managers;
        }

        /// <summary>
        /// orders section
        /// </summary>
        public Orders ParseOrder(OrderModel order)
        {
            return new Orders()
            {
                Customer = order.CustomerID,
                Location = order.LocationID,
                OrderDate = order.OrderDate,
                Price = order.Price
            };
        }

        public ICollection<Orders> ParseOrder(List<OrderModel> order)
        {
            ICollection<Orders> orders = new List<Orders>();
            foreach (var o in order)
            {
                orders.Add(ParseOrder(o));
            }
            return orders;
        }

        public OrderModel ParseOrder(Orders order)
        {
            return new OrderModel()
            {
                ID = order.Id,
                CustomerID = order.Customer,
                LocationID = order.Location,
                Price = order.Price,
                OrderDate = order.OrderDate
            };
        }

        public List<OrderModel> ParseOrder(ICollection<Orders> order)
        {
            List<OrderModel> orders = new List<OrderModel>();
            foreach (var o in order)
            {
                orders.Add(ParseOrder(o));
            }
            return orders;
        }
        /// <summary>
        /// products section
        /// </summary>
        public Products ParseProducts(ProductModel product)
        {
            return new Products()
            {
                Athlete = product.Athlete,
                Item = product.Item,
                Sport = product.Sport,
                Price = product.Price
            };
        }
        public List<ProductModel> ParseProducts(ICollection<Products> products)
        {
            List<ProductModel> product = new List<ProductModel>();
            foreach (var p in products)
            {
                product.Add(ParseProducts(p));
            }
            return product;
        }
        public ProductModel ParseProducts(Products product)
        {
            return new ProductModel()
            {
                ID = product.Id,
                Athlete = product.Athlete,
                Item = product.Item,
                Sport = product.Sport,
                Price = product.Price
            };
        }

        public ICollection<Products> ParseProducts(List<ProductModel> product)
        {
            ICollection<Products> products = new List<Products>();
            foreach (var p in product)
            {
                products.Add(ParseProducts(p));
            }
            return products;
        }

        List<ProductModel> IProductMapper.ParseProducts(ICollection<Products> product)
        {
            List<ProductModel> products = new List<ProductModel>();
            foreach (var p in product)
            {
                products.Add(ParseProducts(p));
            }
            return products;
        }
        // public ProductModel ParseProduct(IQueryable<Products> queryables)
        // {
        //     return new ProductModel()
        //     {
        //         ID = queryables.Count()
        //     };
        //     }
        }
    }