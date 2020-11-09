using StoreUI;
using StoreDB.Entities;
using System;
using Xunit;
using StoreDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StoreTest
{
    public class StoreTest
    {
        private readonly StoreUI.IMapper mapper = new StoreMapper();
        private DBRepo dBrepo;

        #region create test models
        private readonly CustomerModels testcustomer = new CustomerModels()
        {
            ID = 1,
            Username = "Bob",
            email = "Bob@gmail.com"
        };

        private readonly CartItemModel testCartItems = new CartItemModel()
        {
            CartID = 1,
            orderID = 2,
            productID = 3,
            quantity = 5
        };

        private readonly CartsModel testCart = new CartsModel()
        {
            ID = 1,
            CustomerID = 3,
            LocationID = 2
        };
        private readonly InventoryModel testInventory = new InventoryModel()
        {
            locationID = 2,
            productID = 3,
            Quantity = 50
        };
        private readonly LineItemModel lineItemModel = new LineItemModel()
        {
            ID = 1,
            OrderID = 10,
            ProductID = 1,
            Quantity = 4
        };
        private readonly LocationModel locationModel = new LocationModel()
        {
            ID = 2,
            ManagerID = 1,
            Name = "World of Worlds"
        };
        private readonly ManagerModel managerModel = new ManagerModel()
        {
            ID = 1,
            Username = "Testing",
            Email = "testing@test.com"
        };
        private readonly OrderModel orderModel = new OrderModel()
        {
            ID = 1,
            CustomerID = 1,
            LocationID = 2,
            OrderDate = Convert.ToDateTime("November 11, 2020"),
            Price = Convert.ToDecimal(7000)
        };
        private readonly ProductModel productModel = new ProductModel()
        {
            ID = 2,
            Athlete = "Wayne Gretzky",
            Item = "skates",
            Price = Convert.ToDecimal(10000),
            Sport = "Hockey"
        };
        #endregion

        #region seed data
        private void Seed(ixdssaucContext testcontext)
        {
            testcontext.Customer.AddRange((System.Collections.Generic.IEnumerable<Customer>)testcustomer);
            testcontext.CartItems.AddRange((System.Collections.Generic.IEnumerable<CartItems>)testCartItems);
            testcontext.Carts.AddRange((System.Collections.Generic.IEnumerable<Carts>)testCart);
            testcontext.Inventory.AddRange((System.Collections.Generic.IEnumerable<Inventory>)testInventory);
            testcontext.LineItems.AddRange((System.Collections.Generic.IEnumerable<LineItems>)lineItemModel);
            testcontext.Locations.AddRange((System.Collections.Generic.IEnumerable<Locations>)locationModel);
            testcontext.Managers.AddRange((System.Collections.Generic.IEnumerable<Managers>)managerModel);
            testcontext.Orders.AddRange((System.Collections.Generic.IEnumerable<Orders>)orderModel);
            testcontext.Products.AddRange((System.Collections.Generic.IEnumerable<Products>)productModel);
            testcontext.SaveChanges();
        }
        #endregion

        #region tests
        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            //Arange
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("AddCustomerShouldAddCustomer").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            //Act
            dBrepo.AddCustomer(testcustomer);
            //Assert
            using var assertContext = new ixdssaucContext(options);
            Assert.NotNull(assertContext.Customer.Single(c => c.Email == testcustomer.email));
        }
        [Fact]
        public void NewCartShouldCreateNewCart()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("NewCartShouldCreateNewCart").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            //Act
            dBrepo.AddCart(testCart);
            //Assert
            using var assertContext = new ixdssaucContext(options);
            Assert.NotNull(assertContext.Carts.First(c => c.Id == testCart.ID));
        }
        [Fact]
        public void NewCartItemShouldCreateNewCartItem()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("NewCartItemShouldCreateNewCartItem").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            //Act
            dBrepo.AddProductToCart(testCartItems);
            //Assert
            using var assertContext = new ixdssaucContext(options);
            Assert.NotNull(assertContext.Carts.First(c => c.Id == testCart.ID));
        }
        [Fact]
        public void AddToOrderShouldAddToOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("AddToOrderShouldAddToOrder").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            //Act
            dBrepo.AddProductToCart(testCartItems);
            //Assert
            using var assertContext = new ixdssaucContext(options);
            Assert.NotNull(assertContext.LineItems.First(c => c.Id == testCartItems.CartID));
        }
        [Fact]
        public void AddOrderShouldAddOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("AddOrderShouldAddOrder").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            //Act
            dBrepo.AddOrder(orderModel);
            //Assert
            using var assertContext = new ixdssaucContext(options);
            Assert.NotNull(assertContext.Orders.First(c => c.Id == orderModel.ID));
        }
        [Fact]
        public void GetCartIDShouldGetCart()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetCartIDShouldGetCart").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            CartsModel result = dBrepo.GetCartID(1);
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.ID, testCart.ID);
        }
        [Fact]
        public void GetProductByIDShouldGetProduct()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetProductByIDShouldGetProduct").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            ProductModel result = dBrepo.GetProductByID(1);
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.ID, productModel.ID);
        }
        [Fact]
        public void GetCustomerByIDShouldGetCustomer()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetCustomerByIDShouldGetCustomer").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            CustomerModels result = dBrepo.GetCustomerByID(1);
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.ID, testcustomer.ID);
        }
        [Fact]
        public void GetCustomerByNameShouldGetCustomer()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetCustomerByNameShouldGetCustomer").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            CustomerModels result = dBrepo.GetCustomerByName("Bob");
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.Username, testcustomer.Username);
        }
        [Fact]
        public void GetCustomerByEmailShouldGetCustomer()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetCustomerByEmailShouldGetCustomer").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            CustomerModels result = dBrepo.GetCustomerByEmail("Bob@gmail.com");
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.email, testcustomer.email);
        }
        [Fact]
        public void GetManagerByNameShouldGetManager()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetManagerByNameShouldGetManager").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            ManagerModel result = dBrepo.GetManagerByName("Testing");
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.Username, managerModel.Username);
        }
        [Fact]
        public void GetLocationByNameShouldGetLocation()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetLocationByNameShouldGetLocation").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            LocationModel result = dBrepo.GetLocationByName("World of Worlds");
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.Name, locationModel.Name);
        }
        [Fact]
        public void GetLocationByIDShouldGetLocation()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetLocationByIDShouldGetLocation").Options;
            using var testContext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testContext,
                Mapper = mapper
            };
            Seed(testContext);
            //Act
            LocationModel result = dBrepo.GetLocationByID(2);
            //Assert 
            using var assertContext = new ixdssaucContext(options);
            Assert.Equal(result.ID, locationModel.ID);
        }
        [Fact]
        public void GetItemsInCartShouldGetItemsInCart()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetItemsInCartShouldGetItemsInCart").Options;
            using var testcontext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testcontext,
                Mapper = mapper
            };
            Seed(testcontext);
            //Act
            var result = dBrepo.GetAllProductsInCartByCartID(1);
            //Assert
            using var assertcontext = new ixdssaucContext(options);
            Assert.Equal(5, result.Count);
        }
        [Fact]
        public void GetProductsInOrderShouldGetProductsInOrder()
        {
            var options = new DbContextOptionsBuilder<ixdssaucContext>().UseInMemoryDatabase("GetProductsInOrderShouldGetProductsInOrder").Options;
            using var testcontext = new ixdssaucContext(options);
            dBrepo = new DBRepo()
            {
                Context = testcontext,
                Mapper = mapper
            };
            Seed(testcontext);
            //Act
            var result = dBrepo.GetAllProductsInOrderByID(1);
            //Assert
            using var assertcontext = new ixdssaucContext(options);
            Assert.Equal(4, result.Count);
        }

        #endregion
    }
}
