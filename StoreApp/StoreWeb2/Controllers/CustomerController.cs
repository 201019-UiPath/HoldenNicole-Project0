using Microsoft.AspNetCore.Mvc;
using StoreDB;
using StoreDB.Models;
using System.Collections.Generic;
using db = StoreDB.Models;

namespace StoreWeb2.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreRepo storeRepo;
        db.CustomerModels customer = new db.CustomerModels();
        db.CartItemModel cartItemModel = new db.CartItemModel();
        db.LocationModel locationModel = new db.LocationModel();
        public void CustomersController(IStoreRepo repo)
        {
            storeRepo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
     /*   public IActionResult AddCustomer(CustomerModels newCustomer)
        {
            db.CustomerModels customer = storeRepo.AddCustomer(newCustomer);
            return View(signIn);
        }
        public IActionResult SignInAsCustomer(string returningCustomer)
        {
            CustomerModels returning = storeRepo.GetCustomerByName(returningCustomer);
            return View(customerHome);
        }
        public IActionResult ViewCart(int id)
        {
            List<CartItemModel> items = storeRepo.GetAllProductsInCartByCartID(id);
            return View(cart);
        }
        public IActionResult GetOrdersByCustomer(string Username)
        {
            CustomerModels customer = storeRepo.GetCustomerByName(Username);
            List<OrderModel> order = storeRepo.GetAllOrdersByCustomerIDDateAscending(customer);
            return View(customerHistory);
        }
        public IActionResult AddItemToCartFromCart(CartItemModel cartItem)
        {
            CartItemModel cartItemModels = storeRepo.AddProductToCart(cartItem);
            return View(cart);
        }
        public IActionResult RemoveItemFromCartFromCart(int cartid, int productid, int quantity)
        {
            CartItemModel cartItemModels = storeRepo.DeleteProductInCart(cartid, productid, 1);
            return View(cartItemModels);
            return View(cart);
        }
        public IActionResult PlaceOrder(OrderModel order)
        {
            List<CartItemModel> cartItems = storeRepo.GetAllProductsInCartByCartID(order.CustomerID);
            List<LineItemModel> lineItems = new List<LineItemModel>();
            foreach(var c in cartItems)
            {
                storeRepo.AddToOrder((LineItemModel)c);
                storeRepo.DeleteProductInCart(c.CartID, c.productID, c.quantity);
            }
            OrderModel orders = storeRepo.PlaceOrder(order);
            return View(customerHome);
        }
        public IActionResult AddItemToCartFromInventory(CartItemModel cartItem)
        {
            CartItemModel cartItemModels = storeRepo.AddProductToCart(cartItem);
            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        }
        public IActionResult RemoveItemFromCartFromInventory(int cartid, int productid, int quantity)
        {
            CartItemModel cartItemModels = storeRepo.DeleteProductInCart(cartid, productid, 1);
            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        }
        public IActionResult PickShoppingLocation(int id)
        {
            LocationModel location = storeRepo.GetLocationByID(id);
            ///want this to send to matching location so may need 1 for each location
            return View(locationInventory);
        } */
    }
}
