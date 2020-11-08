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
        CartsModel cart = new CartsModel();

        public CustomerInventoryMenu(CustomerModels customer, CartsModel cart, ixdssaucContext ixdssaucContext, LocationModel location, StoreMapper storeMapper)
        {
            this.customer = customer;
            this.cart = cart;
            this.ixdssaucContext = ixdssaucContext;
            this.storeMapper = storeMapper;
            this.location = location;
            this.productServices = new ProductServices();
            this.customerService = new CustomerService();
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
                case "4": Console.WriteLine("Hope you find something you like at another location");
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
            DBRepo dB1 = new DBRepo();
            Console.WriteLine("What is the product ID you would like to add to your cart?");
            CartItemModel addItem = new CartItemModel();
            addItem.CartID = cart.ID;
            addItem.productID = Convert.ToInt32(Console.ReadLine());
            addItem.quantity += 1;
            CartItemModel items = dB2.AddProductToCart(addItem);
            Console.WriteLine("Would you like to add another item (Y/N)?");
            string userInput = Console.ReadLine();
            if (userInput == "Y")
            {
                customerInventoryMenu = new CustomerInventoryMenu(customer, cart, ixdssaucContext, location, new StoreMapper());
                customerInventoryMenu.Start();
            }
            else
            {
                int id = cart.ID;
                cartItemService = new CartItemService();
                List<CartItemModel> item = cartItemService.GetAllProductsInCartByCartID(id);
                foreach (var i in item)
                {
                    DBRepo dB = new DBRepo();
                    ProductModel product = dB.GetProductByID(i.productID);
                    Console.WriteLine($"{product.Athlete} {product.Item} {product.Sport} {product.Price} {i.quantity}");
                }
                Console.WriteLine("What would you like to do now?");
                Console.WriteLine("[1] Place Order now");
                Console.WriteLine("[2] Modify order");
                Console.WriteLine("[3] Back to this location menu");
                Console.WriteLine("[4] Back to locations menu");
                Console.WriteLine("[5] Back to customer menu");
                Console.WriteLine("[6] Back to sign in menu");
                Console.WriteLine("[7] Exit store");
                string UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "1":
                        OrderModel order = new OrderModel();
                        order.CustomerID = customer.ID;
                        order.items = (ICollection<LineItemModel>)(ICollection<LineItems>)item;
                        order.LocationID = location.ID;
                        int total = 0;
                        foreach(var l in order.items)
                        {
                            Products product = new Products();
                            product.Id = l.ID;
                            int price = (int)product.Price;
                            total += price;
                        }
                        ///need to calculate price
                        order.Price = total;
                        DBRepo dBRepo = new DBRepo();
                        dBRepo.PlaceOrder(order);
                        Console.WriteLine("Glad you found something you like come back soon");
                        break;
                    case "2":
                        Console.WriteLine("Would you like to add to your order (Y/N)?");
                        string request = Console.ReadLine();
                        if(request == "Y")
                        {
                            AddToCart(customer, cart);
                        }
                        else
                        {
                            Console.WriteLine("Enter the product ID you would like to remove from your order");
                            int d = Convert.ToInt32(Console.ReadLine());
                            CartItemModel cartItem = new CartItemModel();
                            cartItem.CartID = cart.ID;
                            cartItem.productID = d;
                            cartItem.quantity -= 1;
                            DBRepo dbRepo = new DBRepo();
                            dbRepo.UpdateCartItems(cartItem);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Returning you to this location menu");
                        customerInventoryMenu = new CustomerInventoryMenu(customer, cart, new ixdssaucContext(), location, new StoreMapper());
                        customerInventoryMenu.Start();
                        break;
                    case "4":
                        Console.WriteLine("Returning you to location selection menu");
                        customerLocationMenu = new CustomerLocationMenu(customer, cart, new ixdssaucContext(), new StoreMapper());
                        customerLocationMenu.Start();
                        break;
                    case "5":
                        Console.WriteLine("Returning you to customer menu");
                        customerMenu = new CustomerMenu(customer, cart, new ixdssaucContext(), new StoreMapper());
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
}