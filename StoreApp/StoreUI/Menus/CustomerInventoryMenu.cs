using CustomerLib;
using LocationLib;
using OrdersLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using StoreUI.Menus;
using System;
using System.Collections.Generic;

namespace StoreUI
{
    internal class CustomerInventoryMenu : IMenu
    {
        private readonly CustomerModels customer;
        private readonly ixdssaucContext ixdssaucContext;
        private readonly StoreMapper storeMapper;
        private readonly LocationModel location;
        private readonly ProductServices productServices;
        private readonly CustomerService customerService;
        private CustomerInventoryMenu customerInventoryMenu;
        private CartItemService cartItemService;
        private CustomerLocationMenu customerLocationMenu;
        private CustomerMenu customerMenu;
        private SignInMenu signInMenu;
        readonly CartsModel cart = new CartsModel();
        private readonly OrdersService ordersService;

        public CustomerInventoryMenu(CustomerModels customer, CartsModel cart, ixdssaucContext ixdssaucContext, LocationModel location, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.cart = cart;
            this.ixdssaucContext = ixdssaucContext;
            this.storeMapper = storeMapper;
            this.location = location;
            this.productServices = new ProductServices();
            this.customerService = new CustomerService();
            this.ordersService = new OrdersService();
            this.cartItemService = new CartItemService();
        }
        public void Start()
        {
            ///retrieve location from previous menus
            ///LocationModel location = new LocationModel();
            int id = location.ID;
            string name = location.Name;
            Console.WriteLine($"How would you like to see the inventory for {name} sorted?"); ///{name} doesnt work
            Console.WriteLine("[1] By item ID");
            Console.WriteLine("[2] By quantity of item ascending");
            Console.WriteLine("[3] By quantity of item descending");
            Console.WriteLine("[4] Pick another location");
            Console.WriteLine("[5] exit store");
            string sorting = Console.ReadLine();

            switch (sorting)
            {
                case "1":
                    List<InventoryModel> allProducts = productServices.ViewAllProductsAtLocationSortByID(id);
                    Console.WriteLine("ID \t Athlete \t Item \t \t Sport \t \t Price \t Quantity");
                    foreach (var p in allProducts)
                    {
                        DBRepo bRepo = new DBRepo();
                        ProductModel product = bRepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("type of item selected");
                    AddToCart(customer, cart);
                    break;
                case "2":
                    List<InventoryModel> allProducts2 = productServices.ViewAllProductsAtLocationSortByQuantityAscending(id);
                    Console.WriteLine("ID \t Athlete \t Item \t Sport \t Price \t Quantity");
                    foreach (var p in allProducts2)
                    {
                        DBRepo dbrepo = new DBRepo();
                        ProductModel product = dbrepo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("sport selected");
                    AddToCart(customer, cart);
                    break;
                case "3":
                    List<InventoryModel> allProducts3 = productServices.ViewAllProductsAtLocationSortByQuantityDescending(id);
                    Console.WriteLine("ID \t Athlete \t Item \t Sport \t Price \t Quantity");
                    foreach (var p in allProducts3)
                    {
                        DBRepo repo = new DBRepo();
                        ProductModel product = repo.GetProductByID(p.productID);
                        Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {p.Quantity}");
                    }
                    Log.Information("athlete selected");
                    AddToCart(customer, cart);
                    break;
                case "4":
                    Console.WriteLine("Hope you find something you like at another location");
                    Log.Information("changing locations");
                    break;
                case "5":
                    Console.WriteLine("Bye hope you come again soon");
                    Log.Information("Hsss leaving store");
                    Environment.Exit(0);
                    break;
                default:
                    Log.Error("Invalid input");
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public void AddToCart(CustomerModels customer, CartsModel cart)
        {
            DBRepo dB2 = new DBRepo();
            cart.CustomerID = customer.ID;
            cart.LocationID = location.ID;
            dB2.AddCart(cart);
            int cartID = dB2.GetCartID(customer.ID).ID;
            Console.WriteLine("What is the product ID you would like to add to your cart?");
            CartItems addItem = new CartItems
            {
                Cart = cartID,
                Product = Convert.ToInt32(Console.ReadLine())
            };
            addItem.Quantity += 1;
            cartItemService.AddProductToCart(cartID, addItem.Product, addItem.Quantity);
            dB2.DeleteProductAtLocation(location.ID, addItem.Product, addItem.Quantity);
            Console.WriteLine("Would you like to add another item (Y/N)?");
            string userInput = Console.ReadLine();
            if (userInput == "Y")
            {
                customerInventoryMenu = new CustomerInventoryMenu(customer, cart, ixdssaucContext, location, new StoreMapper());
                customerInventoryMenu.Start();
            }
            else
            {
                cartItemService = new CartItemService();
                //List<CartsModel> item = cartItemService.GetAllProductsInCartByCartID(cartID);
                List<CartItemModel> item = cartItemService.GetAllProductsInCartByCartID(cartID);
                foreach (var i in item)
                {
                    ProductModel product = cartItemService.GetProductByID(i.productID);
                    Console.WriteLine($"{product.ID} \t {product.Athlete} \t {product.Item} \t {product.Sport} \t {product.Price} \t {i.quantity}");
                }
                ModifyOrder(customer, cart);
            }
        }
        public void ModifyOrder(CustomerModels c, CartsModel cart)
        {
            Console.WriteLine("What would you like to do now?");
            Console.WriteLine("[1] Place Order now");
            Console.WriteLine("[2] Modify order");
            Console.WriteLine("[3] Back to this location menu");
            Console.WriteLine("[4] Back to locations menu");
            Console.WriteLine("[5] Back to customer menu");
            Console.WriteLine("[6] Back to sign in menu");
            Console.WriteLine("[7] Exit store");
            string UserInput = Console.ReadLine();
            DBRepo dB1 = new DBRepo();
            switch (UserInput)
            {
                case "1":
                    OrderModel order = new OrderModel
                    {
                        CustomerID = customer.ID,
                        LocationID = location.ID
                    };
                    dB1.AddOrder(order);
                    order = dB1.GetOrderByID(location, customer);
                    decimal total = 0;
                    CartsModel carts = dB1.GetCartID(customer.ID);
                    List<CartItemModel> item = dB1.GetAllProductsInCartByCartID(carts.ID);
                    foreach (var i in item)
                    {
                        LineItemModel lineItem = new LineItemModel
                        {
                            OrderID = order.ID,
                            ProductID = i.productID
                        };
                        CartItemModel cartItemModel = new CartItemModel
                        {
                            CartID = i.CartID,
                            orderID = order.ID,
                            productID = i.productID
                        };
                        lineItem.ProductID = cartItemModel.productID;
                        cartItemModel.quantity = 1;
                        lineItem.Quantity = 1;
                        dB1.AddToOrder(lineItem);

                        ///dB1.DeleteProductInCart(cartItemModel);
                    }
                    foreach (var l in item)
                    {
                        ProductModel product = new ProductModel
                        {
                            ID = l.productID
                        };
                        LineItemModel lineItem = new LineItemModel
                        {
                            ProductID = l.productID,
                            OrderID = l.orderID,
                            Quantity = l.quantity
                        };
                        product = dB1.GetProductByID(l.productID);
                        decimal price = product.Price;
                        total += price;
                    }
                    ///need to calculate price
                    order.Price = total;
                    order.OrderDate = DateTime.Now;
                    DBRepo dBRepo = new DBRepo();
                    dBRepo.AddOrder(order);
                    Console.WriteLine("Glad you found something you like come back soon");
                    customerMenu = new CustomerMenu(c, new CartsModel(), ixdssaucContext, new StoreMapper());
                    customerMenu.Start();
                    break;

                case "2":
                    Console.WriteLine("Would you like to add to your order (Y/N)?");
                    string request = Console.ReadLine();
                    if (request == "Y")
                    {
                        AddToCart(c, cart);
                    }
                    else
                    {
                        Console.WriteLine("Enter the product ID you would like to remove from your order");
                        int d = Convert.ToInt32(Console.ReadLine());
                        CartItemModel cartItem = new CartItemModel
                        {
                            CartID = cart.ID,
                            productID = d
                        };
                        cartItem.quantity -= 1;
                        DBRepo dbRepo = new DBRepo();
                        dbRepo.UpdateCartItems(cartItem);
                        ModifyOrder(c, cart);
                    }
                    break;
                case "3":
                    Console.WriteLine("Returning you to this location menu");
                    customerInventoryMenu = new CustomerInventoryMenu(c, cart, new ixdssaucContext(), location, new StoreMapper());
                    customerInventoryMenu.Start();
                    break;
                case "4":
                    Console.WriteLine("Returning you to location selection menu");
                    customerLocationMenu = new CustomerLocationMenu(c, cart, new ixdssaucContext(), new StoreMapper());
                    customerLocationMenu.Start();
                    break;
                case "5":
                    Console.WriteLine("Returning you to customer menu");
                    customerMenu = new CustomerMenu(c, cart, new ixdssaucContext(), new StoreMapper());
                    customerMenu.Start();
                    break;
                case "6":
                    Console.WriteLine("Returning you to sign in menu");
                    signInMenu = new SignInMenu(new ixdssaucContext(), new StoreMapper());
                    signInMenu.Start();
                    break;
                case "7":
                    Console.WriteLine("Leaving store");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}